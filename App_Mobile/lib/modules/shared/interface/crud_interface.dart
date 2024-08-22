import 'package:dio/dio.dart';

abstract class CrudInterface{
  Future<Response>get();
}