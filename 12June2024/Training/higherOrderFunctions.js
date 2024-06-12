// function checkingEvenNumbers(num)
// {
//     return num%2==0//boolean
// }


// function filteringEvenNumbers(numbers,callbackFunc)
// {
//     let numberArray=[]
//     for(let value of numbers)
//     {
//         if(callbackFunc(value))
//             numberArray.push(value)
//     }
//     return numberArray
// }

// let arrayOfNumbers=[22,45,99,3,8,44]
// console.log(filteringEvenNumbers(arrayOfNumbers,checkingEvenNumbers))

// function greetUser(name){
//     console.log("Welcome User " + name);
// }

// function getInput(name){

//     return greetUser(name);

// }

// getInput("Spidey")


// function checkingEvenNumbers(num)
// {
//     return num%2==0//boolean
// }


// function filteringEvenNumbers(numbers,callbackFunc)
// {
//     let numberArray=[]
//     for(let value of numbers)
//     {
//         if(callbackFunc(value))
//             numberArray.push(value)
//     }
//     return ()=>console.log(numberArray)
// }

// let arrayOfNumbers=[22,45,99,3,8,44]
// // console.log(filteringEvenNumbers(arrayOfNumbers,checkingEvenNumbers))
// let result=filteringEvenNumbers(arrayOfNumbers,checkingEvenNumbers)
// result()

function checkmod(num1,num2){
    return num1>num2;
}

let arrayOfNumbers=[22,45,99,3,8,44]

let newArray = arrayOfNumbers.map(checkmod)

console.log(newArray)

