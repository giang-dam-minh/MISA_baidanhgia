<template>
    <base-page>
    <div style="margin-top: 20px;" class="cart">
        <div class="m-b-10 cl-b f-s-20">Gio hang</div>
        <div class="m-b-10">Gio hang co: <span class="f-w-b"> 1 san pham </span> </div>
        <div class=" m-b-10">Tong tien:<span class="cl-b"> 230.000</span></div>
        <div class="table-detail">
            <table border="1px solid #e5e5e5">
                <tr>
                    <th>Hình Ảnh</th>
                    <th>Sản Phẩm</th>
                    <th>Số lượng</th>
                    <th>Thành Tiền</th>
                </tr>
                <tr v-for="(cart,index) in dataCart" :key="index">
                    <td>
                        <img height="120" width="100" :src="'data:image/png;base64,' + getDataPropertyProduct('Image',cart.ID)">
                    </td>
                    <td style="padding:10px">
                        <div class="product-name f-s-10 f-w-b">{{getDataPropertyProduct('ProductName',cart.ID)}} </div>
                        <div class="price m-t-10"><span>{{getDataPropertyProduct('Price',cart.ID) - (getDataPropertyProduct('Price',cart.ID)*getDataPropertyProduct('Sale',cart.ID)/100)}}</span>- <span class="line-through">{{getDataPropertyProduct('Price',cart.ID)}}</span></div>        
                    </td>
                    <td style="text-align:center"><input style="padding: 5px" type="number" min="0" max="100" v-model="cart.Quanlity" /></td>
                    <td style="text-align:center">{{(getDataPropertyProduct('Price',cart.ID) - (getDataPropertyProduct('Price',cart.ID)*getDataPropertyProduct('Sale',cart.ID)/100))*cart.Quanlity}}</td>
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
                <div class="btnConfirmOrder">
                    <button @click="completeCart">Hoàn tất đơn hàng</button>
                </div>
            </form>
        </div>
    </div>
    </base-page>
</template>

<script>
import ProductsAPI from "@/api/ProductsAPI.js";
import CartAPI from "@/api/CartAPI.js";
import CartDetailAPI from "@/api/CartDetailAPI.js";
import BasePage from '../components/BasePage.vue'
export default {
  components: { BasePage },
    data(){
        return{
            quanlity:  1,
            lstProduct: [],
            dataCart : [],
            cart: {
                CartID: "",
                CustomerName: "",
                Address: "",
                PhoneNumber: "",
                Email: "",
                Note: "",
                Total: ""
            },
            cartDetail:{
                CartID: "",
                ProductID: "",
                Quanlity: ""
            }
        }
    },
    async created(){
        await this.getProductInLocal();
    },
    methods:{
       async getProductInLocal(){
            var me = this;
            if(localStorage.getItem("dataCart"))
            {
                this.dataCart = JSON.parse(localStorage.getItem("dataCart"));
                var lstProductID = []
                this.dataCart.forEach(item => {
                    lstProductID.push(item.ID);
                })
                lstProductID = lstProductID.join(",");
                await ProductsAPI.getByListID(lstProductID).then(res => {
                    me.lstProduct = res.data;
                }).catch(err => {
                })
            }
           
         
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
        async completeCart(){
            var me = this;
            var res = await CartAPI.getIdMax();
            if(res.data.length>0){
                this.cart.CartID = res.data[0].CartID + 1;
            }
            else{
                this.cart.CartID = 1;
            }
            this.cart.Total = this.getTotal();
            CartAPI.insert(this.cart).then(res => {
                me.cartDetail.CartID = me.cart.CartID;
                me.dataCart.forEach(item => {
                    me.cartDetail.ProductID = item.ID;
                    me.cartDetail.Quanlity = item.Quanlity;
                    CartDetailAPI.insert(me.cartDetail);
                })
                debugger
                if(localStorage.userInfo){
                    var userInfo = JSON.parse(localStorage.userInfo);
                    var data = {
                        CartID : me.cartDetail.CartID
                    }
                    userInfo.push(data);
                    localStorage.userInfo = JSON.stringify(userInfo);

                }
                else{
                    userInfo = [];
                    var data = {
                        CartID : me.cartDetail.CartID
                    }
                    userInfo.push(data);
                    localStorage.userInfo = JSON.stringify(userInfo);
                }
                localStorage.dataCart = [];
                
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