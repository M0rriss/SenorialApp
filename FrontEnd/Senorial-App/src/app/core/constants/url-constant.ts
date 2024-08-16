import { subscribeOn } from "rxjs"

const dominio = "https://localhost:7283"

const subRutas = {
    //AUTH
    auth: `${dominio}/api/Auth`,
    //MANTENIMINETO
    usuario: `${dominio}/api/Usuario`,
    producto: `${dominio}/api/Producto`,
    categoria: `${dominio}/api/Categoria`,
    suministro: `${dominio}/api/Insumo`,
    mesas: `${dominio}/api/Mesa`,
    metodoPago: `${dominio}/api/MetodoPago`,
    //UNIDAD
    unidad: `${dominio}/api/UnidadMedicion`,
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
    actulizar: `${subRutas.suministro}/Actulizar/Insumo`,
    delete: `${subRutas.suministro}`,
    filtro: `${subRutas.suministro}/Filtro`,
    crear: `${subRutas.suministro}/Crear`,
    update: `${subRutas.suministro}/Actulizar`,
}

export const urlMesa = {
    generic: `${subRutas.mesas}`,
}

export const urlUnidad = {
    generic : `${subRutas.unidad}`,
}
//AUTH
export const urlAuth = {
    loginDash : `${subRutas.auth}/LoginDash`,
    // ECOMMERCE
    loginEcommerce: `${subRutas.auth}/Login/Ecommerce`,
    registerEcommerce: `${subRutas.auth}/ecommerce/registro`,
    recuperEcommerce: `${subRutas.auth}/SendRecoveryCode/ecommerce`,
    verificarEcommerce: `${subRutas.auth}/RecoveryPassword/ecommerce`
}