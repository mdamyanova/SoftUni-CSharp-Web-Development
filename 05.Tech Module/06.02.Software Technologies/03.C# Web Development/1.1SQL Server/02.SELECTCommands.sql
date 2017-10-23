--Select all posts
SELECT * FROM Blog.dbo.Posts

--List users
SELECT * FROM Blog.dbo.Users

--List columns from posts
SELECT title, body FROM Blog.dbo.Posts

--Order data
SELECT username, fullname FROM Blog.dbo.Users ORDER BY username DESC

--Order by two columns
SELECT username, fullname FROM Blog.dbo.Users
ORDER BY fullname DESC, username DESC

--Nested select
SELECT * FROM Blog.dbo.Users WHERE id IN (SELECT AuthorId FROM Blog.dbo.Posts)

--Join users with posts
SELECT Blog.dbo.Users.UserName, Blog.dbo.Posts.Title From Blog.dbo.Users 
Join Blog.dbo.Posts ON Blog.dbo.Users.Id = Blog.dbo.Posts.AuthorId

--Posts authors
SELECT Blog.dbo.Users.Username, Blog.dbo.Users.FullName FROM Blog.dbo.Users
WHERE Blog.dbo.Users.Id IN (SELECT Blog.dbo.Posts.AuthorId FROM Blog.dbo.Posts) ORDER BY Blog.dbo.Users.Id DESC