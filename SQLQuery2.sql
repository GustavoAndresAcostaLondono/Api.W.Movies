INSERT INTO DBO.Categories (Name, CreatedDate)
VALUES (N'Thriller', SYSDATETIME()),
       (N'Comedy', SYSDATETIME()),
       (N'Action', SYSDATETIME());

select *from Categories