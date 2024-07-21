
document.addEventListener('DOMContentLoaded', function() {
    var myModal = document.getElementById('addProductModal');
    new bootstrap.Modal(myModal);
});

function fetchProductData(){

    fetch(`http://localhost:5036/api/Product/ViewProducts`,{
        method : "GET"
    }).then(res=> res.json())
    .then((data)=>{
        console.log(data)
       
        createCards(data)
       
    }).catch((err)=>{
        console.log(err.message)
        // createErrorRow(err.message)
    
    })

}

fetchProductData()




function createCards(cards){


    let row = document.getElementById('row')

    let innerHtmlContent = ""

    cards.forEach(card => {
        const imgSrc = card.imageDescription || "https://senablobstorage.blob.core.windows.net/imagecontainer/controller.jpeg";
        innerHtmlContent +=`<div class="col-md-4 col-sm-6 mb-4">
       
            <div class="card book-card">
              <img
                src="${imgSrc}"
                class="card-img-top"
                alt="Book Cover"
                height="250px"
                
                
              />
              <div class="card-body text-center">
                <h5 class="card-title">${card.name}</h5>
               
              </div>
            </div>
          
          </div>`


    });

    row.innerHTML = innerHtmlContent;


}


function addProduct() {
    const name = document.getElementById('newProductName').value;
    const image = document.getElementById('ProductImg').files[0];

    // Get the existing modal instance instead of creating a new one
    const addProductModal = bootstrap.Modal.getInstance(document.getElementById('addProductModal'));
    if (!addProductModal) {
        console.error('Modal instance not found');
        return;
    }

    console.log(name, image);
    const formData = new FormData();
    formData.append('Name', name);
    formData.append('ProductImage', image);

    fetch('http://localhost:5036/api/Product', {
        method: "POST",
        body: formData
    })
    .then(async (res) => {
        if (!res.ok) {
            // For other error statuses, parse the error response
            const errorData = await res.json();
            throw errorData;
        }
        return res.json();
    })
    .then((data) => {
        console.log(data);
        fetchProductData();
        addProductModal.hide();  // This should now work correctly
        
        // Reset form fields
        document.getElementById('newProductName').value = '';
        document.getElementById('ProductImg').value = '';
    })
    .catch((error) => {
        console.error('Error:', error);
        // Display the error message
        if (error.message) {
            console.log(error.message);
            // You might want to show this error to the user in the UI
        }
    });
}