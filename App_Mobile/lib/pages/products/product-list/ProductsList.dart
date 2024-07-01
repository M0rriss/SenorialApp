import 'package:flutter/material.dart';
import 'package:m_senorial/components/my_buttonList.dart';
import 'package:m_senorial/components/my_circularbutton.dart';
import 'package:m_senorial/components/my_List_Box.dart';


class ProductsList extends StatefulWidget {
  ProductsList({Key? key}) : super(key: key);

  @override
  _ProductsListState createState() => _ProductsListState();
}

class _ProductsListState extends State<ProductsList> {
  final TextEditingController _searchController = TextEditingController();
  List<String> _products = [
    'Chese Burger',
    'Chicker chicken',
    'Chese Burger',
    'Chicker chicken',
    'Chese Burger',
    'Chicker burger',
    'Chicker chicken',
    'Chicker burger',
    
  ];
  List<String> _filteredProducts = [];

  @override
  void initState() {
    super.initState();
    _filteredProducts = _products;
  }

  void _searchProduct(String query) {
    setState(() {
      _filteredProducts = _products
          .where((product) =>
              product.toLowerCase().contains(query.toLowerCase()))
          .toList();
    });
  }
  
  @override
  Widget build(BuildContext context) {
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
                  },
                  text: '',
                  diameter: 50,
                ),
                SizedBox(width: 20),
                Column(
                  crossAxisAlignment: CrossAxisAlignment.start,
                  children: [],
                ),
                Container(
                  padding: EdgeInsets.all(20.0),
                  child: ListBoxWidget(items: _filteredProducts),
                ),
                SizedBox(width: 100),
                MyCircularButton(
                  onTap: () {
                  },
                  text: '',
                  diameter: 50,
                ),
              ],
            ),
            const SizedBox(height: 15), 
            Padding(
              padding: EdgeInsets.symmetric(horizontal: 20),
              child: TextField(
                controller: _searchController,
                onChanged: _searchProduct,
                decoration: InputDecoration(
                  hintText: 'Search...',
                  border: OutlineInputBorder(
                    borderRadius: BorderRadius.circular(20.0)
                  ),
                  prefixIcon: Icon(Icons.search),
                  suffixIcon: IconButton(
                    onPressed: () {
                      _searchController.clear();
                      _searchProduct('');
                    },
                    icon: Icon(Icons.clear),
                  ),
                ),
              ),
            ),
            const SizedBox(height: 40), 
            Wrap(
              children: [
                for (var product in _filteredProducts)
                  Column(
                    children: [
                      SizedBox(height: 15), 
                      SizedBox(width: 35),
                      MyButtonList(
                        onTap: () {},
                        text: product,
                        additionalText: '200 gr meat+Lettuce chesse+onion+tomato',
                        extraText: 'S/25.oo',
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

class ListBoxItems extends StatelessWidget {
  @override
  Widget build(BuildContext context) {
    return MaterialApp(
      home: Scaffold(
        appBar: AppBar(
          title: Text('hola'),
        ),
        body: Center(
          child: ListBoxExample(),
        ),
      ),
    );
  }
}

class ListBoxExample extends StatelessWidget {
  final List<String> items = ['dar', 'flutter', 'fefo cabro'];

  @override
  Widget build(BuildContext context) {
    return Container(
      padding: EdgeInsets.all(20.0),
      child: ListBoxWidget(items: items),
    );
  }
}
