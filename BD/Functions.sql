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
-- =============================================
--					**  AUTOS  **
-- =============================================
CREATE FUNCTION [MAIDEN].fx_filtrarAutos (@modelo varchar(255),			
								 @patente varchar(10),
								 @marca varchar(255),
								 @choferID int)
RETURNS TABLE
AS RETURN
		(Select a.ID, a.Marca, a.Modelo,a.Patente,a.Licencia,a.Rodado, a.Habilitado,
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
RETURNS TABLE
AS RETURN
		(Select a.ID as ID, a.Marca, a.Modelo,a.Patente,a.Licencia,a.Rodado, a.Habilitado,
		(c.Nombre+' '+c.Apellido) as Chofer, c.ID as IDChofer, t.ID as IDTurno,
		t.Descripcion as Turno 
		From [MAIDEN].Auto a 
		left join [MAIDEN].Chofer c on (a.Chofer = c.ID)
		left join [MAIDEN].Turno t on (a.Turno = t.ID)
		where 
			(Modelo like '%'+@modelo+'%'
			OR
			Patente = @patente
			OR
			Marca = @marca
			OR
			Chofer = @choferID) AND a.Habilitado = 1)
GO

CREATE FUNCTION [MAIDEN].fx_getMarcas()
RETURNS TABLE
AS RETURN 
		(SELECT DISTINCT Marca FROM [MAIDEN].Auto)
GO

-- =============================================
--					**  CHOFERES  **
-- =============================================
CREATE FUNCTION [MAIDEN].fx_filtrarChoferes (@nombre varchar(255),			
								 @apellido varchar(255),
								 @DNI numeric(18,0))
RETURNS TABLE
AS RETURN(
		Select chofer.ID as ID, chofer.Nombre, chofer.Apellido, chofer.Dni, chofer.Mail,chofer.Telefono,
			chofer.Direccion,chofer.Localidad, chofer.Piso, chofer.Depto,
			chofer.Fecha_Nacimiento, chofer.habilitado From [MAIDEN].Chofer chofer
		WHERE Nombre like '%'+ @nombre+ '%'
			  OR
			  Apellido like '%'+@apellido+'%'
			  OR
			  DNI = @DNI)
GO

CREATE FUNCTION [MAIDEN].fx_filtrarChoferesHabilitados (@nombre varchar(255),			
								 @apellido varchar(255),
								 @DNI numeric(18,0))
RETURNS TABLE
AS RETURN
		(	Select chofer.ID as ID, chofer.Nombre, chofer.Apellido, chofer.Dni, chofer.Mail,chofer.Telefono,
			chofer.Direccion,chofer.Localidad, chofer.Piso, chofer.Depto,
			chofer.Fecha_Nacimiento,chofer.Habilitado From [MAIDEN].Chofer chofer
		WHERE ((Nombre like '%'+ @nombre+ '%'
			  OR
			  Apellido like '%'+@apellido+'%'
			  OR
			  DNI = @DNI) AND Habilitado=1)
			  )
GO

-- =============================================
--					**  CLIENTES  **
-- =============================================
CREATE FUNCTION [MAIDEN].fx_filtrarClientes (@nombre varchar(255),			
								 @apellido varchar(255),
								 @DNI numeric(18,0))
RETURNS TABLE
AS RETURN
		(Select cliente.ID as ID, cliente.Nombre, cliente.Apellido, cliente.Dni, cliente.Mail, cliente.Telefono,
		cliente.Direccion,cliente.Localidad, cliente.Piso, cliente.Depto,
		cliente.Fecha_Nacimiento, cliente.Habilitado From [MAIDEN].Cliente cliente
		WHERE Nombre like '%'+ @nombre+ '%'
				OR
			  Apellido like '%'+@apellido+'%'
				OR
			  DNI = @DNI)
GO

CREATE FUNCTION [MAIDEN].fx_filtrarClientesHabilitados (@nombre varchar(255),			
								 @apellido varchar(255),
								 @DNI numeric(18,0))
RETURNS TABLE
AS RETURN
		(Select cliente.ID as ID, cliente.Nombre, cliente.Apellido, cliente.Dni, cliente.Mail, cliente.Telefono,
		cliente.Direccion,cliente.Localidad, cliente.Piso, cliente.Depto,
		cliente.Fecha_Nacimiento, cliente.Habilitado From [MAIDEN].Cliente cliente
		WHERE (Nombre like '%'+ @nombre+ '%'
				OR
			  Apellido like '%'+@apellido+'%'
				OR
			  DNI = @DNI) AND Habilitado = 1)
GO

-- =============================================
--					**  TURNOS  **
-- =============================================
CREATE FUNCTION [MAIDEN].fx_filtrarTurnos (@descripcion varchar(255))		
RETURNS TABLE
AS RETURN
		(Select t.ID,t.Descripcion,t.Hora_Inicio,t.Hora_Fin,t.Precio_Base,t.Precio_km, t.Habilitado From [MAIDEN].Turno t where 
			Descripcion like '%'+ @descripcion+ '%' AND Respaldo = 0)
GO

CREATE FUNCTION [MAIDEN].fx_filtrarTurnosHabilitados (@descripcion varchar(255))		
RETURNS TABLE
AS RETURN
		(Select t.ID,t.Descripcion,t.Hora_Inicio,t.Hora_Fin,t.Precio_Base,t.Precio_km,t.Habilitado From [MAIDEN].Turno t where 
			Descripcion like '%'+ @descripcion+ '%' AND Respaldo = 0 
			AND Habilitado = 1)
GO

-- =============================================
--					**  ROLES  **
-- =============================================
CREATE FUNCTION [MAIDEN].fx_getRolId(@rol varchar(20))
RETURNS INT 
AS
BEGIN
	RETURN (SELECT ID From [MAIDEN].Rol WHERE Rol = @rol)
END;
GO

-- =============================================
--					**  FUNCIONALIDADES  **
-- =============================================
CREATE FUNCTION [MAIDEN].fx_getFuncionalidades(@idRol int)		-- Devuelve las funcionalidades del rol
RETURNS TABLE
AS
RETURN SELECT Funcionalidad from [MAIDEN].Funcionalidad_por_Rol where Rol = @idRol
GO
-- =============================================
--					**  USUARIOS  **
-- =============================================
CREATE FUNCTION [MAIDEN].fx_getUsuarios()			-- Devuelve todos los usuarios registrados
RETURNS TABLE
AS
RETURN (Select Usuario From [MAIDEN].Usuario)
GO

CREATE FUNCTION [MAIDEN].fx_getRolesDeUsuario(@usuario varchar(30))		-- Devuelve los nombres de los roles del usuario
RETURNS TABLE
AS
RETURN (Select Rol From [MAIDEN].Rol 
		Where ID IN (Select Rol FROM [MAIDEN].Rol_por_Usuario Where Usuario = @usuario))
GO

-- =============================================
--					**  ROLES  **
-- =============================================
CREATE FUNCTION [MAIDEN].fx_getRoles()			-- Devuelve los roles existentes
RETURNS TABLE
AS
	RETURN (Select Rol,Habilitado FROM [MAIDEN].Rol)
GO

CREATE FUNCTION [MAIDEN].fx_getRolesHabilitados()			
RETURNS TABLE
AS
	RETURN (Select * FROM [MAIDEN].fx_getRoles() where Habilitado = 1)
GO
-- =============================================
--					**  VIAJES  **
-- =============================================
-- Devuelve los datos del Auto para autocompletar el viaje una vez seleccionado el chofer
CREATE FUNCTION [MAIDEN].fx_getAutoDelChofer(@idChofer int)
RETURNS TABLE 
AS RETURN(
			Select a.*,t.Hora_Inicio,t.Hora_Fin from [MAIDEN].Auto a 
							LEFT JOIN [MAIDEN].Turno t on (a.Turno =t.ID)
			where Chofer = @idChofer 
			AND a.Habilitado = 1)
GO

-- =============================================
--					**  RENDICION  **
-- =============================================
-- Devuelve los datos de la rendicion que ESTÁ SIENDO REGISTRADA (Se usa en SP_Rendicion)
-- La diferencia con la funcion siguiente es que aún no tenemos el total de la rendición
CREATE FUNCTION [MAIDEN].fx_getDatosRendicion(@nroRendicion numeric(18,0))
RETURNS TABLE
AS
RETURN(
	Select c.nombre+' '+c.apellido as Cliente, 
		FORMAT(viaje.Fecha,'HH:mm') as 'Hora Inicio',
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

-- Devuelve los datos de la rendicion que YA había sido registrada. (Por eso podemos obtener el total directamente)
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

-- =============================================
--					**  FACTURA  **
-- =============================================
-- Devuelve los datos de la factura que ESTÁ SIENDO REGISTRADA (Se usa en SP_Facturacion)
-- La diferencia con la funcion siguiente es que aún no tenemos el total de la factura
CREATE FUNCTION [MAIDEN].fx_getDatosFactura(@nroFactura numeric(18,0))
RETURNS TABLE
AS
RETURN(
	Select CAST(viaje.Fecha as Date)as 'Fecha',
		   FORMAT (viaje.Fecha,'HH:mm') as 'Hora Inicio',
		   FORMAT(viaje.Hora_Fin,'HH:mm') as 'Hora Fin',
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

-- Devuelve los datos de la factura que YA había sido registrada. (Por eso podemos obtener el total directamente)
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

-- =============================================
--					**  ESTADISTICAS  **
-- =============================================
-- 1) Se agrupan las rendiciones por chofer
-- 2) Se suman los importes de cada una de la rendicion (Total)
-- 3) Se ordenan de forma descendente según el Total (es decir, quedaran primeros los de mayor recaudación)
-- 4) Se muestran los datos de los 5 primeros. (es decir, los 5 de mayor recaudación)
CREATE FUNCTION [MAIDEN].fx_choferesMayorRecaudacion(@anio int, @trimestre int)
RETURNS TABLE
AS
RETURN(
		SELECT TOP 5 (
			c.Nombre+' '+c.Apellido) as Chofer,
			count(*) as 'Cantidad de Viajes',
			sum(Importe_Total) as Total	
			from [MAIDEN].Rendicion r join [MAIDEN].Chofer c on (r.Chofer = c.ID)
			where year(r.fecha)=@anio AND DATEPART(qq,r.Fecha)=@trimestre 
			Group by r.Chofer, c.Nombre, c.Apellido, c.Direccion, c.Telefono, c.Mail
			order by sum(Importe_Total) desc
)
GO

