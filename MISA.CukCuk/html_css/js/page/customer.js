$(document).ready(function () {
    new CustomerJS();
})


class CustomerJS extends BaseJS {
    constructor() {
        super();   
    }
    setDataUrl() {
        this.url = "http://localhost:56094/api/v1/Customers";
    }
}
