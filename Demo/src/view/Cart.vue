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
                <tr>
                    <td>
                        <img height="95" width="79" src="http://imua.com.vn/images/product/Tat-Phun-Chan-Stocking-Nudv-Han-Quoc-Che-khuyet-Diem-Va-Chong-Nang-Cho-Da-.jpg">
                    </td>
                    <td style="padding:10px">
                        <div class="product-name f-s-10 f-w-b">Tất Phun Chân Stocking Nudv Hàn Quốc - Che khuyết Điểm Và Chống Nắng Cho Da</div>
                        <div class="price m-t-10"><span>220.000 </span>- <span class="line-through">250.000</span></div>        
                    </td>
                    <td style="text-align:center"><input style="padding: 5px" type="number" min="0" max="100" v-model="quanlity" /></td>
                    <td style="text-align:center" >220.000</td>
                </tr>
                <tr style="text-align:right">
                    <td></td>
                    <td></td>
                    <td></td>
                    <td style="padding:10px">Tạm tính: <span class="cl-b f-w-b">220.00</span></td>
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
                        Tổng thanh toán: <span class="cl-b f-w-b">230.00</span>
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
                    <input placeholder="Họ tên (*)" />
                </div>
                <div class="name">
                    <input placeholder="Số điện thoại (*)" />
                </div>
                <div class="name">
                    <input placeholder="Địa chỉ (*)" />
                </div>
                <div class="name">
                    <input  placeholder="Email nhận quà"/>
                </div>
                <div class="name">
                    <textarea  type="text-area" placeholder="Ghi chú đơn hàng" />
                </div>
                <div class="btnConfirmOrder">
                    <button>Hoàn tất đơn hàng</button>
                </div>
            </form>
        </div>
    </div>
    </base-page>
</template>

<script>
import BasePage from '../components/BasePage.vue'
export default {
  components: { BasePage },
    data(){
        return{
            quanlity:  1,
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