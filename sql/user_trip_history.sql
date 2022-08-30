create table if not exists user_trip_history
(
    id SERIAL PRIMARY KEY,
    profile_id INTEGER REFERENCES profile (id) ON UPDATE CASCADE ON DELETE CASCADE,
    route_id INTEGER REFERENCES route (id) ON UPDATE CASCADE ON DELETE CASCADE,
    trip_date DATE
);

--insert into user_trip_history (profile_id,route_id,trip_date) values (20, 1, '2022-08-31');

SELECT * FROM user_trip_history;