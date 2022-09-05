create table if not exists position
(
    id SERIAL PRIMARY KEY,
    position_name CHARACTER VARYING (50),
    wage INTEGER
);

select * from position;