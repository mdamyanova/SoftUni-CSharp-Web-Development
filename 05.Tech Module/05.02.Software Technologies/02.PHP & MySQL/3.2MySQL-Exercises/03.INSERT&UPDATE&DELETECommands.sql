INSERT INTO blog.posts (author_id, title, content, date) 
VALUES(2, 'Random Title', 'Random Content', STR_TO_DATE('2016-07-06', '%Y-%m-%d'))

UPDATE blog.posts SET title = 'Too random to be true' WHERE id = 8

DELETE FROM posts WHERE id = 8