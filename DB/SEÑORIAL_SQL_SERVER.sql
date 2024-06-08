CREATE SCHEMA Almacen 
GO
CREATE SCHEMA Produccion 
GO
CREATE SCHEMA Generico
GO
CREATE SCHEMA Usuarios
GO
CREATE SCHEMA Ventas
GO

CREATE TABLE Ventas.ambiente
(
	id_ambiente          int IDENTITY (1,1) ,
	nombre               nvarchar(100) NOT NULL,
	id_mesa				 int not null
)
go
ALTER TABLE Ventas.ambiente
	ADD CONSTRAINT ambiente_id_pk PRIMARY KEY  CLUSTERED (id_ambiente ASC);
go
CREATE TABLE Ventas.cajas
(
	id_caja              int IDENTITY (1,1) ,
	numero_caja          nvarchar(100) NOT NULL,
)
go
ALTER TABLE Ventas.cajas
	ADD CONSTRAINT caja_id_pk PRIMARY KEY  CLUSTERED (id_caja ASC);
go

CREATE TABLE Almacen.categorias
(
	id_categoria         int IDENTITY (1,1) ,
	nombre               nvarchar(100)  NOT NULL, 
	id_categoria_padre   int  NULL,
)
go
ALTER TABLE Almacen.categorias
	ADD CONSTRAINT categoria_id_pk PRIMARY KEY  CLUSTERED (id_categoria ASC);
go
ALTER TABLE Almacen.categorias
    ADD CONSTRAINT categorias_nombre_uk UNIQUE (nombre);
GO
ALTER TABLE Almacen.categorias
ADD CONSTRAINT categorias_padre_fk FOREIGN KEY (id_categoria_padre) REFERENCES Almacen.categorias(id_categoria)
		ON DELETE NO ACTION
		ON UPDATE NO ACTION
GO

CREATE TABLE Ventas.cliente
(
	id_cliente           int IDENTITY (1,1) ,
	id_persona           int  NOT NULL 
)
go
ALTER TABLE Ventas.cliente
	ADD CONSTRAINT cliente_id_pk PRIMARY KEY  CLUSTERED (id_cliente ASC);
go

CREATE TABLE Ventas.apertura_cajas
(
	id_apertura          int IDENTITY (1,1) ,
	id_caja		         int  NOT NULL ,
	id_usuario           int  NOT NULL,
	monto_inicio		 decimal(10,2) NOT NULL,
	hora_fecha_inicio	 datetime NOt NULL,
	activo			     bit NOT NULL,
	monto_cierre		 decimal(10,2) NULL,
	hora_fecha_cierre	 datetime NOT NULL,
)
go
ALTER TABLE Ventas.apertura_cajas
	ADD CONSTRAINT apertura_caja_id_pk PRIMARY KEY  CLUSTERED (id_apertura ASC);
go

CREATE TABLE Almacen.compra
(
	id_compra            int IDENTITY (1,1) ,
	id_proveedor         int  NOT NULL ,
	id_voucher           int  NOT NULL 
)
go
ALTER TABLE Almacen.compra
	ADD CONSTRAINT compra_id_pk PRIMARY KEY  CLUSTERED (id_compra ASC);
go

CREATE TABLE Almacen.detalle_compra
(
	id_compra            int  NOT NULL ,
	id_insumo            int  NOT NULL ,
	cantidad             int  NULL ,
	precio_compra        decimal(10,2)  NULL ,
	fecha_expiracion     datetime  NULL 
)
go
ALTER TABLE Almacen.detalle_compra
	ADD CONSTRAINT detalle_compra_id_pk PRIMARY KEY  CLUSTERED (id_compra ASC,id_insumo ASC);
go

CREATE TABLE Usuarios.detalle_dash_menu
(
	id_menu              int  NOT NULL ,
	id_rol               int  NOT NULL ,
	descripcion          nvarchar(100)  NULL 
)
go
ALTER TABLE Usuarios.detalle_dash_menu
	ADD CONSTRAINT detalle_dash_menu_id_pk PRIMARY KEY  CLUSTERED (id_menu ASC,id_rol ASC);
go

CREATE TABLE Almacen.detalle_inventario
(
	id_det_inventario    int IDENTITY (1,1) ,
	id_inventario        int  NOT NULL ,
	id_insumo            int  NOT NULL ,
	stock_total          int  NOT NULL ,
	id_estado            int  NOT NULL 
)
go
ALTER TABLE Almacen.detalle_inventario
	ADD CONSTRAINT detalle_inventario_id_pk PRIMARY KEY  CLUSTERED (id_det_inventario ASC);
