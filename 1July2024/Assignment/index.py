import re
from datetime import datetime
import json
import pandas as pd
from reportlab.lib.pagesizes import letter
from reportlab.platypus import SimpleDocTemplate, Table, TableStyle
from reportlab.lib import colors

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

def menu():
    print("Where do you want to save the user details :\n1.Text File\n2.Excel File\n3.pdf File")


def printDetails():
    print("\n**************************\n")
    print(f"Name : {name}\nAge : {age}\nDate Of Birth : {date_of_birth}\nPhone number : {phone}")
    print("\n**************************\n")



class Person:

    def __init__(self, name, date_of_birth, age, phone):

        self.name = name
        self.date_of_birth = date_of_birth
        self.age = age
        self.phone = phone

    def to_dict(self):
        return {
            'name': self.name,
            'date_of_birth': self.date_of_birth.strftime("%Y-%m-%d"),
            'age': self.age,
            'phone': self.phone
        }

def save_to_pdf(data):
    pdf_file = "employee_details.pdf"
    document = SimpleDocTemplate(pdf_file, pagesize=letter)
    elements = []

    # Column headings
    headings = ['Name', 'Date of Birth', 'Age', 'Phone']

    # Convert the data to a list of lists
    data_list = [headings] + [[person['name'], person['date_of_birth'], person['age'], person['phone']] for person in data]

    # Create the table
    table = Table(data_list)

    # Style the table
    style = TableStyle([
        ('BACKGROUND', (0, 0), (-1, 0), colors.grey),
        ('TEXTCOLOR', (0, 0), (-1, 0), colors.whitesmoke),
        ('ALIGN', (0, 0), (-1, -1), 'CENTER'),
        ('FONTNAME', (0, 0), (-1, 0), 'Helvetica-Bold'),
        ('FONTSIZE', (0, 0), (-1, 0), 12),
        ('BOTTOMPADDING', (0, 0), (-1, 0), 12),
        ('BACKGROUND', (0, 1), (-1, -1), colors.beige),
        ('GRID', (0, 0), (-1, -1), 1, colors.black),
    ])
    table.setStyle(style)

    # Add the table to the elements list
    elements.append(table)

    # Build the PDF
    document.build(elements)
    print(f"Data saved to {pdf_file}")


def saveDataToFile(arr):
    menu()
    option = input("Choose an option to save (1 for Text File, 2 for Excel File, 3 for PDF File): ").strip()

    json_data = json.dumps([user.to_dict() for user in arr])

    if option == '1':
        json_obj = json.dumps([person.to_dict() for person in arr])
        with open('read.txt', 'w') as file:
            file.write(json_data)
        print("Data saved to read.txt")
    elif option == '2':
        # data = [person.to_dict() for person in arr]
        df = pd.DataFrame(json_data)
        df.to_excel('employee_details.xlsx', index=False)
        print("Data saved to employee_details.xlsx")
    elif option == '3':
        save_to_pdf(json_data)


def get_user_input():
    l=[]
    while True:
        
        name = validateName(input("Enter name : ").strip())
        date_of_birth = get_date_of_birth()
        age = calculate_age(date_of_birth)
        phone = validatePhone(input("Enter phone number : ").strip())
        obj =  Person(name,date_of_birth,age,phone)
        
        l.append(obj)

        while True:
            print("1. New User\n0. Exit")
            option = input("Enter your choice: ").strip()
            if option in ['0', '1']:
                option = int(option)
                break
            else:
                print("Invalid option. Please enter 0 or 1.")

        if option == 0:
            return l


userInputList = get_user_input()
print(user.to_dict() for user in userInputList)
# m=[{"name": "Spider", "date_of_birth": "2020-01-01", "age": 4, "phone": "9393939393"}, {"name": "Sena", "date_of_birth": "2003-04-03", "age": 21, "phone": "9988788987"}]
saveDataToFile(userInputList)





