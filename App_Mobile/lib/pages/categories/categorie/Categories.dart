import 'package:flutter/material.dart';
import 'package:m_senorial/components/my_CircleAvatar.dart'; 
import 'package:m_senorial/components/my_buttonCategories.dart';
import 'package:m_senorial/components/my_circularbutton.dart';



class Categories extends StatefulWidget {
  Categories({Key? key}) : super(key: key);

  @override
  _CategoriesState createState() => _CategoriesState();
}

class _CategoriesState extends State<Categories> {
  final TextEditingController _searchController = TextEditingController();
  List<String> allCategories = [
    'Burger',
    'Pizza',
    'Noodles',
    'Chicken',
    'Vegetal',
    'Cake',
    'Beer',
    'Others'
  ];
  List<String> filteredCategories = [];

  @override
  void initState() {
    filteredCategories = allCategories;
    super.initState();
  }

  void filterCategories(String searchText) {
    setState(() {
      filteredCategories = allCategories.where((category) =>
        category.toLowerCase().contains(searchText.toLowerCase())
      ).toList();
    });
  }

  @override
  Widget build(BuildContext context) {
    void Categories() {
      Navigator.pushNamed(context, '/Categories');
    }

    return Scaffold(
      appBar: AppBar(),
      body: SingleChildScrollView(
        child: Column(
          children: [
            Row(
              children: [
                SizedBox(width: 20),
                MyCircularButton(
                  onTap: () {
                    Categories(); 
                  },
                  text: '',
                  diameter: 50, 
                ),
                SizedBox(width: 20),
                Column(
                  crossAxisAlignment: CrossAxisAlignment.start,
                  children: [
                    Text(
                      'Ventas',
                      style: TextStyle(
                      fontSize: 16,
                      fontWeight: FontWeight.bold,
                      color: Color.fromARGB(255, 228, 129, 15),
                      ),
                    ),
                    SizedBox(height: 0),
                    Text(
                      'Mauricio',
                      style: TextStyle(
                      fontSize: 16,
                      fontWeight: FontWeight.bold,
                      ),
                    ),
                  ],
                ),
                SizedBox(width: 200),
                MyCircularButton(
                  onTap: () { 
                    Categories(); 
                  },
                  text: '',
                  diameter: 50, 
                ),
              ],
            ),
                const SizedBox(height: 10),
                 Padding(
                  padding: const EdgeInsets.all(8.0),
                  child: TextField(
                  controller: _searchController,
                  onChanged: filterCategories,
                  decoration: InputDecoration(
                  labelText: 'Search',
                  border: OutlineInputBorder(
                  borderRadius: BorderRadius.circular(20.0),
                   ),
                   prefixIcon: Icon(Icons.search),
                ),
               ),
              ),

            const SizedBox(height: 100),
            Wrap(
              children: [
                for (var category in filteredCategories)
                  Padding(
                    padding: const EdgeInsets.all(6.0),
                    child: my_buttonCategories(
                    onTap: Categories,
                    text: category,
                    color: Color.fromARGB(255, 184, 184, 183),
                    ),
                  ),
              ],
            ),
            SizedBox(height: 10),
            Row(
  children: [
    SizedBox(width: 165),
    MyCircleAvatar(
      onTap: () {
      },
      text: '+',
      color: Color.fromARGB(255, 184, 184, 183),
    ),   
  ],
),

          ],
        ),
      ),
    );
  }
}
