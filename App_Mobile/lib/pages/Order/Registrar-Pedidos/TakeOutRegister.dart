import 'package:flutter/material.dart';
import 'package:go_router/go_router.dart';
import 'package:hive/hive.dart';
import 'package:m_senorial/components/Buttons/buttonIntems.dart';
import 'package:m_senorial/components/Buttons/buttonTwo.dart';
import 'package:m_senorial/components/Buttons/buttonUser.dart';
import 'package:m_senorial/components/Buttons/buttonback.dart';

class TakeOutRegister extends StatefulWidget {
  const TakeOutRegister({Key? key}) : super(key: key);

  @override
  _TakeOutRegisterState createState() => _TakeOutRegisterState();
}

class _TakeOutRegisterState extends State<TakeOutRegister> {
  final codeController = TextEditingController();

  void navRegister(BuildContext context) {
    context.go('/home/takeoutregister/registerdata');
  }

  String nombreUsuario = '';


  @override
  void initState() {
    super.initState();

    mostrarNombre().then((value) => {
          setState(() {
            String unico = value.substring(0, value.indexOf(" "));
            nombreUsuario = unico;
          })
        });
  }
  

  Future<String> mostrarNombre() async {
    var box = await Hive.openBox('security'); // Asegurarse de que la caja está abierta
    var nombre = box.get('nombre');
    return nombre;
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
                      // Acción al presionar el botón de usuario
                    },
                  ),
                ],
              ),
              const SizedBox(height: 100),
              const Buttonintems(
                name: 'Edson',
                price: 'S/. 30.00',
                items: '4 items',
                svgIconPath: 'lib/imagenes/IconCube.svg',
              ),
            ],
          ),
        ),
      ),
    );
  }
}
// import 'package:flutter/material.dart';
// import 'package:go_router/go_router.dart';
// import 'package:hive/hive.dart';
// import 'package:m_senorial/components/Buttons/buttonIntems.dart';
// import 'package:m_senorial/components/Buttons/buttonTwo.dart';
// import 'package:m_senorial/components/Buttons/buttonUser.dart';
// import 'package:m_senorial/components/Buttons/buttonback.dart';
// import 'package:m_senorial/models/Resquest/Pedido/listar_request.dart';
// import 'package:m_senorial/models/Resquest/Pedido/pedido_request.dart';
// import 'package:m_senorial/models/Resquest/Pedido/pedidosllevar-request.dart';
// import 'package:m_senorial/services/pedidosllevar/pedidosllevar_services.dart';

// class TakeOutRegister extends StatefulWidget {
//   final PedidoRequest pedido; // Requerido PedidoRequest

//   const TakeOutRegister({Key? key, required this.pedido}) : super(key: key); // Constructor con PedidoRequest como parámetro requerido

//   @override
//   _TakeOutRegisterState createState() => _TakeOutRegisterState();
// }

// class _TakeOutRegisterState extends State<TakeOutRegister> {
//   final codeController = TextEditingController();
//   List<PedidoRequest> pedidos = []; // Lista de pedidos
//   final PedidosLlevarService pedidosLlevarService = PedidosLlevarService(); // Servicio para obtener pedidos
//   String nombreUsuario = '';

//   @override
//   void initState() {
//     super.initState();

//     mostrarNombre().then((value) {
//       setState(() {
//         String unico = value.substring(0, value.indexOf(" "));
//         nombreUsuario = unico;
//       });
//     });

//     // Llamamos a listarPedidosLlevar cuando se inicia el componente
//     listarPedidosLlevar();
//   }

//   Future<String> mostrarNombre() async {
//     var box = await Hive.openBox('security'); // Asegurarse de que la caja está abierta
//     var nombre = box.get('nombre');
//     return nombre;
//   }

//   // Función para convertir OrdenLlevarRequest a PedidoRequest
//   PedidoRequest convertirOrdenLlevarAPedido(OrdenLlevarRequest ordenLlevar) {
//     PedidoRequest pedido = PedidoRequest();
//     pedido.orden.idPedido = ordenLlevar.idPedidoLlevar;
//     pedido.orden.nombreCliente = ordenLlevar.nombreCliente;
//     pedido.orden.total = ordenLlevar.total;

