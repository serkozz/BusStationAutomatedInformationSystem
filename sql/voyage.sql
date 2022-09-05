create table if not exists voyage
(
    id SERIAL PRIMARY KEY,
    tickets_list_id INTEGER REFERENCES tickets_list (id) ON UPDATE CASCADE ON DELETE CASCADE,
    route_id INTEGER REFERENCES route (id) ON UPDATE CASCADE ON DELETE CASCADE,
    bus_id INTEGER REFERENCES bus (id) ON UPDATE CASCADE ON DELETE CASCADE,
    departure_time TIME,
    arrival_time TIME
);

select * from voyage;