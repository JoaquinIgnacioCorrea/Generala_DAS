USE [Generala]
GO
/****** Objeto: Table [dbo].[Bitacora] Fecha de script: 18/11/2026 20:05:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Bitacora](
	[id_bitacora] [int] IDENTITY(1,1) NOT NULL,
	[id_jugador] [int] NOT NULL,
	[fecha] [datetime] NOT NULL,
	[descripcion] [varchar](200) NOT NULL,
 CONSTRAINT [PK_Bitacora] PRIMARY KEY CLUSTERED 
(
	[id_bitacora] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Objeto: Table [dbo].[Jugadas] Fecha de script: 18/11/2026 20:05:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Jugadas](
	[id_jugada] [int] IDENTITY(1,1) NOT NULL,
	[id_jugador] [int] NOT NULL,
	[id_partida] [int] NOT NULL,
	[hora] [datetime] NOT NULL,
	[puntaje] [int] NOT NULL,
	[categoria] [varchar](50) NOT NULL,
	[ronda] [int] NOT NULL,
	[valores_dados] [varchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id_jugada] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Objeto: Table [dbo].[Jugador] Fecha de script: 18/11/2026 20:05:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Jugador](
	[id_jugador] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Jugador] PRIMARY KEY CLUSTERED 
(
	[id_jugador] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Objeto: Table [dbo].[JugadorXPartida] Fecha de script: 18/11/2026 20:05:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[JugadorXPartida](
	[id_jugador] [int] NOT NULL,
	[id_partida] [int] NOT NULL,
	[puntaje_total] [int] NOT NULL,
	[resultado] [varchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id_jugador] ASC,
	[id_partida] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Objeto: Table [dbo].[Partida] Fecha de script: 18/11/2026 20:05:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Partida](
	[id_partida] [int] IDENTITY(1,1) NOT NULL,
	[jugador_actual] [int] NOT NULL,
	[ganador] [int] NOT NULL,
	[fecha_partida] [datetime] NOT NULL,
	[tiempo_partida] [time](7) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id_partida] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Objeto: Table [dbo].[Usuario] Fecha de script: 18/11/2026 20:05:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuario](
	[id_usuario] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](50) NOT NULL,
	[pass] [varchar](50) NOT NULL,
	[id_jugador] [int] NOT NULL,
 CONSTRAINT [PK_Usuario] PRIMARY KEY CLUSTERED 
(
	[id_usuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Jugadas] ADD  DEFAULT ((1)) FOR [ronda]
GO
ALTER TABLE [dbo].[Jugadas] ADD  DEFAULT ('') FOR [valores_dados]
GO
ALTER TABLE [dbo].[Bitacora]  WITH CHECK ADD  CONSTRAINT [FK_Bitacora_Jugador] FOREIGN KEY([id_jugador])
REFERENCES [dbo].[Jugador] ([id_jugador])
GO
ALTER TABLE [dbo].[Bitacora] CHECK CONSTRAINT [FK_Bitacora_Jugador]
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
ALTER TABLE [dbo].[Usuario]  WITH CHECK ADD  CONSTRAINT [FK_Usuario_Jugador1] FOREIGN KEY([id_jugador])
REFERENCES [dbo].[Jugador] ([id_jugador])
GO
ALTER TABLE [dbo].[Usuario] CHECK CONSTRAINT [FK_Usuario_Jugador1]
GO
/****** Objeto: StoredProcedure [dbo].[actualizar_jugadorxpartida] Fecha de script: 18/11/2026 20:05:25 ******/
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
/****** Objeto: StoredProcedure [dbo].[alta_usuario] Fecha de script: 18/11/2026 20:05:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[alta_usuario]
    @nombre VARCHAR(50),
    @pass VARCHAR(50),
    @id_jugador INT
AS
BEGIN
    INSERT INTO Usuario (nombre, pass, id_jugador)
    VALUES (@nombre, @pass, @id_jugador)
    
    -- Retorna el ID generado para usarlo al crear el Jugador asociado
    SELECT SCOPE_IDENTITY() AS id_usuario
END
GO
/****** Objeto: StoredProcedure [dbo].[baja_usuario] Fecha de script: 18/11/2026 20:05:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[baja_usuario]
    @id_usuario INT
AS
BEGIN
    DELETE FROM Usuario 
    WHERE id_usuario = @id_usuario
END
GO
/****** Objeto: StoredProcedure [dbo].[borrar_jugador] Fecha de script: 18/11/2026 20:05:25 ******/
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
/****** Objeto: StoredProcedure [dbo].[borrar_jugadorxpartida] Fecha de script: 18/11/2026 20:05:25 ******/
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
/****** Objeto: StoredProcedure [dbo].[borrar_partida] Fecha de script: 18/11/2026 20:05:25 ******/
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
/****** Objeto: StoredProcedure [dbo].[editar_jugador] Fecha de script: 18/11/2026 20:05:25 ******/
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
/****** Objeto: StoredProcedure [dbo].[editar_partida] Fecha de script: 18/11/2026 20:05:25 ******/
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
/****** Objeto: StoredProcedure [dbo].[insertar_bitacora] Fecha de script: 18/11/2026 20:05:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[insertar_bitacora]
    @id_jugador INT,
    @fecha DATETIME,
    @descripcion VARCHAR(100)
AS
BEGIN
    INSERT INTO Bitacora (id_jugador, fecha, descripcion)
    VALUES (@id_jugador, @fecha, @descripcion)

    SELECT SCOPE_IDENTITY() AS id_bitacora
END
GO
/****** Objeto: StoredProcedure [dbo].[insertar_jugada] Fecha de script: 18/11/2026 20:05:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[insertar_jugada]
    @id_jugador INT,
    @id_partida INT,
    @ronda INT,
    @valores_dados VARCHAR(50),
    @hora DATETIME,
    @puntaje INT,
    @categoria VARCHAR(50)
AS
BEGIN
    INSERT INTO Jugadas (id_jugador, id_partida, ronda, valores_dados, hora, puntaje, categoria)
    VALUES (@id_jugador, @id_partida, @ronda, @valores_dados, @hora, @puntaje, @categoria)
    
    SELECT SCOPE_IDENTITY() AS id_jugada
END
GO
/****** Objeto: StoredProcedure [dbo].[insertar_jugador] Fecha de script: 18/11/2026 20:05:25 ******/
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
    SELECT SCOPE_IDENTITY() AS id_jugador
