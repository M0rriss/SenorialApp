import 'package:flutter/material.dart';

class ListBoxWidget extends StatefulWidget {
  final List<String> items;

  ListBoxWidget({required this.items});

  @override
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