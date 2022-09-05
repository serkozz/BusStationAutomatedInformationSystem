create table if not exists tickets_list
(
    id SERIAL PRIMARY KEY,
    route_id INTEGER REFERENCES route (id) ON UPDATE CASCADE ON DELETE CASCADE,
    ticket_id INTEGER REFERENCES ticket (id) ON UPDATE CASCADE ON DELETE CASCADE,
    departure_time TIMESTAMP
);
--DELETE FROM tickets_list where id > 0;
select * from tickets_list;