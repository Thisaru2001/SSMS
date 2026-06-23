ALTER TABLE users MODIFY COLUMN role ENUM('principal','teacher','student','principal_assistant') NOT NULL;

CREATE TABLE IF NOT EXISTS principal_assistant (
  id INT NOT NULL AUTO_INCREMENT,
  users_id INT NOT NULL,
  employee_id VARCHAR(45) NOT NULL,
  qualification VARCHAR(45) DEFAULT NULL,
  PRIMARY KEY (id),
  UNIQUE KEY employee_id_UNIQUE (employee_id),
  KEY fk_principal_assistant_users1_idx (users_id),
  CONSTRAINT fk_principal_assistant_users1 FOREIGN KEY (users_id) REFERENCES users (id) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3;

INSERT INTO users (id, role, firstname, lastname, email, password_hash, nic, phone, gender, is_active) 
VALUES (200, 'principal_assistant', 'Assistant', 'Principal', 'assistant@ssms.com', 'a665a45920422f9d417e4867efdc4fb8a04a1f3fff1fa07e998e86f7f7a27ae3', '987654321V', '0771111111', 'Female', 1)
ON DUPLICATE KEY UPDATE id=id;

INSERT INTO principal_assistant (id, users_id, employee_id, qualification) VALUES (1, 200, 'PAS/2026/001', 'Assistant')
ON DUPLICATE KEY UPDATE id=id;