go

CREATE TABLE Produccion.detalle_produccion
(
	id_produccion        int  NOT NULL ,
	id_producto_sucursal int  NOT NULL ,
	cantidad_salida      int  NULL ,
	fecha_salida         datetime  NULL 
)
go
ALTER TABLE Produccion.detalle_produccion
	ADD CONSTRAINT detalle_produccion_id_pk PRIMARY KEY  CLUSTERED (id_produccion ASC,id_producto_sucursal ASC);
go

CREATE TABLE Ventas.detalle_ventas
(
	id_det_venta         int  NOT NULL IDENTITY(1,1) ,
	cantidad             int  NULL ,
	precio_unitario      decimal(10,2)  NULL ,
	id_venta             int  NOT NULL ,
	id_producto_sucursal int  NOT NULL 
)
go
ALTER TABLE Ventas.detalle_ventas
	ADD CONSTRAINT detalle_venta_id_pk PRIMARY KEY  CLUSTERED (id_det_venta ASC);
go

CREATE TABLE Ventas.documentos
(
	id_documento         int IDENTITY (1,1) ,
	nro_documento        nvarchar(100)  NULL ,
	id_comprobante       int  NOT NULL 
)
go
ALTER TABLE Ventas.documentos
	ADD CONSTRAINT documento_id_pk PRIMARY KEY  CLUSTERED (id_documento ASC)
go

CREATE TABLE Ventas.empleado
(
	id_empleado          int IDENTITY (1,1) ,
	id_rol               int  NOT NULL ,
	id_persona           int  NOT NULL ,
	id_sucursal          int  NOT NULL 
)
go
ALTER TABLE Ventas.empleado
	ADD CONSTRAINT empleado_id_pk PRIMARY KEY  CLUSTERED (id_empleado ASC);
go

CREATE TABLE Almacen.entradas
(
	id_inventario        int  NOT NULL ,
	id_compra            int  NOT NULL ,
	fecha_Ingreso        DATETIME  NULL ,
	cantidad             int  NULL 
)
go
ALTER TABLE Almacen.entradas
	ADD CONSTRAINT entrada_id_pk PRIMARY KEY  CLUSTERED (id_inventario ASC,id_compra ASC);
go

CREATE TABLE Generico.estado
(
	id_estado            int IDENTITY (1,1) ,
	nombre               nvarchar(50)  NULL ,
	abreviacion          nvarchar(50)  NULL ,
	id_estado_padre      int NULL 
)
go
ALTER TABLE Generico.estado
	ADD CONSTRAINT estado_id_pk PRIMARY KEY  CLUSTERED (id_estado ASC);
go
ALTER TABLE Generico.estado
ADD CONSTRAINT estado_padre_fk FOREIGN KEY (id_estado_padre) REFERENCES Generico.estado(id_estado)
		ON DELETE NO ACTION
		ON UPDATE NO ACTION
GO

CREATE TABLE Generico.imagenes
(
	id_img               int IDENTITY (1,1) ,
	[url]                nvarchar(max)  NULL ,
	nombre               nvarchar(100)  NULL 
)
go
ALTER TABLE Generico.imagenes
	ADD CONSTRAINT imagenes_id_pk PRIMARY KEY  CLUSTERED (id_img ASC)
go

CREATE TABLE Almacen.insumo
(
	id_insumo            int IDENTITY (1,1) ,
	nombre               nvarchar(100)  NULL ,
	[url]                nvarchar(max)  NULL ,
	id_unidad            int  NOT NULL 
)
go
ALTER TABLE Almacen.insumo
	ADD CONSTRAINT insumo_id_pk PRIMARY KEY  CLUSTERED (id_insumo ASC)
go

CREATE TABLE Almacen.inventario
(
	id_inventario        int IDENTITY (1,1) ,
	id_sucursal          int  NOT NULL 
)
go
ALTER TABLE Almacen.inventario
	ADD CONSTRAINT inventario_id_pk PRIMARY KEY  CLUSTERED (id_inventario ASC)
go

CREATE TABLE Usuarios.menu_dash
(
	id_menu              int IDENTITY (1,1) ,
	nombre               nvarchar(100)  NULL ,
	descripcion          nvarchar(100)  NULL ,
	icono                nvarchar(50)  NULL ,
	data_target          nvarchar(50)  NULL ,
	[url]                nvarchar(max)  NULL ,
	parent               int  NULL 
)
go
ALTER TABLE Usuarios.menu_dash
	ADD CONSTRAINT dashboard_id_pk PRIMARY KEY  CLUSTERED (id_menu ASC)
