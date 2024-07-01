import 'package:flutter/material.dart';

class MyCircularButton extends StatelessWidget {
  final Function()? onTap;
  final String text;
  final double diameter;

  const MyCircularButton({
    Key? key,
    required this.onTap,
    required this.text,
    required this.diameter,
  }) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return GestureDetector(
      onTap: onTap,
      child: Container(
        width: diameter,
        height: diameter,
        decoration: BoxDecoration(
          color: Color.fromARGB(255, 177, 175, 174),
          shape: BoxShape.circle,
        ),
        child: Center(
          child: Row(
            mainAxisAlignment: MainAxisAlignment.center,
            children: [
              Icon(Icons.arrow_back, color: const Color.fromARGB(255, 14, 14, 14)),
              
              SizedBox(width: 5), 
              Text(
                text,
                style: TextStyle(
                  color: Colors.white,
                  fontSize: 14,
                  fontWeight: FontWeight.bold,
                ),
              ),
            ],
          ),
        ),
      ),
    );
  }
}

class ListBoxExample extends StatefulWidget {
  @override
  _ListBoxExampleState createState() => _ListBoxExampleState();
}

class _ListBoxExampleState extends State<ListBoxExample> {
  String? _selectedItem;

  List<String> _items = ['Item 1', 'Item 2', 'Item 3', 'Item 4'];

  @override
  Widget build(BuildContext context) {
    return DropdownButton<String>(
      hint: Text('Select an item'),
      value: _selectedItem,
      onChanged: (String? newValue) {
        setState(() {
          _selectedItem = newValue;
        });
      },
      items: _items.map((String item) {
        return DropdownMenuItem<String>(
          value: item,
          child: Text(item),
        );
      }).toList(),
    );
  }
}