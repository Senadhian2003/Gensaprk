from itertools import permutations



name = input().strip()

perms = permutations(name)
perm_list = [''.join(p) for p in perms]
for perm in perm_list:
    print(perm)