go

CREATE TABLE Ventas.mesas
(
	id_mesa              int IDENTITY (1,1) ,
	nombre               nvarchar(100)  NULL 
)
go
ALTER TABLE Ventas.mesas
	ADD CONSTRAINT mesa_id_pk PRIMARY KEY  CLUSTERED (id_mesa ASC)
go

CREATE TABLE Ventas.metodo_pago
(
	id_metodo            int IDENTITY (1,1) ,
	descripcion          nvarchar(100)  NULL 
)
go
ALTER TABLE Ventas.metodo_pago
	ADD CONSTRAINT metodo_pago_id_pk PRIMARY KEY  CLUSTERED (id_metodo ASC);
go


CREATE TABLE Usuarios.persona_juridicas
(
	razon_social         nvarchar(100)  NULL ,
	nombre_comercial     nvarchar(100)  NULL ,
	id_persona           int  NOT NULL 
)
go
ALTER TABLE Usuarios.persona_juridicas
	ADD CONSTRAINT persona_juridica_id_pk PRIMARY KEY  CLUSTERED (id_persona ASC);
go

CREATE TABLE Usuarios.persona_natural
(
	primer_nombre        nvarchar(100)  NULL ,
	segundo_nombre       nvarchar(100)  NULL ,
	apellido_paterno     nvarchar(100)  NULL ,
	apellido_materno     nvarchar(100)  NULL ,
	id_persona           int  NOT NULL 
)
go
ALTER TABLE Usuarios.persona_natural
	ADD CONSTRAINT persona_natural_id_pk PRIMARY KEY  CLUSTERED (id_persona ASC);
go

CREATE TABLE Usuarios.personas
(
	id_persona           int IDENTITY (1,1) ,
	nro_Documento        nvarchar(12)  NULL ,
	correo               nvarchar(50)  NULL ,
	telefono             nvarchar(12)  NULL ,
	direccion            nvarchar(100)  NULL ,
	tipo_documento       nvarchar(100)  NOT NULL ,
	genero				 nvarchar(20)  NOT NULL ,
	tipo_persona         nvarchar(50)  NULL 
)
go
ALTER TABLE Usuarios.personas
	ADD CONSTRAINT persona_id_pk PRIMARY KEY  CLUSTERED (id_persona ASC);
go
ALTER TABLE Usuarios.personas
    ADD CONSTRAINT personas_email_uk UNIQUE (correo) 
GO
ALTER TABLE Usuarios.personas
    ADD CONSTRAINT personas_phone_uk UNIQUE (telefono)
GO

CREATE TABLE Produccion.produccion
(
	id_produccion        int IDENTITY (1,1) ,
	cantidad_total       int  Not NULL,
	motivo				 nvarchar(200) not null,
)
go
ALTER TABLE Produccion.produccion
	ADD CONSTRAINT produccion_id_pk PRIMARY KEY  CLUSTERED (id_produccion ASC)
go

CREATE TABLE Ventas.producto_sucursal
(
	id_producto_sucursal int IDENTITY (1,1) ,
	id_unidad            int  NOT NULL ,
	id_categoria         int  NOT NULL ,
	id_sucursal          int  NOT NULL ,
	id_producto          int  NOT NULL ,
	precio               decimal(10,2)  NULL ,
	cantidad             int  NULL ,
)
go
ALTER TABLE Ventas.producto_sucursal
	ADD CONSTRAINT producto_local_id_pk PRIMARY KEY  CLUSTERED (id_producto_sucursal ASC)
go

CREATE TABLE Ventas.productos
(
	id_producto          int IDENTITY (1,1) ,
	nombre               nvarchar(100)  NULL ,
	descripcion          nvarchar(100)  NULL ,
	derivar				 nvarchar(100) Not NULL,
	id_img               int  NOT NULL 
)
go
ALTER TABLE Ventas.productos
	ADD CONSTRAINT producto_id_pk PRIMARY KEY  CLUSTERED (id_producto ASC)
go

CREATE TABLE Almacen.proveedor
(
	id_proveedor         int IDENTITY (1,1) ,
	id_persona           int  NOT NULL ,
	vende                nvarchar(50)  NULL 
)
go
ALTER TABLE Almacen.proveedor
	ADD CONSTRAINT proveedor_id_pk PRIMARY KEY  CLUSTERED (id_proveedor ASC)
