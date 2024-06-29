#print pyramid 

rows = int(input("Enter no of rows").strip())

columns = (rows*2) -1

left=columns//2
right = columns//2

for i in range(0,rows):

    for j in range(0,columns):

        if(j>=left and j<=right):
            print("*",end="")
        else:
            print(" ",end="")
    print()
    left-=1
    right+=1
