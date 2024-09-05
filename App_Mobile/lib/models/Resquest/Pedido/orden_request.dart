class OrdenRequest {
int idPedido;
int idEmpleado;
int idMesa;
String fechaPedido;
int estado;
double total;
int idTipoPedido;

OrdenRequest({this.idPedido = 0, this.idEmpleado = 0,this.idMesa = 0,
this.fechaPedido = '',this.estado = 0, this.total = 0,this.idTipoPedido = 0 });

}