go

CREATE TABLE Usuarios.roles
(
	id_rol               int IDENTITY (1,1) ,
	nombre               nvarchar(100)  NULL ,
	abreviacion          nvarchar(10)  NULL ,
	descripcion          nvarchar(100)  NULL ,
	id_estado            int NOT NULL
)
GO
ALTER TABLE Usuarios.roles
	ADD CONSTRAINT roles_id_pk PRIMARY KEY  CLUSTERED (id_rol ASC)
GO

CREATE TABLE Produccion.salidas
(
	id_det_inventario    int  NOT NULL ,
	id_produccion        int  NOT NULL ,
	cantidad             int  NULL ,
	id_sucursal          int  NOT NULL 
)
go
ALTER TABLE Produccion.salidas
	ADD CONSTRAINT salida_id_pk PRIMARY KEY  CLUSTERED (id_det_inventario ASC,id_produccion ASC,id_sucursal ASC)
go

Create TABLE Generico.sucursal
(
	id_sucursal          int IDENTITY (1,1) ,
	id_ambiente			 int NOT NULL,
	nombre               nvarchar(100)  NULL ,
	direccion            nvarchar(200)  NULL ,
	id_ubigeo            int  NOT NULL ,
	id_documento         int  NOT NULL 
)
go
ALTER TABLE Generico.sucursal
	ADD CONSTRAINT sucursal_id_pk PRIMARY KEY  CLUSTERED (id_sucursal ASC)
go

CREATE TABLE Ventas.sucursal_usuario
(
	id_sucursal          int  NOT NULL ,
	id_usuario           int  NOT NULL ,
	descripcion          nvarchar(100)  NULL 
)
go
ALTER TABLE Ventas.sucursal_usuario
	ADD CONSTRAINT sucursal_id_usuario_pk PRIMARY KEY  CLUSTERED (id_sucursal ASC,id_usuario ASC)
go

CREATE TABLE Ventas.tipo_comprobantes
(
	id_comprobante       int IDENTITY (1,1) ,
	nombre               nvarchar(100)  NULL 
)
go
ALTER TABLE Ventas.tipo_comprobantes
	ADD CONSTRAINT tipo_comprobante_id_pk PRIMARY KEY  CLUSTERED (id_comprobante ASC)
go


CREATE TABLE Ventas.tipo_pedido
(
	id_tipo_pedido       int IDENTITY (1,1) ,
	descripcion          nvarchar(100)  NULL 
)
go
ALTER TABLE Ventas.tipo_pedido
	ADD CONSTRAINT tipo_pedido_id_pk PRIMARY KEY  CLUSTERED (id_tipo_pedido ASC)
go

CREATE TABLE Ventas.tipo_transaccion
(
	id_tipo_transaccion  int IDENTITY (1,1) ,
	nombre               nvarchar(100)  NULL ,
	descripcion          nvarchar(100)  NULL 
)
go
ALTER TABLE Ventas.tipo_transaccion
	ADD CONSTRAINT tipo_transaccion_id_pk PRIMARY KEY  CLUSTERED (id_tipo_transaccion ASC)
go

CREATE TABLE Generico.ubigeo
(
	id_ubigeo            int IDENTITY (1,1) ,
	codigo               nvarchar(12)  NULL ,
	distrito             nvarchar(100)  NULL ,
	provincia            nvarchar(100)  NULL ,
	departamento         nvarchar(100)  NULL 
)
go
ALTER TABLE Generico.ubigeo
	ADD CONSTRAINT ubigeo_id_pk PRIMARY KEY  CLUSTERED (id_ubigeo ASC)
go

CREATE TABLE Generico.unidad_medicion
(
	id_unidad            int IDENTITY (1,1) ,
	descripcion          nvarchar(50)  NULL ,
	abreviacion          nvarchar(50)  NULL 
)
go
ALTER TABLE Generico.unidad_medicion
	ADD CONSTRAINT unidad_medicion_id_pk PRIMARY KEY  CLUSTERED (id_unidad ASC)
go

CREATE TABLE Usuarios.usuario
(
	id_usuario           int IDENTITY (1,1) ,
	[user_name]          nvarchar(50)  NULL ,
	[password]           nvarchar(50)  NULL ,
	created_at           datetime  NULL DEFAULT(GETDATE()) ,
	id_persona           int  NOT NULL ,
	update_at            datetime  NULL ,
	id_rol               int  NOT NULL ,
	id_img               int NOT NULL
)
go
ALTER TABLE Usuarios.usuario
	ADD CONSTRAINT usuario_id_pk PRIMARY KEY  CLUSTERED (id_usuario ASC)
