// import 'package:flutter/material.dart';
// import 'package:m_senorial/components/my_buttonTwo.dart';
// import 'package:m_senorial/components/my_buttonTables.dart';
// import 'package:m_senorial/components/my_circularbutton.dart';


// class TablesRegister extends StatelessWidget {
//   TablesRegister({Key? key}) : super(key: key);

//   final codeController = TextEditingController();
//   void mesas(){
//   }
//   @override
//   Widget build(BuildContext context) {
//     void Tables() {
//       Navigator.pushNamed(context, '/tableRegister');
//     }
//     return Scaffold(
//       appBar: AppBar(),
//       body: SingleChildScrollView(
//         child: Column(
//           children: [
//      Row(
//   children: [
//     SizedBox(width: 20),
//     MyCircularButton(
//       onTap: () {
//         Tables(); 
//       },
//       text: '',
//       diameter: 50, 
//     ),
//     SizedBox(width: 20),
//     Column(
//       crossAxisAlignment: CrossAxisAlignment.start,
//       children: [
//         Text(
//           'Ventas',
//           style: TextStyle(
//             fontSize: 16,
//             fontWeight: FontWeight.bold,
//             color: Color.fromARGB(255, 228, 129, 15),
//           ),
//         ),
//         SizedBox(height: 0),
//         Text(
//           'Mauricio',
//           style: TextStyle(
//             fontSize: 16,
//             fontWeight: FontWeight.bold,
//           ),
//         ),
//       ],
//     ),
//     SizedBox(width: 100),
//     my_buttonTwo(
//       buttonback: 12,
//       onTap: () {
//         Tables(); 
//       },
//       text: 'Mesas',
//       color: Color.fromARGB(255, 236, 152, 57),
//     ),
//     MyCircularButton(
//       onTap: () { 
//         Tables(); 
//       },
//       text: '',
//       diameter: 50, 
//     ),
//   ],
// ),
//      const SizedBox(height: 190),
//   Wrap(
//   children: [
//     Row(
//    children: [
//     SizedBox(width: 35),
//     my_buttonTables(
//       onTap: () {
//         Tables(); 
//       },
//       text: '1',
//       color: Color.fromARGB(255, 228, 129, 15),
//     ),
//     SizedBox(width: 1), 
//     my_buttonTables(
//       onTap: () {
//         Tables(); 
//       },
//       text: '2',
//       color: Color.fromARGB(255, 184, 184, 183),
//     ),
//     SizedBox(width: 1), 
//     my_buttonTables(
//       onTap: () {
//         Tables(); 
//       },
//       text: '3',
//       color: Color.fromARGB(255, 184, 184, 183),
//     ),
//   ],
// ),
//  SizedBox(height: 80),
//     Row(
//       children: [
//         SizedBox(width: 35,),
//     my_buttonTables(
//       onTap: () {
//         Tables(); 
//       },
//       text: '4',
//       color: Color.fromARGB(255, 184, 184, 183),
//     ),
//         SizedBox(width: 1),
      
//     my_buttonTables(
//       onTap: () {
//         Tables(); 
//       },
//       text: '5',
//       color: Color.fromARGB(255, 184, 184, 183),
//     ),
//         SizedBox(width: 1),
    
//     my_buttonTables(
//       onTap: () {
//         Tables(); 
//       },
//       text: '6',
//       color: Color.fromARGB(255, 184, 184, 183),
//     ),
//    ]
//     ),
//     SizedBox(height: 80),
//      Row(
//       children: [
//         SizedBox(width: 35,),
       
//     my_buttonTables(
//       onTap: () {
//         Tables(); 
//       },
//       text: '7',
//       color: Color.fromARGB(255, 184, 184, 183),
//     ),
//         SizedBox(width: 1),
      
//     my_buttonTables(
//       onTap: () {
//         Tables(); 
//       },
//       text: '8',
//       color: Color.fromARGB(255, 184, 184, 183),
//     ),
//         SizedBox(width: 1),
    
//     my_buttonTables(
//       onTap: () {
//         Tables(); 
//       },
//       text: '9',
//       color: Color.fromARGB(255, 184, 184, 183),
//     ),
//       ],
//     ),
//     SizedBox(height: 80),
//     Row(
//       children: [
//         SizedBox(width: 85),
//     my_buttonTables(
//       onTap: () {
//         Tables(); 
//       },
//       text: '10',
//       color: Color.fromARGB(255, 184, 184, 183),
//     ),
//         SizedBox(width: 20),
//     my_buttonTables(
//       onTap: () {
//         Tables(); 
//       },
//       text: '+',
//       color: Color.fromARGB(255, 184, 184, 183),
//     ),  
//       ],
//     ),
//   ]
//   ),
// ]
// )
// ),    
//   );
//   }
// }
