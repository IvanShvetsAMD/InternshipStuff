'use strict';

function SkewBody() {
    window.open("AirplanesMainPage.html");
    var body = document.getElementsByTagName("body");
    body[0].style="transform: scaleX(35deg);";  
    //alert("hello");
}

function Run_Button_Run(elem) {
    
}

function Highlight(elem) {
    elem.style.backgroundColor = "#556B2F";     
    elem.style.color = "aliceblue";
}

function Dehighlight(elem) {
    elem.style.backgroundColor = "aliceblue";
    elem.style.color = "black";
}