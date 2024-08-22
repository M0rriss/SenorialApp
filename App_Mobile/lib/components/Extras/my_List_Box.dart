import 'package:flutter/material.dart';

class ListBoxWidget extends StatefulWidget {
  final List<String> items;

  const ListBoxWidget({required this.items});

  @override
  // ignore: library_private_types_in_public_api
  _ListBoxWidgetState createState() => _ListBoxWidgetState();
}

class _ListBoxWidgetState extends State<ListBoxWidget> {
  String? _selectedItem;

  @override
  Widget build(BuildContext context) {
    return DropdownButton<String>(
      value: _selectedItem,
      onChanged: (String? newValue) {
        setState(() {
          _selectedItem = newValue;
        });
      },
      items: widget.items.map<DropdownMenuItem<String>>((String value) {
        return DropdownMenuItem<String>(
          value: value,
          child: Text(value),
        );
      }).toList(),
    );
  }
}