go
ALTER TABLE Usuarios.usuario
    ADD CONSTRAINT usuario_user_name_uk UNIQUE ([user_name]);
GO

CREATE TABLE Ventas.ventas
(
	id_venta             int IDENTITY (1,1) ,
	id_apertura			 int NOT NULL,
	id_voucher           int NOT NULL, 
	id_sucursal          int  NOT NULL ,
	id_cliente           int  NOT NULL ,
	id_estado            int  NOT NULL ,
	id_empleado          int  NOT NULL ,
	id_metodo            int  NOT NULL ,
	id_comprobante       int  NOT NULL ,
	nro_documento        nvarchar(50)  NULL ,
	nro_serie            nvarchar(50)  NULL ,
	id_tipo_pedido       int  NOT NULL ,
	fecha_venta          DATETIME  NULL DEFAULT(GETDATE()),
	costo_base           decimal(10,2)  NULL ,
	igv                  decimal(10,2)  NULL ,
	monto_total          decimal(10,2)  NULL ,
	vuelto	             decimal(10,2)  NULL ,
	observacion          nvarchar(100)  NULL ,
)
go
ALTER TABLE Ventas.ventas
	ADD CONSTRAINT venta_id_pk PRIMARY KEY  CLUSTERED (id_venta ASC)
go
ALTER TABLE Ventas.ventas
    ADD CONSTRAINT ventas_numero_documento_uk UNIQUE (nro_documento);
GO
ALTER TABLE Ventas.ventas
    ADD CONSTRAINT ventas_numero_serie_uk UNIQUE (nro_serie);
GO

CREATE TABLE Ventas.voucher
(
	id_voucher           int IDENTITY (1,1) ,
	fecha_emision        nvarchar(50)  NULL ,
	cantidad             nvarchar(50)  NULL ,
	precio_unitario      nvarchar(50)  NULL ,
	igv                  nvarchar(50)  NULL ,
	importe_total        nvarchar(50)  NULL ,
	id_estado            int  NOT NULL ,
	id_tipo_transaccion  int NOT NULL 
)
go
ALTER TABLE Ventas.voucher
	ADD CONSTRAINT voucher_id_pk PRIMARY KEY  CLUSTERED (id_voucher ASC)
go
-- ================
ALTER TABLE Ventas.cliente
	ADD CONSTRAINT persona_id_fk FOREIGN KEY (id_persona) REFERENCES Usuarios.personas(id_persona)
		ON DELETE NO ACTION
		ON UPDATE NO ACTION;
go

ALTER TABLE Almacen.compra
	ADD CONSTRAINT provedor_id_fk FOREIGN KEY (id_proveedor) REFERENCES Almacen.proveedor(id_proveedor)
		ON DELETE NO ACTION
		ON UPDATE NO ACTION;
go

ALTER TABLE Almacen.compra
	ADD CONSTRAINT voucher_id_fk FOREIGN KEY (id_voucher) REFERENCES Ventas.voucher(id_voucher)
		ON DELETE NO ACTION
		ON UPDATE NO ACTION;
go
ALTER TABLE Almacen.detalle_compra
	ADD CONSTRAINT compra_id_fk FOREIGN KEY (id_compra) REFERENCES Almacen.compra(id_compra)
		ON DELETE NO ACTION
		ON UPDATE NO ACTION;
go

ALTER TABLE Almacen.detalle_compra
	ADD CONSTRAINT insumo_id_fk FOREIGN KEY (id_insumo) REFERENCES Almacen.insumo(id_insumo)
		ON DELETE NO ACTION
		ON UPDATE NO ACTION;
go
ALTER TABLE Usuarios.detalle_dash_menu
	ADD CONSTRAINT menu_id_fk FOREIGN KEY (id_menu) REFERENCES Usuarios.menu_dash(id_menu)
		ON DELETE NO ACTION
		ON UPDATE NO ACTION;
go

ALTER TABLE Usuarios.detalle_dash_menu
	ADD CONSTRAINT rol_id_fk FOREIGN KEY (id_rol) REFERENCES Usuarios.roles(Id_Rol)
		ON DELETE NO ACTION
		ON UPDATE NO ACTION;