//     // Convertir los detalles del pedido para llevar
//     pedido.lista = ordenLlevar.detallesLlevar.map((detalle) {
//       return ListarRequest(
//         idProducto: detalle.idProducto,
//         cantidad: detalle.cantidad,
//         precio: detalle.precioUnitario,
//         nombre: '', // Aquí podrías agregar el nombre del producto si lo tienes
//       );
//     }).toList();

//     return pedido;
//   }

//   // Lógica para listar los pedidos en TakeOutRegister
//   Future<void> listarPedidosLlevar() async {
//     try {
//       final response = await pedidosLlevarService.ListarPedidoLlevar(OrdenLlevarRequest(
//         idPedidoLlevar: 0,
//         idEmpleado: 0,
//         idCliente: 0,
//         nombreCliente: '',
//         fechaPedido: DateTime.now(),
//         estado: 0,
//         total: 0.0,
//         idTipoPedido: 2, // Pedido para llevar
//         detallesLlevar: [],
//       ));

//       setState(() {
//         pedidos = (response.data as List).map((ordenLlevarJson) {
//           OrdenLlevarRequest ordenLlevar = OrdenLlevarRequest.fromJson(ordenLlevarJson);
//           return convertirOrdenLlevarAPedido(ordenLlevar);
//         }).toList();
//       });
//     } catch (e) {
//       print('Error al listar los pedidos: $e');
//     }
//   }

//   void navRegister(BuildContext context) {
//     context.go('/home/takeoutregister/registerdata');
//   }

//   @override
//   Widget build(BuildContext context) {
//     return Scaffold(
//       body: SingleChildScrollView(
//         child: Padding(
//           padding: const EdgeInsets.symmetric(horizontal: 20),
//           child: Column(
//             crossAxisAlignment: CrossAxisAlignment.start,
//             children: [
//               const SizedBox(height: 45),
//               Row(
//                 children: [
//                   ButtonBack(
//                     onTap: () {
//                       Navigator.of(context).pop();
//                     },
//                   ),
//                   const SizedBox(width: 20),
//                   Column(
//                     crossAxisAlignment: CrossAxisAlignment.start,
//                     children: [
//                       const Text(
//                         'VENTAS',
//                         style: TextStyle(
//                           fontSize: 14.57,
//                           fontWeight: FontWeight.bold,
//                           color: Color.fromRGBO(252, 110, 42, 1),
//                         ),
//                       ),
//                       Text(
//                         nombreUsuario,
//                         style: const TextStyle(
//                           fontSize: 14,
//                           fontWeight: FontWeight.bold,
//                           color: Color.fromRGBO(153, 153, 153, 1),
//                         ),
//                       ),
//                     ],
//                   ),
//                   const Spacer(),
//                   MyButtonTwo(
//                     onTap: () => navRegister(context),
//                     text: 'Registrar Pedido',
//                     color: const Color.fromRGBO(255, 145, 15, 1),
//                     buttonWidth: 143,
//                     buttonHeight: 40,
//                     fontSize: 17.5,
//                   ),
//                   const SizedBox(width: 20),
//                   UserButton(
//                     onTap: () {
//                       // Acción al presionar el botón de usuario
//                     },
//                   ),
//                 ],
//               ),
//               const SizedBox(height: 100),

//               // Listar los pedidos obtenidos
//               if (pedidos.isNotEmpty)
//                 ...pedidos.map((pedido) {
//                   return Padding(
//                     padding: const EdgeInsets.only(bottom: 20),
//                     child: Buttonintems(
//                       name: pedido.orden.nombreCliente, // Nombre del cliente
//                       price: 'S/. ${pedido.orden.total.toStringAsFixed(2)}', // Precio total
//                       items: '${pedido.lista.length} items', // Cantidad de ítems
//                       svgIconPath: 'lib/imagenes/IconCube.svg', // Icono
//                     ),
//                   );
//                 }).toList()
//               else
//                 const Center(child: Text('No hay pedidos registrados')),
//             ],
//           ),
//         ),
//       ),
//     );
//   }
// }
