
# Python3 program to

# a class
# class Dog:

#     # A simple class
#     attribute = "ggboi"
    
    

#     @staticmethod
#     def say_hello():
#         print("Woof!")

#     # A sample method
#     def fun(self):
#         self.say_hello()
#         print("I'm a", self.attribute)
        


# # Driver code
# # Object instantiation
# Rodger = Dog()
# Badger = Dog()

# Rodger.attribute = "GIrl"

# Badger.attribute  = "Boy"

# Rodger.fun()
# Badger.fun()



#With __init__

class Dog:

    kind = 'canine'         # class variable shared by all instances

    def __init__(self, name):
        self.name = name    # instance variable unique to each instance

    def setKind(self,x):
        self.kind = x

d = Dog('Fido')
e = Dog('Buddy')
d.setKind("GULuGULU")              # shared by all dogs
print(d.kind)
print(e.kind)             # shared by all dogs




class Dog:

    tricks = []             # mistaken use of a class variable

    def __init__(self, name):
        self.name = name

    def add_trick(self, trick):
        self.tricks = trick

d = Dog('Fido')
e = Dog('Buddy')
d.add_trick(['roll over','play dead'])
# e.add_trick('play dead')
print(e.tricks)
print(d.tricks)          




#When we assign something to self.value the value becomes an instance variable so it is 
#not shared by all the instances anymore. But if it is a list and we do self.list.append() 
#instead of assigning the it will be shared to all the instances of the class