END
GO
/****** Objeto: StoredProcedure [dbo].[insertar_jugadorxpartida] Fecha de script: 18/11/2026 20:05:25 ******/
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
/****** Objeto: StoredProcedure [dbo].[insertar_partida] Fecha de script: 18/11/2026 20:05:25 ******/
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
    SELECT SCOPE_IDENTITY() AS id_partida
END
GO
/****** Objeto: StoredProcedure [dbo].[listar_bitacora] Fecha de script: 18/11/2026 20:05:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[listar_bitacora]
AS
BEGIN
    SELECT 
        b.id_bitacora, 
        b.id_jugador, 
        j.nombre AS usuario, 
        b.fecha, 
        b.descripcion
    FROM Bitacora b
    LEFT JOIN Jugador j ON b.id_jugador = j.id_jugador
    ORDER BY b.fecha DESC
END
GO
/****** Objeto: StoredProcedure [dbo].[listar_detalles_por_partida] Fecha de script: 18/11/2026 20:05:25 ******/
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
/****** Objeto: StoredProcedure [dbo].[listar_jugadas_por_jugador_partida] Fecha de script: 18/11/2026 20:05:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[listar_jugadas_por_jugador_partida]
    @id_partida INT,
    @id_jugador INT
AS
BEGIN
    SELECT 
        id_jugada,
        id_partida,
        hora,
        id_jugador,
        ronda,
        valores_dados,
        categoria,
        puntaje
    FROM Jugadas
    WHERE id_partida = @id_partida AND id_jugador = @id_jugador
    ORDER BY ronda ASC, id_jugada ASC
END
GO
/****** Objeto: StoredProcedure [dbo].[listar_jugadas_por_partida] Fecha de script: 18/11/2026 20:05:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[listar_jugadas_por_partida]
    @id_partida INT
AS
BEGIN
    SELECT 
        id_jugada,
        id_partida,
        hora,
        id_jugador,
        ronda,
        valores_dados,
        categoria,
        puntaje
    FROM Jugadas
    WHERE id_partida = @id_partida
    ORDER BY ronda ASC, id_jugada ASC
END
GO
/****** Objeto: StoredProcedure [dbo].[listar_partidas_usuario] Fecha de script: 18/11/2026 20:05:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[listar_partidas_usuario]
    @id_jugador INT
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
    WHERE j.id_jugador = @id_jugador
END
GO
/****** Objeto: StoredProcedure [dbo].[listar_todos_jugadores] Fecha de script: 18/11/2026 20:05:25 ******/
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
/****** Objeto: StoredProcedure [dbo].[login_usuario] Fecha de script: 18/11/2026 20:05:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[login_usuario]
    @nombre VARCHAR(50),
    @pass VARCHAR(50)
AS
BEGIN
    -- Retorna los datos del usuario si las credenciales son correctas
    SELECT id_usuario, nombre, id_jugador
    FROM Usuario 
    WHERE nombre = @nombre AND pass = @pass
END
GO
/****** Objeto: StoredProcedure [dbo].[modificar_usuario] Fecha de script: 18/11/2026 20:05:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[modificar_usuario]
    @id_usuario INT,
    @nombre VARCHAR(50),
    @pass VARCHAR(50)
AS
BEGIN
    UPDATE Usuario 
    SET nombre = @nombre,
        pass = @pass
    WHERE id_usuario = @id_usuario
END
GO
/****** Objeto: StoredProcedure [dbo].[obtener_detalle_jugador_partida] Fecha de script: 18/11/2026 20:05:25 ******/
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
/****** Objeto: StoredProcedure [dbo].[obtener_estadisticas_jugadores] Fecha de script: 18/11/2026 20:05:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[obtener_estadisticas_jugadores]
AS
BEGIN
    SELECT 
        j.id_jugador,
        j.nombre AS jugador,
        COUNT(jxp.id_partida) AS partidas_jugadas,
        SUM(CASE WHEN jxp.resultado IN ('Ganador', 'Ganada', 'Victoria') THEN 1 ELSE 0 END) AS ganadas,
        SUM(CASE WHEN jxp.resultado IN ('Perdedor', 'Perdida', 'Derrota') THEN 1 ELSE 0 END) AS perdidas,
        SUM(CASE WHEN jxp.resultado IN ('Empate', 'Empatada') THEN 1 ELSE 0 END) AS empatadas,
        CAST(
            ISNULL(
                SUM(CASE WHEN jxp.resultado IN ('Ganador', 'Ganada', 'Victoria') THEN 1.0 ELSE 0.0 END) 
                / NULLIF(COUNT(jxp.id_partida), 0) * 100, 
            0) AS DECIMAL(5,2)
        ) AS porcentaje_victorias,
        ISNULL(SUM(DATEDIFF(SECOND, '00:00:00', p.tiempo_partida)), 0) AS tiempo_total_segundos,
        CONVERT(VARCHAR(12), DATEADD(SECOND, ISNULL(SUM(DATEDIFF(SECOND, '00:00:00', p.tiempo_partida)), 0), 0), 108) AS tiempo_total_formato
    FROM Jugador j
    LEFT JOIN JugadorXPartida jxp ON j.id_jugador = jxp.id_jugador
    LEFT JOIN Partida p ON jxp.id_partida = p.id_partida
    GROUP BY j.id_jugador, j.nombre
    ORDER BY ganadas DESC, porcentaje_victorias DESC;
END
GO
/****** Objeto: StoredProcedure [dbo].[obtener_estadisticas_por_jugador] Fecha de script: 18/11/2026 20:05:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[obtener_estadisticas_por_jugador]
    @id_jugador INT
AS
BEGIN
    SELECT 
        j.id_jugador,
        j.nombre AS jugador,
        COUNT(jxp.id_partida) AS partidas_jugadas,
        SUM(CASE WHEN jxp.resultado IN ('Ganador', 'Ganada', 'Victoria') THEN 1 ELSE 0 END) AS ganadas,
        SUM(CASE WHEN jxp.resultado IN ('Perdedor', 'Perdida', 'Derrota') THEN 1 ELSE 0 END) AS perdidas,
        SUM(CASE WHEN jxp.resultado IN ('Empate', 'Empatada') THEN 1 ELSE 0 END) AS empatadas,
        CAST(
            ISNULL(
                SUM(CASE WHEN jxp.resultado IN ('Ganador', 'Ganada', 'Victoria') THEN 1.0 ELSE 0.0 END) 
                / NULLIF(COUNT(jxp.id_partida), 0) * 100, 
            0) AS DECIMAL(5,2)
        ) AS porcentaje_victorias,
        ISNULL(SUM(DATEDIFF(SECOND, '00:00:00', p.tiempo_partida)), 0) AS tiempo_total_segundos,
        CONVERT(VARCHAR(12), DATEADD(SECOND, ISNULL(SUM(DATEDIFF(SECOND, '00:00:00', p.tiempo_partida)), 0), 0), 108) AS tiempo_total_formato
    FROM Jugador j
    LEFT JOIN JugadorXPartida jxp ON j.id_jugador = jxp.id_jugador
    LEFT JOIN Partida p ON jxp.id_partida = p.id_partida
    WHERE j.id_jugador = @id_jugador
    GROUP BY j.id_jugador, j.nombre;
END
GO
/****** Objeto: StoredProcedure [dbo].[obtener_jugador_por_id] Fecha de script: 18/11/2026 20:05:25 ******/
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
/****** Objeto: StoredProcedure [dbo].[obtener_partida_en_juego_por_usuario] Fecha de script: 18/11/2026 20:05:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[obtener_partida_en_juego_por_usuario]
    @id_jugador INT
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
    WHERE j.id_jugador = @id_jugador 
      AND (p.ganador IS NULL OR p.ganador = -1)
END
GO
/****** Objeto: StoredProcedure [dbo].[obtener_partida_por_id] Fecha de script: 18/11/2026 20:05:25 ******/
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
/****** Objeto: StoredProcedure [dbo].[obtener_usuario_por_id] Fecha de script: 18/11/2026 20:05:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[obtener_usuario_por_id]
    @id_usuario INT
AS
BEGIN
    SELECT id_usuario, nombre, pass, id_jugador 
    FROM Usuario 
    WHERE id_usuario = @id_usuario
END
GO
/****** Objeto: StoredProcedure [dbo].[verificar_nombre_usuario] Fecha de script: 18/11/2026 20:05:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[verificar_nombre_usuario]
    @nombre VARCHAR(50)
AS
BEGIN
    SELECT id_usuario
    FROM Usuario 
    WHERE nombre = @nombre
END
GO
USE [master]
GO
ALTER DATABASE [Generala] SET  READ_WRITE 
GO
