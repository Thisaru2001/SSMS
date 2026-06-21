-- MySQL Workbench Forward Engineering

SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION';

-- -----------------------------------------------------
-- Schema mydb
-- -----------------------------------------------------
-- -----------------------------------------------------
-- Schema ssmsdb
-- -----------------------------------------------------

-- -----------------------------------------------------
-- Schema ssmsdb
-- -----------------------------------------------------
CREATE SCHEMA IF NOT EXISTS `ssmsdb` DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci ;
USE `ssmsdb` ;

-- -----------------------------------------------------
-- Table `ssmsdb`.`academic_year`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `ssmsdb`.`academic_year` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `year_name` VARCHAR(9) NOT NULL COMMENT 'e.g. 2026-2027',
  `start_date` DATE NOT NULL,
  `end_date` DATE NOT NULL,
  `is_current` TINYINT(1) NOT NULL DEFAULT '0' COMMENT '1=Current Academic Year',
  `created_at` TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`id`),
  UNIQUE INDEX `uq_year_name` (`year_name` ASC) VISIBLE)
ENGINE = InnoDB
AUTO_INCREMENT = 2
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_unicode_ci
COMMENT = 'Academic years';


-- -----------------------------------------------------
-- Table `ssmsdb`.`grade`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `ssmsdb`.`grade` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `grade_level_number` INT NOT NULL COMMENT 'e.g. 8, 9, 10',
  `section` VARCHAR(10) NOT NULL COMMENT 'e.g. A, B',
  `grade_level` INT NULL DEFAULT NULL COMMENT 'Numeric level for ordering e.g. 8 for Grade 8',
  `next_grade_id` INT NULL DEFAULT NULL COMMENT 'Next grade to promote to',
  PRIMARY KEY (`id`),
  UNIQUE INDEX `uq_grade_section` (`grade_level_number` ASC, `section` ASC) VISIBLE,
  INDEX `fk_grade_next_idx` (`next_grade_id` ASC) VISIBLE,
  CONSTRAINT `fk_grade_next`
    FOREIGN KEY (`next_grade_id`)
    REFERENCES `ssmsdb`.`grade` (`id`)
    ON DELETE SET NULL
    ON UPDATE CASCADE)
ENGINE = InnoDB
AUTO_INCREMENT = 6
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_unicode_ci
COMMENT = 'School grades / classes';


-- -----------------------------------------------------
-- Table `ssmsdb`.`users`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `ssmsdb`.`users` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `role` ENUM('principal', 'teacher', 'student') NOT NULL,
  `firstname` VARCHAR(100) NOT NULL,
  `lastname` VARCHAR(100) NULL DEFAULT NULL,
  `email` VARCHAR(100) NOT NULL,
  `password_hash` VARCHAR(255) NOT NULL COMMENT 'Hashed password',
  `nic` VARCHAR(20) NULL DEFAULT NULL,
  `phone` VARCHAR(20) NULL DEFAULT NULL,
  `address` VARCHAR(255) NULL DEFAULT NULL,
  `gender` VARCHAR(10) NULL DEFAULT NULL,
  `date_of_birth` DATE NULL DEFAULT NULL,
  `image_path` TEXT NULL DEFAULT NULL COMMENT 'Profile photo path',
  `is_active` TINYINT(1) NOT NULL DEFAULT '1',
  `created_at` TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`id`),
  UNIQUE INDEX `uq_email` (`email` ASC) VISIBLE)
ENGINE = InnoDB
AUTO_INCREMENT = 17
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_unicode_ci
COMMENT = 'All system users';


