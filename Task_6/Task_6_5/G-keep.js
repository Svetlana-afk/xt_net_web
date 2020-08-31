import { Service } from "./Storage.js"
let storage = new Service();
// Get the modal
var modal = document.getElementById("addModal");

// Get the button that opens the modal
var btn = document.getElementById("fixedplus");

// Get the <span> element that closes the modal
var span = document.getElementsByClassName("close")[0];

var create = document.getElementById("create");
var close_add = document.getElementById("close_add");


// When the user clicks on the button, open the modal
btn.onclick = function () {
    modal.style.display = "block";
}

// When the user clicks on <span> (x), close the modal
span.onclick = function () {
    modal.style.display = "none";
}

create.onclick = function () {
    //do smth

    var notes = document.getElementById("notes");

    let note = document.createElement('div');
    note.className = "note";

    let nheader = document.createElement('div');
    nheader.className = "note-header";
    nheader.innerHTML = "Blalallsallsala"

    note.appendChild(nheader)
    notes.appendChild(note)

    modal.style.display = "none";
}

close_add.onclick = function () {
    modal.style.display = "none";
}

// When the user clicks anywhere outside of the modal, close it
window.onclick = function (event) {
    if (event.target == modal) {
        modal.style.display = "none";
    }
}

