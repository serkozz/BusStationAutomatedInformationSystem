create table if not exists profile
(
    id SERIAL PRIMARY KEY,
    user_id INTEGER REFERENCES users (id) NOT NULL,
    passport_id INTEGER REFERENCES passport (id),
    address_id INTEGER REFERENCES address (id),
    surname CHARACTER VARYING(100),
    name CHARACTER VARYING(100),
    midname CHARACTER VARYING(100),
    phone_number BIGINT
);

--TRUNCATE profile CASCADE;
--DELETE FROM profile WHERE id > 0;
--insert into profile (user_id, passport_id, address_id, surname, name, midname, phone_number) values (1, 1, 1, 'Козлов', 'Сергей', 'Александрович', 89371850202) RETURNING (id, user_id, passport_id, address_id, surname, name, midname, phone_number);
--insert into profile (user_id) values (2) RETURNING (id, user_id, passport_id, address_id, surname, name, midname, phone_number);
select * from profile;
--SELECT profile.name, profile.surname, users.login, users.password FROM profile JOIN users ON profile.user_id = users.id
