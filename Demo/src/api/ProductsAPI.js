import BaseAPI from '@/api/base/BaseAPI.js';
import BaseAPIConfig from '@/api/base/BaseAPIConfig.js';

class ProductsAPI extends BaseAPI {
    constructor(){
        super();
        this.controler = "product";
    }
    getHotProduct(){
        return BaseAPIConfig.get(`${this.controler}/hot-product`);
    }
}

export default new ProductsAPI();