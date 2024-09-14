import 'package:go_router/go_router.dart';
import 'package:m_senorial/models/Resquest/Pedido/pedido_request.dart';
import 'package:m_senorial/pages/Order/OrderMenu/OrderMenu.dart';
import 'package:m_senorial/pages/Order/OrderMenuIndoor/OrderMenuIndoor.dart';
import 'package:m_senorial/pages/Order/OrderSuccessful.dart';
import 'package:m_senorial/pages/auth/Register-Data/RegisterData.dart';
import 'package:m_senorial/pages/Order/Registrar-Pedidos/TakeOutRegister.dart';
import 'package:m_senorial/pages/home/Welcome-S/Welcome.dart';
import 'package:m_senorial/pages/auth/forget-password/ForgetPassword.dart';
import 'package:m_senorial/pages/auth/recovery-password/Recoverypassword.dart';
import 'package:m_senorial/pages/auth/verification/Verified.dart';
import 'package:m_senorial/pages/categories/categorie/Categories.dart';
import 'package:m_senorial/pages/home/Home.dart';
import 'package:m_senorial/pages/products/product-list/ProductsList.dart';
import 'package:m_senorial/pages/tables/sales-table/SalesTable.dart';
import 'package:m_senorial/pages/auth/login/Login.dart';
import 'package:m_senorial/pages/home/Welcome-S/Loading.dart';

final GoRouter router = GoRouter(
  initialLocation: '/',
  routes: [
    GoRoute(
      path: '/',
      builder: (context, state) => Welcome(),
    ),
    GoRoute(
      path: '/loading',
      builder: (context, state) {
        final destination = state.extra as String? ?? '/login';
        return Loading(destination: destination);
      },
    ),
    GoRoute(
      path: '/login',
      builder: (context, state) => Login(),
      routes: [
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
          routes: [
            GoRoute(
              path: 'categories',
              builder: (context, state) {
                PedidoRequest req = state.extra as PedidoRequest;
                return Categories(data: req);
              },
              routes: [
                GoRoute(
                  path: 'productslist',
                  builder: (context, state) {
                    PedidoRequest req = state.extra as PedidoRequest;
                    return ProductsList(pedido: req);
                  },
                  routes: [
                    GoRoute(
                      path: 'ordermenuindoor',
                      builder: (context, state) {
                        PedidoRequest req = state.extra as PedidoRequest;
                        return OrderMenuIndoor(pedido: req);
                      },
                      routes: [
                        GoRoute(
                          path: 'ordersuccessful',
                          builder: (context, state) => OrderSuccessful(),
                        ),
                      ],
                    ),
                  ],
                ),
                GoRoute(
                  path: 'ordermenu',
                  builder: (context, state) {
                    PedidoRequest req = state.extra as PedidoRequest;
                    return OrderMenu(
                      pedido: req,
                    ); // Faltaba el paso correcto para OrderMenu
                  },
                ),
              ],
            ),
          ],
        ),
        GoRoute(
          path: 'takeoutregister',
          // builder: (context, state) => TakeOutRegister(),
          builder: (context, state) {
            if (state.extra == null) {
              PedidoRequest roq = PedidoRequest();
              return TakeOutRegister(pedido: roq);
            } else {
              PedidoRequest req = state.extra as PedidoRequest;
              return TakeOutRegister(pedido: req);
            }
          },
          routes: [
            GoRoute(
              path: 'registerdata',
              builder: (context, state) => RegisterData(),
              routes: [
                GoRoute(
                  path: 'categories',
                  builder: (context, state) {
                    PedidoRequest req = state.extra as PedidoRequest;
                    return Categories(data: req);
                  },
                  routes: [
                    GoRoute(
                      path: 'productslist',
                      builder: (context, state) {
                        PedidoRequest req = state.extra as PedidoRequest;
                        return ProductsList(pedido: req);
                      },
                      routes: [
                        GoRoute(
                          path: 'ordermenuindoor',
                          builder: (context, state) {
                            PedidoRequest req = state.extra as PedidoRequest;
                            return OrderMenuIndoor(pedido: req);
                          },
                          routes: [
                            GoRoute(
                              path: 'ordersuccessful',
                              builder: (context, state) => OrderSuccessful(),
                            ),
                          ],
                        ),
                      ],
                    ),
                    GoRoute(
                      path: 'ordermenu',
                      builder: (context, state) {
                        PedidoRequest req = state.extra as PedidoRequest;
                        return OrderMenu(
                          pedido: req,
                        ); // Faltaba el paso correcto para OrderMenu
                      },
                    ),
                  ],
                ),
              ],
            ),
          ],
        ),
      ],
    ),
  ],
);
