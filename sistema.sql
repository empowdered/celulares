USE [master]
GO
/****** Object:  Database [sistemaMovil]    Script Date: 11/30/2017 11:50:10 ******/
CREATE DATABASE [sistemaMovil] ON  PRIMARY 
( NAME = N'sistemaMovil', FILENAME = N'C:\Users\caschile\Downloads\DATA\sistemaMovil.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'sistemaMovil_log', FILENAME = N'C:\Users\caschile\Downloads\DATA\sistemaMovil_log.ldf' , SIZE = 1280KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [sistemaMovil] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [sistemaMovil].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [sistemaMovil] SET ANSI_NULL_DEFAULT OFF
GO
ALTER DATABASE [sistemaMovil] SET ANSI_NULLS OFF
GO
ALTER DATABASE [sistemaMovil] SET ANSI_PADDING OFF
GO
ALTER DATABASE [sistemaMovil] SET ANSI_WARNINGS OFF
GO
ALTER DATABASE [sistemaMovil] SET ARITHABORT OFF
GO
ALTER DATABASE [sistemaMovil] SET AUTO_CLOSE OFF
GO
ALTER DATABASE [sistemaMovil] SET AUTO_CREATE_STATISTICS ON
GO
ALTER DATABASE [sistemaMovil] SET AUTO_SHRINK OFF
GO
ALTER DATABASE [sistemaMovil] SET AUTO_UPDATE_STATISTICS ON
GO
ALTER DATABASE [sistemaMovil] SET CURSOR_CLOSE_ON_COMMIT OFF
GO
ALTER DATABASE [sistemaMovil] SET CURSOR_DEFAULT  GLOBAL
GO
ALTER DATABASE [sistemaMovil] SET CONCAT_NULL_YIELDS_NULL OFF
GO
ALTER DATABASE [sistemaMovil] SET NUMERIC_ROUNDABORT OFF
GO
ALTER DATABASE [sistemaMovil] SET QUOTED_IDENTIFIER OFF
GO
ALTER DATABASE [sistemaMovil] SET RECURSIVE_TRIGGERS OFF
GO
ALTER DATABASE [sistemaMovil] SET  DISABLE_BROKER
GO
ALTER DATABASE [sistemaMovil] SET AUTO_UPDATE_STATISTICS_ASYNC OFF
GO
ALTER DATABASE [sistemaMovil] SET DATE_CORRELATION_OPTIMIZATION OFF
GO
ALTER DATABASE [sistemaMovil] SET TRUSTWORTHY OFF
GO
ALTER DATABASE [sistemaMovil] SET ALLOW_SNAPSHOT_ISOLATION OFF
GO
ALTER DATABASE [sistemaMovil] SET PARAMETERIZATION SIMPLE
GO
ALTER DATABASE [sistemaMovil] SET READ_COMMITTED_SNAPSHOT OFF
GO
ALTER DATABASE [sistemaMovil] SET HONOR_BROKER_PRIORITY OFF
GO
ALTER DATABASE [sistemaMovil] SET  READ_WRITE
GO
ALTER DATABASE [sistemaMovil] SET RECOVERY FULL
GO
ALTER DATABASE [sistemaMovil] SET  MULTI_USER
GO
ALTER DATABASE [sistemaMovil] SET PAGE_VERIFY CHECKSUM
GO
ALTER DATABASE [sistemaMovil] SET DB_CHAINING OFF
GO
USE [sistemaMovil]
GO
/****** Object:  User [juanp]    Script Date: 11/30/2017 11:50:10 ******/
CREATE USER [juanp] WITHOUT LOGIN WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  Table [dbo].[movil]    Script Date: 11/30/2017 11:50:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[movil](
	[numeromovil] [smallint] NULL,
	[saldo] [smallint] NULL,
	[estado] [bit] NOT NULL,
	[rutCliente] [nvarchar](15) NULL,
	[inicio] [varchar](50) NULL,
	[termino] [varchar](50) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[movil] ([numeromovil], [saldo], [estado], [rutCliente], [inicio], [termino]) VALUES (123, 123, 1, N'16137272-2', N'28-10-2012 22:05:15', N'28-10-2012 22:05:15')
INSERT [dbo].[movil] ([numeromovil], [saldo], [estado], [rutCliente], [inicio], [termino]) VALUES (234, 123, 1, N'16137272-2', N'28-10-2012 22:14:26', N'30-10-2012 22:14:26')
INSERT [dbo].[movil] ([numeromovil], [saldo], [estado], [rutCliente], [inicio], [termino]) VALUES (6778, 1000, 0, N'7968343-4', N'30-10-2012 21:27:05', N'30-10-2012 21:27:05')
INSERT [dbo].[movil] ([numeromovil], [saldo], [estado], [rutCliente], [inicio], [termino]) VALUES (678, 10000, 0, N'17320649-6', N'30-10-2012 21:27:05', N'30-10-2012 21:27:05')
INSERT [dbo].[movil] ([numeromovil], [saldo], [estado], [rutCliente], [inicio], [termino]) VALUES (655, 10000, 1, N'17320649-6', N'30-10-2012 21:27:05', N'30-10-2012 21:27:05')
INSERT [dbo].[movil] ([numeromovil], [saldo], [estado], [rutCliente], [inicio], [termino]) VALUES (955, 300, 1, N'16285219-1', N'17/04/2017 16:14:41', N'17/04/2017 16:14:41')
/****** Object:  Table [dbo].[mensaje]    Script Date: 11/30/2017 11:50:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[mensaje](
	[fecha] [datetime] NULL,
	[contenido] [nvarchar](50) NULL,
	[recibido] [bit] NOT NULL,
	[destino] [smallint] NULL,
	[valor] [smallint] NULL,
	[numMovil] [smallint] NULL
) ON [PRIMARY]
GO
INSERT [dbo].[mensaje] ([fecha], [contenido], [recibido], [destino], [valor], [numMovil]) VALUES (CAST(0x0000A0FA012240DA AS DateTime), N'asd', 1, 234, 50, 123)
INSERT [dbo].[mensaje] ([fecha], [contenido], [recibido], [destino], [valor], [numMovil]) VALUES (CAST(0x0000A0FA0125A277 AS DateTime), N'asd', 1, 234, 50, 123)
INSERT [dbo].[mensaje] ([fecha], [contenido], [recibido], [destino], [valor], [numMovil]) VALUES (CAST(0x0000A0FA0125CD22 AS DateTime), N'asd', 1, 234, 50, 123)
INSERT [dbo].[mensaje] ([fecha], [contenido], [recibido], [destino], [valor], [numMovil]) VALUES (CAST(0x0000A0FA012FD408 AS DateTime), N'asd', 1, 123, 50, 123)
INSERT [dbo].[mensaje] ([fecha], [contenido], [recibido], [destino], [valor], [numMovil]) VALUES (CAST(0x0000A0FA0143F931 AS DateTime), N'Saldo Recargado con exito', 1, 123, 0, 123)
INSERT [dbo].[mensaje] ([fecha], [contenido], [recibido], [destino], [valor], [numMovil]) VALUES (CAST(0x0000A0FA0144428E AS DateTime), N'Saldo Recargado con exito', 1, 234, 0, 234)
INSERT [dbo].[mensaje] ([fecha], [contenido], [recibido], [destino], [valor], [numMovil]) VALUES (CAST(0x0000A0FA016287CA AS DateTime), N'este es un mensaje', 1, 655, 50, 655)
INSERT [dbo].[mensaje] ([fecha], [contenido], [recibido], [destino], [valor], [numMovil]) VALUES (CAST(0x0000A0FA0162BD74 AS DateTime), N'este es un mensaje', 1, 655, 50, 655)
INSERT [dbo].[mensaje] ([fecha], [contenido], [recibido], [destino], [valor], [numMovil]) VALUES (CAST(0x0000A0FA0162C108 AS DateTime), N'este es un mensaje', 1, 655, 50, 655)
INSERT [dbo].[mensaje] ([fecha], [contenido], [recibido], [destino], [valor], [numMovil]) VALUES (CAST(0x0000A0FA01636BB2 AS DateTime), N'Saldo Recargado con exito', 1, 655, 0, 655)
INSERT [dbo].[mensaje] ([fecha], [contenido], [recibido], [destino], [valor], [numMovil]) VALUES (CAST(0x0000A0FA0167DCE6 AS DateTime), N'No es posible enviar sms a su mismo numero', 1, 123, 0, 123)
INSERT [dbo].[mensaje] ([fecha], [contenido], [recibido], [destino], [valor], [numMovil]) VALUES (CAST(0x0000A0FA0168188D AS DateTime), N'No es posible enviar sms a su mismo numero', 1, 123, 0, 123)
INSERT [dbo].[mensaje] ([fecha], [contenido], [recibido], [destino], [valor], [numMovil]) VALUES (CAST(0x0000A1030128BCCA AS DateTime), N'No es posible enviar sms a su mismo numero', 1, 123, 0, 123)
INSERT [dbo].[mensaje] ([fecha], [contenido], [recibido], [destino], [valor], [numMovil]) VALUES (CAST(0x0000A758010EA7D9 AS DateTime), N'hola como estas?', 1, 6778, 50, 955)
INSERT [dbo].[mensaje] ([fecha], [contenido], [recibido], [destino], [valor], [numMovil]) VALUES (CAST(0x0000A75801101DFF AS DateTime), N'Saldo Recargado con exito', 1, 955, 0, 955)
INSERT [dbo].[mensaje] ([fecha], [contenido], [recibido], [destino], [valor], [numMovil]) VALUES (CAST(0x0000A0FA013BEB1F AS DateTime), N'asd', 1, 123, 50, 234)
INSERT [dbo].[mensaje] ([fecha], [contenido], [recibido], [destino], [valor], [numMovil]) VALUES (CAST(0x0000A0FA0141853D AS DateTime), N'Saldo Recargado con exito', 1, 123, 0, 123)
/****** Object:  Table [dbo].[Historial]    Script Date: 11/30/2017 11:50:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Historial](
	[idRegistro] [int] IDENTITY(1,1) NOT NULL,
	[numeromovil] [smallint] NULL,
	[accion] [varchar](50) NULL,
	[fecha] [datetime] NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Historial] ON
INSERT [dbo].[Historial] ([idRegistro], [numeromovil], [accion], [fecha]) VALUES (1, 234, N'desvio ciclico', CAST(0x0000A1030126EB41 AS DateTime))
INSERT [dbo].[Historial] ([idRegistro], [numeromovil], [accion], [fecha]) VALUES (2, 123, N'envio sms al mismo numero', CAST(0x0000A1030128BE24 AS DateTime))
INSERT [dbo].[Historial] ([idRegistro], [numeromovil], [accion], [fecha]) VALUES (3, 123, N'Desvio al mismo numero movil', CAST(0x0000A103012AAE33 AS DateTime))
INSERT [dbo].[Historial] ([idRegistro], [numeromovil], [accion], [fecha]) VALUES (4, 0, N'login al sistema', CAST(0x0000A103014D7992 AS DateTime))
INSERT [dbo].[Historial] ([idRegistro], [numeromovil], [accion], [fecha]) VALUES (5, 123, N'login al sistema', CAST(0x0000A103014E9458 AS DateTime))
INSERT [dbo].[Historial] ([idRegistro], [numeromovil], [accion], [fecha]) VALUES (6, 123, N'login al sistema', CAST(0x0000A10301511DEE AS DateTime))
INSERT [dbo].[Historial] ([idRegistro], [numeromovil], [accion], [fecha]) VALUES (9, 123, N'login al sistema', CAST(0x0000A6D000DE0799 AS DateTime))
INSERT [dbo].[Historial] ([idRegistro], [numeromovil], [accion], [fecha]) VALUES (10, 955, N'login al sistema', CAST(0x0000A758010E4C14 AS DateTime))
INSERT [dbo].[Historial] ([idRegistro], [numeromovil], [accion], [fecha]) VALUES (11, 955, N'login al sistema', CAST(0x0000A7580110507A AS DateTime))
INSERT [dbo].[Historial] ([idRegistro], [numeromovil], [accion], [fecha]) VALUES (7, 234, N'login al sistema', CAST(0x0000A1030157DEBF AS DateTime))
INSERT [dbo].[Historial] ([idRegistro], [numeromovil], [accion], [fecha]) VALUES (8, 234, N'desvio ciclico', CAST(0x0000A1030157E3C8 AS DateTime))
SET IDENTITY_INSERT [dbo].[Historial] OFF
/****** Object:  Table [dbo].[desvios]    Script Date: 11/30/2017 11:50:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[desvios](
	[numeroDesvia] [smallint] NULL,
	[numeroRecibe] [smallint] NULL
) ON [PRIMARY]
GO
INSERT [dbo].[desvios] ([numeroDesvia], [numeroRecibe]) VALUES (234, 123)
INSERT [dbo].[desvios] ([numeroDesvia], [numeroRecibe]) VALUES (6778, 955)
/****** Object:  Table [dbo].[desviados2]    Script Date: 11/30/2017 11:50:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[desviados2](
	[idMovil] [smallint] NULL
) ON [PRIMARY]
GO
INSERT [dbo].[desviados2] ([idMovil]) VALUES (123)
INSERT [dbo].[desviados2] ([idMovil]) VALUES (955)
/****** Object:  Table [dbo].[Clientes]    Script Date: 11/30/2017 11:50:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Clientes](
	[rut] [nvarchar](15) NULL,
	[nombres] [nvarchar](50) NULL,
	[apellidos] [nvarchar](50) NULL,
	[direccion] [nvarchar](50) NULL
) ON [PRIMARY]
GO
INSERT [dbo].[Clientes] ([rut], [nombres], [apellidos], [direccion]) VALUES (N'16137272-2', N'juan pablo', N'munoz leiva', N'biobio 9110')
INSERT [dbo].[Clientes] ([rut], [nombres], [apellidos], [direccion]) VALUES (N'2223', N'asdx', N'asd', N'asd')
INSERT [dbo].[Clientes] ([rut], [nombres], [apellidos], [direccion]) VALUES (N'7968343-4', N'maria luisa', N'leiva carvallo', N'los olivos 1145')
INSERT [dbo].[Clientes] ([rut], [nombres], [apellidos], [direccion]) VALUES (N'17320649-6', N'giuliano boris', N'garces vega', N'los olivos 7890')
INSERT [dbo].[Clientes] ([rut], [nombres], [apellidos], [direccion]) VALUES (N'18886737-5', N'juan pablo', N'munoz leiva', N'ogilvie 11')
INSERT [dbo].[Clientes] ([rut], [nombres], [apellidos], [direccion]) VALUES (N'16285219-1', N'brenda Ercilia', N'manquepillan caamano', N'carlos valdovinos 783')
/****** Object:  Table [dbo].[tarifas]    Script Date: 11/30/2017 11:50:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tarifas](
	[idtarifa] [int] NOT NULL,
	[vigencia] [datetime] NULL,
	[inicio] [varchar](50) NULL,
	[termino] [varchar](50) NULL,
	[nombreTarifa] [varchar](50) NULL,
	[coste] [numeric](18, 0) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[tarifas] ([idtarifa], [vigencia], [inicio], [termino], [nombreTarifa], [coste]) VALUES (52, NULL, N'17/04/2017 17:35:56', N'17/04/2017 17:35:56', N'seleccion', CAST(2 AS Numeric(18, 0)))
/****** Object:  StoredProcedure [dbo].[spVerificaEstado]    Script Date: 11/30/2017 11:50:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[spVerificaEstado]
@numMovil smallint
as 
	begin
		if exists(select * from movil where estado = 0 and numeromovil = @numMovil)
			begin
				update movil set estado = 1 where numeromovil = @numMovil
				return 1
			end
		else
			begin
				return 0
			end	
	end
GO
/****** Object:  StoredProcedure [dbo].[spRecarga]    Script Date: 11/30/2017 11:50:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[spRecarga]
@cantidad smallint, @destino smallint
as 
begin
declare @mensaje nvarchar(50)
declare @fecha datetime
set @fecha = GETDATE()
set @mensaje = 'Saldo Recargado con exito'
	if exists(select * from movil where numeromovil = @destino)
		begin
			update movil set saldo = @cantidad where numeromovil = @destino
			insert into mensaje values(@fecha,@mensaje,1,@destino,0,@destino)
			return 1
		end
end
GO
/****** Object:  StoredProcedure [dbo].[sp_verificaEstado2]    Script Date: 11/30/2017 11:50:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[sp_verificaEstado2]
@numMovil smallint
as 
	begin
		if exists(select * from movil where estado = 1 and numeromovil = @numMovil)
			begin
				update movil set estado = 0 where numeromovil = @numMovil
				return 1
			end
		else
			begin
				return 0
			end	
	end
GO
/****** Object:  StoredProcedure [dbo].[sp_registroHistorial]    Script Date: 11/30/2017 11:50:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[sp_registroHistorial]
@numero smallint,@accion varchar(50)
as
	declare @fecha datetime
	set @fecha = GETDATE()
		begin
			insert into Historial(numeromovil,accion,fecha) values(@numero,@accion,@fecha)
			return 1
		end
GO
/****** Object:  StoredProcedure [dbo].[sp_insertaTarifa]    Script Date: 11/30/2017 11:50:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[sp_insertaTarifa]
@codigo int,@inicio varchar(50),@termino varchar(50),@nombre varchar(50),@coste numeric
	as
		begin
	
			if not exists(select * from tarifas where idtarifa = @codigo)
				begin
					insert into tarifas(idtarifa,inicio,termino,nombreTarifa,coste) values(@codigo,@inicio,@termino,@nombre,@coste)
					return 1
				end
			else
				begin
					return 0
				end
		
		end
GO
/****** Object:  StoredProcedure [dbo].[sp_insertaMovil]    Script Date: 11/30/2017 11:50:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[sp_insertaMovil]
@num smallint,@saldo smallint, @estado bit,@rutCliente nvarchar(15),@inicio varchar(50),
@termino varchar(50)
as
	begin
		if exists(select rut from Clientes where rut = @rutCliente)
			begin
			 if not exists(select numeromovil from movil where numeromovil = @num)
				begin	
				insert into movil values(@num,@saldo,@estado,@rutCliente,@inicio,@termino)
				return 1
				end
			else
				begin
				return 2
				end
		end 
	end
GO
/****** Object:  StoredProcedure [dbo].[sp_eliminaDesvios]    Script Date: 11/30/2017 11:50:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[sp_eliminaDesvios]
@num smallint

as
	begin
		if exists(select * from desvios where numeroRecibe = @num)
			begin
				delete from desvios where numeroRecibe = @num
				delete from desviados2 where idMovil = @num
				return 1
			end
	end
GO
/****** Object:  StoredProcedure [dbo].[sp_desviaNumero]    Script Date: 11/30/2017 11:50:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[sp_desviaNumero]
@numDesvia smallint, @numOrigen smallint
as
declare @fecha datetime
set @fecha = GETDATE()
begin
if exists(select * from desvios where numeroDesvia = @numOrigen and numeroRecibe =  @numDesvia)
	begin
		insert into Historial(numeromovil,accion,fecha) values(@numOrigen,'desvio ciclico',@fecha)
		return 22
	end
else begin
	if exists(select * from movil where numeromovil = @numOrigen)
		begin
			if exists(select * from movil where numeromovil = @numDesvia)
			begin
				if not exists(select idMovil from desviados2 where idMovil = @numOrigen )
						begin
							insert into desviados2 values(@numOrigen)
							insert into desvios values(@numDesvia,@numOrigen)
							return 1
						end
			end
		end
				else
					begin
						if exists(select * from movil where numeromovil = @numDesvia)
							begin
							update desvios set numeroDesvia = @numDesvia where
							numeroRecibe = @numOrigen 
							return 2
							end
					end
end

end
GO
/****** Object:  StoredProcedure [dbo].[sp_creaSms]    Script Date: 11/30/2017 11:50:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[sp_creaSms]
@contenido nvarchar(50),@destino smallint,@numMovil smallint
as
	begin
	declare @mensaje nvarchar(50),@error nvarchar(50)
	declare @fecha dateTime
	set @fecha = GETDATE()
	set @mensaje = 'Lamentamos no poder enviar su sms, dado que el numero de destino no existe'
	set @error = 'No es posible enviar sms a su mismo numero'
		begin
		if @destino = @numMovil
			begin
				insert into mensaje values(@fecha,@error,1,@numMovil,0,@numMovil)
				return 22
			end 
	else begin			
		if exists (select * from movil where numeromovil = @destino and saldo > 50)
			begin
				insert into mensaje values(@fecha ,@contenido,1,@destino,50,@numMovil)
				update movil set saldo = (saldo - 50) where numeromovil = @numMovil
				return 1
			end
		else
			begin
				insert into mensaje values(@fecha,@mensaje,1,@numMovil,0,@numMovil)
				return 0
			end
		end
	end
end
GO
/****** Object:  StoredProcedure [dbo].[sp_consultaRut]    Script Date: 11/30/2017 11:50:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[sp_consultaRut] @rut nvarchar(15),@nombre nvarchar(50),@apellidos nvarchar(50),@direccion nvarchar(50) 
	as
		begin
			declare @contador int
			set @contador = 0
				select @contador = COUNT(*) from Clientes where rut = @rut
				if @contador = 0
					begin
						insert into Clientes values(@rut,@nombre,@apellidos,@direccion)
						return 1
					end
				else
					begin
						if @contador > 0
							return 0
					end
		end
GO
/****** Object:  StoredProcedure [dbo].[sp_consultaExisteAbonado]    Script Date: 11/30/2017 11:50:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[sp_consultaExisteAbonado]
@rutCliente varchar(15),@numero smallint
as 
begin
	if exists(select * from Clientes,movil where Clientes.rut = movil.rutCliente and Clientes.rut = @rutCliente and movil.numeromovil = @numero)
		begin
			return 1
		end
	else
		begin
			return 0
		end
end
GO
/****** Object:  StoredProcedure [dbo].[sp_actualizaMovil]    Script Date: 11/30/2017 11:50:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[sp_actualizaMovil]
 @numeromovil smallint,
@saldo smallint,@rutCliente nvarchar(15)
as
	begin
		if exists(select * from Clientes where rut=@rutCliente)
			begin
					begin	
						update movil set saldo = @saldo,rutCliente = @rutCliente where numeromovil = @numeromovil;
					return 1
					end
			end
		else
			begin
				return 0
			end
	end
GO
/****** Object:  StoredProcedure [dbo].[sp_ActualizaCliente]    Script Date: 11/30/2017 11:50:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[sp_ActualizaCliente] @rut nvarchar(15),@nombre nvarchar(50),@apellidos nvarchar(50),@direccion nvarchar(50) 
	as
begin
			update Clientes set nombres= @nombre,apellidos = @apellidos,direccion = @direccion
			where rut = @rut
						return 1
		
					
end
GO
