let arr = [{ name: "spider", password: 123 }, { name: "Bat", password: 123 }];

let validateName = () => {
  const name = document.querySelector("#NameInput").value;
  const validationMessage = document.querySelector("#NameHelp");
  const containsNumbers = /\d/;
  if (!name) {
    validationMessage.textContent = "Name cannot be empty";
    validationMessage.style.color = "red";
  } else if (name.length < 3) {
    validationMessage.textContent = "Name cannot be less than 3";
    validationMessage.style.color = "red";
  } else if (containsNumbers.test(name)) {
    validationMessage.textContent = "Name cannot contain numbers";
    validationMessage.style.color = "red";
  } else {
    validationMessage.textContent = "Accepted";
    validationMessage.style.color = "green";
  }
};

let submitData = () => {
  

  let final = document.getElementById("final");
  validateName();

  const name = document.querySelector("#NameInput").value.toLowerCase();
  const password = document.querySelector("#PasswordInput").value;

  const isValid = arr.some(
    (item) =>
      item.name.toLowerCase() === name && item.password === parseInt(password)
  );

  if (isValid) {
    final.textContent = "Success";
    // Redirect the user or perform additional actions
  } else {
    final.textContent = "Invalid username or password";
  }
};