var users =  document.getElementById("users");
users.onclick = function(){
    alert("sdfsdf");
    let something = document.createElement('div');
    something.className = "smth";
    let msg = document.createElement('div');
    let header = document.getElementById("header")
    msg.className = "smth-msg";
    msg.innerHTML = "Working";
    something.appendChild(msg);
    header.appendChild(something);

}