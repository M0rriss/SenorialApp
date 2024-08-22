import 'package:flutter/material.dart';


class ListBoxExample extends StatefulWidget {
  const ListBoxExample({super.key});

  @override
  // ignore: library_private_types_in_public_api
  _ListBoxExampleState createState() => _ListBoxExampleState();
}

class _ListBoxExampleState extends State<ListBoxExample> {
  List<String> _items = ['Option 1', 'Option 2', 'Option 3'];
  String? _selectedItem;

  @override
  Widget build(BuildContext context) {
    return Container(
      padding: const EdgeInsets.all(20.0),
      child: Column(
        mainAxisAlignment: MainAxisAlignment.center,
        children: [
          ListBox(
            items: _items,
            selectedItem: _selectedItem,
            onChanged: (String? newValue) {
              setState(() {
                _selectedItem = newValue;
              });
            },
          ),
        ],
      ),
    );
  }
}
class ListBox extends StatelessWidget {
  final List<String> items;
  final String? selectedItem;
  final ValueChanged<String?>? onChanged;

  ListBox({
    required this.items,
    required this.selectedItem,
    required this.onChanged,
  });
  @override
  Widget build(BuildContext context) {
    return DropdownButton<String>(
      value: selectedItem,
      icon: Icon(Icons.arrow_drop_down),
      iconSize: 24,
      elevation: 16,
      style: TextStyle(color: Colors.deepPurple),
      onChanged: onChanged,
      items: items.map<DropdownMenuItem<String>>((String value) {
        return DropdownMenuItem<String>(
          value: value,
          child: Text(value),
        );
      }).toList(),
    );
  }
}
class OrderSuccessful extends StatelessWidget {
  @override
  Widget build(BuildContext context) {
    return MaterialApp(
      home: Scaffold(
        appBar: AppBar(
        ),
        body: Center(
          child: ListBoxExample(),
        ),
      ),
    );
  }
}