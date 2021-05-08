import axios from 'axios';
import BaseAPIConfig from "@/api/BaseAPIConfig.js";
export default class BaseAPI {

    constructor() {
        this.controler = null;
    }
    insert(param){
        return axios.post(`http://localhost:56094/api/${this.controler}`, param);
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
    update(data) {
        return axios.put(`http://localhost:56094/api/${this.controler}`, data);
    }
    getByPropertyValue(property,value){
        return BaseAPIConfig.get(`${this.controler}/getByPropertyValue?property=${property}&value=${value}`);
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