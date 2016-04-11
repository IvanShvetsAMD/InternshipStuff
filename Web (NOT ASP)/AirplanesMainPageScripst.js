function TableRowOnClick(elem){
    var str = elem.innerHTML;
    
    if (str == "666")
        window.open("AirplaneDetailsPage.html");
    else 
        alert("No info about such aircraft is available.");
}

function Highlight(elem) {
    //elem.style.backgroundColor = "#556B2F";     
    elem.style.color = "blue";
}

function Dehighlight(elem) {
    //elem.style.backgroundColor = "aliceblue";
    elem.style.color = "black";
}