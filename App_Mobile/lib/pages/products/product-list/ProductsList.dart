import 'package:dio/dio.dart';
import 'package:flutter/material.dart';
import 'package:dropdown_button2/dropdown_button2.dart';
import 'package:go_router/go_router.dart';
import 'package:hive/hive.dart';
import 'package:m_senorial/components/Buttons/buttonList.dart';
import 'package:m_senorial/components/Buttons/buttonUser.dart';
import 'package:m_senorial/components/Buttons/buttonback.dart';
import 'package:m_senorial/components/Buttons/custom_button.dart';
import 'package:m_senorial/models/Response/productos/product-response.dart';
import 'package:m_senorial/models/generic/generic-filter-request.dart';
import 'package:m_senorial/models/generic/generic-filter-response.dart';

class ProductsList extends StatefulWidget {
  final String category;

  const ProductsList({Key? key, required this.category}) : super(key: key);

  @override
  _ProductsListState createState() => _ProductsListState();
}

class _ProductsListState extends State<ProductsList> {
  final TextEditingController _searchController = TextEditingController();
  List<Map<String, dynamic>> _productos = [];
  List<Map<String, dynamic>> _productosFiltrados = [];
  List<Map<String, dynamic>> _selectedProducts = [];
  String? selectedValue;

  @override
  void initState() {
    super.initState();
     GenericFilterRequest req =
        GenericFilterRequest(numeroPagina: 1, cantidad: 5, filtros: []);
    filtarOrdenesPraradas(req).then((value) => {
          setState(() {
          print(value);
          })
        });
    // _fetchProductsByCategory(widget.category);
  }

  Future<Response> filtarOrdenesPraradas(GenericFilterRequest req) async {
    final Dio dio = Dio();
    var box = Hive.box("security");
     var token = box.get('token');
    dio.options.headers['content-Type'] = 'application/json';
    dio.options.headers["authorization"] = "Bearer $token";
    String ruta = "https://localhost:7283/api/Producto/Filtro/Ecommerce";
    final response = await dio.post(ruta, data: req);
    return response;
  }

Future<GenericFilterResponse<ProductResponse>> listarMesas() async {
    GenericFilterRequest req =
        GenericFilterRequest(numeroPagina: 1, cantidad: 5, filtros: []);
    final res = await filtarOrdenesPraradas(req);
    print(res.data);
    List<ProductResponse> m = [];
    for (var i in res.data['lista']) {
      ProductResponse tmp = ProductResponse.fromJson(i);
      m.add(tmp);
    }
    GenericFilterResponse<ProductResponse> mesa =
        GenericFilterResponse<ProductResponse>(
            totalRegistros: res.data['totalRegistros'], lista: m);
    return mesa;
  }

  // Future<void> _fetchProductsByCategory(String category) async {
  //   try {
  //     Dio dio = Dio();
  //     GenericFilterRequest request = GenericFilterRequest(numeroPagina: 1, cantidad: 5, filtros: []);
  //     final response = await dio.post('https://localhost:7283/api/Producto/Filtro/Ecommerce', data:request);
  //     print(response.data);
  //     // Verifica si los datos recibidos son válidos
  //     if (response.statusCode == 200 && response.data is List) {
  //       final List<Map<String, dynamic>> productos = List<Map<String, dynamic>>.from(
  //         response.data.map((product) {
  //           // Asegúrate de que los datos están disponibles y se están extrayendo correctamente
  //           double precio = 0.0;
  //           if (product['precio'] != null) {
  //             try {
  //               precio = double.parse(product['precio'].toString());
  //             } catch (e) {
  //               print('Error al convertir el precio: $e');
  //             }
  //           }

  //           return {
  //             'nombre': product['nombre'] ?? 'Sin nombre',
  //             'descripcion': product['descripcion'] ?? 'Sin descripción',
  //             'precio': precio,
  //           };
  //         }),
  //       );

