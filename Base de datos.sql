USE [Qatar2022]
GO
/****** Object:  User [alumno]    Script Date: 6/10/2022 09:09:12 ******/
CREATE USER [alumno] FOR LOGIN [alumno] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  Table [dbo].[Biblioteca]    Script Date: 6/10/2022 09:09:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Biblioteca](
	[IdBibroteca] [int] IDENTITY(1,1) NOT NULL,
	[IdUsuario] [int] NOT NULL,
	[Proxima] [varchar](50) NOT NULL,
	[Leyendo] [varchar](50) NOT NULL,
	[Leido] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Biblioteca] PRIMARY KEY CLUSTERED 
(
	[IdBibroteca] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Libros]    Script Date: 6/10/2022 09:09:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Libros](
	[IdLibro] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[Portada] [varchar](200) NOT NULL,
	[Contraportada] [varchar](200) NOT NULL,
	[Autor] [varchar](50) NOT NULL,
	[CantPaginas] [int] NOT NULL,
	[Descripción] [varchar](max) NOT NULL,
	[TW] [varchar](max) NULL,
	[CantLibros] [int] NOT NULL,
	[Genero] [varchar](max) NOT NULL,
	[Categoria] [varchar](20) NOT NULL,
 CONSTRAINT [PK_Libros] PRIMARY KEY CLUSTERED 
(
	[IdLibro] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Personajes]    Script Date: 6/10/2022 09:09:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Personajes](
	[IdPersonaje] [int] IDENTITY(1,1) NOT NULL,
	[IdLibro] [int] NOT NULL,
	[Nombre] [varchar](100) NOT NULL,
	[FechaNacimiento] [datetime] NOT NULL,
	[Foto] [varchar](200) NOT NULL,
	[Descripcion] [varchar](max) NOT NULL,
	[Estado] [varchar](10) NOT NULL,
	[Genero] [varchar](10) NOT NULL,
	[Nacionalidad] [varchar](10) NOT NULL,
 CONSTRAINT [PK_Personajes] PRIMARY KEY CLUSTERED 
(
	[IdPersonaje] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 6/10/2022 09:09:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuario](
	[IdUsuario] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](20) NOT NULL,
	[Contraseña] [varchar](max) NOT NULL,
	[Activo] [bit] NOT NULL,
	[Mail] [varchar](max) NOT NULL,
	[HoraDeCreación] [date] NOT NULL,
 CONSTRAINT [PK_Usuario] PRIMARY KEY CLUSTERED 
(
	[IdUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Libros] ON 

INSERT [dbo].[Libros] ([IdLibro], [Nombre], [Portada], [Contraportada], [Autor], [CantPaginas], [Descripción], [TW], [CantLibros], [Genero], [Categoria]) VALUES (2, N'Six Of Crows', N'SoC.jpg', N'SoC2.jpg', N'Leigh Bardugo', 465, N'Kaz Brekker, un genio del crimen que regenta un antro de juegos de azar y apuestas conocido como el Club Cuervo, debe reunir a un grupo de seis personas con las habilidades necesarias para entrar (y salir) de la Corte de Hielo, una fortaleza inexpugnable que mantiene bajo llave un secreto que podría dinamitar el equilibrio de poder en el mundo.

Es probable que nadie sobreviva a esta misión, pero si quiere hacerse rico más allá de lo que alcanza su imaginación, Kaz va a tener que jugárselo todo a una sola carta. Y esa carta es un Seis de Cuervos.', N'Adicciones - Trata de niños - Juego - Genocidio - Asesinato - Abuso sexual - esclavitud - Violencia - Trabajo sexual forzado - Abuso infantil - Suicidio', 2, N'Fantasía ', N'+13')
INSERT [dbo].[Libros] ([IdLibro], [Nombre], [Portada], [Contraportada], [Autor], [CantPaginas], [Descripción], [TW], [CantLibros], [Genero], [Categoria]) VALUES (3, N'The Secret History', N'TSH.jpg', N'TSH2.jpg', N'Donna Tartt', 576, N'Sobrecogedora historia ambientada en una elitista universidad de Nueva Inglaterra. Cinco estudiantes notables, seducidos por la Grecia clásica, cometen  un crimen con el que pasarán  la frontera hacia lo más oscuro y violento de la naturaleza humana.

La vida no es fácil en un college de Nueva Inglaterra si eres un chico modesto y falto de afecto que llega de California, y Richard Papen lo sabe; por eso agradece que lo admitan en un pequeño grupo de cinco estudiantes capitaneados por un profesor de literatura clásica con mucho carisma y pocos escrúpulos. Los chicos sueltan comentarios en griego y se ríen de la ingenuidad y la torpeza de los demás, pero bien mirado se pasan el día bebiendo y engullendo pastillas, hasta que un mal día lo que parecían chiquilladas se convierten en asuntos donde la muerte tiene algo que decir. Es entonces cuando Richard y su pandilla descubren qué difícil es vivir sin máscaras y qué fácil es matar sin remordimientos. En El secreto, la primera novela de la gran Donna Tartt, se unen la tensión de la novela psicológica, el ritmo de un thriller y la crónica de una juventud que pide demasiado a la vida sin saber bien qué entregar a cambio. El resultado es una obra que se cuenta entre las mejores del siglo XX.', N'Antisemitismo - Drogas - Homofobia - Incesto - Asesinato - Racismo - Violencia', 2, N'Novela psicológica', N'+16')
INSERT [dbo].[Libros] ([IdLibro], [Nombre], [Portada], [Contraportada], [Autor], [CantPaginas], [Descripción], [TW], [CantLibros], [Genero], [Categoria]) VALUES (4, N'The Seven Husbands of Evelyn Hugo', N'TSHoEH.jpg', N'TSHoEH2.jpeg', N'Taylor Jenkins', 380, N'Evelyn Hugo, el ícono de Hollywood que se ha recluido en su edad madura, decide al fin contar la verdad sobre su vida llena de glamour y de escándalos. Pero cuando elige para ello a Monique Grant, una periodista desconocida, nadie se sorprende más que la misma Monique. ¿Por qué ella ? ¿Por qué ahora ? Monique no está precisamente en su mejor momento. Su marido la abandonó, y su vida profesional no avanza. Aún ignorando por qué Evelyn la ha elegido para escribir su biografía. Monique está decidida a aprovechar esa oportunidad para dar impulso a su carrera. Convocada al lujoso apartamento de Evelyn, Monique escucha fascinada mientras la actriz le cuenta su historia. Desde su llegada a Los Ángeles en los años 50 hasta su decisión de abandonar su carrera en el espectáculo en los 80 - y desde luego, los siete maridos que tuvo en ese tiempo - Evelyn narra una historia de ambición implacable, amistad inesperada y un gran amor prohibido.', N'Agresión sexual - Violación - Relación abusiva - Enfermedades - Accidentes - Abuso físico - Abuso sexual - Abuso infantil- Homofobia - Muerte - Racismo - Sexismo - Suicidio', 1, N'Novela rosa - Ficción histórica - Novela psicológica - Romance', N'+13')
INSERT [dbo].[Libros] ([IdLibro], [Nombre], [Portada], [Contraportada], [Autor], [CantPaginas], [Descripción], [TW], [CantLibros], [Genero], [Categoria]) VALUES (5, N'Dear Evan Hansen', N'DEH.jpg', N'DEH2.jpg', N'Val Emmich y compania', 348, N'Todo comenzó con una carta que salió del corazón y cayó en manos erróneas... para acabar en una auténtica revolución por un mundo más amable. Ahpra, Evan tiene la oportunidad más importante de su vida: no solo de ser conocido, sino también de decir lo que importa, crear vínculos, dejar huella... e incluso entender ese curioso fenómeno llamado amor.', N'Suicidio - Homofobia - Violencia', 1, N'Drama - Adolecente', N'+13')
INSERT [dbo].[Libros] ([IdLibro], [Nombre], [Portada], [Contraportada], [Autor], [CantPaginas], [Descripción], [TW], [CantLibros], [Genero], [Categoria]) VALUES (6, N'Percy Jackson y el Ladón del Rayo', N'PJ.jpg', N'Pj2.jpg', N'Rick Riordan', 285, N'Percy descubre que es el hijo del dios griego Poseidón y que sus discapacidades son naturales para los semidioses, también conocidos como mestizos. Se embarca en una aventura para encontrar el Rayo Maestro de Zeus y evitar una guerra catastrófica entre dioses.', N'', 5, N'Acción- Aventura - Fantasía', N'+7')
INSERT [dbo].[Libros] ([IdLibro], [Nombre], [Portada], [Contraportada], [Autor], [CantPaginas], [Descripción], [TW], [CantLibros], [Genero], [Categoria]) VALUES (8, N'Carrie', N'Carrie.jpg', N'Carrie2.jpg', N'Stephen King', 255, N'El escalofriante caso de una joven de apariencia insignificante que se transformó en un ser de poderes anormales, sembrado el terro en la ciudad. Con pulso mágico para mantener la tensión a lo largo de todo el libro, Stephen King narra la atormentada adolescencia de Carrie, y nos envuelve en una atmósfera sobrecogedora cuando la muchacha realiza una serie de descubrimientos hasta llegar al terrible momento de la venganza. Esta novela fue llevada al cine con un unmenso éxito de público y crítica.', N'Bulling - Acoso - Bulling - Muerte - Abuso emocional - Abuso sexual - Abuso infantil - Control mental - Asesinato - Homofobia - Violencia doméstica - Racismo', 1, N'Terror - Ficción - Novela epistolar', N'+13')
SET IDENTITY_INSERT [dbo].[Libros] OFF
GO
SET IDENTITY_INSERT [dbo].[Personajes] ON 

INSERT [dbo].[Personajes] ([IdPersonaje], [IdLibro], [Nombre], [FechaNacimiento], [Foto], [Descripcion], [Estado], [Genero], [Nacionalidad]) VALUES (2, 3, N'Camilla', CAST(N'1995-07-15T00:00:00.000' AS DateTime), N'CarmillaFoto.jpg', N'Chica Rubia, que lucho contra alguien y es muy querida por el publico y no se que más poner. Ayudaaa.  Si alguien esta leyendo esto quiero decirte que tomes agua y espero que seas muy feliz. Por motivos obvios esto es solo un texto para rellenar el espacio y ver como van quedando las cosas, proximamente habra información :)', N'Viva', N'Mujer     ', N'Europea   ')
SET IDENTITY_INSERT [dbo].[Personajes] OFF
GO
ALTER TABLE [dbo].[Biblioteca]  WITH CHECK ADD  CONSTRAINT [FK_Biblioteca_Usuario] FOREIGN KEY([IdUsuario])
REFERENCES [dbo].[Usuario] ([IdUsuario])
GO
ALTER TABLE [dbo].[Biblioteca] CHECK CONSTRAINT [FK_Biblioteca_Usuario]
GO
ALTER TABLE [dbo].[Personajes]  WITH CHECK ADD  CONSTRAINT [FK_Personajes_Libros] FOREIGN KEY([IdLibro])
REFERENCES [dbo].[Libros] ([IdLibro])
GO
ALTER TABLE [dbo].[Personajes] CHECK CONSTRAINT [FK_Personajes_Libros]
GO
USE [master]
GO
ALTER DATABASE [Qatar2022] SET  READ_WRITE 
GO
