# Default parameters

def perform_operation(x,y='eat'):
    print(x,y)

perform_operation("I want to")


# args parameters, with unknown number of items

def a_list_of_args(*args):
    for item in args:
        print(item)

a_list_of_args("Hello There", "How are you", "I have", 6, "Biscuits")