-- -----------------------------------------------------
-- Table `ssmsdb`.`student`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `ssmsdb`.`student` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `users_id` INT NOT NULL,
  `student_id` VARCHAR(20) NOT NULL COMMENT 'e.g. 1001 or 2024-1015',
  `roll_no` VARCHAR(10) NULL DEFAULT NULL COMMENT 'Class roll number',
  `grade_id` INT NOT NULL,
  `academic_year_id` INT NULL DEFAULT NULL,
  `parent_name` VARCHAR(100) NULL DEFAULT NULL,
  `enrolled_at` DATE NULL DEFAULT NULL,
  `admission_date` DATE NULL DEFAULT NULL,
  `status` ENUM('Active', 'Promoted', 'Transferred', 'Graduated', 'Dropped') NOT NULL DEFAULT 'Active',
  PRIMARY KEY (`id`),
  UNIQUE INDEX `uq_student_id` (`student_id` ASC) VISIBLE,
  INDEX `fk_student_users_idx` (`users_id` ASC) VISIBLE,
  INDEX `fk_student_grade_idx` (`grade_id` ASC) VISIBLE,
  INDEX `fk_student_academic_year_idx` (`academic_year_id` ASC) VISIBLE,
  CONSTRAINT `fk_student_academic_year`
    FOREIGN KEY (`academic_year_id`)
    REFERENCES `ssmsdb`.`academic_year` (`id`)
    ON DELETE RESTRICT
    ON UPDATE CASCADE,
  CONSTRAINT `fk_student_grade`
    FOREIGN KEY (`grade_id`)
    REFERENCES `ssmsdb`.`grade` (`id`)
    ON DELETE RESTRICT
    ON UPDATE CASCADE,
  CONSTRAINT `fk_student_users`
    FOREIGN KEY (`users_id`)
    REFERENCES `ssmsdb`.`users` (`id`)
    ON DELETE CASCADE
    ON UPDATE CASCADE)
ENGINE = InnoDB
AUTO_INCREMENT = 6
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_unicode_ci
COMMENT = 'Student profile';


-- -----------------------------------------------------
-- Table `ssmsdb`.`subject`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `ssmsdb`.`subject` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `subject_name` VARCHAR(100) NOT NULL COMMENT 'e.g. Mathematics',
  PRIMARY KEY (`id`),
  UNIQUE INDEX `uq_subject_name` (`subject_name` ASC) VISIBLE)
ENGINE = InnoDB
AUTO_INCREMENT = 6
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_unicode_ci
COMMENT = 'Available subjects';


-- -----------------------------------------------------
-- Table `ssmsdb`.`assessment`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `ssmsdb`.`assessment` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `student_id` INT NOT NULL,
  `subject_id` INT NOT NULL,
  `assessment_title` VARCHAR(200) NOT NULL,
  `file_path` TEXT NOT NULL COMMENT 'Uploaded file path/URL',
  `uploaded_at` TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`id`),
  INDEX `fk_assess_student_idx` (`student_id` ASC) VISIBLE,
  INDEX `fk_assess_subject_idx` (`subject_id` ASC) VISIBLE,
  CONSTRAINT `fk_assess_student`
    FOREIGN KEY (`student_id`)
    REFERENCES `ssmsdb`.`student` (`id`)
    ON DELETE CASCADE
    ON UPDATE CASCADE,
  CONSTRAINT `fk_assess_subject`
    FOREIGN KEY (`subject_id`)
    REFERENCES `ssmsdb`.`subject` (`id`)
    ON DELETE RESTRICT
    ON UPDATE CASCADE)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_unicode_ci
COMMENT = 'Student assignment/assessment uploads';


-- -----------------------------------------------------
-- Table `ssmsdb`.`exam`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `ssmsdb`.`exam` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `exam_name` VARCHAR(100) NOT NULL COMMENT 'e.g. Mid Term, Final Term',
  `exam_year` YEAR NOT NULL,
  `start_date` DATE NULL DEFAULT NULL,
  `end_date` DATE NULL DEFAULT NULL,
  PRIMARY KEY (`id`))
ENGINE = InnoDB
AUTO_INCREMENT = 3
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_unicode_ci
COMMENT = 'Exam definitions';


