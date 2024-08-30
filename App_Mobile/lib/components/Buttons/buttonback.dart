import 'package:flutter/material.dart';
import 'package:font_awesome_flutter/font_awesome_flutter.dart';

class ButtonBack extends StatelessWidget {
  final Function()? onTap;
  static const double defaultIconSize = 14.0;

  const ButtonBack({
    Key? key,
    required this.onTap,
  }) : super(key: key);

  @override
    Widget build(BuildContext context) {
      return GestureDetector(
      onTap: onTap,
      child: Container(
        width: 45,
        height: 45,
        decoration: const BoxDecoration(
        color: Color.fromRGBO(236, 240, 244, 1),
          shape: BoxShape.circle,
        ),
        child: const Center(
          child: FaIcon(
            FontAwesomeIcons.chevronLeft,
            color: Color.fromARGB(255, 14, 14, 14),
            size: defaultIconSize,
          ),
        ),
      ),
    );
  }
}


// class ListBoxExample extends StatefulWidget {
//   @override
//   _ListBoxExampleState createState() => _ListBoxExampleState();
// }

// class _ListBoxExampleState extends State<ListBoxExample> {
//   String? _selectedItem;

//   List<String> _items = ['Item 1', 'Item 2', 'Item 3', 'Item 4'];

//   @override
//   Widget build(BuildContext context) {
//     return DropdownButton<String>(
//       hint: Text('Select an item'),
//       value: _selectedItem,
//       onChanged: (String? newValue) {
//         setState(() {
//           _selectedItem = newValue;
//         });
//       },
//       items: _items.map((String item) {
//         return DropdownMenuItem<String>(
//           value: item,
//           child: Text(item),
//         );
//       }).toList(),
//     );
//   }
// }
