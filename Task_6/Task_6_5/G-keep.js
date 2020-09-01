import { Service } from "./Storage.js"
let storage = new Service();
let curChangeId;
var modal = document.getElementById("addModal");
var change_modal = document.getElementById("changeModal");

var add_btn = document.getElementById("fixedplus");

var create = document.getElementById("create");
var change = document.getElementById("change");

var close_add = document.getElementById("close_add");
var close_change = document.getElementById("close_change");

var notes_container = document.getElementById("notes");

var trashClick = (event) => {
    if (event.target.className == "fixedTrash" || event.target.className == "far fa-trash-alt") {

        storage.deleteById(event.currentTarget.id);

        var child = document.getElementById(event.currentTarget.id);
        child.removeEventListener('click', trashClick);
        child.parentNode.removeChild(child);
    }
}

add_btn.onclick = function () {
    modal.style.display = "block";
}

create.onclick = function () {

    let valHeader = document.getElementById('add-header').value;
    let valMsg = document.getElementById('add-msg').value;
    let noteId = storage.add({ header: valHeader, msg: valMsg })

    let notes = document.getElementById("notes");

    let note = document.createElement('div');
    note.className = "note";
    note.addEventListener('click', trashClick);
    note.id = noteId;

    let nheader = document.createElement('div');
    nheader.className = "note-header";

    nheader.innerHTML = valHeader;

    let msg = document.createElement('div');
    msg.className = "note-msg";

    msg.innerHTML = valMsg;

    let trash = document.createElement('div');
    trash.className = "fixedTrash";

    let icon = document.createElement('i');
    icon.className = 'far fa-trash-alt';
    trash.appendChild(icon);

    note.appendChild(nheader);
    note.appendChild(msg);
    note.appendChild(trash);

    notes.insertBefore(note, notes.firstChild);

    modal.style.display = "none";
    document.getElementById("add-header").value = "";
    document.getElementById("add-msg").value = "";
}

notes_container.onclick = function (e) {
    let target = e.target;
    if (target.className == "note") {
        change_modal.style.display = "block";
        document.getElementById("change-header").value = target.querySelector(".note-header").innerText;
        document.getElementById("change-msg").value = target.querySelector(".note-msg").innerText;
        curChangeId = target.id;
    }
}

change.onclick = function () {
    let valHeader = document.getElementById('change-header').value;
    let valMsg = document.getElementById('change-msg').value;
    storage.replaceById(curChangeId, { header: valHeader, msg: valMsg });
    let changedNote = document.getElementById(curChangeId);
    changedNote.querySelector(".note-header").innerText = valHeader;
    changedNote.querySelector(".note-msg").innerText = valMsg;
    change_modal.style.display = "none";
}

close_add.onclick = function () {
    modal.style.display = "none";
    document.getElementById("add-header").value = "";
    document.getElementById("add-msg").value = "";
}

close_change.onclick = function () {
    change_modal.style.display = "none";

}

window.onclick = function (event) {
    if (event.target.className == "note") {
        modal.style.display = "block";
    }
}

window.onclick = function (event) {
    if (event.target == modal) {
        modal.style.display = "none";
        document.getElementById("add-header").value = "";
        document.getElementById("add-msg").value = "";
    }
    if (event.target == change_modal) {
        change_modal.style.display = "none";
    }

}