-- -----------------------------------------------------
-- Table `ssmsdb`.`exam_schedule`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `ssmsdb`.`exam_schedule` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `exam_id` INT NOT NULL,
  `subject_id` INT NOT NULL,
  `grade_id` INT NOT NULL,
  `exam_date` DATE NOT NULL,
  `start_time` TIME NOT NULL,
  `hall` VARCHAR(50) NULL DEFAULT NULL,
  PRIMARY KEY (`id`),
  INDEX `fk_es_exam_idx` (`exam_id` ASC) VISIBLE,
  INDEX `fk_es_subject_idx` (`subject_id` ASC) VISIBLE,
  INDEX `fk_es_grade_idx` (`grade_id` ASC) VISIBLE,
  CONSTRAINT `fk_es_exam`
    FOREIGN KEY (`exam_id`)
    REFERENCES `ssmsdb`.`exam` (`id`)
    ON DELETE CASCADE
    ON UPDATE CASCADE,
  CONSTRAINT `fk_es_grade`
    FOREIGN KEY (`grade_id`)
    REFERENCES `ssmsdb`.`grade` (`id`)
    ON DELETE RESTRICT
    ON UPDATE CASCADE,
  CONSTRAINT `fk_es_subject`
    FOREIGN KEY (`subject_id`)
    REFERENCES `ssmsdb`.`subject` (`id`)
    ON DELETE RESTRICT
    ON UPDATE CASCADE)
ENGINE = InnoDB
AUTO_INCREMENT = 7
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_unicode_ci
COMMENT = 'Per-subject exam schedule';


-- -----------------------------------------------------
-- Table `ssmsdb`.`notice`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `ssmsdb`.`notice` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `title` VARCHAR(200) NOT NULL,
  `body` TEXT NOT NULL,
  `target_group` SET('All', 'Teachers', 'Students') NOT NULL DEFAULT 'All',
  `posted_by` INT NOT NULL COMMENT 'users.id',
  `notice_date` DATE NOT NULL,
  `created_at` TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`id`),
  INDEX `fk_notice_user_idx` (`posted_by` ASC) VISIBLE,
  CONSTRAINT `fk_notice_user`
    FOREIGN KEY (`posted_by`)
    REFERENCES `ssmsdb`.`users` (`id`)
    ON DELETE RESTRICT
    ON UPDATE CASCADE)
ENGINE = InnoDB
AUTO_INCREMENT = 8
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_unicode_ci
COMMENT = 'School notices/announcements';


-- -----------------------------------------------------
-- Table `ssmsdb`.`principal`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `ssmsdb`.`principal` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `users_id` INT NOT NULL,
  `employee_id` VARCHAR(20) NOT NULL COMMENT 'e.g. P001',
  `qualification` VARCHAR(100) NULL DEFAULT NULL,
  PRIMARY KEY (`id`),
  UNIQUE INDEX `uq_employee_id` (`employee_id` ASC) VISIBLE,
  INDEX `fk_principal_users_idx` (`users_id` ASC) VISIBLE,
  CONSTRAINT `fk_principal_users`
    FOREIGN KEY (`users_id`)
    REFERENCES `ssmsdb`.`users` (`id`)
    ON DELETE CASCADE
    ON UPDATE CASCADE)
ENGINE = InnoDB
AUTO_INCREMENT = 3
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_unicode_ci
COMMENT = 'Principal profile';


-- -----------------------------------------------------
-- Table `ssmsdb`.`teacher`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `ssmsdb`.`teacher` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `users_id` INT NOT NULL,
  `employee_id` VARCHAR(20) NOT NULL COMMENT 'e.g. T002',
  `qualification` VARCHAR(100) NULL DEFAULT NULL,
  PRIMARY KEY (`id`),
  UNIQUE INDEX `uq_teacher_employee_id` (`employee_id` ASC) VISIBLE,
  INDEX `fk_teacher_users_idx` (`users_id` ASC) VISIBLE,
  CONSTRAINT `fk_teacher_users`
    FOREIGN KEY (`users_id`)
    REFERENCES `ssmsdb`.`users` (`id`)
    ON DELETE CASCADE
    ON UPDATE CASCADE)
ENGINE = InnoDB
AUTO_INCREMENT = 9
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_unicode_ci
COMMENT = 'Teacher profile';


