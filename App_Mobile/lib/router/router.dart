  import 'package:go_router/go_router.dart';
  import 'package:m_senorial/pages/auth/forget-password/ForgetPassword.dart';
  import 'package:m_senorial/pages/auth/verification/Verified.dart';
  import 'package:m_senorial/pages/home/Home.dart';
  import 'package:m_senorial/pages/tables/sales-table/SalesTable.dart';
  import 'package:m_senorial/pages/auth/login/Login.dart';
  import 'package:m_senorial/pages/auth/signup/Signup.dart';
  import 'package:m_senorial/pages/auth/recovery-password/Recoverypassword.dart';


  final GoRouter router = GoRouter(
    initialLocation: '/',
    routes: [
      GoRoute(
        path: '/',
        builder: (context, state) => SignUp(), 
        routes: [
          GoRoute(
            path: 'singup',
            builder: (context, state) => SignUp(),
            ),
          GoRoute(
            path: 'ForgetPassword',
            builder: (context, state) => ForgetPassword(),
            )
        ],
        ),
      GoRoute(
        path: '/home',
        builder: (context, state) => const Home(),
        ),
        GoRoute(
          path: '/salestable', 
          builder: (context, state) => Salestable(),
        )
        
    ], 
    );




//home: Login(),
      /*
      initialRoute: '/',
      routes:{
        '/':(context) => OrderMenu(),
        '/signup':(context) => Sigup(),
        '/forgotpassword':(context) => ForgotPassword(),
        '/home': (context) => const Home(),
        '/verified': (context) => Verified(),
        '/tables': (context) => Tables(),
        '/tablesregister': (context) => TablesRegister(),
        '/categories': (context) => Categories(),
        '/productslist':(context) => ProductsList(),
        '/ordersuccessful':(context) => OrderSuccessful(),
        '/ordermenu':(context) => OrderMenu(), 
      }
      */
      //home: const MyHomePage(title: 'Flutter Demo Home Page'),