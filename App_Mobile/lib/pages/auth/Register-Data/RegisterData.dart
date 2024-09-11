import 'package:flutter/material.dart';
import 'package:flutter/services.dart'; // Necesario para los inputFormatters
import 'package:font_awesome_flutter/font_awesome_flutter.dart';
import 'package:go_router/go_router.dart';
import 'package:hive/hive.dart';
import 'package:m_senorial/components/Buttons/buttonOrden.dart';
import 'package:m_senorial/components/Buttons/buttonTwo.dart';
import 'package:m_senorial/components/Extras/my_form_text.dart';
import 'package:m_senorial/components/Inputs/my_input_text.dart';
import 'package:m_senorial/components/Texts/my_text_center.dart';
import 'package:m_senorial/models/Response/servicio/dni-response.dart';
import 'package:m_senorial/models/Resquest/Pedido/pedido_request.dart';
import 'package:m_senorial/services/apisperu/dni-service.dart';

class RegisterData extends StatefulWidget {
  RegisterData({super.key});
  final DniService dniService = DniService();
  @override
  _RegisterDataState createState() => _RegisterDataState();
}

class _RegisterDataState extends State<RegisterData> {
  int idEmpleado = 0;
  int idCliente = 0;
  final TextEditingController DatosCleinteController = TextEditingController();
  final TextEditingController phoneclienteController = TextEditingController();
  final TextEditingController DniClienteController = TextEditingController();

  bool value =
      true; // Variable para habilitar o deshabilitar el botón "GUARDAR"

  @override
  void initState() {
    super.initState();
    obtenerEmpleado();

    //*
  }

  Future<void> obtenerEmpleado() async {
    var box = await Hive.openBox('security');
    var empleado = box.get('idEmpleado');

    // Si el empleado es null, puedes manejar el error, pero se espera que no lo sea
    if (empleado != null) {
      setState(() {
        idEmpleado = empleado;
      });
    } else {
      // Manejo de error si no se encuentra el idEmpleado
      print('Error: No se encontró idEmpleado');
    }
  }

  void cancel() {
    // Acción al presionar el texto "Cancelar"
    Navigator.pop(context); // Vuelve a la pantalla anteriorS
  }

  DniResponse document = DniResponse(
      success: true,
      dni: "dni",
      nombres: "nombres",
      apellidoPaterno: "apellidoPaterno",
      apellidoMaterno: "apellidoMaterno",
      codVerifica: "codVerifica");
  String persona = "persona";

  int documento = 0;

  bool nombres = true;
  bool apellidos = true;
  bool razon = true;
  void buscarDocumento() async {
    try {
      if (DniClienteController.text.length == 8) {
        DniResponse dni =
            await widget.dniService.buscarDni(DniClienteController.text);
        if (dni.success) {
          // Asumiendo que 'success' es un indicador de respuesta exitosa
          setState(() {
            document = dni;
            documento = 1;
            DatosCleinteController.text =
                "${dni.nombres} ${dni.apellidoPaterno} ${dni.apellidoMaterno}";
          });
        } else {
          // Limpia los campos y permite la entrada manual
          setState(() {
            DatosCleinteController
                .clear(); // Asumiendo que quieres limpiar los campos
            throw Exception(
                "DNI no encontrado, por favor ingrese los datos manualmente.");
          });
        }
      } else {
        throw Exception("Formato de DNI no válido.");
      }
    } on Exception catch (e) {
      ScaffoldMessenger.of(context)
          .showSnackBar(SnackBar(content: Text(e.toString())));
    }
  }

