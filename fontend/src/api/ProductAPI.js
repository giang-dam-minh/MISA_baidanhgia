import BaseAPI from '@/api/base.js';
import BaseAPIConfig from '@/api/BaseAPIConfig.js';

class ProductAPI extends BaseAPI {
    constructor(){
        super();
        this.controler = "product";
    }
}

export default new ProductAPI();