create table if not exists route
(
    id SERIAL PRIMARY KEY,
    route_number INTEGER,
    departure_point_id INTEGER REFERENCES address (id) ON UPDATE CASCADE ON DELETE CASCADE,
    destination_point_id INTEGER REFERENCES address (id) ON UPDATE CASCADE ON DELETE CASCADE,
    departure_time TIME,
    destination_time TIME
);

--DELETE FROM route WHERE id > 6;
-- insert into route (route_number, departure_point_id, destination_point_id, departure_time, destination_time)
-- values (126, 4, 5, '04:05 AM', '05:05 AM', 100);
-- insert into route (route_number, departure_point_id, destination_point_id, departure_time, destination_time)
-- values (170, 5, 7, '04:05 AM', '05:05 AM', 500);
--TRUNCATE address CASCADE;
select * from route;
--SELECT route_number from route where route_number = 100;
--SELECT COUNT(*) FROM information_schema.columns where table_name = 'route';