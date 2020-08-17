class Service {

    storage = [];

    add(obj) {

        let id = (Date.now() + Math.random()).toString();
        let nObj = {
            id: id,
            obj: obj
        }
        this.storage.push(nObj);
        return id;
    }
    getById(id) {
        for (let i = 0; i < this.storage.length; i++) {
            if (this.storage[i].id == id) {
                return this.storage[i].obj;
            }
        }
    }
    getAll() {
        let resultStorage = [];
        for (let i = 0; i < this.storage.length; i++) {
            resultStorage.push(this.storage[i].obj);
        }
        return resultStorage;
    }
    deleteById(id) {
        for (let i = 0; i < this.storage.length; i++) {
            if (this.storage[i].id == id) {
                this.storage.splice(i, 1);
                return true;
            }
        }
        return false;
    }
    updateById(id, obj) {
        let success = false;
        for (let i = 0; i < this.storage.length; i++) {
            if (this.storage[i].id == id) {
                Object.assign(this.storage[i].obj, obj);
                success = true;
            }
        }
        return success;

    }
    replaceById(id, obj) {
        let success = false;
        for (let i = 0; i < this.storage.length; i++) {
            if (this.storage[i].id == id) {
                this.storage[i].obj = obj;
                success = true;
            }
        }
        return success;
    }
}

var storage = new Service();
var id1 = storage.add({
    name: "Sveta",
    age: "ne skaju",
    hair: "blond"
});

var id2 = storage.add({
    name: "Masha",
    age: 35
});

var id3 = storage.add({
    name: "Lena",
    age: 35,
    weight: 54
});

var katya = {
    name : "Katya",
    age : 15,
    height : 175
};
console.log(storage.getById(id1));
console.log(storage.getAll());
console.log(storage.deleteById(id2));
console.log(storage.getAll());
storage.replaceById(id3, katya);
console.log(storage.getAll());
storage.updateById(id1, katya);
console.log(storage.getAll());


