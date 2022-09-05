create table if not exists route
(
    id SERIAL PRIMARY KEY,
    route_number INTEGER,
    departure_point_id INTEGER REFERENCES address (id) ON UPDATE CASCADE ON DELETE CASCADE,
    destination_point_id INTEGER REFERENCES address (id) ON UPDATE CASCADE ON DELETE CASCADE,
    departure_time TIME,
    trip_distance FLOAT
);
-- insert into route (route_number, departure_point_id, destination_point_id, departure_time, trip_distance)
-- values (126, 53, 54, '05:05 AM', 100);
-- insert into route (route_number, departure_point_id, destination_point_id, departure_time, trip_distance)
-- values (170, 54, 53, '04:05 AM', 500);
select * from route;