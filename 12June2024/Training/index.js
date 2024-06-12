// const accessingParaElement=()=>{
    
// }

// const nodeList=document.getElementsByName('gen')
// console.log(nodeList)

// const tagList=document.getElementsByTagName('P')
// console.log(tagList)

// const classList=document.getElementsByClassName('demo')


// console.log(classList)

// // const paraId=document.querySelector('.para1')
// // console.log(paraId)
// accessingParaElement()


// const dateDisplay=()=>{
//     document.getElementById('demo').innerHTML=Date()
// }

// dateDisplay();


let para=document.querySelectorAll('.para1')
    console.log(para)
    para.forEach(element => {
        element.innerHTML = "HELLO BOIS"
    });