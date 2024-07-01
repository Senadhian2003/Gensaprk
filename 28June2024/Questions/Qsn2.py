#Print the list of prime numbers up to a given number
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
    
x = int(input().strip())

for i in range(0,x+1):
    if(checkPrime(i)):
        print(i, end=" ")
