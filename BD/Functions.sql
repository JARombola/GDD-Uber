USE GD1C2017
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Julian
-- Create date: 22/04/2017
-- Description:	Creacion de Funciones
-- =============================================

----------------------FUNCIONES DE AUTOS------------------------------
CREATE FUNCTION [MAIDEN].fx_filtrarAutos (@modelo varchar(255),			
								 @patente varchar(10),
								 @marca varchar(255),
								 @choferID int)
Returns Table
AS
	RETURN
		(Select a.ID as ID, a.Marca, a.Modelo,a.Patente,a.Licencia,a.Rodado,a.Habilitado,
		(c.Nombre+' '+c.Apellido) as Chofer, c.ID as IDChofer, t.ID as IDTurno,
		t.Descripcion as Turno 
		From [MAIDEN].Auto a 
		left join [MAIDEN].Chofer c on (a.Chofer = c.ID)
		left join [MAIDEN].Turno t on (a.Turno = t.ID)
		where 
			Modelo like '%'+@modelo+'%'
			OR
			Patente = @patente
			OR
			Marca = @marca
			OR
			Chofer = @choferID)
GO

CREATE FUNCTION [MAIDEN].fx_filtrarAutosHabilitados (@modelo varchar(255),			
								 @patente varchar(10),
								 @marca varchar(255),
								 @choferID int)
Returns Table
AS
	RETURN
		(Select * From [MAIDEN].fx_filtrarAutos(@modelo,@patente,@marca,@choferID) Where Habilitado = 1)
GO

CREATE FUNCTION [MAIDEN].fx_getAutoId(@patente varchar(10))
RETURNS INT AS
BEGIN
	RETURN(Select id from [MAIDEN].Auto Where Patente = @patente)
END;
GO

----------------------FUNCIONES DE CHOFERES------------------------------
CREATE FUNCTION [MAIDEN].fx_filtrarChoferes (@nombre varchar(255),			
								 @apellido varchar(255),
								 @DNI numeric(18,0))
Returns Table
AS
	RETURN
		(Select chofer.ID as ID, chofer.Nombre, chofer.Apellido, chofer.Dni, chofer.Mail,chofer.Telefono,
		chofer.Direccion,chofer.Localidad, chofer.Piso, chofer.Depto,
		chofer.Fecha_Nacimiento,chofer.Habilitado From [MAIDEN].Chofer chofer
		where 
			Nombre like '%'+ @nombre+ '%'
			OR
			Apellido like '%'+@apellido+'%'
			OR
			DNI = @DNI
		)
GO

CREATE FUNCTION [MAIDEN].fx_filtrarChoferesHabilitados (@nombre varchar(255),			
								 @apellido varchar(255),
								 @DNI numeric(18,0))
Returns Table
AS
	RETURN
		(Select * From [MAIDEN].fx_filtrarChoferes(@nombre, @apellido, @DNI) where habilitado = 1)
GO

CREATE FUNCTION [MAIDEN].fx_getChoferId(@Dni numeric(18,0))
RETURNS int 
as Begin
	return (Select id from [MAIDEN].Chofer where Dni = @Dni)
End;
GO
----------------------FUNCIONES DE CLIENTES------------------------------
CREATE FUNCTION [MAIDEN].fx_filtrarClientes (@nombre varchar(255),			
								 @apellido varchar(255),
								 @DNI numeric(18,0))
Returns Table
AS
	RETURN
		(Select cliente.ID as ID, cliente.Nombre, cliente.Apellido, cliente.Dni, cliente.Mail, cliente.Telefono,
		cliente.Direccion,cliente.Localidad, cliente.Piso, cliente.Depto,
		cliente.Fecha_Nacimiento,cliente.Habilitado From [MAIDEN].Cliente cliente
		where 
			Nombre like '%'+ @nombre+ '%'
			OR
			Apellido like '%'+@apellido+'%'
			OR
			DNI = @DNI
		)
GO

CREATE FUNCTION [MAIDEN].fx_filtrarClientesHabilitados (@nombre varchar(255),			
								 @apellido varchar(255),
								 @DNI numeric(18,0))
