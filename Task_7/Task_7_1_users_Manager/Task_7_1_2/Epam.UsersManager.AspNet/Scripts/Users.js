(function () {
    let UsersContainer = document.getElementById("u_container");
    let userBlock = document.createElement('div');
    userBlock.className = "userBlock";
    let trash = document.createElement('div');
    trash.className = "fixedTrash";

    let icon = document.createElement('i');
    icon.className = 'far fa-trash-alt';
    trash.appendChild(icon);

    let name = document.createElement('p');
    name.innerText = "Name of User";
    userBlock.appendChild(name);
    userBlock.appendChild(trash);
    UsersContainer.appendChild(userBlock); 
 }())
 var trashClick = (event) => {
    if (event.target.className == "fixedTrash" || event.target.className == "far fa-trash-alt") {
        var child = document.getElementById(event.currentTarget.id);
        child.removeEventListener('click', trashClick);
        child.parentNode.removeChild(child);
    }
}