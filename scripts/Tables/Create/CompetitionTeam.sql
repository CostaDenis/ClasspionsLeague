CREATE TABLE[CompetitionTeam](
    [IdCompetition] UNIQUEIDENTIFIER NOT NULL,
    [IdTeam] UNIQUEIDENTIFIER NOT NULL

    CONSTRAINT [PK_CompetitionTeam] PRIMARY KEY ([IdCompetition], [IdTeam])
)