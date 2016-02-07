CREATE DATABASE [ufoTestDb];

CREATE TABLE [dbo].[Admin] (
    [username] NVARCHAR (50) NOT NULL,
    [password] NVARCHAR (50) NOT NULL,
    [email]    NVARCHAR (50) NOT NULL,
    PRIMARY KEY CLUSTERED ([username] ASC)
);

CREATE TABLE [dbo].[Category] (
    [idCategory] NVARCHAR (10) NOT NULL,
    [label]      NVARCHAR (50) NOT NULL,
    PRIMARY KEY CLUSTERED ([idCategory] ASC)
);

CREATE TABLE [dbo].[Location] (
    [idLocation] NVARCHAR (10) DEFAULT ('') NOT NULL,
    [label]      NVARCHAR (50) NOT NULL,
    PRIMARY KEY CLUSTERED ([idLocation] ASC)
);

CREATE TABLE [dbo].[Artist] (
    [idArtist]    INT            IDENTITY (1, 1) NOT NULL,
    [name]        NVARCHAR (50)  NOT NULL,
    [country]     NVARCHAR (50)  NOT NULL,
    [email]       NVARCHAR (150)  NOT NULL,
    [description] NVARCHAR (500) NULL,
    [homepage]    NVARCHAR (250)  NULL,
    [picture]     NVARCHAR (250)  NULL,
    [video]       NVARCHAR (250)  NULL,
    [category]    NVARCHAR (10)  NULL,
    [deleted]     BIT            NOT NULL,
    PRIMARY KEY CLUSTERED ([idArtist] ASC),
    CONSTRAINT [FK_category_ToCategory] FOREIGN KEY ([category]) REFERENCES [dbo].[Category] ([idCategory])
);

CREATE TABLE [dbo].[Venue] (
    [idVenue]       INT           NOT NULL,
    [label]         NVARCHAR (50) NOT NULL,
    [maxSpectators] INT           NULL,
    [location]      NVARCHAR (10) NOT NULL,
    [latitude]      FLOAT         NULL,
    [longitude]     FLOAT         NULL, 
    CONSTRAINT [pkVenue] PRIMARY KEY CLUSTERED ([location] ASC, [idVenue] ASC),
    CONSTRAINT [FK_region_ToRegion] FOREIGN KEY ([location]) REFERENCES [dbo].[Location] ([idLocation])
);

CREATE TABLE [dbo].[Restrictions] (
    [idRestrictions] INT           IDENTITY (1, 1) NOT NULL,
    [start]          DATETIME      NULL,
    [stop]           DATETIME      NULL,
    [venue]          INT           NOT NULL,
    [cLocation]      NVARCHAR (10) NOT NULL,
    [category]       NVARCHAR (10) NOT NULL,
    PRIMARY KEY CLUSTERED ([idRestrictions] ASC),
    CONSTRAINT [fkRestrictions_ToVenue] FOREIGN KEY ([cLocation], [venue]) REFERENCES [dbo].[Venue] ([location], [idVenue]),
    CONSTRAINT [fkRestrictions_ToCategory] FOREIGN KEY ([category]) REFERENCES [dbo].[Category] ([idCategory])
);

CREATE TABLE [dbo].[Performance] (
    [idPerformance] INT           IDENTITY (1, 1) NOT NULL,
    [start]         DATETIME      NOT NULL,
    [artist]        INT           NOT NULL,
    [pVenue]        INT           NOT NULL,
    [pLocation]     NVARCHAR (10) NOT NULL,
    PRIMARY KEY CLUSTERED ([idPerformance] ASC),
    CONSTRAINT [uniqueVenue] UNIQUE NONCLUSTERED ([start] ASC, [pVenue] ASC, [pLocation] ASC),
    CONSTRAINT [uniqueArtist] UNIQUE NONCLUSTERED ([start] ASC, [artist] ASC),
    CONSTRAINT [fkArtist_ToArtist] FOREIGN KEY ([artist]) REFERENCES [dbo].[Artist] ([idArtist]),
    CONSTRAINT [fkVenue_ToVenue] FOREIGN KEY ([pLocation], [pVenue]) REFERENCES [dbo].[Venue] ([location], [idVenue])
);