-- 1) Los viajes se ordenan, para cada chofer, de forma descendente segun la duracion de los mismos (Hora fin - hora inicio)
--		(la numeracion de las filas se reinicia para cada chofer)
-- 2) Se selecciona de los 5 primeros choferes su viaje mas largo (fila = 1)

CREATE FUNCTION [MAIDEN].fx_choferesViajesMasLargos(@anio int,@trimestre int)
RETURNS TABLE
AS
RETURN(
		SELECT TOP 5 (c.nombre+' '+c.Apellido) as Chofer,Resultados.Fecha,a.Patente,Duracion 
				FROM (
					SELECT v.Chofer,
							v.Auto,
							ROW_NUMBER() OVER (PARTITION BY v.Chofer ORDER BY DATEDIFF(MI,cast(v.fecha as time),v.Hora_Fin) DESC) AS fila,
							DATEDIFF(MI,cast(v.fecha as time),v.Hora_Fin) as Duracion,
							v.Fecha
					FROM [MAIDEN].Viaje v
					WHERE YEAR(v.fecha) = @anio AND DATEPART(qq,v.Fecha)=@trimestre AND v.Hora_Fin is not null
					)Resultados 
							JOIN [MAIDEN].Chofer c on Resultados.Chofer = c.ID
							JOIN MAIDEN.Auto a on (Resultados.Auto = a.ID)
				WHERE Resultados.fila = 1
				ORDER BY Duracion DESC
)
GO
-- 1) Se agrupan las facturas por cliente
-- 2) Para cada cliente se suman los importes de cada una de estas facturas
-- 3) Se ordenan de mayor a menor según el total de cada cliente (quedarán primeros los de mayor consumo)
-- 4) Se seleccionan los 5 primeros clientes (es decir, los de mayor recaudación)
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

