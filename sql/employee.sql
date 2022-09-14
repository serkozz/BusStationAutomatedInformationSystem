create table if not exists employee
(
    id SERIAL PRIMARY KEY,
    profile_id INTEGER REFERENCES profile (id) ON UPDATE CASCADE ON DELETE CASCADE,
    position_id INTEGER REFERENCES position (id) ON UPDATE CASCADE ON DELETE CASCADE
);

select * from employee;
SELECT id FROM bus LEFT JOIN
employee ON bus. = profile_id.id;