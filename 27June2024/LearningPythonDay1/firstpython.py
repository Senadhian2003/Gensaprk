Python 3.12.4 (tags/v3.12.4:8e8a4ba, Jun  6 2024, 19:30:16) [MSC v.1940 64 bit (AMD64)] on win32
Type "help", "copyright", "credits" or "license()" for more information.
>>> print("HOLA AMIGO")
HOLA AMIGO
>>> 
>>> 
>>> x = inpu.strip()
Traceback (most recent call last):
  File "<pyshell#3>", line 1, in <module>
    x = inpu.strip()
NameError: name 'inpu' is not defined. Did you mean: 'input'?
>>> x = input.strip()
Traceback (most recent call last):
  File "<pyshell#4>", line 1, in <module>
    x = input.strip()
AttributeError: 'builtin_function_or_method' object has no attribute 'strip'
>>> x = input().strip()
Hakuna matata
>>> print x
SyntaxError: Missing parentheses in call to 'print'. Did you mean print(...)?
>>> print(x)
Hakuna matata
