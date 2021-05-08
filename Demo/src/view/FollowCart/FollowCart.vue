<template>
    <base-page>
    <div class="title">Theo dõi đơn hàng</div>
    <div v-for="(cartID,index) in JSON.parse(lstCartID)"  :key="index" style="margin-top: 20px;" class="cart">
        <div class="m-b-10 cl-b f-s-20">Đơn hàng {{index+1}}</div>
        <div class="m-b-10">Đơn hàng có: <span class="f-w-b"> 1 sản phẩm </span> </div>
        <div class=" m-b-10">Tổng tiền:<span class="cl-b"> 230.000</span></div>
        <div class=" m-b-10">Trạng thái:<span class="cl-b"> Đã xác nhận</span></div>
        <div class="table-detail">
            <table border="1px solid #e5e5e5">
                <tr>
                    <th>Hình Ảnh</th>
                    <th>Sản Phẩm</th>
                    <th>Số lượng</th>
                    <th>Thành Tiền</th>
                </tr>
                <tr v-for="(cart,index) in getListProductByCartID(cartID)" :key="index">
                    <td>
                        <img height="120" width="100" :src="'data:image/png;base64,' + cart.Image">
                    </td>
                    <td style="padding:10px">
                        <div class="product-name f-s-10 f-w-b">{{cart.ProductName}} </div>
                        <div class="price m-t-10"><span>{{cart.Price - (cart.Price*cart.Sale/100)}}</span>- <span class="line-through">{{cart.Price}}</span></div>        
                    </td>
                    <td style="text-align:center">{{getQuanlityByCartID(cartID)}}</td>
                    <td style="text-align:center">{{(cart.Price - (cart.Price*cart.Sale/100))*getQuanlityByCartID(cartID)}}</td>
                </tr>
                <tr style="text-align:right">
                    <td></td>
                    <td></td>
                    <td></td>
                    <td style="padding:10px">Tạm tính: <span class="cl-b f-w-b">{{getTotal()}}</span></td>
                </tr>
                 <tr style="text-align:right">
                      <td></td>
                    <td></td>
                    <td></td>
                    <td style="padding:10px">
                        Phí vẫn chuyển: <span class="cl-b f-w-b">10.000</span></td>
                </tr>
                 <tr style="text-align:right">
                      <td></td>
                    <td></td>
                    <td></td>
                    <td style="padding:10px">
                        Tổng thanh toán: <span class="cl-b f-w-b">{{getTotal() + 10000}}</span>
                    </td>
                </tr>
            </table>
        </div>
        <div class="address-info">
        <div class="title cl-b f-s-20">Thông tin địa chỉ nhận hàng</div>
        <div class="form">
            <form>
                <div  class="name">
                    <input v-model="cart.CustomerName" placeholder="Họ tên (*)" />
                </div>
                <div class="name">
                    <input v-model="cart.PhoneNumber" placeholder="Số điện thoại (*)" />
                </div>
                <div class="name">
                    <input v-model="cart.Address" placeholder="Địa chỉ (*)" />
                </div>
                <div class="name">
                    <input v-model="cart.Email"  placeholder="Email nhận quà"/>
                </div>
                <div class="name">
                    <textarea  v-model="cart.Note" type="text-area" placeholder="Ghi chú đơn hàng" />
                </div>
                <!-- <div class="btnConfirmOrder">
                    <button @click="completeCart">Hoàn tất đơn hàng</button>
                </div> -->
            </form>
        </div>
    </div>
    </div>
    
    </base-page>
</template>

