USE [Generala]
GO
/****** Objeto: Table [dbo].[Jugadas] Fecha de script: 12/11/2026 20:42:26 ******/
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
	[id_partida] [int] NOT NULL,
 CONSTRAINT [PK_Jugadas] PRIMARY KEY CLUSTERED 
(
	[id_jugada] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Objeto: Table [dbo].[Jugador] Fecha de script: 12/11/2026 20:42:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Jugador](
	[id_jugador] [int] NOT NULL,
	[nombre] [varchar](50) NOT NULL,
	[contraseña] [nchar](10) NOT NULL,
 CONSTRAINT [PK_Jugador] PRIMARY KEY CLUSTERED 
(
	[id_jugador] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Objeto: Table [dbo].[JugadorXPartida] Fecha de script: 12/11/2026 20:42:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[JugadorXPartida](
	[id_jugador] [int] NOT NULL,
	[id_partida] [int] NOT NULL,
	[puntaje_total] [int] NOT NULL,
	[resultado] [varchar](50) NOT NULL
) ON [PRIMARY]
GO
/****** Objeto: Table [dbo].[Partida] Fecha de script: 12/11/2026 20:42:27 ******/
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
ALTER TABLE [dbo].[Jugadas]  WITH CHECK ADD  CONSTRAINT [FK_Jugadas_Partida] FOREIGN KEY([id_partida])
REFERENCES [dbo].[Partida] ([id_partida])
GO
ALTER TABLE [dbo].[Jugadas] CHECK CONSTRAINT [FK_Jugadas_Partida]
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
/****** Objeto: StoredProcedure [dbo].[actualizar_jugadorxpartida] Fecha de script: 12/11/2026 20:42:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- 2. Actualizar puntaje y resultado al finalizar la partida
CREATE PROC [dbo].[actualizar_jugadorxpartida]
    @id_partida INT,
    @id_jugador INT,
    @puntaje_total INT,
    @resultado VARCHAR(50)
AS
BEGIN
    UPDATE JugadorXPartida 
    SET puntaje_total = @puntaje_total,
        resultado = @resultado
    WHERE id_partida = @id_partida AND id_jugador = @id_jugador
END
GO
/****** Objeto: StoredProcedure [dbo].[borrar_jugador] Fecha de script: 12/11/2026 20:42:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- 3. Borrar Jugador
CREATE PROC [dbo].[borrar_jugador]
    @id_jugador INT
AS
BEGIN
    DELETE FROM Jugador 
    WHERE id_jugador = @id_jugador
END
GO
/****** Objeto: StoredProcedure [dbo].[borrar_jugadorxpartida] Fecha de script: 12/11/2026 20:42:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- 3. Borrar por partida
CREATE PROC [dbo].[borrar_jugadorxpartida]
    @id_partida INT
AS
BEGIN
    DELETE FROM JugadorXPartida 
    WHERE id_partida = @id_partida
END
GO
/****** Objeto: StoredProcedure [dbo].[borrar_partida] Fecha de script: 12/11/2026 20:42:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[borrar_partida]
    @id_partida INT
AS
BEGIN
    DELETE FROM Partida 
    WHERE id_partida = @id_partida
END
GO
/****** Objeto: StoredProcedure [dbo].[editar_jugador] Fecha de script: 12/11/2026 20:42:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- 2. Editar Jugador
CREATE PROC [dbo].[editar_jugador]
    @id_jugador INT,
    @nombre VARCHAR(50)
AS
BEGIN
    UPDATE Jugador 
    SET nombre = @nombre
    WHERE id_jugador = @id_jugador
END
GO
/****** Objeto: StoredProcedure [dbo].[editar_partida] Fecha de script: 12/11/2026 20:42:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[editar_partida]
    @id_partida INT,
    @jugador_actual INT,
    @ganador INT,
    @tiempo_partida TIME(7)
AS
BEGIN
    UPDATE Partida 
    SET jugador_actual = @jugador_actual,
        ganador = @ganador,
        tiempo_partida = @tiempo_partida
    WHERE id_partida = @id_partida
END
GO
/****** Objeto: StoredProcedure [dbo].[insertar_jugador] Fecha de script: 12/11/2026 20:42:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- 1. Insertar Jugador
CREATE PROC [dbo].[insertar_jugador]
    @nombre VARCHAR(50)
AS
BEGIN
    INSERT INTO Jugador (nombre)
    VALUES (@nombre)
END
GO
/****** Objeto: StoredProcedure [dbo].[insertar_jugadorxpartida] Fecha de script: 12/11/2026 20:42:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- 1. Insertar asociación inicial
CREATE PROC [dbo].[insertar_jugadorxpartida]
    @id_partida INT,
    @id_jugador INT,
    @puntaje_total INT,
    @resultado VARCHAR(50)
AS
BEGIN
    INSERT INTO JugadorXPartida (id_partida, id_jugador, puntaje_total, resultado)
    VALUES (@id_partida, @id_jugador, @puntaje_total, @resultado)
END
GO
/****** Objeto: StoredProcedure [dbo].[insertar_partida] Fecha de script: 12/11/2026 20:42:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[insertar_partida]
    @jugador_actual INT,
    @ganador INT,
    @fecha_partida DATETIME,
    @tiempo_partida TIME(7)
AS
BEGIN
    INSERT INTO Partida (jugador_actual, ganador, fecha_partida, tiempo_partida)
    VALUES (@jugador_actual, @ganador, @fecha_partida, @tiempo_partida)
END
GO
/****** Objeto: StoredProcedure [dbo].[listar_detalles_por_partida] Fecha de script: 12/11/2026 20:42:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- 5. Listar todos los detalles de una partida (para la pantalla de resultados finales)
CREATE PROC [dbo].[listar_detalles_por_partida]
    @id_partida INT
AS
BEGIN
    SELECT j.nombre AS nombre_jugador, jxp.puntaje_total, jxp.resultado
    FROM JugadorXPartida jxp
    INNER JOIN Jugador j ON jxp.id_jugador = j.id_jugador
    WHERE jxp.id_partida = @id_partida
END
GO
/****** Objeto: StoredProcedure [dbo].[listar_partidas_usuario] Fecha de script: 12/11/2026 20:42:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[listar_partidas_usuario]
    @id_usuario INT
AS
BEGIN
    SELECT 
        p.id_partida, 
        p.jugador_actual, 
        p.ganador, 
        p.fecha_partida, 
        p.tiempo_partida
    FROM Partida p
    INNER JOIN JugadorXPartida jxp ON p.id_partida = jxp.id_partida
    INNER JOIN Jugador j ON jxp.id_jugador = j.id_jugador
    WHERE j.id_usuario = @id_usuario
END
GO
/****** Objeto: StoredProcedure [dbo].[listar_todos_jugadores] Fecha de script: 12/11/2026 20:42:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- 5. Listar Todos los Jugadores
CREATE PROC [dbo].[listar_todos_jugadores]
AS
BEGIN
    SELECT id_jugador, nombre 
    FROM Jugador
END
GO
/****** Objeto: StoredProcedure [dbo].[obtener_detalle_jugador_partida] Fecha de script: 12/11/2026 20:42:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- 4. Obtener detalle de un jugador en una partida específica
CREATE PROC [dbo].[obtener_detalle_jugador_partida]
    @id_partida INT,
    @id_jugador INT
AS
BEGIN
    SELECT puntaje_total, resultado 
    FROM JugadorXPartida 
    WHERE id_partida = @id_partida AND id_jugador = @id_jugador
END
GO
/****** Objeto: StoredProcedure [dbo].[obtener_jugador_por_id] Fecha de script: 12/11/2026 20:42:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- 4. Obtener Jugador por ID
CREATE PROC [dbo].[obtener_jugador_por_id]
    @id_jugador INT
AS
BEGIN
    SELECT id_jugador, nombre 
    FROM Jugador 
    WHERE id_jugador = @id_jugador
END
GO
/****** Objeto: StoredProcedure [dbo].[obtener_partida_en_juego_por_usuario] Fecha de script: 12/11/2026 20:42:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[obtener_partida_en_juego_por_usuario]
    @id_usuario INT
AS
BEGIN
    SELECT 
        p.id_partida, 
        p.jugador_actual, 
        p.ganador, 
        p.fecha_partida, 
        p.tiempo_partida
    FROM Partida p
    INNER JOIN JugadorXPartida jxp ON p.id_partida = jxp.id_partida
    INNER JOIN Jugador j ON jxp.id_jugador = j.id_jugador
    WHERE j.id_usuario = @id_usuario 
      AND (p.ganador IS NULL OR p.ganador = -1)
END
GO
/****** Objeto: StoredProcedure [dbo].[obtener_partida_por_id] Fecha de script: 12/11/2026 20:42:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[obtener_partida_por_id]
    @id_partida INT
AS
BEGIN
    SELECT 
        id_partida, 
        jugador_actual, 
        ganador, 
        fecha_partida, 
        tiempo_partida
    FROM Partida
    WHERE id_partida = @id_partida
END
GO
USE [master]
GO
ALTER DATABASE [Generala] SET  READ_WRITE 
GO
