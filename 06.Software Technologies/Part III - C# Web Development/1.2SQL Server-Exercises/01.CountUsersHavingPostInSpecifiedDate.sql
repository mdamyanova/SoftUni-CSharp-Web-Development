SELECT COUNT(Id) as Users_Count from [Blog].[dbo].[Users] WHERE id IN (SELECT
                                                                          AuthorId
                                                                        FROM
                                                                        [Blog].[dbo].[Posts]
                                                                        WHERE
                                                                        Date = '2016-06-14')