import 'package:flutter/material.dart';
import 'package:dropdown_button2/dropdown_button2.dart';
import 'package:go_router/go_router.dart';
import 'package:senorial/components/Buttons/buttonList.dart';
import 'package:senorial/components/Buttons/buttonUser.dart';
import 'package:senorial/components/Buttons/buttonback.dart';
import 'package:senorial/components/Buttons/custom_button.dart';
import 'package:senorial/models/Response/categorias/categorias-response.dart';
import 'package:senorial/models/Response/productos/product-response.dart';
import 'package:senorial/models/Resquest/Pedido/listar_request.dart';
import 'package:senorial/models/Resquest/Pedido/pedido_request.dart';
import 'package:senorial/models/Resquest/products/product-resques.dart';
import 'package:senorial/models/generic/generic-filter-request.dart';
import 'package:senorial/models/generic/generic-filter-response.dart';
import 'package:senorial/services/categorias/categoria_service.dart';
import 'package:senorial/services/products/product_service.dart';

class ProductsList extends StatefulWidget {
  final PedidoRequest pedido;

  const ProductsList({Key? key, required this.pedido}) : super(key: key);

  @override
  State<ProductsList> createState() => _ProductsListState();
}

class _ProductsListState extends State<ProductsList> {
  final CategoriaService categoriaService = CategoriaService();
  final ProductService productService = ProductService();
  final TextEditingController _searchController = TextEditingController();

  GenericFilterResponse<ProductResponse> productosv2 =
      GenericFilterResponse<ProductResponse>(totalRegistros: 0, lista: []);
  List<ProductResponse> _productosFiltrados = [];
  List<Map<String, dynamic>> selectedProducts = [];

  List<String> subCaterias = [];
  String? selectedSubCategorias;
  String? selectedValue;

  int? filtro1;
  int? filtro2;
  List<CategoriasResponse> subCategoria = [];

  @override
  void initState() {
    //cargarSubCategorias();
    super.initState();
    listarProducto(
            idCategoria: widget.pedido.filtro.idCategoria, idSubCategoria: '')
        .then((value) {
      setState(() {
        productosv2 = value;
        _productosFiltrados = productosv2.lista;
      });
    });
    listarSubCategoria().then((value) => {
          setState(() {
            subCategoria = value;
          })
        });
  }

  Future<List<CategoriasResponse>> listarSubCategoria() async {
    final res = await categoriaService
        .filtroSubCategoria(int.parse(widget.pedido.filtro.idCategoria));
    List<CategoriasResponse> data = [];
    for (var c in res.data) {
      CategoriasResponse tmp = CategoriasResponse.fromJson(c);
      data.add(tmp);
    }
    return data;
  }

  Future<void> filtrarProductos(String idSubCategoria) async {
    try {
      // Llama a la función listarProducto para obtener los productos filtrados
      GenericFilterResponse<ProductResponse> res = await listarProducto(
        idCategoria: widget.pedido.filtro.idCategoria,
        idSubCategoria: idSubCategoria,
      );

      setState(() {
        _productosFiltrados = res.lista; // Actualiza los productos filtrados
      });
    } catch (e) {
      print('Error al filtrar productos: $e');
    }
  }

  Future<GenericFilterResponse<ProductResponse>> listarProducto(
      {String idCategoria = "",
      String idSubCategoria = "",
      int page = 1}) async {
    GenericFilterRequest req = GenericFilterRequest(
      numeroPagina: page,
      cantidad: 6,
      filtros: [
        if (idCategoria.isNotEmpty)
          FiltroRequest(name: "Categoria", value: idCategoria),
        if (idSubCategoria.isNotEmpty)
          FiltroRequest(name: "SubCategoria", value: idSubCategoria),
      ],
    );

    final res = await productService.filtrarProductos(req);
    return res;
  }

  void _fetchProducts() {
    listarProducto(
      idCategoria: widget.pedido.filtro.idCategoria,
      idSubCategoria: "",
    ).then((value) {
      setState(() {
        productosv2 = value;
        _productosFiltrados = productosv2.lista;
      });
    });
  }

  void _buscarProducto(String consulta) {
    setState(() {
      if (consulta.isEmpty) {
        _productosFiltrados = productosv2.lista;
      } else {
        _productosFiltrados = productosv2.lista
            .where((producto) => producto.nombreProducto
                .toLowerCase()
                .contains(consulta.toLowerCase()))
            .toList();
      }
    });
  }

  void _incrementProductCount(String nombre, double precio) {
    setState(() {
      selectedProducts.add({'nombre': nombre, 'precio': precio});
    });
  }

