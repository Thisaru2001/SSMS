-- Insert Japanese subject if not exists
INSERT IGNORE INTO subject (id, subject_name) VALUES (11, 'Japanese');

-- Users for 8 Teachers
INSERT INTO users (id, role, firstname, lastname, email, password_hash, is_active) VALUES 
(2, 'teacher', 'Amali', 'Perera', 'amali@ssms.com', 'a665a45920422f9d417e4867efdc4fb8a04a1f3fff1fa07e998e86f7f7a27ae3', 1),
(3, 'teacher', 'Nimal', 'Silva', 'nimal@ssms.com', 'a665a45920422f9d417e4867efdc4fb8a04a1f3fff1fa07e998e86f7f7a27ae3', 1),
(4, 'teacher', 'Kamala', 'Fernando', 'kamala@ssms.com', 'a665a45920422f9d417e4867efdc4fb8a04a1f3fff1fa07e998e86f7f7a27ae3', 1),
(5, 'teacher', 'Sunethra', 'Bandara', 'sunethra@ssms.com', 'a665a45920422f9d417e4867efdc4fb8a04a1f3fff1fa07e998e86f7f7a27ae3', 1),
(6, 'teacher', 'Ruwan', 'Kumara', 'ruwan@ssms.com', 'a665a45920422f9d417e4867efdc4fb8a04a1f3fff1fa07e998e86f7f7a27ae3', 1),
(7, 'teacher', 'Yoshitha', 'Rajapaksha', 'yoshitha@ssms.com', 'a665a45920422f9d417e4867efdc4fb8a04a1f3fff1fa07e998e86f7f7a27ae3', 1),
(8, 'teacher', 'Kasun', 'Kalhara', 'kasun@ssms.com', 'a665a45920422f9d417e4867efdc4fb8a04a1f3fff1fa07e998e86f7f7a27ae3', 1),
(9, 'teacher', 'Nadeeka', 'Jayasinghe', 'nadeeka@ssms.com', 'a665a45920422f9d417e4867efdc4fb8a04a1f3fff1fa07e998e86f7f7a27ae3', 1);

-- Insert into Teacher table
INSERT INTO teacher (id, users_id, employee_id) VALUES 
(1, 2, 'T/2026/001'),
(2, 3, 'T/2026/002'),
(3, 4, 'T/2026/003'),
(4, 5, 'T/2026/004'),
(5, 6, 'T/2026/005'),
(6, 7, 'T/2026/006'),
(7, 8, 'T/2026/007'),
(8, 9, 'T/2026/008');

-- Map Teacher Subjects
INSERT INTO teacher_subject (teacher_id, subject_id) VALUES 
(1, 1), -- Amali = Mathematics (1)
(2, 6), -- Nimal = Sinhala (6)
(3, 3), -- Kamala = English (3)
(4, 8), -- Sunethra = Buddhism (8)
(5, 5), -- Ruwan = IT/Computer (5)
(6, 11), -- Yoshitha = Japanese (11)
(7, 4), -- Kasun = History (4)
(8, 2); -- Nadeeka = Science (2)

