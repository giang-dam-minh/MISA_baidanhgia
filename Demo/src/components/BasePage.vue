<template>
    <div>
       <div class="header">
           <div @click="logoClick(1)" class="logo"><img src="https://imua.com.vn//images/logo.png" /></div>
           <div class="search">
               <input placeholder="Tìm kiếm sản phẩm..." />
               <button><img height="30" width="30" src="@/assets/icons/icon-search.jpg" /></button>
           </div>
           <div @click="cartClick(1)" class="cart"><button><img height="30" width="30" src="@/assets/icons/cart.png" /></button></div>
       </div>
       <div class="menu">
        <ul>
            <li @click="homePageClick(1)">TRANG CHỦ</li>
            <li>
                DANH MỤC SẢN PHẨM
                <ul>
                    <li @click="categoryClick(category.CategoryID)" v-for="(category,index) in lstCategory" :key="index">{{category.CategoryName.toUpperCase()}}</li>
                </ul>
            </li>
            <li>HƯỚNG DẪN MUA HÀNG</li>
            <li>TIN NỔI BẬT</li>
            <li>SẢN PHẨM SALE OFF</li>
            <li>KHO QUÀ TẶNG</li>
            <li>LIỆN HỆ</li>
        </ul>
       </div>
       <div>
           <slot></slot>
       </div>
       <div class="footer">
           <div  class="support-customer float-left">
              <b> Hướng dẫn mua hàng </b><br><br>
               Chính sách đổi trả <br>
               Quy định vận chuyển <br>
               Phương thức thanh toán <br>
               Chính sách bảo mật <br>
           </div>
           <div class="license float-left">
              <b> Website thuộc quyền </b> <br><br>
               CÔNG TY TNHH HV NET <br>
                ĐKKD Số: 0313411135 <br>
                Do Sở KH&ĐT Tp. HCM <br>
                Cấp ngày 24/08/2015 <br><br>
                <img src="https://imua.com.vn//images/DangKyBoCongThuong.png">
           </div>
           <div class="center-provide float-left">
              <b> Trung tâm phân phối </b><br><br>
               255 Bình Lợi, P.13, Q. Bình Thạnh, Tp. HCM <br>
                Tel: 0911 403 114 Email: info@imua.com.vn <br>
                Website: www.imua.com.vn <br><br>
                <img src="http://images.dmca.com/Badges/DMCA_logo-grn-btn150w.png?ID=31bbc2bc-e92e-4421-ab72-4d4e9809c626">
           </div>
       </div>
    </div>
</template>
<script>
import CategoryAPI from "@/api/CategoryAPI.js";
export default {
   name: "BasePage",
   data(){
       return{
           lstCategory: []
       }
   },
   created(){
       var me = this;
       CategoryAPI.getAll().then(res => {
           me.lstCategory = res.data;
       }).catch(err => {

       })
   },
   methods:{
       logoClick(id){
           this.$router.push("/");
       },
       categoryClick(id){
           this.$router.push(`/category/${id}`)
       },
       cartClick(){
           this.$router.push("/cart");
       },
       homePageClick(){
            this.$router.push("/");
       }
   }

}
</script>
<style lang="scss" scoped>
.header{
    height: 100px;
    width: 100%;
    background-image: url("https://imua.com.vn/images/logo/mua-xuan-2020-0.jpg");
    .logo{
        position: absolute;
        top: 8%;
        left: 5.5%;
        &:hover{
            cursor: pointer;
        }
    }
    .search{
        top: 8%;
        position: absolute;
        left: 55%;
        width: 400px ;
        display: flex;
        justify-content: space-between;
        input{
            height: 36px;
            width: 370px;
            border: 1px solid #e5e5e5;
            padding-left: 10px;
            border-top-left-radius: 5px;
            border-bottom-left-radius: 5px;
            outline: none;
        }
        button{
            height: 40px;
            width: 40px;
            border: 1px solid #e5e5e5;
            border-top-left-radius: 0  !important;
            border-bottom-left-radius: 0 !important;
            padding-left: 2px;
            border-left:none ;
            background-color: white;
            outline:none;
        }
    }
    .cart{
        position: absolute;
        left: 85%;
        top: 8%;
    }
}
.menu{
    height: 50px;
    width: 100%;
    background-color: #F27922;
    ul{
        width: 90%;
        height: 100%;
        margin-left: 5%;
        padding: 15px 0px;
        display: flex;
        justify-content: space-between;
        li{
            list-style: none;
            color: white;
            &:hover{
                cursor: pointer;
                color: green;
                ul{
                    display: block;
                }
            }
            ul{
                position: relative;
                display: none;
                width: 100%;
                height: 100%;
                z-index: 100;
                margin-left: 0px;
                margin-top: 2px;
                li{
                    color: white;
                    padding: 10px;
                    background-color: #F27922;
                    border-bottom:1px solid #e5e5e5 ;
                }
            }
        }
    }
}
.footer{
    height: 150px;
    width: 100%;
    background-color:rgb(236, 228, 228);
    display: flex;
    margin-top: 20px;
    padding:  30px;
    justify-content: space-between;
    .support-customer{
        height: 100%;
        width: 25%;
    }
    .license{
        height: 100%;
        width: 25%;
    }
    .center-provide{
        height: 100%;
        width: 25%;
    }
}
</style>