import 'package:dio/dio.dart';
import 'package:flutter/material.dart';
import 'package:go_router/go_router.dart';
import 'package:google_fonts/google_fonts.dart';
import 'package:hive/hive.dart';
import 'package:m_senorial/components/Buttons/buttonCategories.dart';
import 'package:m_senorial/components/Buttons/buttonUser.dart';
import 'package:m_senorial/components/Buttons/buttonback.dart';
import 'package:m_senorial/modules/response/categoriasresponse/categorias.dart';

class Categories extends StatefulWidget {
  Categories({Key? key}) : super(key: key);

  @override
  _CategoriesState createState() => _CategoriesState();
}

class _CategoriesState extends State<Categories> {
  Future listarMesas() async {
    try {
      Dio dio = Dio();
    var box = Hive.box("security");
     var token = box.get('token');
     dio.options.headers['content-Type'] = 'application/json';
     dio.options.headers["authorization"] = "Bearer $token";
    final response = await dio.get("http://senorialapp.somee.com/api/Categoria/listar");
    print(response);
    final list = response.data as List;
    return list;
    }
    on DioException catch (e){
      print(e);
    }
  }
  final TextEditingController _searchController = TextEditingController();
  List<String> allCategories = [
    'Hamburguesas',
    'Parrillas y Pollos',
    'Platos de Fondo',
    'Bebidas',
    'Complementos',
    'Otros',
  ];
  List<String> filteredCategories = [];
  List<Categorias> list = [];
  @override
  void initState() {
    super.initState();
    listarMesas().then((value) => {
          setState(() {
            
            for (var element in value) {
            Categorias tmp = Categorias.fromJson(element);
            list.add(tmp);
    }
          })
        });
  }

  void filterCategories(String searchText) {
    setState(() {
      filteredCategories = allCategories
          .where((category) =>
              category.toLowerCase().contains(searchText.toLowerCase()))
          .toList();
    });
  }

  void navProducts() {
    print('navProducts called');
    context.go('/home/salestable/categories/productslist');
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
                    Navigator.of(context).pop();
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
                      'Mauricio',
                      style: GoogleFonts.sen(
                        fontSize: 17,
                        fontWeight: FontWeight.w500,
                        color: const Color.fromRGBO(103, 103, 103, 1),
                      ),
                    ),
                  ],
                ),
                const SizedBox(width: 203),
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
                onChanged: filterCategories,
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
                      onTap: navProducts,
                      text: category.nombre
                    ),
                  ),
              ],
            ),
          ],
        ),
      ),
    );
  }
}
