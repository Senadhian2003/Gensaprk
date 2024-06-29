x = input("Say somethin....").strip()

print(x)

# String formatting

#type 1
a = 1
b = 'Two'
c = 12.3

print('a: {a}, b: {b}, c: {c}'.format(a=a, b=b, c=c))

# Type 2

x=5
y = 11.56789
z = "numerics"
print('The vaue of x id %d, The value of y is %.3f and they both are %s'%(x,y,z))

#type 3

x=5
y = 11.56789
z = "numerics"

print(f'The value of x is {x}, The value of y is {y} and they both are {z}')


x=5
print(type(x))

# if else

a=input("Say Hii or Bye").strip()
if(a=="Hii"):
    print("Hello user")

elif(a=="Bye"):
    print("Bye User")

else:
    print("Invalid")

# Iterations

for i in range(0,5):
    print(i)

i=0
while(i<5):
    print(i)
    i+=1

# Methods and Return

def calculateSum(a,b):

    return a+b

print(calculateSum(5,5))


# List and indexing

l=[0]*5
# l[6] = 2 Index out of range
l[4] = 2
print(l)