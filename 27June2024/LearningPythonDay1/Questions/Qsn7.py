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

# Average of prime numbers
cnt=0
sum=0
for i in range(0,3):

    x = int(input("Enter number : ").strip())

    if(checkPrime(x)):
        sum+=x
        cnt+=1

print(f"The average of prime numbers is {sum/cnt}")