
# Unordered
# Unchangeable
# Does not allow duplicates
# The values False and 0 are considered the same value in sets, and are treated as duplicates:

myset = {"a", "b", "c"}

print(myset)

myset.add(1)
myset.add("s")
print(myset)

myset.discard('b') # If element is not present no exception raised
print(myset)

myset.remove('a') # If element is not present Key error exception is raised
print(myset)

myset.pop() #Removes random element
print(myset)

myset.clear()
print(myset)

print(type(myset))