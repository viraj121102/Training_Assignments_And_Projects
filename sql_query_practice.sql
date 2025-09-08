
-- Sample Query 
CREATE DATABaSE learning_db;

USE learning_db;

CREATE TABLE accounts (
	id int,
	name varchar(255),
	code int
);

INSERT INTO accounts VALUES (1, 'Nitesh Tiwari', 10);

select * FROM accounts;