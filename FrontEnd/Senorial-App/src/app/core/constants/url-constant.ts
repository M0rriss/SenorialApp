import { subscribeOn } from "rxjs"

const dominio = "https://localhost:7283"
// const dominio = "https://senorialapp.somee.com"

const subRutas = {
    //AUTH
    auth: `${dominio}/api/Auth`,
    //INVENTARIO
    detalleInventario: `${dominio}/api/DetalleInventario`,
    //ENTRADA
    entrada: `${dominio}/api/Entrada`,
    //SALIDA
    salida: `${dominio}/api/Salida`,
    //MANTENIMINETO
    usuario: `${dominio}/api/Usuario`,
    producto: `${dominio}/api/Producto`,
    categoria: `${dominio}/api/Categoria`,
    suministro: `${dominio}/api/Insumo`,
    mesas: `${dominio}/api/Mesa`,
    metodoPago: `${dominio}/api/MetodoPago`,
    //UNIDAD
    unidad: `${dominio}/api/UnidadMedicion`,
    //ROLES
    rol: `${dominio}/api/Roles`,
    // ? LOCAL
    localmesas: `${dominio}/api/Mesa`,
    // * Clientes
    clientes:`${dominio}/api/Cliente`,
    empleados:`${dominio}/api/Empleado`,
    proveedores:`${dominio}/api/Proveedor`,
}

//INVENTARIO
export const urlInventario = {
    buscar : `${subRutas.detalleInventario}/Buscar`,
    listar: `${subRutas.detalleInventario}/Listar`,
    detalle: `${subRutas.detalleInventario}/Detalle`,
    eliminar: `${subRutas.detalleInventario}/Eliminar`
}

//ENTRAD
export const urlEntradas = {
    registrar: `${subRutas.entrada}/Registrar`,
}
//SALIDAD
export const urlSalida = {
    registrar: `${subRutas.salida}/Registrar`,
}
//MANTENIMIENTO
export const urlUsuario = {
    filtro: `${subRutas.usuario}/Filtro`,
    create: `${subRutas.usuario}/Create`,
    update: `${subRutas.usuario}/Update`,
}

export const urlProducto = {
    generic: `${subRutas.producto}`,
    ecommerce: `${subRutas.producto}/Filtro/Ecommerce`,
    dashboard: `${subRutas.producto}/Filtro/Dashboard`,
    create:`${subRutas.producto}/Crear`,
    update: `${subRutas.producto}/Actulizar`,
}

export const urlCategoria = {
    listar:`${subRutas.categoria}/listado`,
    listv2:`${subRutas.categoria}`,
    listEcommer:`${subRutas.categoria}/listar`,
    filttraEcommer:`${subRutas.categoria}/listar/Sub`,
    listarSub: `${subRutas.categoria}/SubCategoria`,
    crearPadre: `${subRutas.categoria}/Create/Padre`,
    crearSub: `${subRutas.categoria}/Create/Sub`,
    actulizarPadre: `${subRutas.categoria}/Actulizar/Padre`,
    actulizarSub: `${subRutas.categoria}/Actulizar/Sub`,
}

export const urlMetodoPago = {
    listar: `${subRutas.metodoPago}/Listado`,
    crear: `${subRutas.metodoPago}/Crear`,
    actulizar: `${subRutas.metodoPago}/Actualizar`,
    delete: `${subRutas.metodoPago}`,
}

export const urlSuministro = {
    listar: `${subRutas.suministro}/Listado`,
    actualizar: `${subRutas.suministro}/Actualizar/Insumo`,
    delete: `${subRutas.suministro}`,
    filtro: `${subRutas.suministro}/Filtro`,
    crear: `${subRutas.suministro}/Crear`,
    update: `${subRutas.suministro}/Actualizar`,
}

export const urlMesa = {
    generic: `${subRutas.mesas}`,
}

export const urlUnidad = {
    generic : `${subRutas.unidad}`,
}

export const urlRol = {
    generic : `${subRutas.rol}`
}
//AUTH
export const urlAuth = {
    loginDash : `${subRutas.auth}/LoginDash`,
    // ECOMMERCE
    loginEcommerce: `${subRutas.auth}/Login/Ecommerce`,
    registerEcommerce: `${subRutas.auth}/ecommerce/registro`,
    recuperEcommerce: `${subRutas.auth}/SendRecoveryCode/ecommerce`,
    verificarEcommerce: `${subRutas.auth}/RecoveryPassword/ecommerce`,
    googleSignInEcommerce:  `${subRutas.auth}/google-signin/ecommerce`
}
// LOCAL
export const urlLocal ={
  listar : `${subRutas.localmesas}/MesaLocal`,
  listarDetalle: `${subRutas.localmesas}/DetalleMesa`
  //https://localhost:7283/api/Mesa/DetalleMesa?IdMesa=1&IdPedido=3
}
//PEDIDOS
//CLIENTES
export const urlClientes = {
 generic: `${subRutas.clientes}`,
}
export const urlEmplados = {
  listar: `${subRutas.empleados}/Listado`,
  crear: `${subRutas.empleados}/Crear`,
  actualizar: `${subRutas.empleados}/Actualizar`,
}
export const urlProveedores = {
  generic: `${subRutas.proveedores}`,
 }
