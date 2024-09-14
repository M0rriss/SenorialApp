import 'package:flutter/material.dart';
import 'package:go_router/go_router.dart';
import 'package:hive/hive.dart';
import 'package:m_senorial/components/Buttons/buttonIntems.dart';
import 'package:m_senorial/components/Buttons/buttonTwo.dart';
import 'package:m_senorial/components/Buttons/buttonUser.dart';
import 'package:m_senorial/components/Buttons/buttonback.dart';
import 'package:m_senorial/models/Resquest/Pedido/pedido_request.dart';
import 'package:m_senorial/models/Resquest/Pedido/pedidosllevar-request.dart';
import 'package:m_senorial/services/pedidosllevar/pedidosllevar_services.dart';

class TakeOutRegister extends StatefulWidget {
  final PedidoRequest pedido; 

  const TakeOutRegister({Key? key, required this.pedido})
      : super(
            key: key); 

  @override
  _TakeOutRegisterState createState() => _TakeOutRegisterState();
}

class _TakeOutRegisterState extends State<TakeOutRegister> {
  final codeController = TextEditingController();
  List<PedidoRequest> pedidos = []; 
  final PedidosLlevarService pedidosLlevarService =
      PedidosLlevarService(); 
  String nombreUsuario = '';
  String nombreCliente = '';

  @override
  void initState() {
    super.initState();

    mostrarNombre().then((value) {
      setState(() {
        String unico = value.substring(0, value.indexOf(" "));
        nombreUsuario = unico;
      });
    });

    
    listarPedidosLlevar();
  }

  Future<String> mostrarNombre() async {
    var box = await Hive.openBox(
        'security'); 
    var nombre = box.get('nombre');
    return nombre;
  }

  String obtenerPrimerNombreCliente(String nombreCliente) {
  
  if (nombreCliente.contains(' ')) {
    
    return nombreCliente.substring(0, nombreCliente.indexOf(' '));
  } else {
    
    return nombreCliente;
  }
}

 PedidoRequest convertirOrdenLlevarAPedido(OrdenLlevarRequest ordenLlevar) {
  PedidoRequest pedido = PedidoRequest();

  pedido.orden.idPedido = ordenLlevar.idPedidoLlevar;
  pedido.orden.nombreCliente = ordenLlevar.nombreCliente;

  // Si no tienes detallesLlevar, inicializa lista como vacío
  pedido.lista = []; 

  pedido.orden.cantidad = ordenLlevar.cantidad;
  pedido.orden.total = ordenLlevar.total; // O calcular el total si tienes detalles

  print("Cantidad total de ítems: ${pedido.orden.cantidad}");
  print("Precio total calculado: ${pedido.orden.total}");

  return pedido;
}



  
  Future<void> listarPedidosLlevar() async {
    try {
      final response =
          await pedidosLlevarService.ListarPedidoLlevar(OrdenLlevarRequest(
        idPedidoLlevar: 0,
        idEmpleado: 0,
        idCliente: 0,
        nombreCliente: '',
        fechaPedido: DateTime.now(),
        estado: 0,
        total: 0.0,
        idTipoPedido: 2, 
        detallesLlevar: [],
        cantidad: 0
      ));
      setState(() {
        pedidos = (response.data as List).map((ordenLlevarJson) {
          OrdenLlevarRequest ordenLlevar =
              OrdenLlevarRequest.fromJson(ordenLlevarJson);
          print("xxxxx");
          return convertirOrdenLlevarAPedido(ordenLlevar);
        }).toList();
        print('Error al listar los pexxxxxdidos: ${pedidos.length}');
      });
    } catch (e) {
      print('Error al listar los pedidos: $e');
    }
  }

  void navRegister(BuildContext context) {
    context.go('/home/takeoutregister/registerdata');
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      body: SingleChildScrollView(
        child: Padding(
          padding: const EdgeInsets.symmetric(horizontal: 20),
          child: Column(
            crossAxisAlignment: CrossAxisAlignment.start,
            children: [
              const SizedBox(height: 45),
              Row(
                children: [
                  ButtonBack(
                    onTap: () {
                      Navigator.of(context).pop();
                    },
                  ),
                  const SizedBox(width: 20),
                  Column(
                    crossAxisAlignment: CrossAxisAlignment.start,
                    children: [
                      const Text(
                        'VENTAS',
                        style: TextStyle(
                          fontSize: 14.57,
                          fontWeight: FontWeight.bold,
                          color: Color.fromRGBO(252, 110, 42, 1),
                        ),
                      ),
                      Text(
                        nombreUsuario,
                        style: const TextStyle(
                          fontSize: 14,
                          fontWeight: FontWeight.bold,
                          color: Color.fromRGBO(153, 153, 153, 1),
                        ),
                      ),
                    ],
                  ),
                  const Spacer(),
                  MyButtonTwo(
                    onTap: () => navRegister(context),
                    text: 'Registrar Pedido',
                    color: const Color.fromRGBO(255, 145, 15, 1),
                    buttonWidth: 143,
                    buttonHeight: 40,
                    fontSize: 17.5,
                  ),
                  const SizedBox(width: 20),
                  UserButton(
                    onTap: () {
                      
                    },
                  ),
                ],
              ),
              const SizedBox(height: 100),

              
              if (pedidos.isNotEmpty)
                ...pedidos.map((pedido) {
                  return Padding(
                    padding: const EdgeInsets.only(bottom: 20),
                   child: Buttonintems(
                   name: obtenerPrimerNombreCliente(pedido.orden.nombreCliente), 
                   price: 'S/. ${pedido.orden.total.toStringAsFixed(2)}', 
                   items: '${pedido.orden.cantidad} items', 
                   svgIconPath: 'lib/imagenes/IconCube.svg', 
                  ),
                  );
                }).toList()
              else
                const Center(child: Text('No hay pedidos registrados')),
            ],
          ),
        ),
      ),
    );
  }
}
