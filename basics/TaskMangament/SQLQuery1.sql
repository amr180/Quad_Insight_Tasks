create database TaskManagementDB;
use TaskManagementDB;

Create Table Users
(
    UserId int primary key identity (1,1),

    UserName nvarchar (100) NOT NULL,

    Email nvarchar(150)
);
create table Tasks
(
    TaskId int primary key identity(1,1),

    Title nvarchar (150) NOT NULL,

    UserId INT,

    foreign key (UserId)
    references Users(UserId)
);
insert into Users(UserName,Email)
values
('ahmed','ahmed@gmail.com'),
('amr','amr@gmail.com'),
('mohamed','mohamedsara@gmail.com');

insert into Tasks(Title,UserId)
values
('Learn C#',1),
('Study SQL',1),
('Finish OOP',2),
('Prepare Presentation',3);
--------------------------------------
select *
from Tasks
where UserId = 1;

go

select
Users.UserName,
Tasks.Title
from Users
INNER JOIN Tasks
on Users.UserId = Tasks.UserId;
go
------------------------------------------------
--asc
select *
from Tasks
Order by  Title ASC;
go
--des
select *
from Tasks
Order by Title DESC;


