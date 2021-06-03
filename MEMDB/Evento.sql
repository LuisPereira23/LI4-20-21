CREATE TABLE [dbo].[Evento] (
    [Id]        INT           NOT NULL,
    [Descricao] VARCHAR (300) NULL,
    [Titulo]    VARCHAR (30)  NULL,
    [Categoria] VARCHAR (30)  NULL,
    [Inicio]    DATE          NULL,
    [Fim]       DATE          NULL,
    [Latitude]  VARCHAR (30)  NULL,
    [Longitude] VARCHAR (30)  NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

