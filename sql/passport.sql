--drop table passport;

create table if not exists passport
(
    id serial primary key,
    series integer,
    number integer
);

--DELETE FROM passport WHERE id > 0;
--insert into passport (series, number) values (3615, 146753);
--UPDATE passport SET series = 3000, number = 192421 where id = 1 RETURNING id;
select * from passport;