# Query Tabelle
## Tabella Articolo
USE [Pizzeria]
GO

/****** Object:  Table [dbo].[Articolo]    Script Date: 15/03/2024 14:04:52 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Articolo](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [nvarchar](50) NOT NULL,
	[Foto] [nvarchar](max) NOT NULL,
	[Prezzo] [money] NOT NULL,
	[TempoConsegna] [int] NOT NULL,
	[Ingredienti] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Articolo] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

## Tabella Dettaglio
USE [Pizzeria]
GO

/****** Object:  Table [dbo].[Dettaglio]    Script Date: 15/03/2024 14:05:30 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Dettaglio](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[OrdineId] [int] NOT NULL,
	[ArticoloId] [int] NOT NULL,
	[Quantità] [int] NOT NULL,
 CONSTRAINT [PK_Dettaglio] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Dettaglio]  WITH CHECK ADD  CONSTRAINT [FK_Dettaglio_Articolo] FOREIGN KEY([ArticoloId])
REFERENCES [dbo].[Articolo] ([Id])
GO

ALTER TABLE [dbo].[Dettaglio] CHECK CONSTRAINT [FK_Dettaglio_Articolo]
GO

ALTER TABLE [dbo].[Dettaglio]  WITH CHECK ADD  CONSTRAINT [FK_Dettaglio_Ordinazione] FOREIGN KEY([OrdineId])
REFERENCES [dbo].[Ordinazione] ([Id])
GO

ALTER TABLE [dbo].[Dettaglio] CHECK CONSTRAINT [FK_Dettaglio_Ordinazione]
GO

## Tabella Ordinazione
USE [Pizzeria]
GO

/****** Object:  Table [dbo].[Ordinazione]    Script Date: 15/03/2024 14:05:56 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Ordinazione](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[Indirizzo] [nvarchar](50) NOT NULL,
	[Note] [nvarchar](max) NOT NULL,
	[Totale] [money] NOT NULL,
	[Evaso] [bit] NOT NULL,
 CONSTRAINT [PK_Ordinazione] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [dbo].[Ordinazione]  WITH CHECK ADD  CONSTRAINT [FK_Ordinazione_User] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([Id])
GO

ALTER TABLE [dbo].[Ordinazione] CHECK CONSTRAINT [FK_Ordinazione_User]
GO

## Tabella User
USE [Pizzeria]
GO

/****** Object:  Table [dbo].[User]    Script Date: 15/03/2024 14:06:11 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[User](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Username] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
	[Ruolo] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
