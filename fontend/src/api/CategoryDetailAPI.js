import BaseAPI from '@/api/base.js';
import BaseAPIConfig from '@/api/BaseAPIConfig.js';

class CategoryDetailAPI extends BaseAPI {
    constructor(){
        super();
        this.controler = "categorydetail";
    }
}

export default new CategoryDetailAPI();