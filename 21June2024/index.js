function employeeDetails(employeeName,employeeSalary){
    this.employeeName=employeeName
    this.employeeSalary=employeeSalary
    this.displayDetails=()=>{
        return "Employee name is "+this.employeeName+" and salary is "+this.employeeSalarya
    }
}
const firstEmployee= new employeeDetails('John',20000)
const secondEmployee= new employeeDetails('Mary',30000)

// console.log(firstEmployee.displayDetails())
// console.log(secondEmployee.displayDetails())
console.log(firstEmployee.employeeName)
console.log(secondEmployee.employeeName)


class Employee{

    constructor(name,phone){
        this.name = name;
        this.phone = phone
    }

    greet(){
        console.log("name" + this.name + "phone" + this.phone + "Paswod" + this.password)
    }

}

class Manager extends Employee{

    constructor(name,phone,password){
        super(name,phone)
        this.password = password
    }

}

let manager = new Manager("spidery","2344566543","#@$")
manager.greet()