<script>
import ProductsAPI from "@/api/ProductsAPI.js";
import CartAPI from "@/api/CartAPI.js";
import CartDetailAPI from "@/api/CartDetailAPI.js"
import BasePage from '../../components/BasePage.vue'
export default {
  components: { BasePage },
    data(){
        return{
            quanlity:  1,
            lstProduct: [],
            dataCart : [],
            lstCartID: [],
            lstCartDetail: [],
            cart: {
                CustomerName: "",
                Address: "",
                PhoneNumber: "",
                Email: "",
                Note: "",
                Total: ""
            },
        }
    },
    async created(){
        var me = this;
        await this.getProductInLocal();
    },
    watch:{
        lstCartDetail(val){

            var me = this;
            me.lstProduct = [];
            val.forEach(item => {
                item.filter(ele => {
                    ProductsAPI.getById(ele.ProductID).then(res => {
                       if(me.checkValidProduct(res.data[0].ProductID)){
                           debugger
                           me.lstProduct.push(res.data);
                       };
                    })
                })
            })
        },
        lstCartID(val){
        },
        lstProduct(val){
        }
    },
    methods:{
        checkValidProduct(id){
            try {
                this.lstProduct.forEach(item => {
                    if(item[0].ProductID == id){
                        debugger
                        return false
                    }
                })
                return true;
            } catch (error) {
                
            }
        },
        getQuanlityByCartID(id){
            try {
                var quanlity = "";
                this.lstCartDetail.forEach(item => {
                    item.filter(ele => {
                        if(ele.CartID == id.CartID){
                            quanlity = ele.Quanlity;
                        }
                    })
                })
                return quanlity;
            } catch (error) {
                
            }
            
        },
        getListProductByCartID(id){
            var me = this;
            try {
                var lstProduct = [];
                this.lstCartDetail.forEach(item => {
                    item.filter(ele => {
                        me.lstProduct.forEach(el => {
                            if(ele.ProductID == el[0].ProductID){
                                lstProduct.push(el[0]);
                            }
                        })
                    })
                })
                return lstProduct;
            } catch (error) {
                
            }
        },
       async getProductInLocal(){
           var me = this;
           this.lstCartID = localStorage.getItem("userInfo");
            if(this.lstCartID){
                var data = JSON.parse(this.lstCartID);
                data.forEach(item => {
                   CartDetailAPI.getByPropertyValue('cartid',item.CartID).then(res => {
                        me.lstCartDetail.push(res.data);
                    })
                })
            }
        //     debugger
        //     var me = this;
        //     this.dataCart = JSON.parse(localStorage.getItem("dataCart"));
        //     var lstProductID = []
        //     this.dataCart.forEach(item => {
        //         lstProductID.push(item.ID);
        //     })
        //     lstProductID = lstProductID.join(",");
        //    await ProductsAPI.getByListID(lstProductID).then(res => {
        //         me.lstProduct = res.data;
        //     }).catch(err => {
        //     })
         
        },
        getDataPropertyProduct(property,id){
            var data = [];
            if(this.lstProduct)
            {
                this.lstProduct.forEach(item => {
                    if(item.ProductID == id){
                        data = item[property];
                    }
                })
            }
            return data;
        },
        getTotal(){
            var me = this;
            var total = 0;
           try {
               this.dataCart.forEach(item =>{
                var price = 0;
                var sale = 0;
                me.lstProduct.filter(ele => {
                    if(ele.ProductID == item.ID){
                        price = ele.Price;
                        sale = ele.Sale;
                        total += (price*item.Quanlity- price*item.Quanlity*sale/100);
                    }
                })
            })
            return total;
           } catch (error) {
               
           }
            
        },
        completeCart(){
            this.cart.Total = this.getTotal();
            CartAPI.insert(this.cart).then(res => {
                debugger
            }).catch(err =>{
                debugger
            })
        }
    }
}
</script>

<style lang="scss" scoped>
.cart{
    width: 90%;
    height: 100%;
    padding: 20px;
    margin-top: 20px;
    border: 1px solid #e5e5e5;
    margin: auto;

    .table-detail{
        table{
            width: 100%;
            border-collapse: collapse;

            th{
                padding: 10px;
            }
        }
    }
}
.address-info{
    width: 100%;
    .title{
        width: 90%;
        margin: auto;
        margin-top: 10px;
        margin-bottom: 10px;
        border-bottom: 2px solid #F27922;
            
        
    }
    .form{
        width: 30%;
        margin: auto;
        input{
            width:100%;
            height: 30px;
            margin-bottom: 10px;
            padding-left: 15px;

        }
        textarea{
            width:97%;
            height: 30px;
            margin-bottom: 10px;
            padding: 15px;
        }
        button{
            padding: 10px 20px;
            background-color: #337AB7;
            color: white;
        }
    }
}
</style>