-- Insert 20 Students into Users
INSERT INTO users (id, role, firstname, lastname, email, password_hash, is_active) VALUES 
(10, 'student', 'Student', 'One', 'stu1@ssms.com', 'a665a45920422f9d417e4867efdc4fb8a04a1f3fff1fa07e998e86f7f7a27ae3', 1),
(11, 'student', 'Student', 'Two', 'stu2@ssms.com', 'a665a45920422f9d417e4867efdc4fb8a04a1f3fff1fa07e998e86f7f7a27ae3', 1),
(12, 'student', 'Student', 'Three', 'stu3@ssms.com', 'a665a45920422f9d417e4867efdc4fb8a04a1f3fff1fa07e998e86f7f7a27ae3', 1),
(13, 'student', 'Student', 'Four', 'stu4@ssms.com', 'a665a45920422f9d417e4867efdc4fb8a04a1f3fff1fa07e998e86f7f7a27ae3', 1),
(14, 'student', 'Student', 'Five', 'stu5@ssms.com', 'a665a45920422f9d417e4867efdc4fb8a04a1f3fff1fa07e998e86f7f7a27ae3', 1),
(15, 'student', 'Student', 'Six', 'stu6@ssms.com', 'a665a45920422f9d417e4867efdc4fb8a04a1f3fff1fa07e998e86f7f7a27ae3', 1),
(16, 'student', 'Student', 'Seven', 'stu7@ssms.com', 'a665a45920422f9d417e4867efdc4fb8a04a1f3fff1fa07e998e86f7f7a27ae3', 1),
(17, 'student', 'Student', 'Eight', 'stu8@ssms.com', 'a665a45920422f9d417e4867efdc4fb8a04a1f3fff1fa07e998e86f7f7a27ae3', 1),
(18, 'student', 'Student', 'Nine', 'stu9@ssms.com', 'a665a45920422f9d417e4867efdc4fb8a04a1f3fff1fa07e998e86f7f7a27ae3', 1),
(19, 'student', 'Student', 'Ten', 'stu10@ssms.com', 'a665a45920422f9d417e4867efdc4fb8a04a1f3fff1fa07e998e86f7f7a27ae3', 1),
(20, 'student', 'Student', 'Eleven', 'stu11@ssms.com', 'a665a45920422f9d417e4867efdc4fb8a04a1f3fff1fa07e998e86f7f7a27ae3', 1),
(21, 'student', 'Student', 'Twelve', 'stu12@ssms.com', 'a665a45920422f9d417e4867efdc4fb8a04a1f3fff1fa07e998e86f7f7a27ae3', 1),
(22, 'student', 'Student', 'Thirteen', 'stu13@ssms.com', 'a665a45920422f9d417e4867efdc4fb8a04a1f3fff1fa07e998e86f7f7a27ae3', 1),
(23, 'student', 'Student', 'Fourteen', 'stu14@ssms.com', 'a665a45920422f9d417e4867efdc4fb8a04a1f3fff1fa07e998e86f7f7a27ae3', 1),
(24, 'student', 'Student', 'Fifteen', 'stu15@ssms.com', 'a665a45920422f9d417e4867efdc4fb8a04a1f3fff1fa07e998e86f7f7a27ae3', 1),
(25, 'student', 'Student', 'Sixteen', 'stu16@ssms.com', 'a665a45920422f9d417e4867efdc4fb8a04a1f3fff1fa07e998e86f7f7a27ae3', 1),
(26, 'student', 'Student', 'Seventeen', 'stu17@ssms.com', 'a665a45920422f9d417e4867efdc4fb8a04a1f3fff1fa07e998e86f7f7a27ae3', 1),
(27, 'student', 'Student', 'Eighteen', 'stu18@ssms.com', 'a665a45920422f9d417e4867efdc4fb8a04a1f3fff1fa07e998e86f7f7a27ae3', 1),
(28, 'student', 'Student', 'Nineteen', 'stu19@ssms.com', 'a665a45920422f9d417e4867efdc4fb8a04a1f3fff1fa07e998e86f7f7a27ae3', 1),
(29, 'student', 'Student', 'Twenty', 'stu20@ssms.com', 'a665a45920422f9d417e4867efdc4fb8a04a1f3fff1fa07e998e86f7f7a27ae3', 1);

-- Map Students (5 per grade: 1A, 1B, 2A, 2B)
INSERT INTO student (id, users_id, student_id, grade_id, academic_year_id, status) VALUES 
(1, 10, 'S/2026/001', 1, 1, 'Active'),
(2, 11, 'S/2026/002', 1, 1, 'Active'),
(3, 12, 'S/2026/003', 1, 1, 'Active'),
(4, 13, 'S/2026/004', 1, 1, 'Active'),
(5, 14, 'S/2026/005', 1, 1, 'Active'),
(6, 15, 'S/2026/006', 2, 1, 'Active'),
(7, 16, 'S/2026/007', 2, 1, 'Active'),
(8, 17, 'S/2026/008', 2, 1, 'Active'),
(9, 18, 'S/2026/009', 2, 1, 'Active'),
(10, 19, 'S/2026/010', 2, 1, 'Active'),
(11, 20, 'S/2026/011', 3, 1, 'Active'),
(12, 21, 'S/2026/012', 3, 1, 'Active'),
(13, 22, 'S/2026/013', 3, 1, 'Active'),
(14, 23, 'S/2026/014', 3, 1, 'Active'),
(15, 24, 'S/2026/015', 3, 1, 'Active'),
(16, 25, 'S/2026/016', 4, 1, 'Active'),
(17, 26, 'S/2026/017', 4, 1, 'Active'),
(18, 27, 'S/2026/018', 4, 1, 'Active'),
(19, 28, 'S/2026/019', 4, 1, 'Active'),
(20, 29, 'S/2026/020', 4, 1, 'Active');