-- -----------------------------------------------------
-- Table `ssmsdb`.`student_attendance`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `ssmsdb`.`student_attendance` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `student_id` INT NOT NULL,
  `grade_id` INT NOT NULL,
  `date` DATE NOT NULL,
  `is_present` TINYINT(1) NOT NULL DEFAULT '1' COMMENT '1=Present, 0=Absent',
  `marked_by` INT NOT NULL COMMENT 'teacher.id',
  `created_at` TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`id`),
  UNIQUE INDEX `uq_student_date` (`student_id` ASC, `date` ASC) VISIBLE,
  INDEX `fk_sa_student_idx` (`student_id` ASC) VISIBLE,
  INDEX `fk_sa_grade_idx` (`grade_id` ASC) VISIBLE,
  INDEX `fk_sa_teacher_idx` (`marked_by` ASC) VISIBLE,
  CONSTRAINT `fk_sa_grade`
    FOREIGN KEY (`grade_id`)
    REFERENCES `ssmsdb`.`grade` (`id`)
    ON DELETE RESTRICT
    ON UPDATE CASCADE,
  CONSTRAINT `fk_sa_student`
    FOREIGN KEY (`student_id`)
    REFERENCES `ssmsdb`.`student` (`id`)
    ON DELETE CASCADE
    ON UPDATE CASCADE,
  CONSTRAINT `fk_sa_teacher`
    FOREIGN KEY (`marked_by`)
    REFERENCES `ssmsdb`.`teacher` (`id`)
    ON DELETE RESTRICT
    ON UPDATE CASCADE)
ENGINE = InnoDB
AUTO_INCREMENT = 2
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_unicode_ci
COMMENT = 'Daily student attendance';


-- -----------------------------------------------------
-- Table `ssmsdb`.`student_grade_history`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `ssmsdb`.`student_grade_history` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `student_id` INT NOT NULL,
  `grade_id` INT NOT NULL,
  `academic_year_id` INT NOT NULL,
  `roll_no` VARCHAR(10) NULL DEFAULT NULL,
  `promoted_from` INT NULL DEFAULT NULL COMMENT 'Previous grade_id',
  `promoted_date` DATE NULL DEFAULT NULL,
  `remarks` VARCHAR(200) NULL DEFAULT NULL,
  `created_by` INT NOT NULL COMMENT 'users.id who promoted',
  `created_at` TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`id`),
  UNIQUE INDEX `uq_student_year_grade` (`student_id` ASC, `academic_year_id` ASC, `grade_id` ASC) VISIBLE,
  INDEX `fk_sgh_student_idx` (`student_id` ASC) VISIBLE,
  INDEX `fk_sgh_grade_idx` (`grade_id` ASC) VISIBLE,
  INDEX `fk_sgh_academic_year_idx` (`academic_year_id` ASC) VISIBLE,
  INDEX `fk_sgh_user_idx` (`created_by` ASC) VISIBLE,
  CONSTRAINT `fk_sgh_academic_year`
    FOREIGN KEY (`academic_year_id`)
    REFERENCES `ssmsdb`.`academic_year` (`id`)
    ON DELETE RESTRICT
    ON UPDATE CASCADE,
  CONSTRAINT `fk_sgh_grade`
    FOREIGN KEY (`grade_id`)
    REFERENCES `ssmsdb`.`grade` (`id`)
    ON DELETE RESTRICT
    ON UPDATE CASCADE,
  CONSTRAINT `fk_sgh_student`
    FOREIGN KEY (`student_id`)
    REFERENCES `ssmsdb`.`student` (`id`)
    ON DELETE CASCADE
    ON UPDATE CASCADE,
  CONSTRAINT `fk_sgh_user`
    FOREIGN KEY (`created_by`)
    REFERENCES `ssmsdb`.`users` (`id`)
    ON DELETE RESTRICT
    ON UPDATE CASCADE)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_unicode_ci
COMMENT = 'Student grade progression history';


