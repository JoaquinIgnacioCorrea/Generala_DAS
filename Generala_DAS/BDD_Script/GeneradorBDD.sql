USE [Generala]
GO
/****** Objeto: Table [dbo].[Jugadas] Fecha de script: 10/11/2026 20:11:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Jugadas](
	[id_jugador] [int] NOT NULL,
	[hora] [datetime] NOT NULL,
	[puntaje] [int] NOT NULL,
	[id_jugada] [int] NOT NULL,
	[categoria] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Jugadas] PRIMARY KEY CLUSTERED 
(
	[id_jugada] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Objeto: Table [dbo].[Jugador] Fecha de script: 10/11/2026 20:11:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Jugador](
	[id_jugador] [int] NOT NULL,
	[nombre] [varchar](50) NOT NULL,
	[id_usuario] [int] NOT NULL,
 CONSTRAINT [PK_Jugador] PRIMARY KEY CLUSTERED 
(
	[id_jugador] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Objeto: Table [dbo].[JugadorXPartida] Fecha de script: 10/11/2026 20:11:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[JugadorXPartida](
	[id_jugador] [int] NOT NULL,
	[id_partida] [int] NOT NULL,
	[puntaje] [int] NOT NULL,
	[resultado] [varchar](50) NOT NULL
) ON [PRIMARY]
GO
/****** Objeto: Table [dbo].[Partida] Fecha de script: 10/11/2026 20:11:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Partida](
	[id_partida] [int] NOT NULL,
	[jugador_actual] [int] NOT NULL,
	[ganador] [int] NOT NULL,
	[fecha_partida] [datetime] NOT NULL,
	[tiempo_partida] [time](7) NOT NULL,
 CONSTRAINT [PK_Partida] PRIMARY KEY CLUSTERED 
(
	[id_partida] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Jugadas]  WITH CHECK ADD  CONSTRAINT [FK_Jugadas_Jugador] FOREIGN KEY([id_jugador])
REFERENCES [dbo].[Jugador] ([id_jugador])
GO
ALTER TABLE [dbo].[Jugadas] CHECK CONSTRAINT [FK_Jugadas_Jugador]
GO
ALTER TABLE [dbo].[JugadorXPartida]  WITH CHECK ADD  CONSTRAINT [FK_JugadorXPartida_Jugador] FOREIGN KEY([id_jugador])
REFERENCES [dbo].[Jugador] ([id_jugador])
GO
ALTER TABLE [dbo].[JugadorXPartida] CHECK CONSTRAINT [FK_JugadorXPartida_Jugador]
GO
ALTER TABLE [dbo].[JugadorXPartida]  WITH CHECK ADD  CONSTRAINT [FK_JugadorXPartida_Partida] FOREIGN KEY([id_partida])
REFERENCES [dbo].[Partida] ([id_partida])
GO
ALTER TABLE [dbo].[JugadorXPartida] CHECK CONSTRAINT [FK_JugadorXPartida_Partida]
GO
USE [master]
GO
ALTER DATABASE [Generala] SET  READ_WRITE 
GO
