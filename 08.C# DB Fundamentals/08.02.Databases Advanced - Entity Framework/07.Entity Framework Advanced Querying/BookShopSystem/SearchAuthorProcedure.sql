create procedure usp_Authors(@firstName nvarchar(max), @lastName nvarchar(max))
as
begin
SELECT Count(*) as Count FROM Authors a
JOIN Books b
on b.Author_Id = a.Id
where a.FirstName = @firstName AND a.LastName = @lastName
end