-- -----------------------------------------------------
-- Table `ssmsdb`.`student_marks`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `ssmsdb`.`student_marks` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `student_id` INT NOT NULL,
  `exam_id` INT NOT NULL,
  `subject_id` INT NOT NULL,
  `marks` DECIMAL(5,2) NOT NULL DEFAULT '0.00',
  `total_marks` DECIMAL(5,2) NOT NULL DEFAULT '100.00',
  `grade_letter` VARCHAR(5) NULL DEFAULT NULL COMMENT 'e.g. A, B+',
  `remarks` VARCHAR(100) NULL DEFAULT NULL COMMENT 'e.g. Excellent, Good',
  `added_by` INT NOT NULL COMMENT 'teacher.id',
  `created_at` TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`id`),
  UNIQUE INDEX `uq_student_exam_subject` (`student_id` ASC, `exam_id` ASC, `subject_id` ASC) VISIBLE,
  INDEX `fk_sm_student_idx` (`student_id` ASC) VISIBLE,
  INDEX `fk_sm_exam_idx` (`exam_id` ASC) VISIBLE,
  INDEX `fk_sm_subject_idx` (`subject_id` ASC) VISIBLE,
  INDEX `fk_sm_teacher_idx` (`added_by` ASC) VISIBLE,
  CONSTRAINT `fk_sm_exam`
    FOREIGN KEY (`exam_id`)
    REFERENCES `ssmsdb`.`exam` (`id`)
    ON DELETE RESTRICT
    ON UPDATE CASCADE,
  CONSTRAINT `fk_sm_student`
    FOREIGN KEY (`student_id`)
    REFERENCES `ssmsdb`.`student` (`id`)
    ON DELETE CASCADE
    ON UPDATE CASCADE,
  CONSTRAINT `fk_sm_subject`
    FOREIGN KEY (`subject_id`)
    REFERENCES `ssmsdb`.`subject` (`id`)
    ON DELETE RESTRICT
    ON UPDATE CASCADE,
  CONSTRAINT `fk_sm_teacher`
    FOREIGN KEY (`added_by`)
    REFERENCES `ssmsdb`.`teacher` (`id`)
    ON DELETE RESTRICT
    ON UPDATE CASCADE)
ENGINE = InnoDB
AUTO_INCREMENT = 6
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_unicode_ci
COMMENT = 'Student exam marks per subject';


-- -----------------------------------------------------
-- Table `ssmsdb`.`student_marks_archive`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `ssmsdb`.`student_marks_archive` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `original_id` INT NOT NULL,
  `student_id` INT NOT NULL,
  `exam_id` INT NOT NULL,
  `subject_id` INT NOT NULL,
  `academic_year_id` INT NOT NULL,
  `marks` DECIMAL(5,2) NOT NULL,
  `total_marks` DECIMAL(5,2) NOT NULL DEFAULT '100.00',
  `grade_letter` VARCHAR(5) NULL DEFAULT NULL,
  `remarks` VARCHAR(100) NULL DEFAULT NULL,
  `added_by` INT NOT NULL,
  `archived_at` TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`id`),
  INDEX `idx_sma_student_year` (`student_id` ASC, `academic_year_id` ASC) VISIBLE)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_unicode_ci
COMMENT = 'Archived exam marks for previous years';


-- -----------------------------------------------------
-- Table `ssmsdb`.`teacher_attendance`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `ssmsdb`.`teacher_attendance` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `teacher_id` INT NOT NULL,
  `date` DATE NOT NULL,
  `status` ENUM('Present', 'Absent', 'Late') NOT NULL DEFAULT 'Present',
  `check_in` TIME NULL DEFAULT NULL,
  `check_out` TIME NULL DEFAULT NULL,
  `department` VARCHAR(100) NULL DEFAULT NULL,
  PRIMARY KEY (`id`),
  UNIQUE INDEX `uq_teacher_date` (`teacher_id` ASC, `date` ASC) VISIBLE,
  INDEX `fk_ta_teacher_idx` (`teacher_id` ASC) VISIBLE,
  CONSTRAINT `fk_ta_teacher`
    FOREIGN KEY (`teacher_id`)
    REFERENCES `ssmsdb`.`teacher` (`id`)
    ON DELETE CASCADE
    ON UPDATE CASCADE)
