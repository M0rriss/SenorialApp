import 'package:flutter/material.dart';
import 'package:dropdown_button2/dropdown_button2.dart';
import 'package:go_router/go_router.dart';
import 'package:m_senorial/components/Buttons/buttonList.dart';
import 'package:m_senorial/components/Buttons/buttonUser.dart';
import 'package:m_senorial/components/Buttons/buttonback.dart';
import 'package:m_senorial/components/Buttons/custom_button.dart';

const List<String> list = <String>['FRIES', 'CHICKEN', 'STEAK', 'MEAL', 'BBQ'];

class ProductsList extends StatefulWidget {
  ProductsList({Key? key}) : super(key: key);

  @override
  _ProductsListState createState() => _ProductsListState();
}

class _ProductsListState extends State<ProductsList> {
  final TextEditingController _searchController = TextEditingController();
  List<String> _productos = [
    'Cheese Burger',
    'Chicken Burger',
    'Cheese Burger',
    'Chicken Burger',
    'Cheese Burger',
    'Chicken Burger',
    'Chicken Burger',
    'Chicken Burger',
  ];
  List<String> _productosFiltrados = [];
  String? selectedValue;
  int _selectedProductCount = 0; // Contador de productos seleccionados

  @override
  void initState() {
    super.initState();
    _productosFiltrados = _productos;
  }

  void _buscarProducto(String consulta) {
    setState(() {
      _productosFiltrados = _productos
          .where((producto) =>
              producto.toLowerCase().contains(consulta.toLowerCase()))
          .toList();
    });
  }

  void _incrementProductCount() {
    setState(() {
      _selectedProductCount++;
    });
  }

  void navCategories() {
    context.go('/home/salestable/categories/productslist/ordermenu');
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
                      contentPadding: const EdgeInsets.symmetric(vertical: 0, horizontal: 8),
                      enabledBorder: OutlineInputBorder(
                        borderRadius: BorderRadius.circular(32),
                        borderSide: BorderSide(color: Color.fromRGBO(23, 1, 29, 1), width: 2),
                      ),
                      focusedBorder: OutlineInputBorder(
                        borderRadius: BorderRadius.circular(32),
                        borderSide: BorderSide(color: Color.fromRGBO(225, 122, 20, 1), width: 2),
                      ),
                    ),
                    hint: const Text(
                      '',
                      style: TextStyle(fontSize: 12),
                    ),
                    items: list
                        .map((item) => DropdownMenuItem<String>(
                              value: item,
                              child: Text(
                                item,
                                style: const TextStyle(fontSize: 12),
                              ),
                            ))
                        .toList(),
                    validator: (value) {
                      if (value == null) {
                        return '';
                      }
                      return null;
                    },
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
                  color: Color.fromRGBO(225, 145, 15, 1),
                  badgeNumber: _selectedProductCount, // Pasar el número actualizado
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
                  hintText: 'Search...',
                  border: OutlineInputBorder(
                    borderRadius: BorderRadius.circular(16.0),
                  ),
                  prefixIcon: Icon(Icons.search),
                  suffixIcon: IconButton(
                    onPressed: () {
                      _searchController.clear();
                      _buscarProducto(''); // Limpiar filtro al vaciar búsqueda
                    },
                    icon: Icon(Icons.clear),
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
                          text: producto,
                          additionalText: '200gr carne + Lechuga + Queso + Cebolla + Tomate',
                          extraText: 'S/25.oo',
                          icon: Icons.add,
                          onIconTap: _incrementProductCount, // Pasar el callback para actualizar el contador
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
