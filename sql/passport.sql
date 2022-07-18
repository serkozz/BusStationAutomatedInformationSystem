create table if not exists passport
(
    id serial primary key,
    series integer not null,
    number integer not null
);

--insert into passport (series, number) values (3615, 146753);

---add passport function---
create or replace function add_passport(_series integer, _number integer)
returns int as
$$
begin
    if (select count(*) from passport where series = _series and number = _number) > 0 then
        return 1; -- added succesfully
    else
        return 0; -- fail
    end if;
end
$$
language plpgsql;

select * from passport;