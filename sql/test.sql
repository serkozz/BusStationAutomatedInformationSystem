select (route_number,a1.city,a1.street,a1.house,a2.city,a2.street,a2.house,voyage.departure_time,voyage.tickets_count) FROM voyage
LEFT JOIN bus ON voyage.bus_id = bus.id
LEFT JOIN employee ON driver_emloyee_id = employee.id
LEFT JOIN route ON route_id = route.id
LEFT JOIN address AS a1 ON departure_point_id = a1.id
LEFT JOIN address AS a2 ON destination_point_id = a2.id
WHERE profile_id = 25;


SELECT (id) from employee WHERE profile_id = 23;