ENGINE = InnoDB
AUTO_INCREMENT = 2
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_unicode_ci
COMMENT = 'Daily teacher attendance';


-- -----------------------------------------------------
-- Table `ssmsdb`.`teacher_subject`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `ssmsdb`.`teacher_subject` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `teacher_id` INT NOT NULL,
  `subject_id` INT NOT NULL,
  PRIMARY KEY (`id`),
  UNIQUE INDEX `uq_teacher_subject` (`teacher_id` ASC, `subject_id` ASC) VISIBLE,
  INDEX `fk_ts_teacher_idx` (`teacher_id` ASC) VISIBLE,
  INDEX `fk_ts_subject_idx` (`subject_id` ASC) VISIBLE,
  CONSTRAINT `fk_ts_subject`
    FOREIGN KEY (`subject_id`)
    REFERENCES `ssmsdb`.`subject` (`id`)
    ON DELETE CASCADE
    ON UPDATE CASCADE,
  CONSTRAINT `fk_ts_teacher`
    FOREIGN KEY (`teacher_id`)
    REFERENCES `ssmsdb`.`teacher` (`id`)
    ON DELETE CASCADE
    ON UPDATE CASCADE)
ENGINE = InnoDB
AUTO_INCREMENT = 4
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_unicode_ci
COMMENT = 'Which subjects a teacher is assigned to';


-- -----------------------------------------------------
-- Table `ssmsdb`.`timetable`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `ssmsdb`.`timetable` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `grade_id` INT NOT NULL,
  `subject_id` INT NOT NULL,
  `teacher_id` INT NOT NULL,
  `day_of_week` ENUM('Monday', 'Tuesday', 'Wednesday', 'Thursday', 'Friday', 'Saturday') NOT NULL,
  `start_time` TIME NOT NULL,
  `end_time` TIME NOT NULL,
  `room` VARCHAR(50) NULL DEFAULT NULL,
  `academic_year_id` INT NOT NULL DEFAULT '1',
  PRIMARY KEY (`id`),
  INDEX `fk_tt_grade_idx` (`grade_id` ASC) VISIBLE,
  INDEX `fk_tt_subject_idx` (`subject_id` ASC) VISIBLE,
  INDEX `fk_tt_teacher_idx` (`teacher_id` ASC) VISIBLE,
  INDEX `fk_tt_academic_year` (`academic_year_id` ASC) VISIBLE,
  CONSTRAINT `fk_tt_academic_year`
    FOREIGN KEY (`academic_year_id`)
    REFERENCES `ssmsdb`.`academic_year` (`id`)
    ON DELETE RESTRICT
    ON UPDATE CASCADE,
  CONSTRAINT `fk_tt_grade`
    FOREIGN KEY (`grade_id`)
    REFERENCES `ssmsdb`.`grade` (`id`)
    ON DELETE RESTRICT
    ON UPDATE CASCADE,
  CONSTRAINT `fk_tt_subject`
    FOREIGN KEY (`subject_id`)
    REFERENCES `ssmsdb`.`subject` (`id`)
    ON DELETE RESTRICT
    ON UPDATE CASCADE,
  CONSTRAINT `fk_tt_teacher`
    FOREIGN KEY (`teacher_id`)
    REFERENCES `ssmsdb`.`teacher` (`id`)
    ON DELETE RESTRICT
    ON UPDATE CASCADE)
ENGINE = InnoDB
AUTO_INCREMENT = 4
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_unicode_ci
COMMENT = 'Class timetable';

USE `ssmsdb` ;

-- -----------------------------------------------------
-- Placeholder table for view `ssmsdb`.`view_current_students`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `ssmsdb`.`view_current_students` (`student_id` INT, `student_code` INT, `roll_no` INT, `firstname` INT, `lastname` INT, `email` INT, `phone` INT, `grade_name` INT, `section` INT, `grade_level` INT, `academic_year` INT, `status` INT, `admission_date` INT, `parent_name` INT);

