CREATE TABLE[CompetitionTeam](
    [CompetitionId] UNIQUEIDENTIFIER NOT NULL,
    [TeamId] UNIQUEIDENTIFIER NOT NULL

    CONSTRAINT [PK_CompetitionTeam] PRIMARY KEY ([CompetitionId], [TeamId])
)