import BaseAPI from '@/api/base/BaseAPI.js';

class CategoryAPI extends BaseAPI {
    constructor(){
        super();
        this.controler = "category";
    }
}

export default new CategoryAPI();