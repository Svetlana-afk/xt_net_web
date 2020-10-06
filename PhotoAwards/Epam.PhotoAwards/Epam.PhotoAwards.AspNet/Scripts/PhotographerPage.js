var logo = document.getElementById('logo');
var modal = document.getElementById('addPicture');
//var close_add = document.getElementById('close_add');
//var userpicContainer = document.getElementById('userpicContainer');
//var addUserpic = document.getElementById('addUserpic');


logo.onclick = function () {
    window.location.assign("index.cshtml");
}
var plusPic = document.getElementById('plusPic');
plusPic.onclick = function(){
    modal.style.display = "block";
}
//close_add.onclick = function () {
//    modal.style.display = "none";
//}
//userpicContainer.onclick = function(){
//    addUserpic.style.display = "block";
//}