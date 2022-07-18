create table if not exists address
(
    id SERIAL PRIMARY KEY,
    city CHARACTER VARYING(100) NOT NULL,
    street CHARACTER VARYING(100) NOT NULL,
    house INTEGER NOT NULL
);

--insert into address (city, street, house) values ('Самара', 'Физкультурная', 94);

---add address function---
create or replace function add_address(_city character varying, _street character varying, _house integer)
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

select * from address;