[Reflection.Assembly]::LoadFile('C:\Users\CYBORG\OneDrive\Desktop\SSMS\SSMS\SSMS\bin\Debug\net10.0-windows\MySql.Data.dll')
$conn = New-Object MySql.Data.MySqlClient.MySqlConnection('Server=localhost;Database=ssmsdb;Uid=root;Pwd=;')
$conn.Open()
$cmd = $conn.CreateCommand()
$cmd.CommandText = 'DESCRIBE assessment'
$reader = $cmd.ExecuteReader()
while ($reader.Read()) {
    Write-Host ($reader.GetString(0) + ' - ' + $reader.GetString(1))
}
$conn.Close()
