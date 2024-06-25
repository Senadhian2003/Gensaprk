class Person {

    constructor(name,age){
        this.name = name
        this.age = age;

    }

    greetPerson(){
        console.log("WELCOME " + this.name)
    }

    getMyDetails(){
        console.log("Name :"+this.name+"\nAge :" + age)
    }

}

class Student extends Person{

    constructor(name,age,schoolName){
        super(name,age)
        this.schoolName = schoolName;
    }

    getMyDetails(){
        console.log("Name : "+ this.name + "\nAge :"+this.age+"\nSchool :"+this.schoolName)

    }

}

let student = new Student("Spider",20,"ABC")
student.greetPerson()
student.getMyDetails()