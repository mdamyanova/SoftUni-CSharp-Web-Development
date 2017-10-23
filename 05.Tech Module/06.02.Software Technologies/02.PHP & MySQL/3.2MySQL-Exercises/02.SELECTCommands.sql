SELECT * FROM users

SELECT * FROM posts

SELECT title, content FROM posts

SELECT username, fullname FROM users ORDER BY username ASC

SELECT username, fullname FROM users ORDER BY fullname DESC, username DESC

SELECT * FROM users WHERE id IN (SELECT author_id FROM posts)

SELECT users.username, posts.title FROM users JOIN posts ON users.id = posts.author_id

SELECT username, fullname FROM users WHERE id IN (SELECT author_id FROM posts WHERE id = 4)

SELECT username, fullname FROM users WHERE id IN (SELECT author_id FROM posts) ORDER BY id DESC