create table if not exists ticket
(
    id SERIAL PRIMARY KEY,
    profile_id INTEGER REFERENCES profile (id) ON UPDATE CASCADE ON DELETE CASCADE,
    route_id INTEGER REFERENCES route (id) ON UPDATE CASCADE ON DELETE CASCADE,
    trip_date DATE,
    price FLOAT
);

--DELETE FROM ticket where id > 0; 
-- insert into ticket (profile_id, route_id, trip_date, price)
-- values (20, 1, '2022-08-30', 100) RETURNING id;
select * from ticket;