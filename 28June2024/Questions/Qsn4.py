#Application to play the Cow and Bull game maintain score as well. - reff - Wordle of New York Times

def print_guesses(guesses):

    for i in guesses:
        print(i)

def cows_and_bulls(target):
    guesses = []

    cows = 0
    bulls = 0
    cnt = 0


    while(cows != 4):

        guess = input("Enter the guess word").strip()
        guesses.append(guess)
        for i in range(0,4):

            if guess[i] in  target:
                bulls+=1
            
            if guess[i] == target[i]:
                cows+=1
        
        bulls-=cows

        cnt+=1

        print(f'You found the target at attempt {cnt}')
        print_guesses(guesses)