go
ALTER TABLE Almacen.detalle_inventario
	ADD CONSTRAINT inventario_id_fk FOREIGN KEY (id_inventario) REFERENCES Almacen.inventario(id_inventario)
		ON DELETE NO ACTION
		ON UPDATE NO ACTION;
go

ALTER TABLE Almacen.detalle_inventario
	ADD CONSTRAINT det_insumo_id_fk FOREIGN KEY (id_insumo) REFERENCES Almacen.insumo(id_insumo)
		ON DELETE NO ACTION
		ON UPDATE NO ACTION;
go

ALTER TABLE Almacen.detalle_inventario
	ADD CONSTRAINT estado_id_fk FOREIGN KEY (id_estado) REFERENCES Generico.estado(id_estado)
		ON DELETE NO ACTION
		ON UPDATE NO ACTION;
go

ALTER TABLE Produccion.detalle_produccion
	ADD CONSTRAINT produccion_id_fk FOREIGN KEY (id_produccion) REFERENCES Produccion.produccion(id_produccion)
		ON DELETE NO ACTION
		ON UPDATE NO ACTION;
go

ALTER TABLE Produccion.detalle_produccion
	ADD CONSTRAINT sucurusal_id_fk FOREIGN KEY (id_producto_sucursal) REFERENCES Ventas.producto_sucursal(id_producto_sucursal)
		ON DELETE NO ACTION
		ON UPDATE NO ACTION;
go
ALTER TABLE Ventas.detalle_ventas
	ADD CONSTRAINT venta_id_fk FOREIGN KEY (id_venta) REFERENCES Ventas.ventas(id_venta)
		ON DELETE NO ACTION
		ON UPDATE NO ACTION;
go

ALTER TABLE Ventas.detalle_ventas
	ADD CONSTRAINT producto_sucursal_id_fk FOREIGN KEY (id_producto_sucursal) REFERENCES Ventas.producto_sucursal(id_producto_sucursal)
		ON DELETE NO ACTION
		ON UPDATE NO ACTION;
go
ALTER TABLE Ventas.documentos
	ADD CONSTRAINT comprobante_tipo_id_fk FOREIGN KEY (id_comprobante) REFERENCES Ventas.tipo_comprobantes(id_comprobante)
		ON DELETE NO ACTION
		ON UPDATE NO ACTION
go
ALTER TABLE Ventas.empleado
	ADD CONSTRAINT rol_id_fk FOREIGN KEY (id_rol) REFERENCES Usuarios.roles(id_Rol)
		ON DELETE NO ACTION
		ON UPDATE NO ACTION;
go

ALTER TABLE Ventas.empleado
	ADD CONSTRAINT empleado_persona_id_fk FOREIGN KEY (id_persona) REFERENCES Usuarios.personas(id_persona)
		ON DELETE NO ACTION
		ON UPDATE NO ACTION;
go

ALTER TABLE Ventas.empleado
	ADD CONSTRAINT sucursal_id_fk FOREIGN KEY (id_sucursal) REFERENCES Generico.sucursal(id_sucursal)
		ON DELETE NO ACTION
		ON UPDATE NO ACTION;
go
ALTER TABLE Almacen.entradas
	ADD CONSTRAINT inventario_id_entrada_fk FOREIGN KEY (id_inventario) REFERENCES Almacen.inventario(id_inventario)
		ON DELETE NO ACTION
		ON UPDATE NO ACTION;
go

ALTER TABLE Almacen.entradas
	ADD CONSTRAINT compras_id_fk FOREIGN KEY (id_compra) REFERENCES Almacen.compra(id_compra)
		ON DELETE NO ACTION
		ON UPDATE NO ACTION;
go

ALTER TABLE Generico.estado
    ADD CONSTRAINT estado_descripcion_uk UNIQUE (nombre);
GO

ALTER TABLE Almacen.insumo
	ADD CONSTRAINT unidad_medida_id_fk FOREIGN KEY (id_unidad) REFERENCES Generico.unidad_medicion(id_unidad)
		ON DELETE NO ACTION
		ON UPDATE NO ACTION
go
ALTER TABLE Almacen.inventario
	ADD CONSTRAINT sucursal_id_fk FOREIGN KEY (id_sucursal) REFERENCES Generico.sucursal(id_sucursal)
		ON DELETE NO ACTION
		ON UPDATE NO ACTION
go
ALTER TABLE Usuarios.persona_juridicas
	ADD CONSTRAINT persona_id_fk FOREIGN KEY (id_persona) REFERENCES Usuarios.personas(id_persona)
		ON DELETE NO ACTION
		ON UPDATE NO ACTION;