  void navCategories() {
    // Verificamos si el tipo de pedido es "Comer Aquí" o "Para Llevar"
  if (widget.pedido.orden.idTipoPedido == 1) {
    // Si es "Comer Aquí"
    context.go('/home/salestable/categories/productslist/ordermenuindoor', extra: widget.pedido);
  } else if (widget.pedido.orden.idTipoPedido == 2) {
    // Si es "Para Llevar"
    context.go('/home/takeoutregister/registerdata/categories/productslist/ordermenuindoor', extra: widget.pedido);
  } else {
    ScaffoldMessenger.of(context).showSnackBar(
      SnackBar(content: Text('Tipo de pedido no válido.')),
    );
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
                const SizedBox(width: 20),
                ButtonBack(
                  onTap: () {
                    
                      // Verificamos si el tipo de pedido es "Comer Aquí" o "Para Llevar"
                    if (widget.pedido.orden.idTipoPedido == 1) {
                      // Si es "Comer Aquí"
                      context.go('/home/salestable/categories', extra: widget.pedido);
                    } else if (widget.pedido.orden.idTipoPedido == 2) {
                      // Si es "Para Llevar"
                      context.go('/home/takeoutregister/registerdata/categories', extra: widget.pedido);
                    } else {
                      ScaffoldMessenger.of(context).showSnackBar(
                        SnackBar(content: Text('Tipo de pedido no válido.')),
                      );
                    }
                  },
                ),
                const SizedBox(width: 10),
                SizedBox(
                  width: 170,
                  height: 40,
                  child: DropdownButtonFormField2<String>(
                    isExpanded: true,
                    decoration: InputDecoration(
                      contentPadding: const EdgeInsets.symmetric(
                          vertical: 0, horizontal: 1),
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
                    hint: const Text("Sub Categorias"),
                    // hint: const Text(
                    //   'nombre',
                    //   style: TextStyle(fontSize: 12),
                    // ),
                    items: subCategoria
                        .map((subCategoria) => DropdownMenuItem<String>(
                              value: subCategoria.idCategoria.toString(),
                              child: Text(
                                subCategoria.nombre,
                                style: const TextStyle(fontSize: 12),
                              ),
                            ))
                        .toList(),
                    onChanged: (value) {
                      setState(() {
                        selectedValue = value;
                      });
                      filtrarProductos(value!);
                    },
                    onSaved: (value) {
                      selectedValue = value;
                    },
                    value: selectedValue,
                  ),
                ),
                CustomButton(
                  onTap: navCategories,
                  text: 'Ordenar',
                  color: const Color.fromRGBO(225, 145, 15, 1),
                  badgeNumber: widget.pedido.lista.length,
                ),
                UserButton(
                  onTap: () {},
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
              spacing: -5,
              runSpacing: 20,
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
                          text: producto.nombreProducto,
                          additionalText: producto.detalleProducto,
                          extraText:
                              'S/${producto.precioVenta.toStringAsFixed(2)}',
                          icon: Icons.add,
                          onIconTap: () {
                            // setState(() {
                            //   if (widget.pedido.lista.isEmpty) {
                            //     ListarRequest data = ListarRequest();
                            //     data.idProducto = producto.idProducto;
                            //     data.cantidad = 1;
                            //     data.precio = producto.precioVenta;
                            //     data.nombre = producto.nombreProducto;
                            //     data.ruta = producto.rutaImagen;
                            //     widget.pedido.lista.add(data);
                            //   } else {
                            //     for (var i in widget.pedido.lista) {
                            //       if (i.idProducto == producto.idProducto) {
                            //         //agregar aqui tu diseño de modas

                            //         return;
                            //       }
                            //     }
                            //     ListarRequest data = ListarRequest();
                            //     data.idProducto = producto.idProducto;
                            //     data.cantidad = 1;
                            //     data.precio = producto.precioVenta;
                            //     data.nombre = producto.nombreProducto;
                            //     data.ruta = producto.rutaImagen;
                            //     widget.pedido.lista.add(data);
                            //   }
                            // });
                            setState(() {
                              if (widget.pedido.lista.isEmpty) {
                                ListarRequest data = ListarRequest();
                                data.idProducto = producto.idProducto;
                                data.cantidad = 1;
                                data.precio = producto.precioVenta;
                                data.nombre = producto.nombreProducto;
                                data.ruta = producto.rutaImagen;
                                widget.pedido.lista.add(data);
                              } else {
                                bool productoYaSeleccionado = false;
                                
                                // Comprobar si el producto ya está seleccionado
                                for (var i in widget.pedido.lista) {
                                  if (i.idProducto == producto.idProducto) {
                                    productoYaSeleccionado = true;
                                    break;
                                  }
                                }

                                if (productoYaSeleccionado) {
                                  // Mostrar SnackBar si el producto ya ha sido seleccionado
                                  ScaffoldMessenger.of(context).showSnackBar(
                                    SnackBar(
                                      content: const Text(
                                        'Este producto ya ha sido seleccionado.',
                                      ),
                                      duration: const Duration(seconds: 2),
                                      action: SnackBarAction(
                                        label: 'OK',
                                        onPressed: () {
                                          // Aquí puedes manejar alguna acción si lo deseas
                                        },
                                      ),
                                    ),
                                  );
                                  return; // Detener la ejecución si el producto ya fue agregado
                                } else {
                                  // Agregar el producto si no ha sido seleccionado
                                  ListarRequest data = ListarRequest();
                                  data.idProducto = producto.idProducto;
                                  data.cantidad = 1;
                                  data.precio = producto.precioVenta;
                                  data.nombre = producto.nombreProducto;
                                  data.ruta = producto.rutaImagen;
                                  widget.pedido.lista.add(data);
                                }
                              }
                            });
                          },
                          imageProduc: producto.rutaImagen,
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
