class Service {

    storage = [];

    add(obj) {

        let id = Date.now().toString();
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
                return this.storage[i].obj||null;
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
    getAllWithId() {
        return this.storage;
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
export {Service}