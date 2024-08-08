const dominio = "https://localhost:7283"

const subRutas = {
    categoria: `${dominio}/api/Categoria`,
}

export const urlCategoria = {
    listar:`${subRutas.categoria}/listado`,
    listv2:`${subRutas.categoria}`,
}