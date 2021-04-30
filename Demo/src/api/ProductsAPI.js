import BaseAPI from '@/api/base/BaseAPI.js';

class ProductsAPI extends BaseAPI {
    constructor(){
        super();
        this.controler = "product";
    }
}

export default new ProductsAPI();