  //       setState(() {
  //         _productos = productos;
  //         _productosFiltrados = productos;
  //       });
  //     } else {
  //       print('Error en la estructura de los datos recibidos.');
  //     }
  //   } catch (e) {
  //     print('Error fetching products: $e');
  //   }
  // }

  void _buscarProducto(String consulta) {
    setState(() {
      _productosFiltrados = _productos
          .where((producto) =>
              producto['nombre'].toLowerCase().contains(consulta.toLowerCase()))
          .toList();
    });
  }

  void _incrementProductCount(String nombre, double precio) {
    setState(() {
      _selectedProducts.add({'nombre': nombre, 'precio': precio});
    });
  }

  void navCategories() {
    context.go('/home/salestable/categories/productslist/ordermenu',
        extra: _selectedProducts);
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
                const SizedBox(width: 22),
                ButtonBack(
                  onTap: () {
                    Navigator.of(context).pop();
                  },
                ),
                const SizedBox(width: 20),
                SizedBox(
                  width: 124,
                  height: 45,
                  child: DropdownButtonFormField2<String>(
                    isExpanded: true,
                    decoration: InputDecoration(
                      contentPadding:
                          const EdgeInsets.symmetric(vertical: 0, horizontal: 8),
                      enabledBorder: OutlineInputBorder(
                        borderRadius: BorderRadius.circular(32),
                        borderSide: const BorderSide(
                            color: Color.fromRGBO(23, 1, 29, 1), width: 2),
                      ),
                      focusedBorder: OutlineInputBorder(
                        borderRadius: BorderRadius.circular(32),
                        borderSide: const BorderSide(
                            color: Color.fromRGBO(225, 122, 20, 1), width: 2),
                      ),
                    ),
                    hint: const Text(
                      '',
                      style: TextStyle(fontSize: 12),
                    ),
                    items: _productos
                        .map((item) => DropdownMenuItem<String>(
                              value: item['nombre'],
                              child: Text(
                                item['nombre'],
                                style: const TextStyle(fontSize: 12),
                              ),
                            ))
                        .toList(),
                    onChanged: (value) {
                      setState(() {
                        selectedValue = value;
                      });
                    },
                    onSaved: (value) {
                      selectedValue = value;
                    },
                  ),
                ),
                const SizedBox(width: 22),
                CustomButton(
                  onTap: navCategories,
                  text: 'Ordenar',
                  color: const Color.fromRGBO(225, 145, 15, 1),
                  badgeNumber: _selectedProducts.length,
                ),
                UserButton(
                  onTap: () {
                    // Acción cuando se presiona el botón
                  },
                ),
              ],
            ),
            const SizedBox(height: 15),
            SizedBox(
              width: 398,
              height: 54,
              child: TextField(
                controller: _searchController,
                onChanged: _buscarProducto,
                decoration: InputDecoration(
                  hintText: 'Buscar...',
                  border: OutlineInputBorder(
                    borderRadius: BorderRadius.circular(16.0),
                  ),
                  prefixIcon: const Icon(Icons.search),
                  suffixIcon: IconButton(
                    onPressed: () {
                      _searchController.clear();
                      _buscarProducto('');
                    },
                    icon: const Icon(Icons.clear),
                  ),
                ),
              ),
            ),
            const SizedBox(height: 40),
            Wrap(
              spacing: 15,
              runSpacing: 15,
              children: [
                for (var producto in _productosFiltrados)
                  Column(
                    mainAxisSize: MainAxisSize.min,
                    children: [
                      SizedBox(
                        width: 185,
                        height: 215,
                        child: ButtonList(
                          onTap: () {},
                          text: producto['nombre'],
                          additionalText: producto['descripcion'],
                          extraText: 'S/${producto['precio'].toStringAsFixed(2)}',
                          icon: Icons.add,
                          onIconTap: () =>
                              _incrementProductCount(producto['nombre'], producto['precio']),
                        ),
                      ),
                    ],
                  ),
              ],
            ),
          ],
        ),
      ),
    );
  }
}
