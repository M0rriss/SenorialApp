import 'package:flutter/material.dart';
import 'package:m_senorial/router/router.dart';
import 'package:hive_flutter/hive_flutter.dart';


void main() async {
 await Hive.initFlutter();
  Hive.openBox('security');
  WidgetsFlutterBinding.ensureInitialized();
  runApp(MyApp());
}


class MyApp extends StatelessWidget {
  const MyApp({super.key});

  // This widget is the root of your application.flutter run

  @override
  Widget build(BuildContext context)  {
  
    return MaterialApp.router(
      debugShowCheckedModeBanner: false,
      
      title: 'Señorial0',
      theme: ThemeData(
        useMaterial3: true,
        
      ),
      routerConfig: router, 
    );
  }
}