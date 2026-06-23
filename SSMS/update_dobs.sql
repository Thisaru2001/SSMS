UPDATE users SET date_of_birth = '2008-05-14' WHERE role = 'student' AND (date_of_birth IS NULL OR date_of_birth = '0000-00-00');
