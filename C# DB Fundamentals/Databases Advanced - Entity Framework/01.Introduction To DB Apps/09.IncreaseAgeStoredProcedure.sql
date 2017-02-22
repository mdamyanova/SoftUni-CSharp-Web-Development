CREATE PROCEDURE usp_GetOlder(@minionId int)
AS
BEGIN
UPDATE Minions
SET Age += 1
END