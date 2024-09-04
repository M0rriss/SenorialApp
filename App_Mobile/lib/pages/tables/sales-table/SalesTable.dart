import 'package:flutter/material.dart';
import 'package:go_router/go_router.dart';
import 'package:google_fonts/google_fonts.dart';
import 'package:hive/hive.dart';
import 'package:m_senorial/components/Buttons/buttonTwo.dart';
import 'package:m_senorial/components/Buttons/buttonTables.dart';
import 'package:m_senorial/components/Buttons/buttonback.dart';
import 'package:m_senorial/components/Extras/status.dart';
import 'package:m_senorial/components/Buttons/buttonUser.dart';
import 'package:m_senorial/models/Response/mesas/mesas-response.dart';
import 'package:m_senorial/models/Resquest/Pedido/pedido_request.dart';
import 'package:m_senorial/services/auth/login.service.dart';
import 'package:m_senorial/services/mesas/mesa_service.dart';

class Salestable extends StatefulWidget {
  final mesasService = MesasService();
  Salestable({Key? key}) : super(key: key);

  @override
  State<Salestable> createState() => _SalestableState();
}

class _SalestableState extends State<Salestable> {
  List<MesasResponse> mesas = [];
  // AuthService loginService = AuthService(ruta: UrlAuth.login, dio: Dio());
  String nombreUsuario = '';
  late AuthService loginService;
  @override
  void initState() {
    super.initState();
    listarMesas().then((value) => {
          setState(() {
            mesas = value;
          })
        });
        mostrarNombre().then((value)=>{
          setState(() {
            String unico = value.substring(0,value.indexOf(" "));
            nombreUsuario = unico;
          })
        });
  }

  Future<String> mostrarNombre() async {
    var box = await Hive.openBox(
        'security'); // Asegurarse de que la caja está abierta
    var nombre = box.get('nombre');
    return nombre;
  }

  Future<List<MesasResponse>> listarMesas() async {
    final response = await widget.mesasService.listarMesas();
    List<MesasResponse> list =
        response.map((data) => MesasResponse.fromJson(data)).toList();
    return list;
    // Actualizar el estado con la lista obtenida
  }

  void navCategories(PedidoRequest req) {
    context.go('/home/salestable/categories',extra: req);
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      body: SingleChildScrollView(
        child: Column(
          children: [
            const SizedBox(height: 45),
            Row(
              children: [
                const SizedBox(width: 20),
                ButtonBack(
                  onTap: () {
                    Navigator.pop(context);
                  },
                ),
                const SizedBox(width: 20),
                Column(
                  crossAxisAlignment: CrossAxisAlignment.start,
                  children: [
                    Text(
                      'VENTAS',
                      style: GoogleFonts.sen(
                        fontSize: 15,
                        fontWeight: FontWeight.bold,
                        color: const Color.fromRGBO(252, 110, 42, 1),
                      ),
                    ),
                    Text(
                      nombreUsuario,
                      style: GoogleFonts.sen(
                        fontSize: 17,
                        fontWeight: FontWeight.w500,
                        color: const Color.fromRGBO(103, 103, 103, 1),
                      ),
                    ),
                  ],
                ),
                const SizedBox(width: 83),
                MyButtonTwo(
                  onTap: () {
                    // Deja vacío si no quieres que haga nada
                  },
                  text: 'Mesas',
                  color: const Color.fromRGBO(255, 145, 15, 1),
                ),
                const SizedBox(width: 2),
                UserButton(
                  onTap: () {},
                ),
              ],
            ),
            const SizedBox(height: 85),
            StatusRow(),
            const SizedBox(height: 30),
            Center(
              child: Container(
                width: 280,
                child: GridView.builder(
                  shrinkWrap: true,
                  gridDelegate: const SliverGridDelegateWithFixedCrossAxisCount(
                    crossAxisCount: 3,
                    crossAxisSpacing: 25,
                    mainAxisSpacing: 10,
                    childAspectRatio: 74 / 60, // Ajusta el aspect ratio
                  ),
                  itemCount: mesas.length,
                  itemBuilder: (BuildContext context, int index) {
                    return ButtonTables(
                      onTap:(){
                        PedidoRequest req = PedidoRequest();
                        req.orden.idMesa = mesas[index].idMesa;
                        req.orden.idTipoPedido = 1;
                        navCategories(req);
                      }, // Navega a Categories al hacer clic en una mesa
                      text: mesas[index].idMesa.toString(),
                      color: const Color.fromRGBO(254, 240, 211, 1),
                      status: '0 items',
                      statusColor: const Color.fromRGBO(171, 174, 188, 1),
                      width: 74,
                      height: 60,
                    );
                  },
                ),
              ),
            ),
          ],
        ),
      ),
    );
  }
}
