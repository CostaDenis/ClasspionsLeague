CREATE TABLE [Coach](
    [Id] UNIQUEIDENTIFIER NOT NULL,
    [Name] VARCHAR(50) NOT NULL,
    [Country] VARCHAR(30) NOT NULL,
    [BirthDate] DATE NOT NULL,
    [TeamId] UNIQUEIDENTIFIER

    CONSTRAINT [PK_Coach] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Coach_Team_TeamId] FOREIGN KEY ([TeamId]) REFERENCES [Team] ([Id]),
    CONSTRAINT [UQ_Coach_Id] UNIQUE ([Id])
)