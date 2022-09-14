create table if not exists bus
(
    id SERIAL PRIMARY KEY,
    bus_number INTEGER,
    model_name CHARACTER VARYING (50),
    driver_emloyee_id INTEGER REFERENCES employee (id) ON UPDATE CASCADE ON DELETE CASCADE
);

--INSERT INTO bus (bus_number,model_name,driver_emloyee_id) values (170, 'Иж', 2);

select * from bus;

SELECT (bus_number,surname,name,midname) FROM bus LEFT JOIN employee ON bus.driver_emloyee_id = employee.id LEFT JOIN profile ON employee.profile_id = profile.id WHERE bus_number = 126;
SELECT bus.id FROM bus
LEFT JOIN employee ON bus.driver_emloyee_id = employee.id
LEFT JOIN profile ON employee.profile_id = profile.id
WHERE bus.bus_number = 126 AND profile.surname = 'Алексеев'
AND profile.name = 'Сергей' AND profile.midname = 'Сергеевич';