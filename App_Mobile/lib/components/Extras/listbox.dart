import 'package:flutter/material.dart';
import 'package:dropdown_button2/dropdown_button2.dart';
import 'package:font_awesome_flutter/font_awesome_flutter.dart';

void main() {
  runApp(const Listbox());
}

class Listbox extends StatelessWidget {
  const Listbox({super.key});

  @override
  Widget build(BuildContext context) {
    return MaterialApp(
      home: Scaffold(
        appBar: AppBar(
          backgroundColor: Color.fromRGBO(225, 122, 40, 1),
        ),
        body: const MyForm(),
      ),
    );
  }
}

class MyForm extends StatefulWidget {
  const MyForm({super.key});

  @override
  State<MyForm> createState() => _MyFormState();
}

class _MyFormState extends State<MyForm> {
  final List<String> genderItems = ['FRIES', 'CHICKEN', 'STEAK', 'MEAL', 'BBQ'];
  String? selectedValue;

  @override
  Widget build(BuildContext context) {
    return Center(
      child: Padding(
        padding: const EdgeInsets.symmetric(horizontal: 80),
        child: DropdownButtonHideUnderline(
          child: DropdownButton2<String>(
            isExpanded: true,
            hint: const Text(
              'CATEGORÍAS',
              style: TextStyle(fontSize: 14),
            ),
            items: genderItems
                .map((item) => DropdownMenuItem<String>(
                      value: item,
                      child: Text(
                        item,
                        style: const TextStyle(fontSize: 14),
                      ),
                    ))
                .toList(),
            value: selectedValue,
            onChanged: (value) {
              setState(() {
                selectedValue = value;
              });
            },
            dropdownStyleData: DropdownStyleData(
              decoration: BoxDecoration(
                borderRadius: BorderRadius.circular(15.09),
                color: Color.fromARGB(255, 20, 201, 116),
                boxShadow: [
                  BoxShadow(
                    color: Color.fromARGB(255, 83, 26, 26).withOpacity(10),
                    spreadRadius: 2,
                    blurRadius: 5,
                    offset: Offset(0, 10),
                  ),
                ],
              ),
              offset: Offset(0, 20), // Ajusta la posición del menú desplegable
            ),
            buttonStyleData: ButtonStyleData(
              decoration: BoxDecoration(
                borderRadius: BorderRadius.circular(32),
                border: Border.all(color: Color.fromRGBO(225, 122, 40, 1)),
              ),
            ),
            iconStyleData: IconStyleData(
              icon: FaIcon(
                FontAwesomeIcons.chevronDown, // Cambia el icono a tu preferido
                color: Color.fromRGBO(236, 108, 4, 1),
              ),
            ),
          ),
        ),
      ),
    );
  }
}
