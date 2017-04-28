SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
-------------------------------- >> CLIENTES
CREATE PROCEDURE [ASD].SP_cargarClientes 
AS
BEGIN
	Insert into [ASD].Clientes(Nombre,Apellido,DNI,Telefono,Direccion,Mail,Fecha_Nacimiento)
	SELECT Distinct
		[gd_esquema].Maestra.Cliente_Nombre,
		[gd_esquema].Maestra.Cliente_Apellido,
		[gd_esquema].Maestra.Cliente_DNI,
		[gd_esquema].Maestra.Cliente_Telefono,
		[gd_esquema].Maestra.Cliente_Direccion,
		[gd_esquema].Maestra.Cliente_Mail,
		[gd_esquema].Maestra.Cliente_Fecha_Nac		
	FROM [gd_esquema].Maestra
END
GO

CREATE PROCEDURE [ASD].SP_eliminarTodosClientes 
AS
BEGIN
	SET NOCOUNT OFF;
	DELETE FROM [ASD].Clientes
	
	DELETE FROM [ASD].Clientes
	DBCC CHECKIDENT ('[ASD].Clientes', RESEED, 0)
END
GO

CREATE PROCEDURE [ASD].SP_altaCliente(
		@nombre varchar(255),
		@apellido varchar(255),
		@dni numeric(18,0),
		@telefono numeric(18,0),
		@direccion varchar(255),
		@mail varchar(255),
		@fecha_nacimiento datetime)
AS
BEGIN
	INSERT INTO [ASD].Clientes
	values(@nombre, @apellido, @dni, @telefono, @direccion, @mail, @fecha_nacimiento,1)
END
GO

CREATE PROCEDURE [ASD].SP_modifCliente(
		@id int,
		@nombre varchar(255),
		@apellido varchar(255),
		@dni numeric(18,0),
		@telefono numeric(18,0),
		@direccion varchar(255),
		@mail varchar(255),
		@fecha_nacimiento datetime)
AS
BEGIN
	UPDATE [ASD].fx_getCliente(@id)
   SET Nombre = @nombre,
       Apellido = @apellido,
	   DNI = @dni,
	   Telefono = @telefono,
	   Direccion = @direccion,
	   Mail = @mail,
	   Fecha_Nacimiento = @fecha_nacimiento
END
GO

CREATE PROCEDURE [ASD].SP_deshabilitarCliente(@id int)
AS BEGIN
	UPDATE [ASD].fx_getCliente(@id)
	SET Habilitado=0
END
GO

CREATE PROCEDURE [ASD].SP_habilitarCliente(@id int)
AS BEGIN
	UPDATE [ASD].fx_getCliente(@id)
	SET Habilitado=1
END
GO


-------------------------------- >> CHOFERES

CREATE PROCEDURE [ASD].SP_cargarChoferes 
AS
BEGIN
	Insert into [ASD].Choferes(Nombre,Apellido,DNI,Telefono,Direccion,Mail,Fecha_Nacimiento)
	SELECT Distinct
		[gd_esquema].Maestra.Cliente_Nombre,
		[gd_esquema].Maestra.Cliente_Apellido,
		[gd_esquema].Maestra.Cliente_DNI,
		[gd_esquema].Maestra.Cliente_Telefono,
		[gd_esquema].Maestra.Cliente_Direccion,
		[gd_esquema].Maestra.Cliente_Mail,
		[gd_esquema].Maestra.Cliente_Fecha_Nac		
	FROM [gd_esquema].Maestra
END
GO

CREATE PROCEDURE [ASD].SP_eliminarTodosChoferes 
AS
BEGIN
	SET NOCOUNT OFF;
	DELETE FROM [ASD].Choferes
	
	DELETE FROM [ASD].Choferes
	DBCC CHECKIDENT ('[ASD].Choferes', RESEED, 0)
END
GO

CREATE PROCEDURE [ASD].SP_altaChofer(
		@nombre varchar(255),
		@apellido varchar(255),
		@dni numeric(18,0),
		@telefono numeric(18,0),
		@direccion varchar(255),
		@mail varchar(255),
		@fecha_nacimiento datetime,
		@cocheID int)
AS
BEGIN
	INSERT INTO [ASD].Choferes
	values(@nombre, @apellido, @dni, @telefono, @direccion, @mail, @fecha_nacimiento,@cocheID, 1)
END
GO

CREATE PROCEDURE [ASD].SP_modifChofer(
		@id int,
		@nombre varchar(255),
		@apellido varchar(255),
		@dni numeric(18,0),
		@telefono numeric(18,0),
		@direccion varchar(255),
		@mail varchar(255),
		@fecha_nacimiento datetime)