go
ALTER TABLE Usuarios.persona_natural
	ADD CONSTRAINT personas_id_fk FOREIGN KEY (id_persona) REFERENCES Usuarios.personas(id_persona)
		ON DELETE NO ACTION
		ON UPDATE NO ACTION;
go
ALTER TABLE Usuarios.personas
    ADD CONSTRAINT personas_numero_documento_uk UNIQUE (nro_documento)
GO

ALTER TABLE Ventas.producto_sucursal
	ADD CONSTRAINT sucursales_id_fk FOREIGN KEY (id_sucursal) REFERENCES Generico.sucursal(id_sucursal)
		ON DELETE NO ACTION
		ON UPDATE NO ACTION
go

ALTER TABLE Ventas.producto_sucursal
	ADD CONSTRAINT producto_id_fk FOREIGN KEY (id_producto) REFERENCES Ventas.productos(id_producto)
		ON DELETE NO ACTION
		ON UPDATE NO ACTION
go

ALTER TABLE Ventas.producto_sucursal
	ADD CONSTRAINT unidad_medida_id_fk FOREIGN KEY (id_unidad) REFERENCES Generico.unidad_medicion(id_unidad)
		ON DELETE NO ACTION
		ON UPDATE NO ACTION
go
ALTER TABLE Ventas.producto_sucursal
	ADD CONSTRAINT categorias_id_fk FOREIGN KEY (id_categoria) REFERENCES Almacen.categorias(id_categoria)
		ON DELETE NO ACTION
		ON UPDATE NO ACTION
go

ALTER TABLE Ventas.productos
	ADD CONSTRAINT img_id_fk FOREIGN KEY (id_img) REFERENCES Generico.imagenes(id_img)
		ON DELETE NO ACTION
		ON UPDATE NO ACTION
go
ALTER TABLE Almacen.proveedor
	ADD CONSTRAINT proveedor_id_fk FOREIGN KEY (id_persona) REFERENCES Usuarios.personas(id_persona)
		ON DELETE NO ACTION
		ON UPDATE NO ACTION
go
ALTER TABLE Usuarios.roles
	ADD CONSTRAINT estado_id_fk FOREIGN KEY (id_estado) REFERENCES Generico.estado(id_estado)
		ON DELETE NO ACTION
		ON UPDATE NO ACTION
GO
ALTER TABLE Produccion.salidas
	ADD CONSTRAINT det_inventario_id_fk FOREIGN KEY (id_det_inventario) REFERENCES Almacen.detalle_inventario(id_det_inventario)
		ON DELETE NO ACTION
		ON UPDATE NO ACTION
go

ALTER TABLE Produccion.salidas
	ADD CONSTRAINT produccion_salida_id_fk FOREIGN KEY (id_produccion) REFERENCES Produccion.produccion(id_produccion)
		ON DELETE NO ACTION
		ON UPDATE NO ACTION
go

ALTER TABLE Produccion.salidas
	ADD CONSTRAINT sucursal_id_fk FOREIGN KEY (id_sucursal) REFERENCES Generico.sucursal(id_sucursal)
		ON DELETE NO ACTION
		ON UPDATE NO ACTION
go

ALTER TABLE Generico.sucursal
	ADD CONSTRAINT ubigeo_id_fk FOREIGN KEY (id_ubigeo) REFERENCES Generico.ubigeo(id_ubigeo)
		ON DELETE NO ACTION
		ON UPDATE NO ACTION
go

ALTER TABLE Generico.sucursal
	ADD CONSTRAINT documento_id_fk FOREIGN KEY (id_documento) REFERENCES Ventas.documentos(id_documento)
		ON DELETE NO ACTION
		ON UPDATE NO ACTION
go
ALTER TABLE Generico.sucursal
	ADD CONSTRAINT ambientes_id_fk FOREIGN KEY (id_ambiente) REFERENCES Ventas.ambiente(id_ambiente)
		ON DELETE NO ACTION
		ON UPDATE NO ACTION
go
ALTER TABLE Ventas.sucursal_usuario
	ADD CONSTRAINT sucursal_user_id_fk FOREIGN KEY (id_sucursal) REFERENCES Generico.sucursal(id_sucursal)
		ON DELETE NO ACTION
		ON UPDATE NO ACTION
go

ALTER TABLE Ventas.sucursal_usuario
	ADD CONSTRAINT usuario_id_fk FOREIGN KEY (id_usuario) REFERENCES Usuarios.usuario(id_usuario)
		ON DELETE NO ACTION
		ON UPDATE NO ACTION
