import 'package:dio/dio.dart';
import 'package:flutter/material.dart';
import 'package:go_router/go_router.dart';
import 'package:google_fonts/google_fonts.dart';
import 'package:hive/hive.dart';

import 'package:senorial/components/Buttons/buttonCategories.dart'; // Asegúrate de que la ruta es correcta
import 'package:senorial/components/Buttons/buttonUser.dart';
import 'package:senorial/components/Buttons/buttonback.dart';
import 'package:senorial/core-url/urlconst.dart';
import 'package:senorial/models/Response/categorias/categorias-response.dart';
import 'package:senorial/models/Resquest/Pedido/pedido_request.dart';

class Categories extends StatefulWidget {
  final PedidoRequest data;
  const Categories({Key? key, required this.data}) : super(key: key);

  @override
  State<Categories> createState() => _CategoriesState();
}

String nombreUsuario = '';

class _CategoriesState extends State<Categories> {
  Future listarMesas() async {
    try {
      Dio dio = Dio();
      var box = Hive.box("security");
      var token = box.get('token');
      dio.options.headers['content-Type'] = 'application/json';
      dio.options.headers["authorization"] = "Bearer $token";
      final response = await dio.get(UrlCategorias.listar);
      // await dio.get("https://localhost:7283/api/Categoria/listar");
      final list = response.data as List;
      return list;
    } on DioException catch (e) {
      print(e);
    }
  }

  Future<String> mostrarNombre() async {
    var box = await Hive.openBox(
        'security'); // Asegurarse de que la caja está abierta
    var nombre = box.get('nombre');
    return nombre;
  }

  final TextEditingController _searchController = TextEditingController();
  List<CategoriasResponse> list = [];

  @override
  void initState() {
    super.initState();
    listarMesas().then((value) {
      setState(() {
        for (var element in value) {
          CategoriasResponse tmp = CategoriasResponse.fromJson(element);
          list.add(tmp);
        }
      });
      mostrarNombre().then((value) => {
            setState(() {
              String unico = value.substring(0, value.indexOf(" "));
              nombreUsuario = unico;
            })
          });
    });
  }

  void SearchCategories(String searchText) {
    setState(() {
      list = list
          .where((category) =>
              category.nombre.toLowerCase().contains(searchText.toLowerCase()))
          .toList();
    });
  }

  void listarProductos() {}

  void navProducts(PedidoRequest data) {
    PedidoRequest req = data;

   // Verificar si es un pedido para llevar o comer aquí
  if (req.orden.idTipoPedido == 1) {
    // Comer aquí
    context.go('/home/salestable/categories/productslist', extra: req);
  } else if (req.orden.idTipoPedido == 2) {
    // Para llevar
    context.go('/home/takeoutregister/registerdata/categories/productslist', extra: req);
  } else {
    // Caso de error si no está definido correctamente el idTipoPedido
    ScaffoldMessenger.of(context).showSnackBar(
      SnackBar(content: Text('Tipo de pedido no válido.')),
    );
  }
  }

  String getImagePath(String categoryName) {
    switch (categoryName) {
      case 'Hamburguesas':
        return 'lib/imagenes/burger.png';
      case 'Parrillas y Pollos':
        return 'lib/imagenes/pollos.png';
      case 'Platos de Fondo':
        return 'lib/imagenes/platos-fondo.png';
      case 'Bebidas':
        return 'lib/imagenes/bebidas.png';
      case 'Complementos':
        return 'lib/imagenes/complementos.png';
      default:
        return 'lib/imagenes/burger.png';
    }
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      body: SingleChildScrollView(
        child: Column(
          children: [
            const SizedBox(height: 50),
            Row(
              children: [
                const SizedBox(width: 18),
                ButtonBack(
                   onTap: () {
                      if (widget.data.orden.idTipoPedido == 1) {
                        // Si es "Comer Aquí"
                        Navigator.of(context).pop();  // Simplemente retrocede a la pantalla anterior
                      } else if (widget.data.orden.idTipoPedido == 2) {
                        // Si es "Para Llevar"
                        Navigator.of(context).pop();  // Igual retrocede, pero está listo para más lógica
                      } else {
                        // Si no hay un tipo de pedido válido, mostramos un mensaje de error
                        ScaffoldMessenger.of(context).showSnackBar(
                          SnackBar(content: Text('Tipo de pedido no válido.')),
                        );
                      }
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
                const SizedBox(width: 213),
                UserButton(
                  onTap: () {
                    // Acción cuando se presiona el botón
                  },
                ),
              ],
            ),
            const SizedBox(height: 20),
            SizedBox(
              width: 398,
              height: 54,
              child: TextField(
                controller: _searchController,
                onChanged: SearchCategories,
                decoration: InputDecoration(
                  labelText: 'Buscar',
                  border: OutlineInputBorder(
                    borderRadius: BorderRadius.circular(16.0),
                  ),
                  prefixIcon: const Icon(Icons.search),
                ),
              ),
            ),
            const SizedBox(height: 50),
            Wrap(
              spacing: 17.0,
              children: [
                for (var category in list)
                  Padding(
                    padding: const EdgeInsets.all(10.0),
                    child: MyButtonCategories(
                      onTap: () {
                        //var box = Hive.box("security");
                        //PedidoRequest req = PedidoRequest();
                        //widget.data.orden.idEmpleado = box.get('idEmpleado');
                        widget.data.lista = widget.data.lista;
                        widget.data.filtro.idCategoria =
                            category.idCategoria.toString();
                        widget.data.filtro.idSubCategoria =
                            category.idCategoriaPadre.toString();
                        print("Booooo");
                        print(widget.data.orden.idEmpleado);
                        print(widget.data.orden.idMesa);
                        print("Boooooxxxxx");
                        navProducts(widget.data);
                      },
                      text: category.nombre,
                      imagePath: getImagePath(
                          category.nombre), // Se obtiene la imagen correcta
                    ),
                  ),
                if (list.isEmpty)
                  const Padding(
                    padding: EdgeInsets.all(20.0),
                    child: Text('No se encontraron categorías'),
                  ),
              ],
            ),
          ],
        ),
      ),
    );
  }
}
