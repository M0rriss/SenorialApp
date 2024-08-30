import 'package:flutter/material.dart';
import 'package:flutter/src/services/text_formatter.dart';
import 'package:flutter/services.dart';

class MyInputText extends StatefulWidget {
  final TextEditingController controller;
  final String hintText;
  final bool obscureText;
  final Color fillColor;
  final double width;
  final double height;
  final int? maxLength;
  final List<TextInputFormatter>? inputFormatters;

  const MyInputText({
    Key? key,
    required this.controller,
    required this.hintText,
    required this.obscureText,
    required this.fillColor,
    this.width = 398,
    this.height = 57,
    this.maxLength, 
    this.inputFormatters,
  }) : super(key: key);

  @override
  _MyInputTextState createState() => _MyInputTextState();
}

class _MyInputTextState extends State<MyInputText> {
  late FocusNode _focusNode;
  bool _hasFocus = false;
  bool _obscureText = true;
  Color focusColor = const Color.fromRGBO(236, 236, 236, 1);

  @override
  void initState() {
    super.initState();
    _focusNode = FocusNode();
    _focusNode.addListener(_handleFocusChange);
    _obscureText = widget.obscureText;
  }

  void _handleFocusChange() {
    if (_focusNode.hasFocus != _hasFocus) {
      setState(() {
        _hasFocus = _focusNode.hasFocus;
      });
    }
  }

  @override
  void dispose() {
    _focusNode.removeListener(_handleFocusChange);
    _focusNode.dispose();
    super.dispose();
  }

  @override
  Widget build(BuildContext context) {
    return Padding(
      padding: const EdgeInsets.symmetric(horizontal: 25.0),
      child: Column(
        crossAxisAlignment: CrossAxisAlignment.start,
        children: [
          Container(
            width: widget.width,
            height: widget.height,
            child: TextFormField(
              focusNode: _focusNode,
              controller: widget.controller,
              obscureText: _obscureText,
              style: const TextStyle(
                fontWeight: FontWeight.bold,
              ),
              decoration: InputDecoration(
                filled: true,
                fillColor: _hasFocus ? focusColor : widget.fillColor,
                hintText: widget.hintText,
                suffixIcon: widget.obscureText
                    ? IconButton(
                        icon: Icon(
                          _obscureText ? Icons.visibility : Icons.visibility_off,
                          color: const Color.fromRGBO(180, 185, 202, 1),
                        ),
                        onPressed: () {
                          setState(() {
                            _obscureText = !_obscureText;
                          });
                        },
                      )
                    : null,
                focusedBorder: OutlineInputBorder(
                  borderSide: BorderSide.none,
                  borderRadius: BorderRadius.circular(12),
                ),
                enabledBorder: OutlineInputBorder(
                  borderSide: BorderSide.none,
                  borderRadius: BorderRadius.circular(12),
                ),
                border: OutlineInputBorder(
                  borderSide: BorderSide.none,
                  borderRadius: BorderRadius.circular(12),
                ),
              ),
              maxLength: widget.maxLength,
              inputFormatters: widget.inputFormatters,
              onChanged: (text) {
                if (text.isNotEmpty) {
                  widget.controller.selection = TextSelection.fromPosition(
                    TextPosition(offset: text.length),
                  );
                }
              },
            ),
          ),
        ],
      ),
    );
  }
}
