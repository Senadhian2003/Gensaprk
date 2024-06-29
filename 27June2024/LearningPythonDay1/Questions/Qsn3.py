name = input("Enter your Name : ").strip()
gender = input("Gender M or F : ").strip()

if(gender=="M"):
    print(f'Hello, Welcome Mr.{name}')
else:
    print(f'Hello, Welcome Mrs.{name}')