import 'package:flutter/material.dart';

class Popup extends StatefulWidget {
  Popup({super.key});

  @override
  State<StatefulWidget> createState() => PopUpClass();
}

class PopUpClass extends State<Popup> {
  @override
  Widget build(BuildContext context) {
    return Container(
      color: Colors.white,
      child: SizedBox(
        width: 270,
        height: 118,
        child: Stack(
          children: [
            Positioned(
              left: 0,
              top: 0,
              child: Container(
                decoration: BoxDecoration(
                  color: const Color(0xffffffff),
                  borderRadius: BorderRadius.circular(14),
                ),
                child: Column(
                  mainAxisAlignment: MainAxisAlignment.start,
                  mainAxisSize: MainAxisSize.min,
                  crossAxisAlignment: CrossAxisAlignment.start,
                  children: [
                    SizedBox(
                      width: 270,
                      height: 74,
                      child: Padding(
                        padding: const EdgeInsets.only(left: 16, top: 20, right: 16, bottom: 20),
                        child: Column(
                          mainAxisAlignment: MainAxisAlignment.center,
                          crossAxisAlignment: CrossAxisAlignment.center,
                          children: [
                            Row(
                              children: [
                                Expanded(
                                  child: Container(
                                    child: Column(
                                      mainAxisAlignment: MainAxisAlignment.start,
                                      mainAxisSize: MainAxisSize.min,
                                      crossAxisAlignment: CrossAxisAlignment.center,
                                      children: [
                                        Row(
                                          children: [
                                            Expanded(
                                              child: Container(
                                                child: const Text(
                                                  '“Campos Requeridos” ',
                                                  textAlign: TextAlign.center,
                                                  style: TextStyle(decoration: TextDecoration.none, fontSize: 17, color: Color(0xff000000), fontWeight: FontWeight.normal),
                                                  maxLines: 9999,
                                                  overflow: TextOverflow.ellipsis,
                                                ),
                                              ),
                                            ),
                                          ],
                                        ),
                                        const SizedBox(height: 2),
                                        Row(
                                          children: [
                                            Expanded(
                                              child: Container(
                                                child: const Text(
                                                  'Todos los campos son requeridos',
                                                  textAlign: TextAlign.center,
                                                  style: TextStyle(decoration: TextDecoration.none, fontSize: 13, color: Color(0xff000000), fontFamily: 'Roboto-Regular', fontWeight: FontWeight.normal),
                                                  maxLines: 9999,
                                                  overflow: TextOverflow.ellipsis,
                                                ),
                                              ),
                                            ),
                                          ],
                                        ),
                                      ],
                                    ),
                                  ),
                                ),
                              ],
                            ),
                          ],
                        ),
                      ),
                    ),
                    SizedBox(
                      width: 270,
                      height: 44,
                      child: Stack(
                        children: [
                          const Positioned(
                            left: 124,
                            top: 11,
                            child: Text(
                              'Ok',
                              textAlign: TextAlign.center,
                              style: TextStyle(decoration: TextDecoration.none, fontSize: 17, color: Color(0xffff910f), fontFamily: 'Poppins-SemiBold', fontWeight: FontWeight.normal),
                              maxLines: 9999,
                              overflow: TextOverflow.ellipsis,
                            ),
                          ),
                          Positioned(
                            left: 0,
                            right: 0,
                            top: 0,
                            height: 1,
                            child: Container(
                              height: 1,
                              decoration: const BoxDecoration(
                                color: Color(0x3d000000),
                              ),
                            ),
                          ),
                        ],
                      ),
                    ),
                  ],
                ),
              ),
            ),
          ],
        ),
      ),
    );
  }
}
