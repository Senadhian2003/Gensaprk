let professions = ['IT','Civil','Doctor']

const datalist = document.getElementById('professions')

professions.forEach((item)=>{
    let option = document.createElement('option');
    option.value = item;
    datalist.appendChild(option);
})



document.getElementById('InputPhone').addEventListener('input', function (e) {
    // Remove any non-numeric characters
    this.value = this.value.replace(/\D/g, '');
});


let validateDate = ()=>{


    const date = document.getElementById("date")
    console.log(date)
    if(!date.value){

        const dateHelp = document.getElementById('date-help');
        dateHelp.innerHTML = "Please enter date";
        dateHelp.style.color = "red";
    }

    const ageInput = document.getElementById('age');
    const birthDate = new Date(date.value);
            const currentDate = new Date();

            let age = currentDate.getFullYear() - birthDate.getFullYear();
            const monthDifference = currentDate.getMonth() - birthDate.getMonth();
            if (monthDifference < 0 || (monthDifference === 0 && currentDate.getDate() < birthDate.getDate())) {
                age--;
            }

            ageInput.value = age;

}
    
            let validateName = () =>{
    
    
                const name = document.querySelector("#InputEmail").value;
                const validationMessage = document.querySelector("#emailHelp");
                const containsNumbers = /\d/; 
                if (!name) {
                    validationMessage.textContent = "Name cannot be empty";
                    validationMessage.style.color = "red";
                } else if (name.length < 3) {
                    validationMessage.textContent = "Name cannot be less than 3";
                    validationMessage.style.color = "red";
                }else if (containsNumbers.test(name)) {
            validationMessage.textContent = "Name cannot contain numbers";
            validationMessage.style.color = "red";
        } else {
                    validationMessage.textContent = "Accepted";
                    validationMessage.style.color = "green";
                }
               
    
    
    
            }

            let validatePhoneNumber = () => {
                const phone = document.querySelector("#InputPhone").value;
                const validationMessage = document.querySelector("#phoneHelp");
                const phonePattern = /^\d{10}$/;
            
                if (!phone) {
                    validationMessage.textContent = "Phone number cannot be empty";
                    validationMessage.style.color = "red";
                } else if (!phonePattern.test(phone)) {
                    validationMessage.textContent = "Phone number must be exactly 10 digits and contain no letters or symbols";
                    validationMessage.style.color = "red";
                } else {
                    validationMessage.textContent = "Accepted";
                    validationMessage.style.color = "green";
                }
            };


            function validateQualification() {
                const checkboxes = document.querySelectorAll('.qualification-checkbox');
                const qualificationHelp = document.getElementById('qualification-help');
                let isChecked = false;
    
                checkboxes.forEach((checkbox) => {
                    if (checkbox.checked) {
                        isChecked = true;
                    }
                });
    
                if (!isChecked) {
                    qualificationHelp.innerHTML = "Please select at least one qualification.";
                } else {
                    qualificationHelp.innerHTML = "";
                    alert("Form submitted successfully");
                    // Additional form submission logic here
                }
            }

            let validateProfession = () =>{
    
    
const professionsInput = document.getElementById("profesion-input");


                const value = professionsInput.value.trim();
                console.log("va")
                const validationMessage = document.querySelector("#profession-help");
                const containsNumbers = /\d/; 
                if (!value) {
                    validationMessage.textContent = "Profession cannot be empty";
                    validationMessage.style.color = "red";
                }
                else if (containsNumbers.test(value)) {
                    validationMessage.textContent = "Profession cannot contain numbers";
                    validationMessage.style.color = "red";
                } else {
                            validationMessage.textContent = "Accepted";
                            validationMessage.style.color = "green";
                        }
                if(!professions.includes(value)){
            
                    professions.push(value);
                    let option = document.createElement('option');
                    option.value = value;
                    datalist.appendChild(option);
            
            
            
                }
            }

let submitData = ()=>{

    let smallTags = document.querySelectorAll('small');

    let finalError = document.getElementById('final-error');
    validateName();
    validatePhoneNumber();
    validateDate();
    validateProfession();
    validateQualification();
    
    smallTags.forEach(small => {
        finalError.innerHTML += small.textContent + '<br/>';
    });

}