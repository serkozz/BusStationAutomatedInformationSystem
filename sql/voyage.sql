create table if not exists voyage
(
    id SERIAL PRIMARY KEY,
    route_id INTEGER REFERENCES route (id) ON UPDATE CASCADE ON DELETE CASCADE,
    bus_id INTEGER REFERENCES bus (id) ON UPDATE CASCADE ON DELETE CASCADE,
    tickets_list INTEGER[],
    departure_time TIME
);

select * from voyage;