CREATE TABLE [Competition](
    [Id] UNIQUEIDENTIFIER NOT NULL,
    [Name] VARCHAR(60) NOT NULL,
    [Country] VARCHAR(30)

    CONSTRAINT [PK_Competition] PRIMARY KEY([Id])
)