Returns Table
AS
	RETURN
		(Select * From [MAIDEN].fx_filtrarClientes(@nombre, @apellido, @DNI)where Habilitado = 1)
GO

CREATE FUNCTION [MAIDEN].fx_getClienteId(@dni int)
RETURNS INT
AS BEGIN
	RETURN(Select id from [MAIDEN].Cliente where DNI = @dni)
END;
GO
----------------------FUNCIONES DE TURNOS------------------------------
CREATE FUNCTION [MAIDEN].fx_filtrarTurnos (@descripcion varchar(255))		
Returns Table
AS
	RETURN
		(Select * From [MAIDEN].Turno where 
			Descripcion like '%'+ @descripcion+ '%')
GO

CREATE FUNCTION [MAIDEN].fx_filtrarTurnosHabilitados (@descripcion varchar(255))		
Returns Table
AS
	RETURN
		(Select * From [MAIDEN].fx_filtrarTurnos(@descripcion) where Habilitado = 1)
GO

CREATE FUNCTION [MAIDEN].fx_getTurnoId (@hora_inicio numeric(18,0))		
Returns int
AS BEGIN
	RETURN
		(Select ID From [MAIDEN].Turno t
		where @hora_inicio BETWEEN Hora_Inicio AND Hora_Fin-1)
	END;
GO

----------------------- BUSQUEDAS POR ID --------------------------
CREATE FUNCTION [MAIDEN].fx_getCliente(@id int)
RETURNS TABLE 
AS
RETURN 
(SELECT * From [MAIDEN].Cliente WHERE id = @id)
GO

CREATE FUNCTION [MAIDEN].fx_getChofer(@id int)
RETURNS TABLE 
AS
RETURN (SELECT * From [MAIDEN].Chofer WHERE id = @id)
GO

CREATE FUNCTION [MAIDEN].fx_getAuto(@id int)
RETURNS TABLE 
AS
RETURN (SELECT * From [MAIDEN].Auto WHERE id = @id)
GO

CREATE FUNCTION [MAIDEN].fx_getTurno(@id int)
RETURNS TABLE 
AS
RETURN (SELECT * From [MAIDEN].Turno WHERE id = @id)
GO

CREATE FUNCTION [MAIDEN].fx_getDescripcion(@id int)
RETURNS VARCHAR(256) 
AS
BEGIN
	RETURN (SELECT Descripcion From [MAIDEN].fx_getTurno(@id))
END;
GO

CREATE FUNCTION [MAIDEN].fx_getRol(@Id int)
RETURNS TABLE 
AS
RETURN (SELECT * From [MAIDEN].Rol WHERE ID = @id)
GO

CREATE FUNCTION [MAIDEN].fx_getRolId(@rol varchar(20))
RETURNS int 
AS
BEGIN
	RETURN (SELECT ID From [MAIDEN].Rol WHERE Rol = @rol)
END;
GO

CREATE FUNCTION [MAIDEN].fx_getNombreChofer(@id int)
RETURNS nvarchar(255)
AS BEGIN
	RETURN (SELECT Nombre+' '+Apellido From [MAIDEN].fx_getChofer(@id))
	END
GO

CREATE FUNCTION [MAIDEN].fx_getUsuario(@user varchar(30))
RETURNS TABLE 
AS
RETURN (SELECT * From [MAIDEN].Usuario WHERE Usuario = @user)
GO
-----------------------------------FUNCIONALIDADES
CREATE FUNCTION [MAIDEN].fx_getFuncionalidades(@idRol int)		-- Devuelve las funcionalidades activas del rol
RETURNS TABLE
AS
RETURN SELECT Funcionalidad from [MAIDEN].Funcionalidad_por_Rol where Rol = @idRol
GO

---------------------------------- LOGIN USUARIO
CREATE FUNCTION [MAIDEN].fx_getRolesDeUsuario(@usuario varchar(30))
RETURNS TABLE
AS
RETURN (Select Rol From [MAIDEN].Rol 
		Where ID IN (Select Rol FROM [MAIDEN].Rol_por_Usuario Where Usuario = @usuario))
