d = {
    "name" : "Spiderman",
    "age" : 20
}


print(d)

l = d.keys() # Keys as a list
print(l)
for i in l:
    print(i)

m = d.values() # values as a list
print(m)

d_cpy = d.copy() #Returns a shallow copy of the dictionary
print(d_cpy)

print(d["name"])#If not present values are given throws error
print(d.get("notpresent"))#If not present values are given None is returned

items = d.items()
for i in items:
    print(i)