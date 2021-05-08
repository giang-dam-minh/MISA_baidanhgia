import BaseAPI from '@/api/base.js';
import BaseAPIConfig from '@/api/BaseAPIConfig.js';

class CategoryAPI extends BaseAPI {
    constructor(){
        super();
        this.controler = "category";
    }
}

export default new CategoryAPI();