-- 1) Los viajes se ordenan, para cada cliente, en forma descendente segun la cantidad de veces que utilizó el mismo auto
--				(la numeracion de las filas se reinicia para cada cliente)
-- 2)  Se selecciona de los 5 primeros clientes el vehículo con el que mayor viajes realizó (fila = 1).
CREATE FUNCTION [MAIDEN].fx_clientesMismoAuto(@anio int,@trimestre int)
RETURNS TABLE
AS
RETURN(
		SELECT TOP 5 (cliente.nombre+' '+cliente.Apellido)as Cliente,auto.Marca, auto.Patente,Viajes
				FROM ( SELECT v.cliente, v.Auto,
						 ROW_NUMBER() OVER (PARTITION BY v.Cliente ORDER BY count(*) DESC) AS fila,
						 count(*) as Viajes
				   FROM MAIDEN.Viaje v
				   WHERE YEAR(FECHA)=@anio AND DATEPART(qq,Fecha) = @trimestre
				   GROUP BY v.Cliente,v.Auto)Resultados JOIN [MAIDEN].Cliente cliente ON (Resultados.Cliente = cliente.ID)
														JOIN [MAIDEN].Auto auto on (Resultados.Auto = auto.ID)
				   WHERE Resultados.fila = 1
				   ORDER BY Viajes DESC
)
GO
