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