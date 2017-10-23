--Insert command
INSERT INTO Blog.dbo.Posts (AuthorId, Title, Body, Date) 
VALUES (2, 'Random Title', 'Random Content', CAST('2016-07-17T12:56:34' AS DateTime))

--Update command
UPDATE Blog.dbo.Posts SET Title = 'New Title' WHERE Id = 9

--Delete command 
DELETE FROM Blog.dbo.Posts WHERE Id = 9

--Count command 
SELECT COUNT(*) as Posts_Count FROM Blog.dbo.Posts

--Count where author id = 2
SELECT COUNT(*) as Posts_Count_AuthorId FROM Blog.dbo.Posts WHERE AuthorId = 2

--Min command
SELECT MIN(AuthorId) as Min_Value FROM Blog.dbo.Posts

--Min command for the date of posts
SELECT MIN(Date) as Min_Value_Date FROM Blog.dbo.Posts

--Max command
SELECT MAX(AuthorId) as Max_Value FROM Blog.dbo.Posts

--Max command for tags table 
SELECT MAX(Id) as Max_Value_Id FROM Blog.dbo.Tags

--Sum command
SELECT SUM(Id) as Sum_Ids FROM Blog.dbo.Tags

--Sum users with posts ids
SELECT SUM(DISTINCT AuthorId) as Sum_Users_With_Posts_Ids FROM Blog.dbo.Posts