create table if not exists userTripHistory
(
    id SERIAL PRIMARY KEY,
    profile_id INTEGER REFERENCES profile (id) ON UPDATE CASCADE ON DELETE CASCADE,
    route_id INTEGER REFERENCES route (id) ON UPDATE CASCADE ON DELETE CASCADE,
    trip_date DATE
);

SELECT * FROM userTripHistory;