from math import *
def checkPrime(num):

    if(num<=1):
        return False
    elif num<=3:
        return True
    else:

        if(num%2==0 or num%3==0):
            return False
        
        for i in range(5,floor(sqrt(num)),6):
            if(num%i==0 or num%(i+2)==0):
                return False
        return True

x = int(input("Enter the number : ").strip())
print(checkPrime(x))

