import BaseAPI from '@/api/base/BaseAPI.js';
import BaseAPIConfig from '@/api/base/BaseAPIConfig.js';

class CartDetailAPI extends BaseAPI {
    constructor(){
        super();
        this.controler = "cartdetail";
    }
}

export default new CartDetailAPI();