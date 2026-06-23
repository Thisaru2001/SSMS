using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using Markdig;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;

namespace SSMS
{
    
    
    
    public partial class AiAssistantForm : Form
    {
        private ChatManager _chatManager;
        private string _currentImageBase64 = null;
        
        
        

        public AiAssistantForm(int loggedInUserId)
        {
            InitializeComponent();
            
            _chatManager = new ChatManager(loggedInUserId, new OllamaService());
            InitializeDynamicEvents();
            LoadChatHistoryAsync();
        }

        private void InitializeDynamicEvents()
        {
            
            bottomPanel.Resize += (s, e) => { inputContainer.Width = bottomPanel.Width - 100; };
            
            inputContainer.Resize += (s, e) => { txtMessage.Width = inputContainer.Width - 110; };
            txtMessage.KeyDown += (s, e) => { if (e.KeyCode == Keys.Enter) BtnSend_Click(s, e); };

            
            inputContainer.Resize += (s, e) => { 
                btnSend.Location = new Point(inputContainer.Width - 50, 10); 
                btnUploadImage.Location = new Point(inputContainer.Width - 100, 10);
            };
            btnSend.Click += BtnSend_Click;
            btnUploadImage.Click += BtnUploadImage_Click;
            
            
            btnDeleteAll.Click += async (s, e) => {
                var repo = new ChatRepository();
                using (var conn = new MySqlConnection(EnvironmentConfig.GetConnectionString()))
                {
                    await conn.OpenAsync();
                    await new MySqlCommand($"DELETE FROM chat_sessions WHERE user_id = {_chatManager.UserId}", conn).ExecuteNonQueryAsync();
                }
                chatHistoryList.Controls.Clear();
                messageContainer.Controls.Clear();
            };

            btnNewChat.Click += BtnNewChat_Click;

            
            mainPanel.Resize += (s, e) => { 
                foreach (Control c in messageContainer.Controls) 
                    c.Width = mainPanel.Width - 120; 
            };
            
            cmbModel.Items.AddRange(new string[] { 
                "General Chat (Local Qwen)", 
                "GPT-OSS(Groq)", 
                "Llama 3.3(Smart & Reasoning)", 
                "Llama 3.1(Fast & Lightweight)", 
                "Llama 4 Scout (Vision / Image Upload)" 
            });
            cmbModel.SelectedIndex = 0;
        }


        private async void LoadChatHistoryAsync()
        {
            chatHistoryList.Controls.Clear();
            var repo = new ChatRepository();
            var sessions = await repo.GetUserSessionsAsync(_chatManager.UserId);
            
            foreach (var session in sessions)
            {
                var btn = new Guna2Button
                {
                    Text = session.Title,
                    Width = 230,
                    Height = 40,
                    FillColor = Color.Transparent,
                    ForeColor = Color.Black,
                    TextAlign = HorizontalAlignment.Left,
                    Tag = session.SessionId
                };
                btn.Click += async (s, e) => await LoadSessionAsync(session.SessionId);
                chatHistoryList.Controls.Add(btn);
            }
        }

        private async void BtnNewChat_Click(object sender, EventArgs e)
        {
            await _chatManager.StartNewSessionAsync();
            messageContainer.Controls.Clear();
            LoadChatHistoryAsync();
        }

        private async Task LoadSessionAsync(string sessionId)
        {
            messageContainer.Controls.Clear();
            await _chatManager.LoadSessionAsync(sessionId);
            
            foreach (var msg in _chatManager.CurrentMessages)
            {
                string timeStr = msg.CreatedAt.ToString("HH:mm");
                if (msg.Role == "assistant") timeStr += $" ({msg.ResponseTimeMs}ms)";
                
                var bubble = new ChatBubbleUserControl(msg.Role, msg.Content, timeStr);
                messageContainer.Controls.Add(bubble);
            }
            if (messageContainer.Controls.Count > 0)
                messageContainer.ScrollControlIntoView(messageContainer.Controls[messageContainer.Controls.Count - 1]);
        }

