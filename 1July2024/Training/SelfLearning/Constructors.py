class GFG:
    def __init__(somename, name, company):
        somename.name = name
        somename.company = company

    def show(self):
        print("Hello my name is " + self.name +
              " and I work in "+self.company+".")


obj = GFG("John", "GeeksForGeeks")
print(obj.company)
obj.show()

#Here another word for self could be used under different functions 