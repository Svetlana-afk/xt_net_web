var add_btn = document.getElementById("AwardsFixedplus");
var modal = document.getElementById("addAwardModal");
var delModal = document.getElementById("delAwardModal");
var close_add = document.getElementById("close_addAward");
var close_delAward = document.getElementById("close_delAward");
add_btn.onclick = function () {
    modal.style.display = "block";
}
close_add.onclick = function () {
    modal.style.display = "none";
    document.getElementById("add-title").value = "";
}
close_delAward.onclick = function () {
    delModal.style.display = "none";
    document.getElementById("deleteAward-id").value = "";
}