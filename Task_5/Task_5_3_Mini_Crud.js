class Service {

    storage = [];

    add(obj) {
        let id = Date.now().toString();
        let nObj = {
            id: id,
            obj: obj
        }
        this.storage.push(nobj);
        return id;
    }
    getById(id) {
        for (let i = 0; i < this.storage.length; i++) {
            if (this.storage[i] == id) {
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
    deleteById() {
        let success = false;
        for (let i = 0; i < this.storage.length; i++) {
            if (this.storage[i].id == id) {
                this.storage.splice(i, 1);
                success = true;
            }
        }
        return success;
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
