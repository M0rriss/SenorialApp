import 'package:flutter/material.dart';
import 'package:m_senorial/components/my_buttonExtras.dart';
import 'package:m_senorial/components/my_circularbutton.dart';
import 'package:m_senorial/components/my_buttonOrden.dart';


class OrderMenu extends StatelessWidget {
  OrderMenu({Key? key}) : super(key: key);

  final codeController = TextEditingController();

  void mesas() {}

  @override
  Widget build(BuildContext context) {
    void OrderMenu() {
      Navigator.pushNamed(context, '/OrderMenu');
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
                    OrderMenu();
                  },
                  text: '',
                  diameter: 50,
                ),
                SizedBox(width: 20),
                Column(
                  crossAxisAlignment: CrossAxisAlignment.start,
                  children: [
                    Text(
                      'ORDER MENU',
                      style: TextStyle(
                        fontSize: 16,
                        fontWeight: FontWeight.bold,
                        color: Color.fromARGB(255, 14, 14, 13),
                      ),
                    ),
                    SizedBox(height: 0),
                    Text(
                      'Order N°.16',
                      style: TextStyle(
                        fontSize: 16,
                        fontWeight: FontWeight.normal,
                      ),
                    ),
                  ],
                ),
              ],
            ),
            SizedBox(height: 40),
            Row(
              children: [
                SizedBox(width: 200),
                MyButtonExtras(
                  borderRadius: 10,
                  onTap: () {},
                  text: 'Agregar Extras',
                  color: Color.fromARGB(255, 230, 138, 32),
                ),
              ],
            ),
            SizedBox(height: 20),
                Row(
                  children: [
                    SizedBox(width: 30,),
                    Text(
                      'Total 03 items',
                      style: TextStyle(
                        color: Color.fromARGB(255, 171, 169, 167),
                        fontSize: 18,
                        fontWeight: FontWeight.normal
                      ),
                    ),
                  ],
                ),
            SizedBox(height: 35),
            ProductWidget(),
            SizedBox(height: 35),
            ProductWidget(),
            SizedBox(height: 35),
            ProductWidget(),
            SizedBox(height: 35),
            Column(
              crossAxisAlignment: CrossAxisAlignment.start,
            children: [
            MyButtonOrdern(
            borderRadius: 10,
            onTap: () {},
            text: 's/.115.00',
            color: Color.fromARGB(255, 230, 138, 32),
            additionalText: Text(
              '3 Items',
              style: TextStyle(
                color: Color.fromARGB(255, 233, 233, 233),
                fontSize: 10,
                fontWeight: FontWeight.normal,
              ),
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
class ProductWidget extends StatefulWidget {
  @override
  _ProductWidgetState createState() => _ProductWidgetState();
}

class _ProductWidgetState extends State<ProductWidget> {
  int quantity = 0;

  void incrementQuantity() {
    setState(() {
      quantity++;
    });
  }
  void decrementQuantity() {
    if (quantity > 0) {
      setState(() {
        quantity--;
      });
    }
  }
  @override
  Widget build(BuildContext context) {
    return Row(
  mainAxisAlignment: MainAxisAlignment.center,
  children: [
    Image.asset(
      'lib/imagenes/burger1.png',
      width: 90, 
      height: 90, 
    ),
    SizedBox(width: 10),
    Column(
      crossAxisAlignment: CrossAxisAlignment.start,
      children: [
        Text(
          'Chicken Thai Biriyani',
          style: TextStyle(
            fontSize: 16,
            fontWeight: FontWeight.bold,
          ),
        ),
        Text(
          'Container',
          style: TextStyle(
            fontSize: 14,
          ),
        ),
        SizedBox(width: 200), 
        Container(
          padding: EdgeInsets.symmetric(vertical: 0.1, horizontal: 0.1),
          decoration: BoxDecoration(
            color: Color.fromARGB(255, 232, 146, 41),
            borderRadius: BorderRadius.circular(18),
          ),
          child: Row(     
            children: [
              IconButton(
                iconSize: 12,
                icon: Icon(Icons.remove),
                onPressed: decrementQuantity,
              ),
              Text(
                '$quantity',
                style: TextStyle(fontSize: 12),
              ),
              IconButton(
                iconSize: 12,
                icon: Icon(Icons.add),
                onPressed: incrementQuantity,
              ),
            ],
          ),
        ),
      ],
    ),
    SizedBox(width: 10),
    Column(
      crossAxisAlignment: CrossAxisAlignment.start,
      children: [
        Text(
          's/.60',
          style: TextStyle(
            fontSize: 16,
            fontWeight: FontWeight.bold,
            color: Colors.green,
          ),
        ),
      ],
    ),
    
    
  ],
  
);



  }
}

