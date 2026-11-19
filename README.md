# Generala DAS

## Alumnos

- Federico Lautaro Giubis fede.giubis@gmail.com
- Joaquin Ignacio Correa joaquincorrea006@gmail.com

---

Trabajo Práctico **Generala** para 2 jugadores, desarrollado en **C# (.NET Framework 4.7.2, Windows Forms)** con base de datos **MS SQL Server**. Los dos jugadores pueden jugar en la misma máquina o en red mediante **sockets TCP** (un jugador hostea y el otro se une).

El juego administra los turnos, calcula el puntaje de cada combinación (Escalera, Full, Póker, Generala, etc.), muestra el puntaje en todo momento y determina el ganador (o el empate) al finalizar.

---

## Cómo ejecutarlo

### Requisitos

- Windows con **Visual Studio 2019/2022** (carga de trabajo "Desarrollo de escritorio con .NET").
- **SQL Server** (por ejemplo SQL Server Express) con la instancia `.\SQLEXPRESS`.
- **SQL Server Management Studio** (o cualquier cliente SQL) para correr el script.

### Pasos

1. **Abrir la solución:** `Generala_DAS.sln`.
2. **Crear la base de datos:** en SSMS ejecutar
   ```sql
   CREATE DATABASE Generala;
   ```
   El script no crea la base, solo la puebla.
3. **Cargar tablas y procedimientos almacenados:** abrir y ejecutar `Generala_DAS/BDD_Script/bdd.sql` sobre la base `Generala`.
4. **Revisar la cadena de conexión** en `DAL/ACCESO_DAL.cs`. Por defecto usa autenticación de Windows:
   ```
   Data Source=.\SQLEXPRESS;Initial Catalog=Generala;Integrated Security=true
   ```
   Si tu instancia tiene otro nombre (por ejemplo `.\SQLEXPRESS02`), cambiala ahí.
5. **Compilar y ejecutar** con el proyecto `Generala_DAS` como proyecto de inicio (F5).
6. En la ventana de login, **Registrarse** con un usuario y contraseña, y luego **Iniciar Sesión**.

---

## Cómo se juega

Desde el **Menú Principal** se puede:

| Botón                    | Qué hace                                                                     |
| ------------------------ | ---------------------------------------------------------------------------- |
| Jugar Partida            | Partida local (el segundo jugador es un usuario "INVITADO").                 |
| Hostear                  | Crea la partida en red y espera al rival en el puerto **5000**.              |
| Unirse                   | Pide la IP del host y se conecta a su partida.                               |
| Bitácora de Eventos      | Lista inicios y cierres de sesión, comienzos y finales de partida.           |
| Visor de Movimientos XML | Abre y muestra los movimientos guardados de una partida.                     |
| Estadisticas             | Muestra victorias, derrotas, empates, promedio de victorias y tiempo jugado. |
| Hacer Backup / Restaurar | Respalda o restaura la base de datos.                                        |
| Cerrar Sesión            | Cierra la sesión del usuario actual.                                         |

### Partida en red (2 jugadores)

1. Cada jugador abre la aplicación e inicia sesión **con un usuario distinto**.
2. Un jugador toca **Hostear** y espera.
3. El otro toca **Unirse**, ingresa la **IP del host** y se conecta.
4. Si están en PCs distintas, el puerto TCP **5000** tiene que estar habilitado en el firewall del host.

> **Importante:** el host es quien ejecuta las reglas y guarda todo en la base de datos, y el rival se identifica por su id de jugador. Por eso **ambos usuarios tienen que existir en la base que usa el host**. Lo más simple para probar es abrir dos instancias del programa en la misma PC (IP `127.0.0.1`). Para usar dos PCs, ambas deben apuntar a la misma instancia de SQL Server cambiando `Data Source` en `ACCESO_DAL.cs`.

### Reglas y turnos

