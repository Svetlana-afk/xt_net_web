var add_btn = document.getElementById("fixedplus");
var modal = document.getElementById("addModal");
add_btn.onclick = function () {
    modal.style.display = "block";
}
close_add.onclick = function () {
    modal.style.display = "none";
    document.getElementById("add-name").value = "";
    document.getElementById("mydata").value = "";
}
window.onclick = function (event) {
    if (event.target == modal) {
        modal.style.display = "none";
        document.getElementById("add-header").value = "";
        document.getElementById("add-msg").value = "";
    }
}

var input = document.getElementById('mydata');
     
var dateInputMask = function dateInputMask(elm) {
     
    elm.addEventListener('keyup', function(e) {

        if( e.keyCode < 47 || e.keyCode > 57) {
            e.preventDefault();
        }
     
        var len = elm.value.length;
     
        if(len !== 1 || len !== 3) {
            if(e.keyCode == 47) {
                e.preventDefault();
            }
        }
        
        if(len === 2) {
            if (e.keyCode !== 8 && e.keyCode !== 46) { 
                elm.value = elm.value+'.';
            }
        }
     
        if(len === 5) {
            if (e.keyCode !== 8 && e.keyCode !== 46) { 
                elm.value = elm.value+'.';
            }
        }
    });
};
     
dateInputMask(input);