AS
BEGIN
	UPDATE [ASD].Choferes
   SET Nombre = @nombre,
       Apellido = @apellido,
	   DNI = @dni,
	   Telefono = @telefono,
	   Direccion = @direccion,
	   Mail = @mail,
	   Fecha_Nacimiento = @fecha_nacimiento
 WHERE ID = @id
END
GO

CREATE PROCEDURE [ASD].SP_deshabilitarChofer(@id int)
AS BEGIN
	UPDATE [ASD].fx_getChofer(@id)
	SET Habilitado=0
END
GO

CREATE PROCEDURE [ASD].SP_habilitarChofer(@id int)
AS BEGIN
	UPDATE [ASD].fx_getChofer(@id)
	SET Habilitado=1
END
GO

------------------------------ >> AUTOS
CREATE PROCEDURE [ASD].SP_cargarAutos
AS
BEGIN
	INSERT INTO [ASD].Autos(Marca, Modelo, Patente, Licencia, Rodado)
	SELECT DISTINCT 
		[gd_esquema].Maestra.Auto_Marca,
		[gd_esquema].Maestra.Auto_Modelo,
		[gd_esquema].Maestra.Auto_Patente,
		[gd_esquema].Maestra.Auto_Licencia,
		[gd_esquema].Maestra.Auto_Rodado
	FROM [gd_esquema].Maestra
END
GO

CREATE PROCEDURE [ASD].SP_eliminarTodosAutos
AS
Begin
	SET NOCOUNT OFF;
	DELETE FROM [ASD].Autos
	
	DELETE FROM [ASD].Autos
	DBCC CHECKIDENT ('[ASD].Autos', RESEED, 0)
End
go

CREATE PROCEDURE [ASD].SP_altaAuto(
			@marca varchar(255),
			@modelo varchar(255),
			@patente varchar(10),
			@licencia varchar(26),
			@rodado varchar(10))
AS
BEGIN
	Insert into [ASD].Autos
	values(@marca, @modelo, @patente, @licencia, @rodado,1)
END
GO

CREATE PROCEDURE [ASD].SP_deshabilitarAuto(@id int)
AS BEGIN
	UPDATE [ASD].fx_getAuto(@id)
	SET Habilitado=0
END
GO

CREATE PROCEDURE [ASD].SP_habilitarAuto(@id int)
AS BEGIN
	UPDATE [ASD].fx_getAuto(@id)
	SET Habilitado=1
END
GO

CREATE PROCEDURE [ASD].SP_modifAuto(
				@id int,
				@marca varchar(255),
				@modelo varchar(255),
				@patente varchar(10),
				@licencia varchar(26),
				@rodado varchar(10)
				)
AS
BEGIN
	UPDATE [ASD].Autos
	SET Marca = @marca,
		Modelo = @modelo,
		Patente = @patente,
		Licencia = @licencia,
		Rodado = @rodado
	WHERE ID = @id
END
GO

------------------------------ >> TURNOS
CREATE PROCEDURE [ASD].SP_altaTurno(@inicio numeric(18,0),
								 @fin numeric(18,0),
								 @precioBase numeric(18,2),
								 @precioKm numeric(18,2),
								 @descripcion varchar(255),
								 @habilitado bit) 
AS
BEGIN
	Insert into [ASD].Turnos
	values(@inicio, @fin, @precioBase, @precioKm, @descripcion, @habilitado)
END
GO

CREATE PROCEDURE [ASD].SP_eliminarTodosTurnos 
AS
BEGIN
	SET NOCOUNT OFF;
	DELETE FROM [ASD].Turnos
	
	DELETE FROM [ASD].Turnos
	DBCC CHECKIDENT ('[ASD].Turnos', RESEED, 0)
END
GO

CREATE PROCEDURE [ASD].SP_deshabilitarTurno(@id int)
AS
BEGIN
	UPDATE [ASD].fx_getTurno(@id)
	SET Habilitado=0
END
GO

CREATE PROCEDURE [ASD].SP_habilitarTurno(@id int)
AS
BEGIN
	UPDATE [ASD].fx_getTurno(@id)
	SET Habilitado=1
END
GO


CREATE PROCEDURE [ASD].SP_modifTurno(
					@id int,
					@inicio numeric(18,0),
					@fin numeric(18,0),
					@precioBase numeric(18,2),
					@precioKm numeric(18,2),
					@descripcion varchar(255))
AS
BEGIN
	UPDATE [ASD].Turnos
	SET Hora_Inicio = @inicio,
		Hora_Fin = @fin,
		Precio_Base = @precioBase,
		Precio_km = @precioKM,
		Descripcion = @descripcion
	WHERE ID = @id
END
GO