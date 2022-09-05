create table if not exists address
(
    id SERIAL PRIMARY KEY,
    city CHARACTER VARYING(100),
    street CHARACTER VARYING(100),
    house INTEGER
);

--DELETE FROM address where id = 4;
--insert into address (id, city, street, house) values (4, 'Самара', 'Гагарина', 17);
--TRUNCATE address CASCADE;
select * from address;
--SELECT (city, street) from address where id = 5;