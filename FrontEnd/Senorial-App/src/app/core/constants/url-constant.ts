const dominio = "https://localhost:7283"

const subRutas = {
    //AUTH
    auth: `${dominio}/api/Auth`,
    //MANTENIMINETO
    categoria: `${dominio}/api/Categoria`,
    suministro: `${dominio}/api/Insumo`,
    mesas: `${dominio}/api/Mesa`,
    metodoPago: `${dominio}/api/MetodoPago`,
    producto: `${dominio}/api/Producto`,
}

//MANTENIMIENTO
export const urlCategoria = {
    listar:`${subRutas.categoria}/listado`,
    listv2:`${subRutas.categoria}`,
    listEcommer:`${subRutas.categoria}/listar`,
    filttraEcommer:`${subRutas.categoria}/listar/Sub`,
}
export const urlSuministro = {
    listar: `${subRutas.suministro}/Listado`,
    crear: `${subRutas.suministro}/Crear/Insumo`,
    actulizar: `${subRutas.suministro}/Actulizar/Insumo`,
    delete: `${subRutas.suministro}`,
}
export const urlMesa = {
    generic: `${subRutas.mesas}`,
    listar: `${subRutas.mesas}`,
    crear: `${subRutas.mesas}`,
    actulizar: `${subRutas.mesas}`,
    delete: `${subRutas.mesas}`,
}
export const urlMetodoPago = {
    listar: `${subRutas.metodoPago}/Listado`,
    crear: `${subRutas.metodoPago}/Crear`,
    actulizar: `${subRutas.metodoPago}/Actulizar`,
    delete: `${subRutas.metodoPago}`,
}
export const urlProducto = {
    generic: `${subRutas.producto}`,
    ecommerce: `${subRutas.producto}/Filtro/Ecommerce`,
    dashboard: `${subRutas.producto}/Filtro/Dashboard`,
    create:`${subRutas.producto}/Crear`,
    update: `${subRutas.producto}/Actulizar`,
}
//AUTH
export const urlAuth = {
    loginDash : `${subRutas.auth}/LoginDash`,
}