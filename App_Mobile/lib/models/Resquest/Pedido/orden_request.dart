class OrdenRequest {
int idPedido = 0;
int idEmpleado;
int idMesa;
String fechaPedido;
int estado;
double total = 0;
int idTipoPedido = 0;

OrdenRequest({this.idPedido = 0, this.idEmpleado = 0,this.idMesa = 0,
this.fechaPedido = '',this.estado = 0, this.total = 0,this.idTipoPedido = 0 });

}