create table if not exists address
(
    id SERIAL PRIMARY KEY,
    city CHARACTER VARYING(100),
    street CHARACTER VARYING(100),
    house INTEGER
);

--DELETE FROM address WHERE id > 0;
--insert into address (city, street, house) values ('Самара', 'Победа', 17);
--TRUNCATE address CASCADE;
select * from address;