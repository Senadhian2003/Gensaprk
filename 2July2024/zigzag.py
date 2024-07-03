def convert(s: str, row: int) -> str:
        
        const_gap = (row*2) - 2
        variable_gap = (row*2) - 2
        left=0
        right=0
        start = 0
        f=""
        for i in range(0,row):
            left=i
            right=i
            while left<len(s) :
                if(left!=right and variable_gap!=0 ):
                   f+=s[left]
                #    print("left ", f)
                if(right<len(s)):
                    f+=s[right]
                    # print("Right :" , f)
                left=right + variable_gap
                right+=const_gap
            # print(f)
            variable_gap-=2
            
        return f 

s=convert("PAYPALISHIRING",4)
print(s)