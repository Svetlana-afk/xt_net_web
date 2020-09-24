var add_btn = document.getElementById("AwardsFixedplus");
var modal = document.getElementById("addAwardModal");
var close_add = document.getElementById("close_addAward");
add_btn.onclick = function () {
    modal.style.display = "block";
}
close_add.onclick = function () {
    modal.style.display = "none";
    document.getElementById("add-title").value = "";
}