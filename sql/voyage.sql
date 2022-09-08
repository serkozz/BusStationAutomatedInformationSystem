--drop table voyage;

create table if not exists voyage
(
    id SERIAL PRIMARY KEY,
    route_id INTEGER REFERENCES route (id) ON UPDATE CASCADE ON DELETE CASCADE,
    bus_id INTEGER REFERENCES bus (id) ON UPDATE CASCADE ON DELETE CASCADE,
    tickets_count INTEGER,
    departure_time TIMESTAMP
);

select * from voyage;