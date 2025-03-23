CREATE TABLE [Player](
    [Id] UNIQUEIDENTIFIER NOT NULL,
    [Name] VARCHAR(50) NOT NULL,
    [Country] VARCHAR(30) NOT NULL,
    [BirthDate] DATE NOT NULL,
    [Position] VARCHAR(30) NOT NULL,
    [TeamId] UNIQUEIDENTIFIER

    CONSTRAINT [PK_Player] PRIMARY KEY([Id]),
    CONSTRAINT [FK_Player_Team_TeamId] FOREIGN KEY ([TeamId]) REFERENCES [Team] ([Id]),
    CONSTRAINT [UQ_Player_Id] UNIQUE ([Id])
)