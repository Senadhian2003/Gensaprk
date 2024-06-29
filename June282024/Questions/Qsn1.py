#1) Longest Substring Without Repeating Characters. 
# That is in a given string find the longest substring that does not contain any character twice.

x='ABCDEFGABEF'

left = 0
right = 0
newString = ""
max_len = 0
sub_string_list = []

while right<len(x):

    temp = x[right]

    while temp in newString:
        newString = newString[1:]
    
    newString+=temp

    if(len(newString)>max_len):
        sub_string_list.clear()
        sub_string_list.append(newString)
        max_len = len(newString)
    elif(len(newString)==max_len):
        sub_string_list.append(newString)
    right+=1

print(sub_string_list)