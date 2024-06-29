import re
from datetime import datetime

def validatePhone(phone):

    while not phone.isnumeric() or len(phone)!=10:
        phone = input("Enter valid phone number : ").strip()
    return phone

def validateName(name):
    pattern = re.compile("^[A-Za-z]+$")

    while not pattern.match(name) or name=='':
        name = input("Enter a valid name : ").strip()
    return name

def get_date_of_birth():
    while True:
        dob_input = input("Enter your date of birth (YYYY-MM-DD): ")
        try:
            dob = datetime.strptime(dob_input, "%Y-%m-%d")
            return dob
        except ValueError:
            print("Invalid date format. Please enter the date in YYYY-MM-DD format.")

def calculate_age(dob):
    today = datetime.today()
    age = today.year - dob.year - ((today.month, today.day) < (dob.month, dob.day))
    return age



def printDetails():
    print("\n**************************\n")
    print(f"Name : {name}\nAge : {age}\nDate Of Birth : {date_of_birth}\nPhone number : {phone}")
    print("\n**************************\n")

name = validateName(input("Enter name : ").strip())
date_of_birth = get_date_of_birth()
age = calculate_age(date_of_birth)
phone = validatePhone(input("Enter phone number : ").strip())



printDetails()


