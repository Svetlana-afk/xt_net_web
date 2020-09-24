var add_btn = document.getElementById("fixedplus");
var modal = document.getElementById("addModal");
var input = document.getElementById('mydata');
var close_add = document.getElementById('close_add');
var changeInput = document.getElementById('change-bday');
var change_modal = document.getElementById("changeModal");
var change = document.getElementById("change");
var close_change = document.getElementById("close_change");
var userContainer = document.getElementById("u_container");
let curChangeId;

add_btn.onclick = function () {
    modal.style.display = "block";
}
close_add.onclick = function () {
    modal.style.display = "none";
    document.getElementById("add-name").value = "";
    document.getElementById("mydata").value = "";
}
close_change.onclick = function () {
    change_modal.style.display = "none";
    document.getElementById("change-name").value = "";
    document.getElementById("change-bday").value = "";
}

userContainer.onclick = function (e) {
    let target = e.target;
    if (target.className == "userBlock"||target.className =="picContainer") {
        change_modal.style.display = "block";
        document.getElementById("change-name").value = target.querySelector(".userNamePlace").innerText;
        document.getElementById("change-bday").value = target.querySelector(".userBday").innerText;
        curChangeId = target.id;

        let changedUserIdInput = document.getElementById("change-id");
        changedUserIdInput.value = curChangeId;
    }
}


     
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
dateInputMask(changeInput);


