#Credit card validation - Luhn check algorithm

def validate_credit_card(number):

    number_length = len(number)
    final_sum = 0
    for i in range(number_length - 2, -1, -2):

        double = int(number[i]) * 2

        if(double>=10):
        
            final_sum += double // 10 + double % 10
        else:
            final_sum+=double
    
    for i in range(number_length - 1, -1, -2):
        final_sum += int(number[i])
    
    if(final_sum%10==0):
        return True
    # print(final_sum)
    return False


credit_card_number = input("Enter credit card number : ").strip()

print(validate_credit_card(credit_card_number))