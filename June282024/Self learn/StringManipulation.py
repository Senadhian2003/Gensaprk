
name  = 'spiderMAN'
# upper() converts whole text to Upper case

print("Upper : ",name.upper())

# capitalize() converts first character of word to uppercase

print("Capitalize : ",name.capitalize())

# capitalize() converts first character of word to uppercase and others to lower case
print("Title : ",name.title()) 

# Inverses the case of the word
print("Swapcase : ",name.swapcase())

# Count a substring in string
print("Count of man : ",name.count('a'))

# Replace a character in string (substring, replaceString, First how many occurance should be changed(default-1 all occurances changed))
print("Replace m to l : ",name.replace('MA','l',-1))


name.isalnum()
name.isalpha()
name.isascii()
name.isdigit()
name.isdecimal()
name.isnumeric()
name.isupper()
name.islower()
name.isspace()
name.isprintable()
name.isidentifier()