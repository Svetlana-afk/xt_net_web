import './Task_5_3_Mini_Crud.js';

var storage = new Service();
var id = storage.add({
    name: "Sveta",
    age: "ne skaju"
});
console.log(id);