GO

CREATE FUNCTION [MAIDEN].fx_getCantidadRolesDeUsuario(@usuario varchar(30))			--Devuelve la cantidad de roles que tiene ese usuario
RETURNS int																		--(Usada para otorgar funcionalidades)
AS
BEGIN
	RETURN (Select count(*) as 'Cantidad de Roles' FROM [MAIDEN].Rol_por_Usuario Where Usuario = @usuario)
END;
GO


CREATE FUNCTION [MAIDEN].fx_getRoles()			--Devuelve la cantidad de roles que tiene ese usuario
RETURNS TABLE																		--(Usada para otorgar funcionalidades)
AS
	RETURN (Select Rol,Habilitado FROM [MAIDEN].Rol)
GO

CREATE FUNCTION [MAIDEN].fx_getRolesHabilitados()			--Devuelve la cantidad de roles que tiene ese usuario
RETURNS TABLE																		--(Usada para otorgar funcionalidades)
AS
	RETURN (Select * FROM [MAIDEN].fx_getRoles() where Habilitado = 1)
GO


----------------------- FUNCION PARA LOS VIAJES
-- Devuelve los datos del Auto para autocompletar el viaje una vez seleccionado el chofer

CREATE FUNCTION [MAIDEN].fx_getAutoDelChofer(@idChofer int)
Returns Table
AS Return(
		Select a.*,t.Hora_Inicio,t.Hora_Fin from [MAIDEN].Auto a LEFT JOIN [MAIDEN].Turno t on (a.Turno =t.ID)
		where
		(Chofer = @idChofer 
		AND a.Habilitado = 1)
	)
GO

--------------------------------------------------------------- RENDICION

CREATE FUNCTION [MAIDEN].fx_getDatosRendicion(@nroRendicion numeric(18,0))
RETURNS TABLE
AS
RETURN(
	Select c.nombre+' '+c.apellido as Cliente, 
		FORMAT(viaje.Fecha,'HH:mm') as Inicio,
		FORMAT(viaje.Hora_Fin,'HH:mm') as 'Hora Fin',
		viaje.Km as 'Distancia(Kms)', 
		turno.Precio_Base as 'Precio Base',
		turno.Precio_km as 'Precio Km',
		(turno.Precio_Base+turno.Precio_km*viaje.Km) as 'Precio del Viaje',
		(turno.Precio_Base+turno.Precio_km*viaje.Km)*0.3 as 'Importe(30%)', 
		null as 'Total del Dia'
		FROM [MAIDEN].Cliente c join [MAIDEN].Viaje viaje on (c.ID = viaje.Cliente) join [MAIDEN].Turno turno on (turno.ID = viaje.Turno)
		Where viaje.NroRendicion = @nroRendicion)
GO

CREATE FUNCTION [MAIDEN].fx_getRendicionExistente(@nroRendicion numeric(18,0))
RETURNS TABLE
AS
RETURN(
	Select * FROM [MAIDEN].fx_getDatosRendicion(@nroRendicion)
	UNION
	SELECT null,null,null,null,null,null,null,null,Importe_Total from [Maiden].Rendicion
	WHERE Nro=@nroRendicion
)
GO


------------------------------------------------------------- FACTURA
CREATE FUNCTION [MAIDEN].fx_getDatosFactura(@nroFactura numeric(18,0))
RETURNS TABLE
AS
RETURN(
	Select CAST(viaje.Fecha as Date)as 'Fecha',
		   FORMAT (viaje.Fecha,'HH:mm') as Inicio,
		   FORMAT(viaje.Hora_Fin,'HH:mm') as 'Fin',
		   viaje.Km as 'Distancia(Kms)',
		   turno.Precio_Base as 'Precio Base',
		   turno.Precio_km as 'Precio Km', 
		   (turno.Precio_Base+turno.Precio_km*viaje.Km) as 'Precio del Viaje',
		   null as 'Total de Factura'
		FROM [MAIDEN].Viaje viaje join [MAIDEN].Turno turno on (viaje.Turno = turno.ID) 
						 join [MAIDEN].Chofer chofer on (chofer.ID = viaje.Chofer)
		Where Viaje.NroFactura = @nroFactura
		)
