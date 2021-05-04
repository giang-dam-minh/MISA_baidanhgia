import BaseAPI from '@/api/base/BaseAPI.js';
import BaseAPIConfig from '@/api/base/BaseAPIConfig.js';

class CartAPI extends BaseAPI {
    constructor(){
        super();
        this.controler = "cart";
    }

    getIdMax(){
        return BaseAPIConfig.get(`${this.controler}/idmax`);
    }
}

export default new CartAPI();