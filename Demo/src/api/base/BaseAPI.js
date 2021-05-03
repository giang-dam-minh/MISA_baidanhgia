import BaseAPIConfig from '@/api/base/BaseAPIConfig.js';
import axios from 'axios';

export default class BaseAPI {

    constructor() {
        this.controler = null;
    }
    insert(param){
        return BaseAPIConfig.post(`${this.controler}`, param);
    }
    /**
     * Phương thức lấy tất cả dữ liệu
     */
    getAll() {
        return BaseAPIConfig.get(`${this.controler}`);
    }
    /**
     * Hàm lấy dữ liệu phân trang
     * @param {*} payload 
     */
    paging(payload) {
        return BaseAPIConfig.post(`${this.controler}/paging`, payload);
    }
    /**
     * Hàm cập nhật dữ liệu
     * @param {*} id 
     * @param {*} body 
     */
    update1(data) {
        return axios.put(`http://localhost:56094/api/${this.controler}`, data);
    }
    /**
     * Hàm xóa bản ghi
     * @param {*} id 
     */
    delete(id) {
        return BaseAPIConfig.delete(`${this.controler}?id=${id}`);
    }
    
    getById(id){
        return BaseAPIConfig.get(`${this.controler}/id?id=${id}`)
    }
    getByListID(lstID){
        return BaseAPIConfig.post(`${this.controler}/lstID`,`"${lstID}"` );
    }
}