GO

CREATE FUNCTION [MAIDEN].fx_getFacturaExistente(@nroFactura numeric(18,0))
RETURNS TABLE
AS
RETURN(
	Select * FROM [MAIDEN].fx_getDatosFactura(@nroFactura)
	UNION
	SELECT null,null,null,null,null,null,null,Importe_Total from [Maiden].Factura
	WHERE Nro=@nroFactura
)
GO
------------------------------------------------------------ ESTADISTICAS

CREATE FUNCTION [MAIDEN].fx_choferesMayorRecaudacion(@anio int, @trimestre int)
RETURNS TABLE
AS
RETURN(

		SELECT TOP 5 (c.Nombre+' '+c.Apellido) as Chofer,
		count(*) as 'Cantidad de Viajes',
		sum(Importe_Total) as Total
		from [MAIDEN].Rendicion r join [MAIDEN].Chofer c on (r.Chofer = c.ID)
		where year(r.fecha)=@anio AND DATEPART(qq,r.Fecha)=@trimestre 
		Group by r.Chofer, c.Nombre, c.Apellido, c.Direccion, c.Telefono, c.Mail
		order by sum(Importe_Total) desc
)
GO

CREATE FUNCTION [MAIDEN].fx_choferesViajesMasLargos(@anio int,@trimestre int)
RETURNS TABLE
AS
RETURN(
		SELECT TOP 5 (c.Nombre+' '+c.apellido)as Chofer,max(DATEDIFF(MI,cast(Fecha as time),Hora_Fin))as Duracion
		FROM [MAIDEN].Viaje v join [MAIDEN].Chofer c on (v.Chofer = c.ID)
		WHERE YEAR(v.fecha) = @anio AND DATEPART(qq,v.Fecha)=@trimestre AND v.Hora_Fin is not null
		GROUP BY c.Nombre,c.Apellido,c.Dni
		ORDER BY Duracion DESC
)
GO

CREATE FUNCTION [MAIDEN].fx_clientesMayorConsumo(@anio int,@trimestre int)
RETURNS TABLE
AS
RETURN(
		SELECT TOP 5 (c.Nombre+' '+c.Apellido) as Cliente,sum(Importe_Total) as Consumo 
		from [MAIDEN].Factura f join [MAIDEN].Cliente c on (f.Cliente = c.ID)
		WHERE year(f.Fecha) = @anio AND DATEPART(qq,f.Fecha) = @trimestre
		GROUP BY f.Cliente, c.nombre, c.Apellido
		ORDER BY Consumo Desc
)
GO

CREATE FUNCTION [MAIDEN].fx_clientesMismoAuto(@anio int,@trimestre int)
RETURNS TABLE
AS
RETURN(
		SELECT TOP 5 (c.Nombre+' '+c.Apellido)AS Cliente, 
				(SELECT a.Patente FROM MAIDEN.Viaje V JOIN MAIDEN.Auto a on (a.ID = V.Auto) WHERE V.Cliente=Cliente AND YEAR(FECHA)=@anio AND DATEPART(qq,Fecha) = @trimestre
				GROUP BY CLIENTE,a.Patente 
				HAVING COUNT(*)=X.VIAJES) AS Patente
				,X.Viajes 
				FROM(
					SELECT CLIENTE, MAX(CANTIDAD) AS VIAJES FROM
						(SELECT CLIENTE,COUNT(*)AS CANTIDAD FROM MAIDEN.VIAJE
							WHERE YEAR(FECHA)=@anio AND DATEPART(qq,Fecha) = @trimestre
							GROUP BY CLIENTE,AUTO
						)A
						GROUP BY CLIENTE)X JOIN [MAIDEN].Cliente c ON (X.Cliente=c.ID)
						ORDER BY VIAJES DESC
)
GO

