create proc usp_GetProjects (@firstName nvarchar(max), @lastName nvarchar(max))
as
begin
Select p.Name, p.Description, p.StartDate  from Projects p
Join EmployeesProjects ep
on ep.ProjectID = p.ProjectID
join Employees e
on e.EmployeeID = ep.EmployeeID
where e.FirstName = @firstName AND e.LastName = @lastName
end