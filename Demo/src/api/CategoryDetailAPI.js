import BaseAPI from '@/api/base/BaseAPI.js';

class CategoryDetailAPI extends BaseAPI {
    constructor(){
        super();
        this.controler = "categorydetail";
    }
}

export default new CategoryDetailAPI();