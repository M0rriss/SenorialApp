import 'package:flutter/material.dart';
import 'package:google_fonts/google_fonts.dart';
import 'package:m_senorial/components/Buttons/button.dart';
import 'package:m_senorial/components/Buttons/buttonUser.dart';
import 'package:m_senorial/components/Buttons/buttonback.dart';
import 'package:m_senorial/components/Inputs/my_input_text.dart';



// ignore: must_be_immutable
class EditTables extends StatelessWidget {
  EditTables({Key? key}) : super(key: key);

  final editmesaController = TextEditingController();
  final DescripcionmesaController = TextEditingController();

   ValueNotifier<bool> isFormValid = ValueNotifier<bool>(false);


  void EditState() {}

  @override
  Widget build(BuildContext context) {
    void EditTables() {
      Navigator.pushNamed(context, '/EditTables');
    }

    void guardar(){

    }

    return Scaffold(
      body: SingleChildScrollView(
        child: Column(
          children: [
            const SizedBox(height: 50),
            Row(
              children: [
                const SizedBox(width: 20),
                ButtonBack(
                  onTap: () {
                    Navigator.pop(context); // Retrocede una página
                  },
                ),
                const SizedBox(width: 20),
                Column(
                  crossAxisAlignment: CrossAxisAlignment.start,
                  children: [
                    Text(
                      'EDIT TABLES',
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
                        color: const Color.fromRGBO(103, 103, 103, 1)
                      ),
                    ),
                  ],
                ),
                const SizedBox(width:168),
                UserButton(
                  onTap: () {
                         // Acción cuando se presiona el botón
                            },
                )
              ],
            ),
            const SizedBox(height: 50),
             MyInputText(
              controller: editmesaController,
              hintText: "Editar el N° de mesa",
              obscureText: false,
              fillColor: Colors.grey[200] ?? Colors.grey,
            ),
            const SizedBox(height: 15),
             MyInputText(
              controller: DescripcionmesaController,
              hintText: "Descripcion de la mesa",
              obscureText: false,
              fillColor: Colors.grey[200] ?? Colors.grey,
            ),
            const SizedBox(height: 30),
           // Login button
            ValueListenableBuilder<bool>(
              valueListenable: isFormValid,
              builder: (context, value, child) {
                return MyButton(
                  width: 130,
                  height: 60,
                  onTap: guardar,
                  text: "Guardar",
                );
              },
            ),
          ]
        ),
  
      ),
    ); 
  }
}

    
    