- En cada turno el jugador puede **tirar los dados hasta 3 veces**.
- Entre tiros puede **apartar dados**: con un clic sobre un dado (se marca en rojo) o con el botón **Bloquear dados**, que aparta todos los libres.
- Al terminar, elige una casilla de su fila en el tablero y toca **Terminar turno** para anotar el puntaje.
- La partida termina cuando ambos tableros están completos. Gana quien tenga **más puntos**; si hay igualdad se registra **empate**.
- Una **Generala servida** (en el primer tiro) gana la partida en el acto.

### Puntajes

| Categoría      | Puntos                           | Servida              |
| -------------- | -------------------------------- | -------------------- |
| Unos a Seises  | Suma de los dados con ese número | -                    |
| Escalera       | 20                               | 25                   |
| Full           | 30                               | 35                   |
| Póker          | 40                               | 45                   |
| Generala       | 50                               | 60 (gana la partida) |
| Generala doble | 100                              | 120                  |

La **Generala doble** solo puede anotarse si ya se anotó una Generala con puntaje mayor a 0.

---

## Arquitectura (4 capas)

```
Generala_DAS.sln
├── BE/            Entidades: Jugador, Partida, Tablero, Turno, Cubilete, Dado, Usuario, Estadística...
├── DAL/           Acceso a datos: ACCESO (SQL Server), mappers (MP_*) y XML_MOVIMIENTOS
├── BLL/           Lógica de negocio: reglas del juego, cálculo de puntaje, usuarios, bitácora, estadísticas, backup
└── Generala_DAS/  Capa de presentación (Windows Forms) y ServidorGenerala (socket TCP)
    └── BDD_Script/bdd.sql
```

La presentación solo conoce BE y BLL; la BLL accede a datos a través de la DAL, que usa procedimientos almacenados.

**Funcionamiento del modo en red:** el host ejecuta toda la lógica del juego. El rival envía sus acciones (`TIRAR`, `BLOQUEAR`, `ANOTAR`) por el socket y el host le devuelve el estado completo de la partida, que ambas pantallas muestran.

---

## Requisitos de la LUG y dónde se cumplen

| Requisito                                                  | Dónde                                          |
| ---------------------------------------------------------- | ---------------------------------------------- |
| Orientado a objetos en C#                                  | Toda la solución                               |
| Base de datos MS SQL Server                                | `BDD_Script/bdd.sql`, DAL                      |
| Arquitectura de 4 capas                                    | BE, DAL, BLL, Generala_DAS                     |
| Registro de usuarios con credenciales                      | `frmLoginUsuario` (Registrarse), `USUARIO_BLL` |
| Login / Logout                                             | `frmLoginUsuario`, botón Cerrar Sesión         |
| Bitácora: inicio/cierre de sesión, comienzo/fin de partida | `BITACORA_BLL`, `frmBitacora`                  |
| Estadísticas ganadas / perdidas / empatadas                | `ESTADISTICA_BLL`, `frmEstadisticas`           |
| Movimientos de la partida en XML                           | `XML_MOVIMIENTOS`, `frmVisorXML`               |
| Promedio de victorias                                      | `frmEstadisticas`                              |
| Tiempo total jugado                                        | `frmEstadisticas`                              |
| Backup y Restore                                           | `BACKUP_BLL`, `MP_BACKUP`                      |
| Partida de a dos con socket                                | `ServidorGenerala`, botones Hostear / Unirse   |

---

## Notas

- **Archivos XML:** se guardan en la carpeta `PartidasXML`, junto al ejecutable (por ejemplo `Generala_DAS/bin/Debug/PartidasXML/partida_<id>.xml`), un archivo por partida. Los escribe el host.
- **Backup y Restore:** el archivo se guarda siempre en `C:\BackupsGenerala\backup.bak`. La carpeta se crea sola, pero el servicio de SQL Server necesita permiso de escritura sobre ella. Restaurar reemplaza el contenido actual de la base `Generala`.
- La cadena de conexión y el puerto (5000) están fijos en el código.