        private async void BtnSend_Click(object sender, EventArgs e)
        {
            string content = txtMessage.Text.Trim();
            if (string.IsNullOrEmpty(content)) return;

            txtMessage.Clear();
            btnSend.Enabled = false;

            var userBubble = new ChatBubbleUserControl("user", content, DateTime.Now.ToString("HH:mm"));
            messageContainer.Controls.Add(userBubble);
            messageContainer.ScrollControlIntoView(userBubble);

            var intelligence = new SchoolIntelligenceService();
            string enhancedPrompt = await intelligence.EnhancePromptWithSchoolData(content, 1);

            string modelSelection = cmbModel.SelectedItem?.ToString() ?? "General Chat (Local Qwen)";
            bool deepThink = tglDeepThink.Checked;

            string actualModelId = "qwen";
            
            
            if (modelSelection == "General Chat (Local Qwen)")
            {
                _chatManager.SetProvider(new OllamaService());
                actualModelId = "qwen3.5:4b"; 
            }
            else
            {
                _chatManager.SetProvider(new GroqService());
                if (modelSelection == "GPT-OSS(Groq)")
                    actualModelId = "llama-3.1-8b-instant"; 
                else if (modelSelection == "Llama 3.3(Smart & Reasoning)")
                    actualModelId = "llama-3.3-70b-versatile";
                else if (modelSelection == "Llama 3.1(Fast & Lightweight)")
                    actualModelId = "llama-3.1-8b-instant";
                else if (modelSelection == "Llama 4 Scout (Vision / Image Upload)")
                    actualModelId = "meta-llama/llama-4-scout-17b-16e-instruct"; 
            }

            var aiResponse = await _chatManager.SendMessageAsync(enhancedPrompt, actualModelId, deepThink, _currentImageBase64);

            _currentImageBase64 = null; 
            txtMessage.PlaceholderText = "Ask anything...";

            var aiBubble = new ChatBubbleUserControl("assistant", aiResponse.Content, DateTime.Now.ToString("HH:mm") + $" ({aiResponse.ResponseTimeMs}ms)");
            messageContainer.Controls.Add(aiBubble);
            messageContainer.ScrollControlIntoView(aiBubble);

            btnSend.Enabled = true;
            LoadChatHistoryAsync();
        }

