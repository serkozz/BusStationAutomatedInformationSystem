--drop table users;

---create table with data---
create table if not exists users
(
    id SERIAL PRIMARY KEY,
    login CHARACTER VARYING(100) NOT NULL,
    password CHARACTER VARYING(64) NOT NULL
);

---insert data---
--insert into users (login, password) values ('admin', '8c6976e5b5410415bde908bd4dee15dfb167a9c873fc4bb8a81f6f2ab448a918');

---login function---
create or replace function user_login(_login character varying, _password character varying)
returns int as
$$
begin
    if (select count(*) from users where login = _login and password = _password) > 0 then
        return 1; -- loged succesfully
    else
        return 0; -- fail
    end if;
end
$$
language plpgsql;

--TRUNCATE users CASCADE;
SELECT * FROM users;
SELECT column_name FROM information_schema.columns where table_name = 'users';