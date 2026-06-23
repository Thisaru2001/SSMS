SET FOREIGN_KEY_CHECKS = 0;
TRUNCATE TABLE student_marks;
TRUNCATE TABLE student_marks_archive;
TRUNCATE TABLE student_attendance;
TRUNCATE TABLE teacher_attendance;
TRUNCATE TABLE timetable;
TRUNCATE TABLE relief_timetable;
TRUNCATE TABLE teacher_subject;
TRUNCATE TABLE notice;
TRUNCATE TABLE exam;
TRUNCATE TABLE exam_schedule;
TRUNCATE TABLE assessment;
TRUNCATE TABLE student;
TRUNCATE TABLE teacher;
TRUNCATE TABLE users;
TRUNCATE TABLE principal;
TRUNCATE TABLE principal_assistant;
TRUNCATE TABLE grade;
TRUNCATE TABLE subject;
TRUNCATE TABLE academic_year;
SET FOREIGN_KEY_CHECKS = 1;

-- Insert default academic year
INSERT INTO academic_year (id, year_name, start_date, end_date, is_current) VALUES (1, '2024/2025', '2024-01-01', '2025-12-31', 1);

-- Insert default principal user (Password is '123')
-- The login ID will be 'PS/2026/001'
INSERT INTO users (id, role, firstname, lastname, email, password_hash, nic, phone, gender, is_active) 
VALUES (1, 'principal', 'Admin', 'Principal', 'admin@ssms.com', 'a665a45920422f9d417e4867efdc4fb8a04a1f3fff1fa07e998e86f7f7a27ae3', '123456789V', '0770000000', 'Male', 1);

INSERT INTO principal (id, users_id, employee_id, qualification) VALUES (1, 1, 'PS/2026/001', 'Admin');

-- Insert default principal assistant user (Password is '123')
-- The login ID will be 'PAS/2026/001'
INSERT INTO users (id, role, firstname, lastname, email, password_hash, nic, phone, gender, is_active) 
VALUES (200, 'principal_assistant', 'Assistant', 'Principal', 'assistant@ssms.com', 'a665a45920422f9d417e4867efdc4fb8a04a1f3fff1fa07e998e86f7f7a27ae3', '987654321V', '0771111111', 'Female', 1);

INSERT INTO principal_assistant (id, users_id, employee_id, qualification) VALUES (1, 200, 'PAS/2026/001', 'Assistant');

-- Insert sample grades
INSERT INTO grade (id, grade_level_number, section, grade_level) VALUES 
(1, 1, 'A', 1), (2, 1, 'B', 1),
(3, 2, 'A', 2), (4, 2, 'B', 2),
(5, 3, 'A', 3), (6, 3, 'B', 3),
(7, 4, 'A', 4), (8, 4, 'B', 4),
(9, 5, 'A', 5), (10, 5, 'B', 5),
(11, 6, 'A', 6), (12, 6, 'B', 6),
(13, 7, 'A', 7), (14, 7, 'B', 7),
(15, 8, 'A', 8), (16, 8, 'B', 8),
(17, 9, 'A', 9), (18, 9, 'B', 9),
(19, 10, 'A', 10), (20, 10, 'B', 10),
(21, 11, 'A', 11), (22, 11, 'B', 11),
(23, 12, 'A', 12), (24, 12, 'B', 12),
(25, 13, 'A', 13), (26, 13, 'B', 13);

-- Insert sample subjects
INSERT INTO subject (id, subject_name) VALUES 
(1, 'Mathematics'),
(2, 'Science'),
(3, 'English'),
(4, 'History'),
(5, 'Computer'),
(6, 'Sinhala'),
(7, 'Tamil'),
(8, 'Buddhism'),
(9, 'Geography'),
(10, 'Civics');