go
ALTER TABLE Usuarios.usuario
	ADD CONSTRAINT personas_usuario_id_fk FOREIGN KEY (id_persona) REFERENCES Usuarios.personas(id_persona)
		ON DELETE NO ACTION
		ON UPDATE NO ACTION
go

ALTER TABLE Usuarios.usuario
	ADD CONSTRAINT roles_id_fk FOREIGN KEY (id_rol) REFERENCES Usuarios.roles(Id_Rol)
		ON DELETE NO ACTION
		ON UPDATE NO ACTION
go

ALTER TABLE Usuarios.usuario
	ADD CONSTRAINT img_id_fk FOREIGN KEY (id_img) REFERENCES Generico.imagenes(id_img)
		ON DELETE NO ACTION
		ON UPDATE NO ACTION
go
ALTER TABLE Ventas.ventas
	ADD CONSTRAINT cliente_id_fk FOREIGN KEY (id_cliente) REFERENCES Ventas.cliente(id_cliente)
		ON DELETE NO ACTION
		ON UPDATE NO ACTION
go
ALTER TABLE Ventas.ventas
	ADD CONSTRAINT apertura_caja_id_fk FOREIGN KEY (id_apertura) REFERENCES Ventas.apertura_cajas(id_apertura)
		ON DELETE NO ACTION
		ON UPDATE NO ACTION
go

ALTER TABLE Ventas.ventas
	ADD CONSTRAINT estado_id_fk FOREIGN KEY (id_estado) REFERENCES Generico.estado(id_estado)
		ON DELETE NO ACTION
		ON UPDATE NO ACTION
go

ALTER TABLE Ventas.ventas
	ADD CONSTRAINT sucursales_ventas_id_fk FOREIGN KEY (id_sucursal) REFERENCES Generico.sucursal(id_sucursal)
		ON DELETE NO ACTION
		ON UPDATE NO ACTION
go

ALTER TABLE Ventas.ventas
	ADD CONSTRAINT empleado_id_fk FOREIGN KEY (id_empleado) REFERENCES Ventas.empleado(id_empleado)
		ON DELETE NO ACTION
		ON UPDATE NO ACTION
go

ALTER TABLE Ventas.ventas
	ADD CONSTRAINT metodo_id_fk FOREIGN KEY (id_metodo) REFERENCES Ventas.metodo_pago(id_metodo)
		ON DELETE NO ACTION
		ON UPDATE NO ACTION
go

ALTER TABLE Ventas.ventas
	ADD CONSTRAINT comprobante_id_fk FOREIGN KEY (id_comprobante) REFERENCES Ventas.tipo_comprobantes(id_comprobante)
		ON DELETE NO ACTION
		ON UPDATE NO ACTION
go

ALTER TABLE Ventas.ventas
	ADD CONSTRAINT tipo_pedido_id_fk FOREIGN KEY (id_tipo_pedido) REFERENCES Ventas.tipo_pedido(id_tipo_pedido)
		ON DELETE NO ACTION
		ON UPDATE NO ACTION
go

ALTER TABLE Ventas.ventas
	ADD CONSTRAINT voucher_id_fk FOREIGN KEY (id_voucher) REFERENCES Ventas.voucher(id_voucher)
		ON DELETE NO ACTION
		ON UPDATE NO ACTION
go
ALTER TABLE Ventas.voucher
	ADD CONSTRAINT estados_id_fk FOREIGN KEY (id_estado) REFERENCES Generico.estado(id_estado)
		ON DELETE NO ACTION
		ON UPDATE NO ACTION
go

ALTER TABLE Ventas.voucher
	ADD CONSTRAINT tipo_transaccion_id_fk FOREIGN KEY (id_tipo_transaccion) REFERENCES Ventas.tipo_transaccion(id_tipo_transaccion)
		ON DELETE NO ACTION
		ON UPDATE NO ACTION
go
ALTER TABLE Ventas.ambiente
	ADD CONSTRAINT mesa_id_fk FOREIGN KEY (id_mesa) REFERENCES Ventas.mesas(id_mesa)
		ON DELETE NO ACTION
		ON UPDATE NO ACTION
go

ALTER TABLE Ventas.apertura_cajas
ADD CONSTRAINT caja_id_fk FOREIGN KEY (id_caja) REFERENCES Ventas.cajas(id_caja)
		ON DELETE NO ACTION
		ON UPDATE NO ACTION
GO
