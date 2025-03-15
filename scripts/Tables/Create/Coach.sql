CREATE TABLE [Coach](
    [Id] UNIQUEIDENTIFIER NOT NULL,
    [Nationality] NVARCHAR(30) NOT NULL,
    [BirthDate] DATE NOT NULL,
    [TeamId] UNIQUEIDENTIFIER NOT NULL

    CONSTRAINT [PK_Coach] PRIMARY KEY ([Id])
)