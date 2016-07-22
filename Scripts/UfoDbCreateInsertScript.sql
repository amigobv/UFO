CREATE DATABASE [ufoDb];

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

INSERT INTO  [dbo].[Admin] ([username], [password], [email]) VALUES ('swk5', 'dAGv7nlKMsAtU1R2aNyfeVUFiig=', 's1310307036@students.fh-hagenberg.at');
INSERT INTO  [dbo].[Admin] ([username], [password], [email]) VALUES  ('s1310307036', 'NXyisQv5c9aYq9uwwc1mB8zagOs=', 'daniell.rotaru@gmail.com');

INSERT INTO [dbo].[Category] ([idCategory], [label]) VALUES ('A', 'Akrobatik');
INSERT INTO [dbo].[Category] ([idCategory], [label]) VALUES ('K', 'Komedy');
INSERT INTO [dbo].[Category] ([idCategory], [label]) VALUES ('F', 'Feuershow');
INSERT INTO [dbo].[Category] ([idCategory], [label]) VALUES ('J', 'Jonglage');
INSERT INTO [dbo].[Category] ([idCategory], [label]) VALUES ('L', 'LuftAkrobatik');
INSERT INTO [dbo].[Category] ([idCategory], [label]) VALUES ('M', 'Musik');
INSERT INTO [dbo].[Category] ([idCategory], [label]) VALUES ('S', 'Samba');
INSERT INTO [dbo].[Category] ([idCategory], [label]) VALUES ('T', 'Tanz');
INSERT INTO [dbo].[Category] ([idCategory], [label]) VALUES ('Fig', 'Figurentheater');

INSERT INTO [dbo].[Location] ([idLocation], [label]) VALUES ('H', 'Hauptplatz');
INSERT INTO [dbo].[Location] ([idLocation], [label]) VALUES ('P', 'Pfarrplatz und Domgasse');
INSERT INTO [dbo].[Location] ([idLocation], [label]) VALUES ('A', 'Altstadt');
INSERT INTO [dbo].[Location] ([idLocation], [label]) VALUES ('L', 'Landstraße');
INSERT INTO [dbo].[Location] ([idLocation], [label]) VALUES ('X', 'Promenade');
INSERT INTO [dbo].[Location] ([idLocation], [label]) VALUES ('T', 'Straßentheater');
INSERT INTO [dbo].[Location] ([idLocation], [label]) VALUES ('M', 'Musik-Spot');
INSERT INTO [dbo].[Location] ([idLocation], [label]) VALUES ('N', 'Nightline');

INSERT INTO [dbo].[Venue] ([idVenue], [label], [maxSpectators], [location], [latitude], [longitude]) VALUES (1, 'Dreifaltigkeitssäule', 100, 'H', 48.305916, 14.286436);
INSERT INTO [dbo].[Venue] ([idVenue], [label], [maxSpectators], [location], [latitude], [longitude]) VALUES (2, 'Mader Reisen', 150, 'H', 48.306162, 14.286124);
INSERT INTO [dbo].[Venue] ([idVenue], [label], [maxSpectators], [location], [latitude], [longitude]) VALUES (3, 'Haltestelle', 110, 'H', 48.306323, 14.286446);
INSERT INTO [dbo].[Venue] ([idVenue], [label], [maxSpectators], [location], [latitude], [longitude]) VALUES (4, 'Altes Rathaus', 120, 'H', 48.305980, 14.286784);
INSERT INTO [dbo].[Venue] ([idVenue], [label], [maxSpectators], [location], [latitude], [longitude]) VALUES (5, 'Fa. Mammut', 100, 'H', 48.305627, 14.286951);
INSERT INTO [dbo].[Venue] ([idVenue], [label], [maxSpectators], [location], [latitude], [longitude]) VALUES (6, 'Bank Austria', 120, 'H', 48.305197, 14.287310);

INSERT INTO [dbo].[Venue] ([idVenue], [label], [maxSpectators], [location], [latitude], [longitude]) VALUES (1, 'Keplersalon', 80, 'P', 48.306551, 14.287423);
INSERT INTO [dbo].[Venue] ([idVenue], [label], [maxSpectators], [location], [latitude], [longitude]) VALUES (2, 'Adalbert-Stifter-Platz', 70, 'P', 48.307123, 14.287801);
INSERT INTO [dbo].[Venue] ([idVenue], [label], [maxSpectators], [location], [latitude], [longitude]) VALUES (3, 'Stadtpfarrkirche', 60, 'P', 48.306713, 14.288369);
INSERT INTO [dbo].[Venue] ([idVenue], [label], [maxSpectators], [location], [latitude], [longitude]) VALUES (4, 'Pfarrgasse 3', 50, 'P', 48.306135, 14.287581);
INSERT INTO [dbo].[Venue] ([idVenue], [label], [maxSpectators], [location], [latitude], [longitude]) VALUES (5, 'Pfarrplatz', 85, 'P', 48.306633, 14.288987);
INSERT INTO [dbo].[Venue] ([idVenue], [label], [maxSpectators], [location], [latitude], [longitude]) VALUES (6, 'Domgasse', 40, 'P', 48.305379, 14.288054);

INSERT INTO [dbo].[Venue] ([idVenue], [label], [maxSpectators], [location], [latitude], [longitude]) VALUES (1, 'Klosterstraße 7', 50, 'A', 48.304520, 14.286231);
INSERT INTO [dbo].[Venue] ([idVenue], [label], [maxSpectators], [location], [latitude], [longitude]) VALUES (2, 'Landhaus', 60, 'A', 48.303988, 14.285517);
INSERT INTO [dbo].[Venue] ([idVenue], [label], [maxSpectators], [location], [latitude], [longitude]) VALUES (3, 'Altstadt 13', 60, 'A', 48.304982, 14.284830);
INSERT INTO [dbo].[Venue] ([idVenue], [label], [maxSpectators], [location], [latitude], [longitude]) VALUES (4, 'Alter Markt', 55, 'A', 48.305661, 14.284498);
INSERT INTO [dbo].[Venue] ([idVenue], [label], [maxSpectators], [location], [latitude], [longitude]) VALUES (5, 'Hofgasse 13', 40, 'A', 48.305842, 14.284505);
INSERT INTO [dbo].[Venue] ([idVenue], [label], [maxSpectators], [location], [latitude], [longitude]) VALUES (6, 'Schlossmuseum', 10, 'A', 48.304873, 14.283464);

