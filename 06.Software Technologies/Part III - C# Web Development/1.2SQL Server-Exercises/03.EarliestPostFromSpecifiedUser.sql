SELECT
    Id, AuthorId, Title, Body, Date
FROM
    [Blog].[dbo].[Posts]
WHERE Date IN (SELECT
                  MIN(Date)
               FROM
                  [Blog].[dbo].[Posts]
               WHERE
                  AuthorId = 2)