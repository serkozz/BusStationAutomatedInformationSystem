
DROP table utility_table;

create table if not exists utility_table
(
    id SERIAL PRIMARY KEY,
    parameter CHARACTER VARYING(50),
    parameter_value CHARACTER VARYING(50)
);

-- INSERT INTO utility_table (parameter,parameter_value) VALUES ('adminPassword', 'adminPassword');
-- INSERT INTO utility_table (parameter,parameter_value) VALUES ('rublesPerKilometer', '5.2');

SELECT * FROM utility_table;