INSERT INTO [dbo].[Venue] ([idVenue], [label], [maxSpectators], [location], [latitude], [longitude]) VALUES (1, 'Annagasse', 40, 'L', 48.304613, 14.287660);
INSERT INTO [dbo].[Venue] ([idVenue], [label], [maxSpectators], [location], [latitude], [longitude]) VALUES (2, 'Taubenmarkt', 45, 'L', 48.304174, 14.288344);
INSERT INTO [dbo].[Venue] ([idVenue], [label], [maxSpectators], [location], [latitude], [longitude]) VALUES (3, 'Bethlehemstraße', 55, 'L', 48.303135, 14.289146);
INSERT INTO [dbo].[Venue] ([idVenue], [label], [maxSpectators], [location], [latitude], [longitude]) VALUES (4, 'Spittelwiese 4', 55, 'L', 48.303005, 14.288166);
INSERT INTO [dbo].[Venue] ([idVenue], [label], [maxSpectators], [location], [latitude], [longitude]) VALUES (5, 'Ursulinenkirche', 50, 'L', 48.302520, 14.289769);
INSERT INTO [dbo].[Venue] ([idVenue], [label], [maxSpectators], [location], [latitude], [longitude]) VALUES (6, 'Karmeliterkirche', 45, 'L', 48.301872, 14.290344);
INSERT INTO [dbo].[Venue] ([idVenue], [label], [maxSpectators], [location], [latitude], [longitude]) VALUES (7, 'OK-Platz', 80, 'L', 48.302900, 14.290918);
INSERT INTO [dbo].[Venue] ([idVenue], [label], [maxSpectators], [location], [latitude], [longitude]) VALUES (8, 'Martin-Luther-Platz', 70, 'L', 48.300542, 14.291115);

INSERT INTO [dbo].[Venue] ([idVenue], [label], [maxSpectators], [location], [latitude], [longitude]) VALUES (1, 'Cafe Traxlmayr', 55, 'X', 48.304561, 14.287178);
INSERT INTO [dbo].[Venue] ([idVenue], [label], [maxSpectators], [location], [latitude], [longitude]) VALUES (2, 'Sparkasse', 50, 'X', 48.304037, 14.286364);
INSERT INTO [dbo].[Venue] ([idVenue], [label], [maxSpectators], [location], [latitude], [longitude]) VALUES (3, 'Promenade 17', 45, 'X', 48.303546, 14.286039);
INSERT INTO [dbo].[Venue] ([idVenue], [label], [maxSpectators], [location], [latitude], [longitude]) VALUES (4, 'Medienhaus Wimmer', 40, 'X', 48.302592, 14.286293);

INSERT INTO [dbo].[Restrictions] ([start], [stop], [venue], [cLocation], [category]) VALUES ('20160722 21:00', '20160722 23:00', 1, 'H', 'F');
INSERT INTO [dbo].[Restrictions] ([start], [stop], [venue], [cLocation], [category]) VALUES ('20160723 21:00', '20160723 23:00', 2, 'H', 'F');
INSERT INTO [dbo].[Restrictions] ([start], [stop], [venue], [cLocation], [category]) VALUES ('20160724 21:00', '20160724 23:00', 3, 'H', 'F');
INSERT INTO [dbo].[Restrictions] ([start], [stop], [venue], [cLocation], [category]) VALUES ('20160722 16:00', '20160722 23:00', 4, 'L', 'M');
INSERT INTO [dbo].[Restrictions] ([start], [stop], [venue], [cLocation], [category]) VALUES ('20160723 16:00', '20160723 23:00', 5, 'L', 'M');
INSERT INTO [dbo].[Restrictions] ([start], [stop], [venue], [cLocation], [category]) VALUES ('20160724 16:00', '20160724 23:00', 6, 'L', 'M');

