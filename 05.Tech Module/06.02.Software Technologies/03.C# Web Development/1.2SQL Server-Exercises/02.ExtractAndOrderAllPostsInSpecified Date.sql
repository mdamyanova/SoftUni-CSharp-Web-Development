SELECT
    Id, AuthorId, Title, Body, Date
FROM
    [Blog].[dbo].[Posts]
WHERE Date = '2016-06-14'                
ORDER BY AuthorId ASC