  void navGuardar(BuildContext context) {
// INICIO DEL PEDIDO PARA LLEVAR
    // Enviar peticion Dio que crea un cliente

    // Verificamos si el campo DNI está vacío
    if (DniClienteController.text.isEmpty) {
      ScaffoldMessenger.of(context).showSnackBar(
          SnackBar(content: Text('El campo DNI no puede estar vacío.')));
      return;
    }

    // Verificamos si el campo Nombres y Apellidos está vacío
    if (DatosCleinteController.text.isEmpty) {
      ScaffoldMessenger.of(context).showSnackBar(SnackBar(
          content: Text('El campo Nombres y Apellidos no puede estar vacío.')));
      return;
    }
// Validamos si hay un idCliente válido.
    /*  if (idCliente == 0) {
      ScaffoldMessenger.of(context).showSnackBar(
        SnackBar(content: Text('No se pudo asignar un cliente, por favor intente nuevamente.'))
      );
      return;
    } */
    // Llenamos los datos del pedido para llevar.
    // Guardar 
    
    PedidoLlevarRequest pedido = PedidoLlevarRequest();
    pedido.orden.nombreCliente = DatosCleinteController.text;
    pedido.orden.idCliente = idCliente; // ID del cliente generado.
    pedido.orden.idEmpleado = idEmpleado;
    pedido.orden.idTipoPedido = 2; // Tipo "2" para pedidos "para llevar".
    print({pedido});
    // Finalmente, redirigimos a la siguiente pantalla con los datos del pedido
    context.go('/home/takeoutregister/registerdata/categories', extra: pedido);
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      body: SingleChildScrollView(
        child: Column(
          children: [
            const SizedBox(height: 70),
            const Text(
              'Pedido para llevar',
              style: TextStyle(
                fontSize: 28,
                fontWeight: FontWeight.bold,
              ),
            ),
            const SizedBox(height: 30),
            const MyTextCenter(text: 'Por favor ingrese sus datos del cliente'),
            const SizedBox(height: 40),
            const MyFormText(text: "Ingresar DNI del cliente"),
            const SizedBox(height: 6),
            Row(
              mainAxisAlignment: MainAxisAlignment.start,
              children: [
                MyInputText(
                  width: 219.37,
                  height: 57,
                  controller: DniClienteController,
                  hintText: "N° de DNI",
                  obscureText: false,
                  fillColor: Colors.grey[200] ?? Colors.grey,
                ),
                const SizedBox(width: 8), // Espacio entre el input y el botón
                MyButtonTwo(
                  onTap: () {
                    // Acción al presionar el botón de "Buscar"
                    buscarDocumento();
                  },
                  text: 'Buscar',
                  color: const Color.fromRGBO(255, 145, 15, 1),
                  buttonWidth: 95,
                  buttonHeight: 40,
                  fontSize: 17.5,
                  icon: FontAwesomeIcons.magnifyingGlass, // Ícono de búsqueda
                ),
              ],
            ),
            const SizedBox(height: 50),
            const MyFormText(text: "Nombres y Apellidos"),
            const SizedBox(height: 6),
            MyInputText(
              controller: DatosCleinteController,
              hintText: "Ingrese sus Nombres y Apellidos",
              obscureText: false,
              fillColor: Colors.grey[200] ?? Colors.grey,
              inputFormatters: [
                FilteringTextInputFormatter.singleLineFormatter,
              ],
            ),
            const SizedBox(height: 10),
            const MyFormText(text: "Teléfono (opcional)"),
            const SizedBox(height: 6),
            MyInputText(
              controller: phoneclienteController,
              hintText: "985471455",
              obscureText: false,
              fillColor: Colors.grey[200] ?? Colors.grey,
              inputFormatters: [
                FilteringTextInputFormatter.digitsOnly,
              ],
            ),
            const SizedBox(height: 55),
            MyButtonOrdern(
              onTap: () => navGuardar(context),
              text: 'Guardar',
              borderRadius: 10,
              widthllevar: 120.39,
              heightllevar: 45,
              color: Color.fromRGBO(255, 145, 15, 1),
            ),
            const SizedBox(height: 20),
            GestureDetector(
              onTap: cancel,
              child: const Text(
                'Cancelar',
                style: TextStyle(
                  color: Color.fromRGBO(18, 18, 35, 1),
                  fontSize: 16,
                  fontWeight: FontWeight.bold,
                ),
              ),
            ),
          ],
        ),
      ),
    );
  }
}
