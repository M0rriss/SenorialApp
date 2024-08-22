import 'package:flutter/material.dart';
import 'package:go_router/go_router.dart';
import 'package:google_fonts/google_fonts.dart';
import 'package:m_senorial/components/Buttons/buttonTwo.dart';
import 'package:m_senorial/components/Buttons/buttonTables.dart';
import 'package:m_senorial/components/Buttons/buttonback.dart';
import 'package:m_senorial/components/Extras/status.dart';
import 'package:m_senorial/components/Buttons/buttonUser.dart';

class Salestable extends StatefulWidget {
  Salestable({Key? key}) : super(key: key);

  @override
  _SalestableState createState() => _SalestableState();
}

class _SalestableState extends State<Salestable> {
  final codeController = TextEditingController();
  List<int> mesas = List<int>.generate(9, (index) => index + 1);

  void navCategories() {
    context.go('/home/salestable/categories');
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      body: SingleChildScrollView(
        child: Column(
          children: [
            const SizedBox(height: 45),
            Row(
              children: [
                const SizedBox(width: 20),
                ButtonBack(
                  onTap: () {
                    Navigator.pop(context);
                  },
                ),
                const SizedBox(width: 20),
                Column(
                  crossAxisAlignment: CrossAxisAlignment.start,
                  children: [
                    Text(
                      'VENTAS',
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
                        color: const Color.fromRGBO(103, 103, 103, 1),
                      ),
                    ),
                  ],
                ),
                const SizedBox(width: 83),
                MyButtonTwo(
                  onTap: () {
                    // Deja vacío si no quieres que haga nada
                  },
                  text: 'Mesas',
                  color: const Color.fromRGBO(255, 145, 15, 1),
                ),
                const SizedBox(width: 2),
                UserButton(
                  onTap: () {},
                ),
              ],
            ),
            const SizedBox(height: 85),
            StatusRow(),
            const SizedBox(height: 30),
            Center(
              child: Container(
                width: 280,
                child: GridView.builder(
                  shrinkWrap: true,
                  gridDelegate: const SliverGridDelegateWithFixedCrossAxisCount(
                    crossAxisCount: 3,
                    crossAxisSpacing: 25,
                    mainAxisSpacing: 10,
                    childAspectRatio: 74 / 60, // Ajusta el aspect ratio
                  ),
                  itemCount: mesas.length,
                  itemBuilder: (BuildContext context, int index) {
                    return ButtonTables(
                      onTap: navCategories, // Navega a Categories al hacer clic en una mesa
                      text: mesas[index].toString(),
                      color: const Color.fromRGBO(254, 240, 211, 1),
                      status: '0 items',
                      statusColor: const Color.fromRGBO(171, 174, 188, 1),
                      width: 74,
                      height: 60,
                    );
                  },
                ),
              ),
            ),
          ],
        ),
      ),
    );
  }
}
