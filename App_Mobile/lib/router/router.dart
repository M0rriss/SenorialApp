import 'package:go_router/go_router.dart';
import 'package:m_senorial/pages/auth/forget-password/ForgetPassword.dart';
import 'package:m_senorial/pages/auth/recovery-password/Recoverypassword.dart';
import 'package:m_senorial/pages/auth/verification/Verified.dart';
import 'package:m_senorial/pages/home/Home.dart';
import 'package:m_senorial/pages/tables/sales-table/SalesTable.dart';
import 'package:m_senorial/pages/auth/login/Login.dart';
import 'package:m_senorial/pages/auth/signup/Signup.dart';

final GoRouter router = GoRouter(
  initialLocation: '/',
  routes: [
    GoRoute(
      path: '/',
      builder: (context, state) => Login(),
      routes: [
        GoRoute(
          path: 'signup',
          builder: (context, state) => SignUp(),
        ),
        GoRoute(
          path: 'forgetpassword',
          builder: (context, state) => ForgetPassword(),
          routes: [
            GoRoute(
              path: 'verified',
              builder: (context, state) => Verified(),
            ),
            GoRoute(
              path: 'recoverypassword',
              builder: (context, state) => Recoverypassword(),
            ),
          ],
        ),
      ],
    ),
    GoRoute(
      path: '/home',
      builder: (context, state) => const Home(),
      routes: [
        GoRoute(
          path: 'salestable',
          builder: (context, state) => Salestable(),
        ),
      ],
    ),
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