        private void BtnUploadImage_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.webp;*.bmp;*.gif";
                ofd.Title = "Select an Image to Analyze";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        byte[] imageBytes = System.IO.File.ReadAllBytes(ofd.FileName);
                        _currentImageBase64 = Convert.ToBase64String(imageBytes);
                        
                        
                        cmbModel.SelectedItem = "Llama 4 Scout (Vision / Image Upload)";
                        txtMessage.PlaceholderText = $"Attached: {System.IO.Path.GetFileName(ofd.FileName)}";
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error loading image: " + ex.Message, "Error");
                    }
                }
            }
        }
    }

    
    
    
    public class ChatBubbleUserControl : UserControl
    {
        private Guna2Panel bubblePanel;
        private WebBrowser webBrowserContent;
        private Label lblTime;

        public ChatBubbleUserControl(string role, string content, string timeStr)
        {
            this.Padding = new Padding(10);
            this.Width = 800; 
            this.Height = 100; 
            
            bubblePanel = new Guna2Panel
            {
                BorderRadius = 15,
                Padding = new Padding(15),
                Height = 80
            };

            webBrowserContent = new WebBrowser
            {
                ScrollBarsEnabled = false,
                WebBrowserShortcutsEnabled = false,
                IsWebBrowserContextMenuEnabled = false,
                Location = new Point(15, 15),
                Height = 50 
            };
            
            lblTime = new Label
            {
                AutoSize = true,
                Font = new Font("Segoe UI", 8),
                ForeColor = Color.Gray,
                Location = new Point(15, 70) 
            };

            bubblePanel.Controls.Add(webBrowserContent);
            bubblePanel.Controls.Add(lblTime);
            this.Controls.Add(bubblePanel);

            var pipeline = new MarkdownPipelineBuilder().UseAdvancedExtensions().Build();
            string htmlContent = Markdown.ToHtml(content, pipeline);

            string finalHtml = $@"
                <html>
                <head>
                    <meta http-equiv='X-UA-Compatible' content='IE=edge' />
                    <style>
                        body {{ font-family: 'Segoe UI', Arial; font-size: 14px; margin: 0; padding: 10px; padding-bottom: 20px; }}
                        pre {{ background-color: #f4f4f4; padding: 15px; border-radius: 8px; overflow-x: auto; overflow-y: hidden; border: 1px solid #ddd; }}
                        code {{ font-family: Consolas, monospace; font-size: 13px; }}
                        table {{ border-collapse: collapse; width: 100%; margin-top: 10px; margin-bottom: 10px; }}
                        th, td {{ border: 1px solid #ddd; padding: 8px; }}
                        th {{ background-color: #f2f2f2; }}
                        p {{ margin-top: 5px; margin-bottom: 10px; }}
                        img {{ max-width: 100%; height: auto; }}
                    </style>
                </head>
                <body>
                    {htmlContent}
                </body>
                </html>";

            webBrowserContent.DocumentText = finalHtml;
            webBrowserContent.DocumentCompleted += (s, e) =>
            {
                if (webBrowserContent.Document != null && webBrowserContent.Document.Body != null)
                {
                    
                    int tempHeight = webBrowserContent.Height;
                    webBrowserContent.Height = 10000;
                    Application.DoEvents(); 
                    
                    int height = webBrowserContent.Document.Body.ScrollRectangle.Height + 10; 
                    
                    webBrowserContent.Height = height;
                    lblTime.Location = new Point(15, height + 10);
                    bubblePanel.Height = height + 35;
                    this.Height = bubblePanel.Height + 20;
                }
            };

            lblTime.Text = timeStr;

            if (role == "user")
            {
                bubblePanel.FillColor = Color.FromArgb(240, 240, 240); 
                bubblePanel.Dock = DockStyle.Right; 
                webBrowserContent.Width = 600; 
                bubblePanel.Width = 630;
            }
            else
            {
                bubblePanel.FillColor = Color.FromArgb(220, 245, 230); 
                bubblePanel.Dock = DockStyle.Left; 
                webBrowserContent.Width = 700; 
                bubblePanel.Width = 730;
            }
        }
    }

    
    
    
    public class ChatSession
    {
        public string SessionId { get; set; } = Guid.NewGuid().ToString();
        public int UserId { get; set; }
        public string Title { get; set; } = "New Chat";
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }

    public class ChatMessage
    {
        public string MessageId { get; set; } = Guid.NewGuid().ToString();
        public string SessionId { get; set; }
        public string Role { get; set; } 
        public string Content { get; set; }
        public string ModelUsed { get; set; }
        public int ResponseTimeMs { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }

    public class AiUsageLog
    {
        public int LogId { get; set; }
        public int UserId { get; set; }
        public string ModelName { get; set; }
        public int TokensUsed { get; set; }
        public int ResponseTimeMs { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }

    
    
    
    public class ChatRepository
    {
        private string GetConnectionString() => EnvironmentConfig.GetConnectionString();

        public async Task<List<ChatSession>> GetUserSessionsAsync(int userId)
        {
            var sessions = new List<ChatSession>();
            using (var conn = new MySqlConnection(GetConnectionString()))
            {
                await conn.OpenAsync();
                string query = "SELECT * FROM chat_sessions WHERE user_id = @userId ORDER BY updated_at DESC";
                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@userId", userId);
                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            sessions.Add(new ChatSession
                            {
                                SessionId = reader["session_id"].ToString(),
                                UserId = Convert.ToInt32(reader["user_id"]),
                                Title = reader["title"].ToString(),
                                CreatedAt = Convert.ToDateTime(reader["created_at"]),
                                UpdatedAt = Convert.ToDateTime(reader["updated_at"])
                            });
                        }
                    }
                }
            }
            return sessions;
        }

        public async Task SaveSessionAsync(ChatSession session)
        {
            using (var conn = new MySqlConnection(GetConnectionString()))
            {
                await conn.OpenAsync();
                string query = @"INSERT INTO chat_sessions (session_id, user_id, title, created_at, updated_at) 
                                 VALUES (@sessionId, @userId, @title, @createdAt, @updatedAt)
                                 ON DUPLICATE KEY UPDATE title = @title, updated_at = @updatedAt";
                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@sessionId", session.SessionId);
                    cmd.Parameters.AddWithValue("@userId", session.UserId);
                    cmd.Parameters.AddWithValue("@title", session.Title);
                    cmd.Parameters.AddWithValue("@createdAt", session.CreatedAt);
                    cmd.Parameters.AddWithValue("@updatedAt", session.UpdatedAt);
                    await cmd.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task SaveMessageAsync(ChatMessage msg)
        {
            using (var conn = new MySqlConnection(GetConnectionString()))
            {
                await conn.OpenAsync();
                string query = @"INSERT INTO chat_messages (message_id, session_id, role, content, model_used, response_time, created_at) 
                                 VALUES (@msgId, @sessId, @role, @content, @model, @resTime, @createdAt)";
                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@msgId", msg.MessageId);
                    cmd.Parameters.AddWithValue("@sessId", msg.SessionId);
                    cmd.Parameters.AddWithValue("@role", msg.Role);
                    cmd.Parameters.AddWithValue("@content", msg.Content);
                    cmd.Parameters.AddWithValue("@model", (object)msg.ModelUsed ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@resTime", msg.ResponseTimeMs);
                    cmd.Parameters.AddWithValue("@createdAt", msg.CreatedAt);
                    await cmd.ExecuteNonQueryAsync();
                }
                
                string updateSession = "UPDATE chat_sessions SET updated_at = @now WHERE session_id = @sessId";
                using (var cmd2 = new MySqlCommand(updateSession, conn))
                {
                    cmd2.Parameters.AddWithValue("@now", DateTime.Now);
                    cmd2.Parameters.AddWithValue("@sessId", msg.SessionId);
                    await cmd2.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task<List<ChatMessage>> GetSessionMessagesAsync(string sessionId)
        {
            var messages = new List<ChatMessage>();
            using (var conn = new MySqlConnection(GetConnectionString()))
            {
                await conn.OpenAsync();
                string query = "SELECT * FROM chat_messages WHERE session_id = @sessId ORDER BY created_at ASC";
                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@sessId", sessionId);
                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            messages.Add(new ChatMessage
                            {
                                MessageId = reader["message_id"].ToString(),
                                SessionId = reader["session_id"].ToString(),
                                Role = reader["role"].ToString(),
                                Content = reader["content"].ToString(),
                                ModelUsed = reader["model_used"] != DBNull.Value ? reader["model_used"].ToString() : null,
                                ResponseTimeMs = Convert.ToInt32(reader["response_time"]),
                                CreatedAt = Convert.ToDateTime(reader["created_at"])
                            });
                        }
                    }
                }
            }
            return messages;
        }
    }

    public class UsageLogger
    {
        private string GetConnectionString() => EnvironmentConfig.GetConnectionString();

        public async Task LogUsageAsync(AiUsageLog log)
        {
            using (var conn = new MySqlConnection(GetConnectionString()))
            {
                await conn.OpenAsync();
                string query = @"INSERT INTO ai_usage_logs (user_id, model_name, tokens_used, response_time, created_at) 
                                 VALUES (@userId, @model, @tokens, @resTime, @createdAt)";
                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@userId", log.UserId);
                    cmd.Parameters.AddWithValue("@model", log.ModelName);
                    cmd.Parameters.AddWithValue("@tokens", log.TokensUsed);
                    cmd.Parameters.AddWithValue("@resTime", log.ResponseTimeMs);
                    cmd.Parameters.AddWithValue("@createdAt", log.CreatedAt);
                    await cmd.ExecuteNonQueryAsync();
                }
            }
        }
    }

    
    
    
    public interface IAiProvider
    {
        string ProviderName { get; }
        Task<string> SendMessageAsync(List<ChatMessage> history, string model, bool deepThink);
        Task<string> AnalyzeImageAsync(string imageBase64, string prompt, string model);
    }

    public class OllamaService : IAiProvider
    {
        public string ProviderName => "Ollama";
        private readonly HttpClient _httpClient;
        private readonly string _baseUrl = "http://localhost:11434/api/chat";

        public OllamaService()
        {
            _httpClient = new HttpClient();
            _httpClient.Timeout = TimeSpan.FromMinutes(5); 
        }

        public async Task<string> SendMessageAsync(List<ChatMessage> history, string model, bool deepThink)
        {
            var messages = history.Select(m => new { role = m.Role, content = m.Content }).ToList();
            var payload = new
            {
                model = model,
                messages = messages,
                stream = false,
                options = new
                {
                    temperature = deepThink ? 0.2 : 0.7,
                    num_ctx = deepThink ? 8192 : 4096
                }
            };

            string jsonPayload = JsonConvert.SerializeObject(payload);
            var content = new StringContent(jsonPayload, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync(_baseUrl, content);
            response.EnsureSuccessStatusCode();

            string responseJson = await response.Content.ReadAsStringAsync();
            dynamic result = JsonConvert.DeserializeObject(responseJson);

            return result.message.content;
        }

        public async Task<string> AnalyzeImageAsync(string imageBase64, string prompt, string model)
        {
            var payload = new
            {
                model = model,
                messages = new[] { new { role = "user", content = prompt, images = new[] { imageBase64 } } },
                stream = false
            };

            string jsonPayload = JsonConvert.SerializeObject(payload);
            var content = new StringContent(jsonPayload, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync(_baseUrl, content);
            response.EnsureSuccessStatusCode();

            string responseJson = await response.Content.ReadAsStringAsync();
            dynamic result = JsonConvert.DeserializeObject(responseJson);

            return result.message.content;
        }
    }

    public class GroqService : IAiProvider
    {
        public string ProviderName => "Groq";
        private readonly HttpClient _httpClient;
        private readonly string _baseUrl = "https://api.groq.com/openai/v1/chat/completions";

        public GroqService()
        {
            _httpClient = new HttpClient();
            _httpClient.Timeout = TimeSpan.FromMinutes(2); 
            _httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {EnvironmentConfig.GetGroqApiKey()}");
        }

        public async Task<string> SendMessageAsync(List<ChatMessage> history, string model, bool deepThink)
        {
            var messages = history.Select(m => new { role = m.Role, content = m.Content }).ToList();
            var payload = new
            {
                model = model,
                messages = messages,
                temperature = deepThink ? 0.2 : 0.7,
                max_tokens = deepThink ? 4096 : 1024
            };

            string jsonPayload = JsonConvert.SerializeObject(payload);
            var content = new StringContent(jsonPayload, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync(_baseUrl, content);
            response.EnsureSuccessStatusCode();

            string responseJson = await response.Content.ReadAsStringAsync();
            dynamic result = JsonConvert.DeserializeObject(responseJson);

            return result.choices[0].message.content;
        }

        public async Task<string> AnalyzeImageAsync(string imageBase64, string prompt, string model)
        {
            
            var payload = new
            {
                model = model,
                messages = new[]
                {
                    new 
                    { 
                        role = "user", 
                        content = new object[]
                        {
                            new { type = "text", text = prompt },
                            new { type = "image_url", image_url = new { url = $"data:image/jpeg;base64,{imageBase64}" } }
                        }
                    }
                }
            };

            string jsonPayload = JsonConvert.SerializeObject(payload);
            var content = new StringContent(jsonPayload, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync(_baseUrl, content);
            response.EnsureSuccessStatusCode();

            string responseJson = await response.Content.ReadAsStringAsync();
            dynamic result = JsonConvert.DeserializeObject(responseJson);

            return result.choices[0].message.content;
        }
    }

    public class SchoolIntelligenceService
    {
        private string GetConnectionString() => EnvironmentConfig.GetConnectionString();

        public async Task<string> EnhancePromptWithSchoolData(string userPrompt, int userId)
        {
            string lowerPrompt = userPrompt.ToLower();
            string context = "";

            if (lowerPrompt.Contains("student") || lowerPrompt.Contains("how many students"))
                context += await GetStudentStatsAsync();
            
            if (lowerPrompt.Contains("teacher") || lowerPrompt.Contains("faculty"))
                context += await GetTeacherStatsAsync();

            if (lowerPrompt.Contains("timetable") || lowerPrompt.Contains("schedule"))
                context += await GetUserTimetableAsync(userId);

            if (lowerPrompt.Contains("notice") || lowerPrompt.Contains("announcement"))
                context += await GetLatestNoticesAsync();

            if (!string.IsNullOrEmpty(context))
                return $"[System Context Provided to AI. Do not mention to the user that you were given this context unless asked. Use this to answer their question accuracy: {context}]\n\nUser Question: {userPrompt}";

            return userPrompt; 
        }

        private async Task<string> GetStudentStatsAsync()
        {
            try
            {
                using (var conn = new MySqlConnection(GetConnectionString()))
                {
                    await conn.OpenAsync();
                    using (var cmd = new MySqlCommand("SELECT COUNT(*) FROM student WHERE status = 'Active'", conn))
                    {
                        int count = Convert.ToInt32(await cmd.ExecuteScalarAsync());
                        return $"There are currently {count} active students enrolled in the school. ";
                    }
                }
            } catch { return ""; }
        }

        private async Task<string> GetTeacherStatsAsync()
        {
            try
            {
                using (var conn = new MySqlConnection(GetConnectionString()))
                {
                    await conn.OpenAsync();
                    using (var cmd = new MySqlCommand("SELECT COUNT(*) FROM teacher", conn))
                    {
                        int count = Convert.ToInt32(await cmd.ExecuteScalarAsync());
                        return $"There are currently {count} teachers employed at the school. ";
                    }
                }
            } catch { return ""; }
        }

        private async Task<string> GetUserTimetableAsync(int userId)
        {
            try
            {
                using (var conn = new MySqlConnection(GetConnectionString()))
                {
                    await conn.OpenAsync();
                    string query = @"SELECT t.day_of_week, t.start_time, t.end_time, s.subject_name, g.grade_level_number
                                     FROM timetable t
                                     JOIN teacher te ON t.teacher_id = te.id
                                     JOIN subject s ON t.subject_id = s.id
                                     JOIN grade g ON t.grade_id = g.id
                                     WHERE te.users_id = @uid AND t.day_of_week = @day";
                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@uid", userId);
                        cmd.Parameters.AddWithValue("@day", DateTime.Now.DayOfWeek.ToString());
                        
                        string schedule = $"Today's ({DateTime.Now.DayOfWeek}) schedule for the logged in user: \n";
                        using (var reader = await cmd.ExecuteReaderAsync())
                        {
                            bool hasClasses = false;
                            while (await reader.ReadAsync())
                            {
                                hasClasses = true;
                                schedule += $"- {reader["start_time"]} to {reader["end_time"]}: {reader["subject_name"]} (Grade {reader["grade_level_number"]})\n";
                            }
                            if (!hasClasses) return "The user has no classes scheduled for today. ";
                            return schedule;
                        }
                    }
                }
            } catch { return ""; }
        }

        private async Task<string> GetLatestNoticesAsync()
        {
            try
            {
                using (var conn = new MySqlConnection(GetConnectionString()))
                {
                    await conn.OpenAsync();
                    using (var cmd = new MySqlCommand("SELECT title, body FROM notice ORDER BY notice_date DESC LIMIT 3", conn))
                    {
                        string notices = "The latest 3 school notices are:\n";
                        using (var reader = await cmd.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                notices += $"- Title: '{reader["title"]}' Content: '{reader["body"]}'\n";
                            }
                            return notices;
                        }
                    }
                }
            } catch { return ""; }
        }
    }

    public class ChatManager
    {
        public int UserId { get; private set; }
        private readonly ChatRepository _chatRepo;
        private readonly UsageLogger _usageLogger;
        private IAiProvider _aiProvider;
        public List<ChatMessage> CurrentMessages { get; private set; }
        public event Action<string> OnChatUpdated;
        public event Action<string, bool> OnError;
        
        public ChatSession CurrentSession { get; private set; }

        public ChatManager(int userId, IAiProvider defaultProvider)
        {
            UserId = userId;
            _chatRepo = new ChatRepository();
            _usageLogger = new UsageLogger();
            _aiProvider = defaultProvider;
            CurrentMessages = new List<ChatMessage>();
        }

        public void SetProvider(IAiProvider provider)
        {
            _aiProvider = provider;
        }

        public async Task StartNewSessionAsync()
        {
            CurrentSession = new ChatSession { UserId = UserId };
            await _chatRepo.SaveSessionAsync(CurrentSession);
            CurrentMessages.Clear();
        }

        public async Task LoadSessionAsync(string sessionId)
        {
            var sessions = await _chatRepo.GetUserSessionsAsync(UserId);
            CurrentSession = sessions.FirstOrDefault(s => s.SessionId == sessionId);
            if (CurrentSession != null)
            {
                CurrentMessages = await _chatRepo.GetSessionMessagesAsync(sessionId);
            }
        }

        public async Task<ChatMessage> SendMessageAsync(string content, string model, bool deepThink, string imageBase64 = null)
        {
            if (CurrentSession == null)
                await StartNewSessionAsync();

            var userMsg = new ChatMessage { SessionId = CurrentSession.SessionId, Role = "user", Content = content };
            await _chatRepo.SaveMessageAsync(userMsg);
            CurrentMessages.Add(userMsg);

            var watch = System.Diagnostics.Stopwatch.StartNew();
            string aiResponseText = "";
            
            try
            {
                if (!string.IsNullOrEmpty(imageBase64))
                    aiResponseText = await _aiProvider.AnalyzeImageAsync(imageBase64, content, model);
                else
                    aiResponseText = await _aiProvider.SendMessageAsync(CurrentMessages, model, deepThink);
            }
            catch (Exception ex)
            {
                aiResponseText = $"[Error communicating with AI Provider: {ex.Message}]";
            }
            
            watch.Stop();

            var aiMsg = new ChatMessage
            {
                SessionId = CurrentSession.SessionId,
                Role = "assistant",
                Content = aiResponseText,
                ModelUsed = model,
                ResponseTimeMs = (int)watch.ElapsedMilliseconds
            };
            await _chatRepo.SaveMessageAsync(aiMsg);
            CurrentMessages.Add(aiMsg);

            await _usageLogger.LogUsageAsync(new AiUsageLog
            {
                UserId = UserId,
                ModelName = model,
                ResponseTimeMs = aiMsg.ResponseTimeMs,
                TokensUsed = 0
            });

            if (CurrentMessages.Count(m => m.Role == "user") == 1)
                await AutoGenerateTitleAsync(content, model);

            return aiMsg;
        }

        private async Task AutoGenerateTitleAsync(string firstMessage, string model)
        {
            try
            {
                var titlePrompt = new List<ChatMessage>
                {
                    new ChatMessage { Role = "system", Content = "Generate a short, concise title (max 4 words) for a chat that starts with the following message. Respond ONLY with the title." },
                    new ChatMessage { Role = "user", Content = firstMessage }
                };

                string title = await _aiProvider.SendMessageAsync(titlePrompt, model, false);
                CurrentSession.Title = title.Trim('\"', '\n', '\r');
                await _chatRepo.SaveSessionAsync(CurrentSession);
            }
            catch { }
        }
    }
}
