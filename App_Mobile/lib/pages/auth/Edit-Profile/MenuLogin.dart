import 'package:flutter/material.dart';
import 'package:font_awesome_flutter/font_awesome_flutter.dart';
import 'package:m_senorial/components/Buttons/buttonUser.dart';
import 'package:m_senorial/components/Buttons/buttonback.dart';
import 'package:m_senorial/components/Extras/EditUsuarioWidget.dart';

class MenuLogin extends StatelessWidget {
  MenuLogin({Key? key}) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      body: SingleChildScrollView(
        child: Column(
          crossAxisAlignment: CrossAxisAlignment.start,
          children: [
            const SizedBox(height: 45),
            Row(
              children: [
                const SizedBox(width: 20),
                ButtonBack(
                  onTap: () {
                    // Acción al presionar el botón de regreso
                  },
                ),
                const SizedBox(width: 20),
                Column(
                  crossAxisAlignment: CrossAxisAlignment.start,
                  children: const [
                    Text(
                      'Profile',
                      style: TextStyle(
                        fontSize: 20.69,
                        fontWeight: FontWeight.normal,
                        color: Color.fromRGBO(24, 28, 46, 1),
                      ),
                    ),
                  ],
                ),
                const Spacer(), // Asegura que el ícono esté en el extremo derecho
                Container(
                  width: 54.77,
                  height: 54.77,
                  decoration: BoxDecoration(
                    color: Colors.transparent, // Hace que el fondo del círculo sea transparente
                    shape: BoxShape.circle,
                  ),
                  child: IconButton(
                    icon: const FaIcon(
                      FontAwesomeIcons.ellipsis,
                      color: Color.fromRGBO(24, 28, 46, 1),
                    ),
                    iconSize: 24,
                    onPressed: () {
                      // Acción al presionar el ícono de "ellipsis"
                    },
                  ),
                ),
                const SizedBox(width: 20), // Espacio a la derecha
              ],
            ),
            const SizedBox(height: 10),
            Row(
              children: [
                const SizedBox(width: 65),
                UserButton(
                  widthUser: 118.66,
                  heightUser: 118.66,
                  onTap: () {
                    // Acción al presionar el botón de usuario
                  },
                ),
                const SizedBox(width: 40), // Espacio adicional a la derecha del UserButton
                Column(
                  crossAxisAlignment: CrossAxisAlignment.start,
                  children: const [
                    Text(
                      'Felix Lujan',
                      style: TextStyle(
                        fontSize: 23.73,
                        fontWeight: FontWeight.bold,
                        color: Color.fromRGBO(24, 28, 46, 1),
                      ),
                    ),
                    Text(
                      'Mi perra',
                      style: TextStyle(
                        fontSize: 16.61,
                        color: Color.fromRGBO(24, 28, 46, 1),
                      ),
                    ),
                  ],
                ),
              ],
            ),
            const SizedBox(height: 20),
            EditUsuarioWidget(
              name: 'Personal Info',
              onEdit: () {
                // Acción al presionar el botón de editar
              },
            ),
            const SizedBox(height: 330),
            EditUsuarioWidget(
              name: 'Log Out',
              onEdit: () {
                // Acción al presionar el botón de editar
              },
              showLogoutIcon: true, // Muestra el ícono de logout
              customIcon: FontAwesomeIcons.signOutAlt, // Ícono de logout personalizado
            ),
          ],
        ),
      ),
    );
  }
}
