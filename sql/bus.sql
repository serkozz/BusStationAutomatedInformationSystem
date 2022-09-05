create table if not exists bus
(
    id SERIAL PRIMARY KEY,
    bus_number INTEGER,
    model_name CHARACTER VARYING (50),
    driver_emloyee_id INTEGER REFERENCES employee (id) ON UPDATE CASCADE ON DELETE CASCADE
);

select * from bus;