var select_element = document.getElementById('main_menu');
var logo = document.getElementById('logo');
logo.onclick = function(){
    window.location.assign("index.cshtml");
}


select_element.onchange = function() {
    var elem = (typeof this.selectedIndex === "undefined" ? window.event.srcElement : this);
    var value = elem.value || elem.options[elem.selectedIndex].value;
    if(value==="Users") 
    {
        window.location.assign("/Pages/Users.cshtml");
    }
    if(value==="Awards") 
    {
        window.location.assign("/Pages/Awards.cshtml");
    }
}