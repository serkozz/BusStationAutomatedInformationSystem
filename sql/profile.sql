create table if not exists profile
(
    id SERIAL PRIMARY KEY,
    user_id INTEGER REFERENCES users (id) NOT NULL,
    passport_id INTEGER REFERENCES passport (id) NOT NULL,
    address_id INTEGER REFERENCES address (id) NOT NULL,
    surname CHARACTER VARYING(100) NOT NULL,
    name CHARACTER VARYING(100) NOT NULL,
    midname CHARACTER VARYING(100),
    phone_number BIGINT NOT NULL
);

--insert into profile (user_id, passport_id, address_id, surname, name, midname, phone_number) values (1, 1, 1, 'Козлов', 'Сергей', 'Александрович', 89371850202);

---profile updated check function---
create or replace function profile_updated( character varying, _street character varying, _house integer)
returns int as
$$
begin
    if (select count(*) from address where city = _city and street = _street and house = _house) > 0 then
        return 1; -- added succesfully
    else
        return 0; -- fail
    end if;
end
$$
language plpgsql;

select * from profile;
