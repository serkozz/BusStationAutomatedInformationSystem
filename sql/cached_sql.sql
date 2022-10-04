create table if not exists cached_sql
(
    id SERIAL PRIMARY KEY,
    key_sentence CHARACTER VARYING (50),
    sql_string CHARACTER VARYING (500)
);

--INSERT INTO cached_sql (key_sentence,sql_string) values ('Select all from ticket', 'select * from ticket');
SELECT * from cached_sql;
select (id) from cached_sql where key_sentence = 'Select all from ticket' OR sql_string = 'Select * from ticket';