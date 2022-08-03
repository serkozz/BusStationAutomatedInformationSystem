create table if not exists route
(
    id SERIAL PRIMARY KEY,
    route_number INTEGER,
    departure_point_id INTEGER REFERENCES address (id) ON UPDATE CASCADE ON DELETE CASCADE,
    destination_point_id INTEGER REFERENCES address (id) ON UPDATE CASCADE ON DELETE CASCADE,
    departure_time TIME,
    destination_time TIME
);

--DELETE FROM address WHERE id > 0;
--insert into address (city, street, house) values ('Самара', 'Победа', 17);
--TRUNCATE address CASCADE;
select * from route;