INSERT INTO [dbo].[Artist] ([name], [country], [email], [homepage], [picture], [video], [description], [category], [deleted]) VALUES ('figurentheater ', 'Österreich', 'figurentheater@armyspy.com', NULL, 'C:\Temp\assets\images\Figurentheater150x100.jpg', NULL, NULL, 'Fig', 'false');
INSERT INTO [dbo].[Artist] ([name], [country], [email], [homepage], [picture], [video], [description], [category], [deleted]) VALUES ('circoPitanga', 'Schweiz', 'circoPitanga@teleworm.us', NULL, 'C:\Temp\assets\images\CircoPitanga150x100.jpg', NULL, NULL, 'K', 'false');
INSERT INTO [dbo].[Artist] ([name], [country], [email], [homepage], [picture], [video], [description], [category], [deleted]) VALUES ('Compagnie Antipodes', 'Frankreich', 'CompagnieAntipodes@jourrapide.com', NULL, 'C:\Temp\assets\images\CompagnieAntipodes150x100.jpg', NULL, NULL, 'A', 'false');
INSERT INTO [dbo].[Artist] ([name], [country], [email], [homepage], [picture], [video], [description], [category], [deleted]) VALUES ('Los Galindos', 'Spanien', 'LosGalindos@dayrep.com', NULL, 'C:\Temp\assets\images\LosGalindos150x100.jpg', NULL, NULL, 'M', 'false');
INSERT INTO [dbo].[Artist] ([name], [country], [email], [homepage], [picture], [video], [description], [category], [deleted]) VALUES ('La Trocola Circo', 'Spanien', 'LaTrocolaCirco@dayrep.com', NULL, 'C:\Temp\assets\images\LaTrocolaCirco150x100.jpg', NULL, NULL, 'A', 'false');
INSERT INTO [dbo].[Artist] ([name], [country], [email], [homepage], [picture], [video], [description], [category], [deleted]) VALUES ('Jean Philippe Kikolas', 'Spanien', 'JeanPhilippeKikolas@dayrep.com', NULL, 'C:\Temp\assets\images\JeanPhilippeKikolas150x100.jpg', NULL, NULL, 'K', 'false');
INSERT INTO [dbo].[Artist] ([name], [country], [email], [homepage], [picture], [video], [description], [category], [deleted]) VALUES ('Hint', 'Schweden', 'Hint@dayrep.com', NULL, 'C:\Temp\assets\images\Hint150x100.jpg', NULL, NULL, 'J', 'false');
INSERT INTO [dbo].[Artist] ([name], [country], [email], [homepage], [picture], [video], [description], [category], [deleted]) VALUES ('Box Actor Yaya', 'Japan', 'BoxActorYaya@cuvox.de', NULL, 'C:\Temp\assets\images\BoxActorYaya150x100.jpg', NULL, NULL, 'K', 'false');
INSERT INTO [dbo].[Artist] ([name], [country], [email], [homepage], [picture], [video], [description], [category], [deleted]) VALUES ('Compagnie MOBIL', 'Niederlande', 'CompagnieMobil@cuvox.de', NULL, 'C:\Temp\assets\images\CompagnieMobil150x100.jpg', NULL, NULL, 'M', 'false');
INSERT INTO [dbo].[Artist] ([name], [country], [email], [homepage], [picture], [video], [description], [category], [deleted]) VALUES ('Derek Derek', 'USA', 'DerekDerek@cuvox.de', NULL, 'C:\Temp\assets\images\DerekDerek150x100.jpg', NULL, NULL, 'A', 'false');
INSERT INTO [dbo].[Artist] ([name], [country], [email], [homepage], [picture], [video], [description], [category], [deleted]) VALUES ('Die Buschs', 'Deutschland', 'DieBuschs@cuvox.de', NULL, 'C:\Temp\assets\images\DieBuschs150x100.jpg', NULL, NULL, 'S', 'false');
INSERT INTO [dbo].[Artist] ([name], [country], [email], [homepage], [picture], [video], [description], [category], [deleted]) VALUES ('Dimitar and Tui', 'Bulgarien', 'DimitarTui@armyspy.com', NULL, 'C:\Temp\assets\images\DimitarTui150x100.jpg', NULL, NULL, 'A', 'false');
INSERT INTO [dbo].[Artist] ([name], [country], [email], [homepage], [picture], [video], [description], [category], [deleted]) VALUES ('Capuzzi Senorita', 'Argentinien', 'CapuzziSenorita@armyspy.com', NULL, 'C:\Temp\assets\images\CapuzziSenorita150x100.jpg', NULL, NULL, 'L', 'false');
INSERT INTO [dbo].[Artist] ([name], [country], [email], [homepage], [picture], [video], [description], [category], [deleted]) VALUES ('El Diabolero', 'Österreich', 'ElDiabolero@armyspy.com', NULL, 'C:\Temp\assets\images\ElDiabolero150x100.jpg', NULL, NULL, 'K', 'false');
INSERT INTO [dbo].[Artist] ([name], [country], [email], [homepage], [picture], [video], [description], [category], [deleted]) VALUES ('Hundertpfund', 'Deutschland', 'Hundertpfund@fleckens.hu', NULL, 'C:\Temp\assets\images\Hundertpfund150x100.jpg', NULL, NULL, 'K', 'false');
INSERT INTO [dbo].[Artist] ([name], [country], [email], [homepage], [picture], [video], [description], [category], [deleted]) VALUES ('Konrad', 'Deutschland', 'Konrad@fleckens.hu', NULL, 'C:\Temp\assets\images\Konrad150x100.jpg', NULL, NULL, 'F', 'false');
INSERT INTO [dbo].[Artist] ([name], [country], [email], [homepage], [picture], [video], [description], [category], [deleted]) VALUES ('HoopStep', 'Deutschland', 'HoopStep@fleckens.hu', NULL, 'C:\Temp\assets\images\HoopStep150x100.jpg', NULL, NULL, 'A', 'false');
INSERT INTO [dbo].[Artist] ([name], [country], [email], [homepage], [picture], [video], [description], [category], [deleted]) VALUES ('Ian Deadly', 'Großbritannien', 'IanDeadly@superrito.com', NULL, 'C:\Temp\assets\images\IanDeadly150x100.jpg', NULL, NULL, 'M', 'false');
INSERT INTO [dbo].[Artist] ([name], [country], [email], [homepage], [picture], [video], [description], [category], [deleted]) VALUES ('Kammann', 'Deutschland', 'Kammann@superrito.com', NULL, 'C:\Temp\assets\images\Kammann150x100.jpg', NULL, NULL, 'K', 'false');
INSERT INTO [dbo].[Artist] ([name], [country], [email], [homepage], [picture], [video], [description], [category], [deleted]) VALUES ('Kana', 'Japan', 'Kana@superrito.com', NULL, 'C:\Temp\assets\images\Kana150x100.jpg', NULL, NULL, 'L', 'false');
INSERT INTO [dbo].[Artist] ([name], [country], [email], [homepage], [picture], [video], [description], [category], [deleted]) VALUES ('Mostacho', 'Chile', 'Mostacho@superrito.com', NULL, 'C:\Temp\assets\images\Mostacho150x100.jpg', NULL, NULL, 'S', 'false');
INSERT INTO [dbo].[Artist] ([name], [country], [email], [homepage], [picture], [video], [description], [category], [deleted]) VALUES ('Nanirossi', 'Italien', 'Nanirossi@superrito.com', NULL, 'C:\Temp\assets\images\Nanirossi150x100.jpg', NULL, NULL, 'K', 'false');
INSERT INTO [dbo].[Artist] ([name], [country], [email], [homepage], [picture], [video], [description], [category], [deleted]) VALUES ('Pallotto', 'Italien', 'Pallotto@superrito.com', NULL, 'C:\Temp\assets\images\Pallotto150x100.jpg', NULL, NULL, 'A', 'false');
INSERT INTO [dbo].[Artist] ([name], [country], [email], [homepage], [picture], [video], [description], [category], [deleted]) VALUES ('Samuelito', 'Schweiz', 'Samuelito@superrito.com', NULL, 'C:\Temp\assets\images\Samuelito150x100.jpg', NULL, NULL, 'K', 'false');
INSERT INTO [dbo].[Artist] ([name], [country], [email], [homepage], [picture], [video], [description], [category], [deleted]) VALUES ('Shay Wapniaz', 'Italien', 'ShayWapniaz@gustr.com', NULL, 'C:\Temp\assets\images\ShayWapniaz150x100.jpg', NULL, NULL, 'M', 'false');
INSERT INTO [dbo].[Artist] ([name], [country], [email], [homepage], [picture], [video], [description], [category], [deleted]) VALUES ('DANCEproject', 'Österreich', 'DanceProject@gustr.com', NULL, 'C:\Temp\assets\images\DanceProject150x100.jpg', NULL, NULL, 'T', 'false');
INSERT INTO [dbo].[Artist] ([name], [country], [email], [homepage], [picture], [video], [description], [category], [deleted]) VALUES ('Duo Kate', 'Finnland', 'DuoKate@gustr.com', NULL, 'C:\Temp\assets\images\DuoKate150x100.jpg', NULL, NULL, 'T', 'false');
INSERT INTO [dbo].[Artist] ([name], [country], [email], [homepage], [picture], [video], [description], [category], [deleted]) VALUES ('Duo Looky', 'Israel', 'DuoLooky@gustr.com', NULL, 'C:\Temp\assets\images\DuoLooky150x100.jpg', NULL, NULL, 'A', 'false');
INSERT INTO [dbo].[Artist] ([name], [country], [email], [homepage], [picture], [video], [description], [category], [deleted]) VALUES ('Duo Masawa', 'Argentinien', 'DuoMasawa@gustr.com', NULL, 'C:\Temp\assets\images\DuoMasawa150x100.jpg', NULL, NULL, 'A', 'false');  
INSERT INTO [dbo].[Artist] ([name], [country], [email], [homepage], [picture], [video], [description], [category], [deleted]) VALUES ('Katay Santos', 'Venezuela', 'KataySantos@superrito.com', NULL, 'C:\Temp\assets\images\KataySantos150x100.jpg', NULL, NULL, 'S', 'false'); 
INSERT INTO [dbo].[Artist] ([name], [country], [email], [homepage], [picture], [video], [description], [category], [deleted]) VALUES ('El Otro', 'Spanien', 'ElOtro@superrito.com', NULL, 'C:\Temp\assets\images\ElOtro150x100.jpg', NULL, NULL, 'A', 'false'); 
INSERT INTO [dbo].[Artist] ([name], [country], [email], [homepage], [picture], [video], [description], [category], [deleted]) VALUES ('Frutillas Con Crema', 'Chile', 'FrutillasConCrema@superrito.com', NULL, 'C:\Temp\assets\images\FrutillasConCrema150x100.jpg', NULL, NULL, 'L', 'false'); 
INSERT INTO [dbo].[Artist] ([name], [country], [email], [homepage], [picture], [video], [description], [category], [deleted]) VALUES ('Passabarret', 'Spanien', 'Passabarret@superrito.com', NULL, 'C:\Temp\assets\images\Passabarret150x100.jpg', NULL, NULL, 'K', 'false'); 
INSERT INTO [dbo].[Artist] ([name], [country], [email], [homepage], [picture], [video], [description], [category], [deleted]) VALUES ('Fausto Giori', 'Italien', 'FaustoGiori@superrito.com', NULL, 'C:\Temp\assets\images\FaustoGiori150x100.jpg', NULL, NULL, 'A', 'false'); 
INSERT INTO [dbo].[Artist] ([name], [country], [email], [homepage], [picture], [video], [description], [category], [deleted]) VALUES ('Luca Bellezze', 'Italien', 'LucaBellezze@gustr.com', NULL, 'C:\Temp\assets\images\LucaBellezze150x100.jpg', NULL, NULL, 'L', 'false'); 
INSERT INTO [dbo].[Artist] ([name], [country], [email], [homepage], [picture], [video], [description], [category], [deleted]) VALUES ('Mattress Circus', 'Portugal', 'MattressCircus@gustr.com', NULL, 'C:\Temp\assets\images\MattressCircus150x100.jpg', NULL, NULL, 'A', 'false'); 
INSERT INTO [dbo].[Artist] ([name], [country], [email], [homepage], [picture], [video], [description], [category], [deleted]) VALUES ('Mute', 'Thailand', 'Mute@gustr.com', NULL, 'C:\Temp\assets\images\Mute150x100.jpg', NULL, NULL, 'K', 'false'); 
INSERT INTO [dbo].[Artist] ([name], [country], [email], [homepage], [picture], [video], [description], [category], [deleted]) VALUES ('Omnivolant', 'Deutschland', 'Omnivolant@fleckens.com', NULL, 'C:\Temp\assets\images\Omnivolant150x100.jpg', NULL, NULL, 'K', 'false'); 
INSERT INTO [dbo].[Artist] ([name], [country], [email], [homepage], [picture], [video], [description], [category], [deleted]) VALUES ('Secret Circus', 'Brasilien', 'SecretCircus@gustr.com', NULL, 'C:\Temp\assets\images\SecretCircus150x100.jpg', NULL, NULL, 'L', 'false'); 
INSERT INTO [dbo].[Artist] ([name], [country], [email], [homepage], [picture], [video], [description], [category], [deleted]) VALUES ('The Sideshow Charlatans', 'Deutschland', 'TheSideShowCharlatans@fleckens.com', NULL, 'C:\Temp\assets\images\TheSideShowCharlatans150x100.jpg', NULL, NULL, 'A', 'false'); 
INSERT INTO [dbo].[Artist] ([name], [country], [email], [homepage], [picture], [video], [description], [category], [deleted]) VALUES ('TON', 'Niederlande', 'Ton@fleckens.com', NULL, 'C:\Temp\assets\images\Ton150x100.jpg', NULL, NULL, 'M', 'false'); 
INSERT INTO [dbo].[Artist] ([name], [country], [email], [homepage], [picture], [video], [description], [category], [deleted]) VALUES ('Trinity', 'Chile', 'Trinity@fleckens.com', NULL, 'C:\Temp\assets\images\Trinity150x100.jpg', NULL, NULL, 'T', 'false'); 
INSERT INTO [dbo].[Artist] ([name], [country], [email], [homepage], [picture], [video], [description], [category], [deleted]) VALUES ('Benni Green', 'Italien', 'BenniGreen@fleckens.com', NULL, 'C:\Temp\assets\images\BenniGreen150x100.jpg', NULL, NULL, 'K', 'false'); 
INSERT INTO [dbo].[Artist] ([name], [country], [email], [homepage], [picture], [video], [description], [category], [deleted]) VALUES ('Les Contes Asphalt', 'Belgien', 'LesContesAsphalt@fleckens.com', NULL, 'C:\Temp\assets\images\LesContesAsphalt150x100.jpg', NULL, NULL, 'K', 'false'); 
INSERT INTO [dbo].[Artist] ([name], [country], [email], [homepage], [picture], [video], [description], [category], [deleted]) VALUES ('Lutrek Statues', 'Polen', 'LutrekStatues@gustr.com', NULL, 'C:\Temp\assets\images\LutrekStatues150x100.jpg', NULL, NULL, 'K', 'false'); 
INSERT INTO [dbo].[Artist] ([name], [country], [email], [homepage], [picture], [video], [description], [category], [deleted]) VALUES ('OAKLEAF Stelzenkunst', 'Deutschland', 'OakleafStelzenkunst@gustr.com', NULL, 'C:\Temp\assets\images\OakleafStelzenkunst150x100.jpg', NULL, NULL, 'K', 'false'); 
INSERT INTO [dbo].[Artist] ([name], [country], [email], [homepage], [picture], [video], [description], [category], [deleted]) VALUES ('The LEDies', 'Deutschland', 'TheLEDies@gustr.com', NULL, 'C:\Temp\assets\images\TheLEDies150x100.jpg', NULL, NULL, 'T', 'false'); 
INSERT INTO [dbo].[Artist] ([name], [country], [email], [homepage], [picture], [video], [description], [category], [deleted]) VALUES ('Urban Safari', 'Niederlande', 'UrbanSafari@gustr.com', NULL, 'C:\Temp\assets\images\UrbanSafari150x100.jpg', NULL, NULL, 'K', 'false'); 
INSERT INTO [dbo].[Artist] ([name], [country], [email], [homepage], [picture], [video], [description], [category], [deleted]) VALUES ('Barada Street', 'Großbritannien', 'BaradaStreet@armyspy.com', NULL, 'C:\Temp\assets\images\BaradaStreet150x100.jpg', NULL, NULL, 'M', 'false'); 
INSERT INTO [dbo].[Artist] ([name], [country], [email], [homepage], [picture], [video], [description], [category], [deleted]) VALUES ('Batucada Brass', 'Frankreich', 'BatucadaBrass@armyspy.com', NULL, 'C:\Temp\assets\images\BatucadaBrass150x100.jpg', NULL, NULL, 'T', 'false'); 
INSERT INTO [dbo].[Artist] ([name], [country], [email], [homepage], [picture], [video], [description], [category], [deleted]) VALUES ('Blechsalat', 'Österreich', 'Blechsalat@armyspy.com', NULL, 'C:\Temp\assets\images\Blechsalat150x100.jpg', NULL, NULL, 'M', 'false'); 
INSERT INTO [dbo].[Artist] ([name], [country], [email], [homepage], [picture], [video], [description], [category], [deleted]) VALUES ('ZagreB', 'Argentinien', 'ZagreB@armyspy.com', NULL, 'C:\Temp\assets\images\ZagreB150x100.jpg', NULL, NULL, 'M', 'false'); 
INSERT INTO [dbo].[Artist] ([name], [country], [email], [homepage], [picture], [video], [description], [category], [deleted]) VALUES ('Eco Commotion', 'Großbritannien', 'EcoCommotion@gustr.com', NULL, 'C:\Temp\assets\images\EcoCommotion150x100.jpg', NULL, NULL, 'M', 'false'); 
INSERT INTO [dbo].[Artist] ([name], [country], [email], [homepage], [picture], [video], [description], [category], [deleted]) VALUES ('Eric Tarantola', 'Frankreich', 'EricTarantola@gustr.com', NULL, 'C:\Temp\assets\images\EricTarantola150x100.jpg', NULL, NULL, 'M', 'false'); 
INSERT INTO [dbo].[Artist] ([name], [country], [email], [homepage], [picture], [video], [description], [category], [deleted]) VALUES ('folkshilfe', 'Österreich', 'folkshilfe@gustr.com', NULL, 'C:\Temp\assets\images\Folkshilfe150x100.jpg', NULL, NULL, 'M', 'false'); 
INSERT INTO [dbo].[Artist] ([name], [country], [email], [homepage], [picture], [video], [description], [category], [deleted]) VALUES ('Grande Cantagiro Barattoli', 'Italien', 'GrandeCantagiroBarattoli@gustr.com', NULL, 'C:\Temp\assets\images\GrandeCantagiroBarattoli150x100.jpg', NULL, NULL, 'M', 'false'); 
INSERT INTO [dbo].[Artist] ([name], [country], [email], [homepage], [picture], [video], [description], [category], [deleted]) VALUES ('JACKtheBUSCH', 'Österreich', 'JACKtheBUSCH@gustr.com', NULL, 'C:\Temp\assets\images\JackTheBusch150x100.jpg', NULL, NULL, 'M', 'false'); 
INSERT INTO [dbo].[Artist] ([name], [country], [email], [homepage], [picture], [video], [description], [category], [deleted]) VALUES ('Liederweib aus Berufung', 'Schweiz', 'LiederweibAusBerufung@gustr.com', NULL, 'C:\Temp\assets\images\LiederweibAusBerufung150x100.jpg', NULL, NULL, 'M', 'false'); 
INSERT INTO [dbo].[Artist] ([name], [country], [email], [homepage], [picture], [video], [description], [category], [deleted]) VALUES ('Matsumoto Zoku', 'Japan', 'MatsumotoZoku@gustr.com', NULL, 'C:\Temp\assets\images\MatsumotoZoku150x100.jpg', NULL, NULL, 'M', 'false'); 
INSERT INTO [dbo].[Artist] ([name], [country], [email], [homepage], [picture], [video], [description], [category], [deleted]) VALUES ('MiraMundo', 'Brasilien', 'MiraMundo@gustr.com', NULL, 'C:\Temp\assets\images\MiraMundo150x100.jpg', NULL, NULL, 'K', 'false'); 


INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160722 16:00', 1,   1, 'H');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160722 16:00', 2,   2, 'H');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160722 16:00', 3,   3, 'H');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160722 16:00', 4,   4, 'H');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160722 16:00', 5,   5, 'H');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160722 16:00', 6,   6, 'H');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160722 16:00', 7,   1, 'P');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160722 16:00', 8,   2, 'P');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160722 16:00', 9,   3, 'P');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160722 16:00', 10, 4, 'P');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160722 16:00', 11, 5, 'P');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160722 16:00', 12, 6, 'P');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160722 16:00', 13, 1, 'A');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160722 16:00', 14, 2, 'A');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160722 16:00', 15, 3, 'A');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160722 16:00', 16, 4, 'A');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160722 16:00', 17, 5, 'A');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160722 16:00', 18, 6, 'A');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160722 16:00', 19, 1, 'L');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160722 16:00', 20, 2, 'L');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160722 16:00', 21, 3, 'L');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160722 16:00', 22, 4, 'L');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160722 16:00', 23, 5, 'L');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160722 16:00', 24, 6, 'L');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160722 16:00', 25, 7, 'L');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160722 16:00', 26, 8, 'L');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160722 16:00', 27, 1, 'X');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160722 16:00', 28, 2, 'X');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160722 16:00', 29, 3, 'X');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160722 16:00', 30, 4, 'X');

INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160722 17:00', 31, 1, 'H');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160722 17:00', 32, 2, 'H');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160722 17:00', 33, 3, 'H');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160722 17:00', 34, 4, 'H');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160722 17:00', 35, 5, 'H');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160722 17:00', 36, 6, 'H');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160722 17:00', 37, 1, 'P');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160722 17:00', 38, 2, 'P');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160722 17:00', 39, 3, 'P');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160722 17:00', 40, 4, 'P');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160722 17:00', 41, 5, 'P');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160722 17:00', 42, 6, 'P');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160722 17:00', 43, 1, 'A');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160722 17:00', 44, 2, 'A');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160722 17:00', 45, 3, 'A');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160722 17:00', 46, 4, 'A');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160722 17:00', 47, 5, 'A');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160722 17:00', 48, 6, 'A');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160722 17:00', 49, 1, 'L');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160722 17:00', 50, 2, 'L');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160722 17:00', 51, 3, 'L');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160722 17:00', 52, 4, 'L');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160722 17:00', 53, 5, 'L');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160722 17:00', 54, 6, 'L');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160722 17:00', 55, 7, 'L');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160722 17:00', 56, 8, 'L');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160722 17:00', 57, 1, 'X');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160722 17:00', 58, 2, 'X');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160722 17:00', 59, 3, 'X');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160722 17:00', 60, 4, 'X');

INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160722 18:00', 1,   2, 'H');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160722 18:00', 2,   3, 'H');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160722 18:00', 3,   4, 'H');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160722 18:00', 4,   5, 'H');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160722 18:00', 5,   6, 'H');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160722 18:00', 6,   1, 'H');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160722 18:00', 7,   2, 'P');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160722 18:00', 8,   3, 'P');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160722 18:00', 9,   4, 'P');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160722 18:00', 10, 5, 'P');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160722 18:00', 11, 6, 'P');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160722 18:00', 12, 1, 'P');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160722 18:00', 13, 2, 'A');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160722 18:00', 14, 3, 'A');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160722 18:00', 15, 4, 'A');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160722 18:00', 16, 5, 'A');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160722 18:00', 17, 6, 'A');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160722 18:00', 18, 1, 'A');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160722 18:00', 19, 2, 'L');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160722 18:00', 20, 3, 'L');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160722 18:00', 21, 4, 'L');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160722 18:00', 22, 5, 'L');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160722 18:00', 23, 6, 'L');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160722 18:00', 24, 7, 'L');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160722 18:00', 25, 8, 'L');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160722 18:00', 26, 1, 'L');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160722 18:00', 27, 2, 'X');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160722 18:00', 28, 3, 'X');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160722 18:00', 29, 4, 'X');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160722 18:00', 30, 1, 'X');

INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160722 19:00', 31, 2, 'H');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160722 19:00', 32, 3, 'H');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160722 19:00', 33, 4, 'H');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160722 19:00', 34, 5, 'H');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160722 19:00', 35, 6, 'H');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160722 19:00', 36, 1, 'H');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160722 19:00', 37, 2, 'P');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160722 19:00', 38, 3, 'P');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160722 19:00', 39, 4, 'P');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160722 19:00', 40, 5, 'P');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160722 19:00', 41, 6, 'P');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160722 19:00', 42, 1, 'P');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160722 19:00', 43, 2, 'A');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160722 19:00', 44, 3, 'A');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160722 19:00', 45, 4, 'A');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160722 19:00', 46, 5, 'A');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160722 19:00', 47, 6, 'A');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160722 19:00', 48, 1, 'A');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160722 19:00', 49, 2, 'L');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160722 19:00', 50, 3, 'L');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160722 19:00', 51, 4, 'L');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160722 19:00', 52, 5, 'L');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160722 19:00', 53, 6, 'L');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160722 19:00', 54, 7, 'L');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160722 19:00', 55, 8, 'L');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160722 19:00', 56, 1, 'L');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160722 19:00', 57, 2, 'X');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160722 19:00', 58, 3, 'X');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160722 19:00', 59, 4, 'X');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160722 19:00', 60, 1, 'X');

INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160722 20:00', 1,   3, 'H');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160722 20:00', 2,   4, 'H');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160722 20:00', 3,   5, 'H');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160722 20:00', 4,   6, 'H');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160722 20:00', 5,   1, 'H');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160722 20:00', 6,   2, 'H');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160722 20:00', 7,   3, 'P');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160722 20:00', 8,   4, 'P');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160722 20:00', 9,   5, 'P');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160722 20:00', 10, 6, 'P');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160722 20:00', 11, 1, 'P');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160722 20:00', 12, 2, 'P');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160722 20:00', 13, 3, 'A');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160722 20:00', 14, 4, 'A');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160722 20:00', 15, 5, 'A');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160722 20:00', 16, 6, 'A');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160722 20:00', 17, 1, 'A');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160722 20:00', 18, 2, 'A');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160722 20:00', 19, 3, 'L');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160722 20:00', 20, 4, 'L');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160722 20:00', 21, 5, 'L');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160722 20:00', 22, 6, 'L');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160722 20:00', 23, 7, 'L');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160722 20:00', 24, 8, 'L');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160722 20:00', 25, 1, 'L');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160722 20:00', 26, 2, 'L');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160722 20:00', 27, 3, 'X');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160722 20:00', 28, 4, 'X');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160722 20:00', 29, 1, 'X');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160722 20:00', 30, 2, 'X');

INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160722 21:00', 31, 3, 'H');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160722 21:00', 32, 4, 'H');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160722 21:00', 33, 5, 'H');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160722 21:00', 34, 6, 'H');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160722 21:00', 35, 1, 'H');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160722 21:00', 36, 2, 'H');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160722 21:00', 37, 3, 'P');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160722 21:00', 38, 4, 'P');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160722 21:00', 39, 5, 'P');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160722 21:00', 40, 6, 'P');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160722 21:00', 41, 1, 'P');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160722 21:00', 42, 2, 'P');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160722 21:00', 43, 3, 'A');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160722 21:00', 44, 4, 'A');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160722 21:00', 45, 5, 'A');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160722 21:00', 46, 6, 'A');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160722 21:00', 47, 1, 'A');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160722 21:00', 48, 2, 'A');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160722 21:00', 49, 3, 'L');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160722 21:00', 50, 4, 'L');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160722 21:00', 51, 5, 'L');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160722 21:00', 52, 6, 'L');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160722 21:00', 53, 7, 'L');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160722 21:00', 54, 8, 'L');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160722 21:00', 55, 1, 'L');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160722 21:00', 56, 2, 'L');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160722 21:00', 57, 3, 'X');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160722 21:00', 58, 4, 'X');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160722 21:00', 59, 1, 'X');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160722 21:00', 60, 2, 'X');

INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160722 22:00', 1,   4, 'H');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160722 22:00', 2,   5, 'H');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160722 22:00', 3,   6, 'H');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160722 22:00', 4,   1, 'H');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160722 22:00', 5,   2, 'H');

INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160722 22:00', 7,   4, 'P');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160722 22:00', 8,   5, 'P');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160722 22:00', 9,   6, 'P');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160722 22:00', 10, 1, 'P');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160722 22:00', 11, 2, 'P');

INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160722 22:00', 13, 4, 'A');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160722 22:00', 14, 5, 'A');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160722 22:00', 15, 6, 'A');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160722 22:00', 16, 1, 'A');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160722 22:00', 17, 2, 'A');

INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160722 22:00', 19, 4, 'L');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160722 22:00', 20, 5, 'L');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160722 22:00', 22, 7, 'L');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160722 22:00', 23, 8, 'L');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160722 22:00', 24, 1, 'L');



INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160723 16:00', 1,   1, 'H');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160723 16:00', 2,   2, 'H');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160723 16:00', 3,   3, 'H');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160723 16:00', 4,   4, 'H');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160723 16:00', 5,   5, 'H');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160723 16:00', 6,   6, 'H');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160723 16:00', 7,   1, 'P');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160723 16:00', 8,   2, 'P');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160723 16:00', 9,   3, 'P');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160723 16:00', 10, 4, 'P');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160723 16:00', 11, 5, 'P');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160723 16:00', 12, 6, 'P');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160723 16:00', 13, 1, 'A');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160723 16:00', 14, 2, 'A');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160723 16:00', 15, 3, 'A');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160723 16:00', 16, 4, 'A');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160723 16:00', 17, 5, 'A');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160723 16:00', 18, 6, 'A');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160723 16:00', 19, 1, 'L');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160723 16:00', 20, 2, 'L');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160723 16:00', 21, 3, 'L');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160723 16:00', 22, 4, 'L');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160723 16:00', 23, 5, 'L');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160723 16:00', 24, 6, 'L');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160723 16:00', 25, 7, 'L');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160723 16:00', 26, 8, 'L');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160723 16:00', 27, 1, 'X');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160723 16:00', 28, 2, 'X');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160723 16:00', 29, 3, 'X');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160723 16:00', 30, 4, 'X');

INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160723 17:00', 31, 1, 'H');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160723 17:00', 32, 2, 'H');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160723 17:00', 33, 3, 'H');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160723 17:00', 34, 4, 'H');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160723 17:00', 35, 5, 'H');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160723 17:00', 36, 6, 'H');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160723 17:00', 37, 1, 'P');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160723 17:00', 38, 2, 'P');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160723 17:00', 39, 3, 'P');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160723 17:00', 40, 4, 'P');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160723 17:00', 41, 5, 'P');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160723 17:00', 42, 6, 'P');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160723 17:00', 43, 1, 'A');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160723 17:00', 44, 2, 'A');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160723 17:00', 45, 3, 'A');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160723 17:00', 46, 4, 'A');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160723 17:00', 47, 5, 'A');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160723 17:00', 48, 6, 'A');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160723 17:00', 49, 1, 'L');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160723 17:00', 50, 2, 'L');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160723 17:00', 51, 3, 'L');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160723 17:00', 52, 4, 'L');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160723 17:00', 53, 5, 'L');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160723 17:00', 54, 6, 'L');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160723 17:00', 55, 7, 'L');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160723 17:00', 56, 8, 'L');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160723 17:00', 57, 1, 'X');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160723 17:00', 58, 2, 'X');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160723 17:00', 59, 3, 'X');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160723 17:00', 60, 4, 'X');

INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160723 18:00', 1,   2, 'H');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160723 18:00', 2,   3, 'H');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160723 18:00', 3,   4, 'H');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160723 18:00', 4,   5, 'H');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160723 18:00', 5,   6, 'H');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160723 18:00', 6,   1, 'H');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160723 18:00', 7,   2, 'P');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160723 18:00', 8,   3, 'P');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160723 18:00', 9,   4, 'P');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160723 18:00', 10, 5, 'P');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160723 18:00', 11, 6, 'P');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160723 18:00', 12, 1, 'P');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160723 18:00', 13, 2, 'A');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160723 18:00', 14, 3, 'A');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160723 18:00', 15, 4, 'A');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160723 18:00', 16, 5, 'A');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160723 18:00', 17, 6, 'A');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160723 18:00', 18, 1, 'A');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160723 18:00', 19, 2, 'L');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160723 18:00', 20, 3, 'L');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160723 18:00', 21, 4, 'L');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160723 18:00', 22, 5, 'L');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160723 18:00', 23, 6, 'L');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160723 18:00', 24, 7, 'L');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160723 18:00', 25, 8, 'L');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160723 18:00', 26, 1, 'L');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160723 18:00', 27, 2, 'X');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160723 18:00', 28, 3, 'X');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160723 18:00', 29, 4, 'X');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160723 18:00', 30, 1, 'X');

INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160723 19:00', 31, 2, 'H');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160723 19:00', 32, 3, 'H');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160723 19:00', 33, 4, 'H');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160723 19:00', 34, 5, 'H');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160723 19:00', 35, 6, 'H');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160723 19:00', 36, 1, 'H');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160723 19:00', 37, 2, 'P');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160723 19:00', 38, 3, 'P');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160723 19:00', 39, 4, 'P');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160723 19:00', 40, 5, 'P');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160723 19:00', 41, 6, 'P');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160723 19:00', 42, 1, 'P');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160723 19:00', 43, 2, 'A');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160723 19:00', 44, 3, 'A');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160723 19:00', 45, 4, 'A');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160723 19:00', 46, 5, 'A');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160723 19:00', 47, 6, 'A');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160723 19:00', 48, 1, 'A');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160723 19:00', 49, 2, 'L');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160723 19:00', 50, 3, 'L');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160723 19:00', 51, 4, 'L');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160723 19:00', 52, 5, 'L');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160723 19:00', 53, 6, 'L');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160723 19:00', 54, 7, 'L');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160723 19:00', 55, 8, 'L');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160723 19:00', 56, 1, 'L');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160723 19:00', 57, 2, 'X');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160723 19:00', 58, 3, 'X');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160723 19:00', 59, 4, 'X');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160723 19:00', 60, 1, 'X');

INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160723 20:00', 1,   3, 'H');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160723 20:00', 2,   4, 'H');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160723 20:00', 3,   5, 'H');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160723 20:00', 4,   6, 'H');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160723 20:00', 5,   1, 'H');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160723 20:00', 6,   2, 'H');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160723 20:00', 7,   3, 'P');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160723 20:00', 8,   4, 'P');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160723 20:00', 9,   5, 'P');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160723 20:00', 10, 6, 'P');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160723 20:00', 11, 1, 'P');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160723 20:00', 12, 2, 'P');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160723 20:00', 13, 3, 'A');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160723 20:00', 14, 4, 'A');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160723 20:00', 15, 5, 'A');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160723 20:00', 16, 6, 'A');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160723 20:00', 17, 1, 'A');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160723 20:00', 18, 2, 'A');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160723 20:00', 19, 3, 'L');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160723 20:00', 20, 4, 'L');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160723 20:00', 21, 5, 'L');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160723 20:00', 22, 6, 'L');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160723 20:00', 23, 7, 'L');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160723 20:00', 24, 8, 'L');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160723 20:00', 25, 1, 'L');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160723 20:00', 26, 2, 'L');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160723 20:00', 27, 3, 'X');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160723 20:00', 28, 4, 'X');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160723 20:00', 29, 1, 'X');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160723 20:00', 30, 2, 'X');

INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160723 21:00', 31, 3, 'H');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160723 21:00', 32, 4, 'H');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160723 21:00', 33, 5, 'H');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160723 21:00', 34, 6, 'H');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160723 21:00', 35, 1, 'H');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160723 21:00', 36, 2, 'H');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160723 21:00', 37, 3, 'P');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160723 21:00', 38, 4, 'P');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160723 21:00', 39, 5, 'P');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160723 21:00', 40, 6, 'P');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160723 21:00', 41, 1, 'P');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160723 21:00', 42, 2, 'P');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160723 21:00', 43, 3, 'A');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160723 21:00', 44, 4, 'A');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160723 21:00', 45, 5, 'A');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160723 21:00', 46, 6, 'A');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160723 21:00', 47, 1, 'A');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160723 21:00', 48, 2, 'A');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160723 21:00', 49, 3, 'L');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160723 21:00', 50, 4, 'L');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160723 21:00', 51, 5, 'L');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160723 21:00', 52, 6, 'L');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160723 21:00', 53, 7, 'L');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160723 21:00', 54, 8, 'L');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160723 21:00', 55, 1, 'L');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160723 21:00', 56, 2, 'L');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160723 21:00', 57, 3, 'X');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160723 21:00', 58, 4, 'X');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160723 21:00', 59, 1, 'X');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160723 21:00', 60, 2, 'X');

INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160723 22:00', 1,   4, 'H');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160723 22:00', 2,   5, 'H');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160723 22:00', 3,   6, 'H');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160723 22:00', 4,   1, 'H');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160723 22:00', 5,   2, 'H');

INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160723 22:00', 7,   4, 'P');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160723 22:00', 8,   5, 'P');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160723 22:00', 9,   6, 'P');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160723 22:00', 10, 1, 'P');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160723 22:00', 11, 2, 'P');

INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160723 22:00', 13, 4, 'A');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160723 22:00', 14, 5, 'A');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160723 22:00', 15, 6, 'A');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160723 22:00', 16, 1, 'A');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160723 22:00', 17, 2, 'A');

INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160723 22:00', 19, 4, 'L');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160723 22:00', 20, 5, 'L');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160723 22:00', 22, 7, 'L');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160723 22:00', 23, 8, 'L');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160723 22:00', 24, 1, 'L');



INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160724 16:00', 1,   1, 'H');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160724 16:00', 2,   2, 'H');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160724 16:00', 3,   3, 'H');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160724 16:00', 4,   4, 'H');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160724 16:00', 5,   5, 'H');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160724 16:00', 6,   6, 'H');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160724 16:00', 7,   1, 'P');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160724 16:00', 8,   2, 'P');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160724 16:00', 9,   3, 'P');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160724 16:00', 10, 4, 'P');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160724 16:00', 11, 5, 'P');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160724 16:00', 12, 6, 'P');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160724 16:00', 13, 1, 'A');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160724 16:00', 14, 2, 'A');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160724 16:00', 15, 3, 'A');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160724 16:00', 16, 4, 'A');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160724 16:00', 17, 5, 'A');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160724 16:00', 18, 6, 'A');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160724 16:00', 19, 1, 'L');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160724 16:00', 20, 2, 'L');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160724 16:00', 21, 3, 'L');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160724 16:00', 22, 4, 'L');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160724 16:00', 23, 5, 'L');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160724 16:00', 24, 6, 'L');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160724 16:00', 25, 7, 'L');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160724 16:00', 26, 8, 'L');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160724 16:00', 27, 1, 'X');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160724 16:00', 28, 2, 'X');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160724 16:00', 29, 3, 'X');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160724 16:00', 30, 4, 'X');

INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160724 17:00', 31, 1, 'H');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160724 17:00', 32, 2, 'H');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160724 17:00', 33, 3, 'H');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160724 17:00', 34, 4, 'H');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160724 17:00', 35, 5, 'H');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160724 17:00', 36, 6, 'H');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160724 17:00', 37, 1, 'P');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160724 17:00', 38, 2, 'P');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160724 17:00', 39, 3, 'P');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160724 17:00', 40, 4, 'P');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160724 17:00', 41, 5, 'P');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160724 17:00', 42, 6, 'P');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160724 17:00', 43, 1, 'A');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160724 17:00', 44, 2, 'A');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160724 17:00', 45, 3, 'A');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160724 17:00', 46, 4, 'A');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160724 17:00', 47, 5, 'A');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160724 17:00', 48, 6, 'A');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160724 17:00', 49, 1, 'L');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160724 17:00', 50, 2, 'L');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160724 17:00', 51, 3, 'L');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160724 17:00', 52, 4, 'L');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160724 17:00', 53, 5, 'L');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160724 17:00', 54, 6, 'L');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160724 17:00', 55, 7, 'L');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160724 17:00', 56, 8, 'L');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160724 17:00', 57, 1, 'X');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160724 17:00', 58, 2, 'X');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160724 17:00', 59, 3, 'X');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160724 17:00', 60, 4, 'X');

INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160724 18:00', 1,   2, 'H');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160724 18:00', 2,   3, 'H');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160724 18:00', 3,   4, 'H');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160724 18:00', 4,   5, 'H');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160724 18:00', 5,   6, 'H');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160724 18:00', 6,   1, 'H');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160724 18:00', 7,   2, 'P');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160724 18:00', 8,   3, 'P');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160724 18:00', 9,   4, 'P');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160724 18:00', 10, 5, 'P');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160724 18:00', 11, 6, 'P');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160724 18:00', 12, 1, 'P');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160724 18:00', 13, 2, 'A');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160724 18:00', 14, 3, 'A');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160724 18:00', 15, 4, 'A');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160724 18:00', 16, 5, 'A');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160724 18:00', 17, 6, 'A');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160724 18:00', 18, 1, 'A');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160724 18:00', 19, 2, 'L');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160724 18:00', 20, 3, 'L');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160724 18:00', 21, 4, 'L');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160724 18:00', 22, 5, 'L');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160724 18:00', 23, 6, 'L');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160724 18:00', 24, 7, 'L');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160724 18:00', 25, 8, 'L');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160724 18:00', 26, 1, 'L');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160724 18:00', 27, 2, 'X');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160724 18:00', 28, 3, 'X');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160724 18:00', 29, 4, 'X');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160724 18:00', 30, 1, 'X');

INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160724 19:00', 31, 2, 'H');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160724 19:00', 32, 3, 'H');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160724 19:00', 33, 4, 'H');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160724 19:00', 34, 5, 'H');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160724 19:00', 35, 6, 'H');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160724 19:00', 36, 1, 'H');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160724 19:00', 37, 2, 'P');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160724 19:00', 38, 3, 'P');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160724 19:00', 39, 4, 'P');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160724 19:00', 40, 5, 'P');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160724 19:00', 41, 6, 'P');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160724 19:00', 42, 1, 'P');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160724 19:00', 43, 2, 'A');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160724 19:00', 44, 3, 'A');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160724 19:00', 45, 4, 'A');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160724 19:00', 46, 5, 'A');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160724 19:00', 47, 6, 'A');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160724 19:00', 48, 1, 'A');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160724 19:00', 49, 2, 'L');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160724 19:00', 50, 3, 'L');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160724 19:00', 51, 4, 'L');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160724 19:00', 52, 5, 'L');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160724 19:00', 53, 6, 'L');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160724 19:00', 54, 7, 'L');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160724 19:00', 55, 8, 'L');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160724 19:00', 56, 1, 'L');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160724 19:00', 57, 2, 'X');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160724 19:00', 58, 3, 'X');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160724 19:00', 59, 4, 'X');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160724 19:00', 60, 1, 'X');

INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160724 20:00', 1,   3, 'H');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160724 20:00', 2,   4, 'H');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160724 20:00', 3,   5, 'H');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160724 20:00', 4,   6, 'H');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160724 20:00', 5,   1, 'H');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160724 20:00', 6,   2, 'H');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160724 20:00', 7,   3, 'P');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160724 20:00', 8,   4, 'P');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160724 20:00', 9,   5, 'P');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160724 20:00', 10, 6, 'P');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160724 20:00', 11, 1, 'P');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160724 20:00', 12, 2, 'P');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160724 20:00', 13, 3, 'A');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160724 20:00', 14, 4, 'A');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160724 20:00', 15, 5, 'A');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160724 20:00', 16, 6, 'A');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160724 20:00', 17, 1, 'A');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160724 20:00', 18, 2, 'A');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160724 20:00', 19, 3, 'L');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160724 20:00', 20, 4, 'L');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160724 20:00', 21, 5, 'L');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160724 20:00', 22, 6, 'L');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160724 20:00', 23, 7, 'L');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160724 20:00', 24, 8, 'L');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160724 20:00', 25, 1, 'L');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160724 20:00', 26, 2, 'L');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160724 20:00', 27, 3, 'X');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160724 20:00', 28, 4, 'X');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160724 20:00', 29, 1, 'X');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160724 20:00', 30, 2, 'X');

INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160724 21:00', 31, 3, 'H');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160724 21:00', 32, 4, 'H');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160724 21:00', 33, 5, 'H');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160724 21:00', 34, 6, 'H');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160724 21:00', 35, 1, 'H');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160724 21:00', 36, 2, 'H');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160724 21:00', 37, 3, 'P');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160724 21:00', 38, 4, 'P');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160724 21:00', 39, 5, 'P');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160724 21:00', 40, 6, 'P');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160724 21:00', 41, 1, 'P');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160724 21:00', 42, 2, 'P');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160724 21:00', 43, 3, 'A');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160724 21:00', 44, 4, 'A');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160724 21:00', 45, 5, 'A');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160724 21:00', 46, 6, 'A');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160724 21:00', 47, 1, 'A');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160724 21:00', 48, 2, 'A');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160724 21:00', 49, 3, 'L');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160724 21:00', 50, 4, 'L');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160724 21:00', 51, 5, 'L');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160724 21:00', 52, 6, 'L');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160724 21:00', 53, 7, 'L');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160724 21:00', 54, 8, 'L');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160724 21:00', 55, 1, 'L');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160724 21:00', 56, 2, 'L');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160724 21:00', 57, 3, 'X');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160724 21:00', 58, 4, 'X');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160724 21:00', 59, 1, 'X');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160724 21:00', 60, 2, 'X');

INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160724 22:00', 1,   4, 'H');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160724 22:00', 2,   5, 'H');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160724 22:00', 3,   6, 'H');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160724 22:00', 4,   1, 'H');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160724 22:00', 5,   2, 'H');

INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160724 22:00', 7,   4, 'P');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160724 22:00', 8,   5, 'P');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160724 22:00', 9,   6, 'P');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160724 22:00', 10, 1, 'P');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160724 22:00', 11, 2, 'P');

INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160724 22:00', 13, 4, 'A');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160724 22:00', 14, 5, 'A');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160724 22:00', 15, 6, 'A');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160724 22:00', 16, 1, 'A');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160724 22:00', 17, 2, 'A');

INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160724 22:00', 19, 4, 'L');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160724 22:00', 20, 5, 'L');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160724 22:00', 22, 7, 'L');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160724 22:00', 23, 8, 'L');
INSERT INTO [dbo].[Performance] ([start], [artist], [pVenue], [pLocation]) VALUES ('20160724 22:00', 24, 1, 'L');

