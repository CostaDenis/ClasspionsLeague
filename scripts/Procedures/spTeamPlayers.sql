CREATE OR ALTER PROCEDURE spTeamPlayers(
    @TeamId UNIQUEIDENTIFIER
) AS

SELECT 
    [Player].[Name] AS [Player],
    [Team].[Name] AS [Team]
FROM
    [Player]
    INNER JOIN [Team] ON [Team].[Id] = [Player].[TeamId]
WHERE
    [Team].[Id] = @TeamId
ORDER BY
    [Player].[Name]