const {JSDOM} = require('jsdom');
const fs = require('fs');
const path = require('path');
//import {JSDOM} from 'jsdom';

test('Correct name and password',()=>{
    const html = fs.readFileSync(path.resolve(__dirname,'./index.html'),'utf8');
    const script = fs.readFileSync(path.resolve(__dirname,'./index.js'),'utf8');
    
    const dom = new JSDOM(html,{runScripts: 'dangerously',resources: 'usable'});
    const scriptElement = dom.window.document.createElement('script');
    scriptElement.textContent = script;
    dom.window.document.body.appendChild(scriptElement);

    const name = dom.window.document.querySelector("#NameInput");
    const password = dom.window.document.querySelector("#PasswordInput");

    name.value = "Spider";
    password.value = 123;

    //Raising the event
    dom.window.document.getElementById('submit-btn').click();
    const actual = dom.window.document.getElementById('final').innerHTML;
    expect(actual).toBe('Success');
})


test('Incorrect name and password',()=>{
    const html = fs.readFileSync(path.resolve(__dirname,'./index.html'),'utf8');
    const script = fs.readFileSync(path.resolve(__dirname,'./index.js'),'utf8');
    
    const dom = new JSDOM(html,{runScripts: 'dangerously',resources: 'usable'});
    const scriptElement = dom.window.document.createElement('script');
    scriptElement.textContent = script;
    dom.window.document.body.appendChild(scriptElement);

    const name = dom.window.document.querySelector("#NameInput");
    const password = dom.window.document.querySelector("#PasswordInput");

    name.value = "Spiderman";
    password.value = 12345;

    //Raising the event
    dom.window.document.getElementById('submit-btn').click();
    const actual = dom.window.document.getElementById('final').innerHTML;
    expect(actual).toBe('Invalid username or password');
})