-- -----------------------------------------------------
-- procedure PromoteStudentsToNextGrade
-- -----------------------------------------------------

DELIMITER $$
USE `ssmsdb`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `PromoteStudentsToNextGrade`(
    IN p_academic_year_id INT,
    IN p_promoted_by INT
)
BEGIN
    DECLARE v_student_id INT;
    DECLARE v_current_grade_id INT;
    DECLARE v_next_grade_id INT;
    DECLARE v_done INT DEFAULT FALSE;
    
    -- Cursor for active students
    DECLARE cur CURSOR FOR
        SELECT s.id, s.grade_id
        FROM student s
        INNER JOIN grade g ON s.grade_id = g.id
        WHERE s.status = 'Active';
    
    DECLARE CONTINUE HANDLER FOR NOT FOUND SET v_done = TRUE;
    
    START TRANSACTION;
    
    OPEN cur;
    
    read_loop: LOOP
        FETCH cur INTO v_student_id, v_current_grade_id;
        
        IF v_done THEN
            LEAVE read_loop;
        END IF;
        
        -- Get next grade
        SELECT next_grade_id INTO v_next_grade_id
        FROM grade
        WHERE id = v_current_grade_id;
        
        IF v_next_grade_id IS NOT NULL THEN
            -- Insert into history
            INSERT INTO student_grade_history 
                (student_id, grade_id, academic_year_id, roll_no, promoted_from, promoted_date, created_by)
            VALUES 
                (v_student_id, v_current_grade_id, 
                 (SELECT id FROM academic_year WHERE is_current = 1),
                 (SELECT roll_no FROM student WHERE id = v_student_id),
                 NULL, NOW(), p_promoted_by);
            
            -- Update student to next grade
            UPDATE student 
            SET grade_id = v_next_grade_id,
                academic_year_id = p_academic_year_id,
                roll_no = NULL,
                status = 'Promoted'
            WHERE id = v_student_id;
            
            -- Reactivate with new status
            UPDATE student 
            SET status = 'Active'
            WHERE id = v_student_id;
            
        ELSE
            -- Highest grade - mark as graduated
            INSERT INTO student_grade_history 
                (student_id, grade_id, academic_year_id, roll_no, remarks, created_by)
            VALUES 
                (v_student_id, v_current_grade_id,
                 (SELECT id FROM academic_year WHERE is_current = 1),
                 (SELECT roll_no FROM student WHERE id = v_student_id),
                 'Graduated', p_promoted_by);
            
            UPDATE student SET status = 'Graduated' WHERE id = v_student_id;
        END IF;
    END LOOP;
    
    CLOSE cur;
    
    COMMIT;
    
    SELECT 'Promotion completed successfully' AS message;
END$$

DELIMITER ;

-- -----------------------------------------------------
-- View `ssmsdb`.`view_current_students`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `ssmsdb`.`view_current_students`;
USE `ssmsdb`;
CREATE  OR REPLACE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `ssmsdb`.`view_current_students` AS select `s`.`id` AS `student_id`,`s`.`student_id` AS `student_code`,`s`.`roll_no` AS `roll_no`,`u`.`firstname` AS `firstname`,`u`.`lastname` AS `lastname`,`u`.`email` AS `email`,`u`.`phone` AS `phone`,`g`.`grade_name` AS `grade_name`,`g`.`section` AS `section`,`g`.`grade_level` AS `grade_level`,`ay`.`year_name` AS `academic_year`,`s`.`status` AS `status`,`s`.`admission_date` AS `admission_date`,`s`.`parent_name` AS `parent_name` from (((`ssmsdb`.`student` `s` join `ssmsdb`.`users` `u` on((`s`.`users_id` = `u`.`id`))) join `ssmsdb`.`grade` `g` on((`s`.`grade_id` = `g`.`id`))) left join `ssmsdb`.`academic_year` `ay` on((`s`.`academic_year_id` = `ay`.`id`))) where ((`u`.`is_active` = 1) and (`s`.`status` = 'Active'));

SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;
