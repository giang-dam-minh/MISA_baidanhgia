<template>
  <BasePage>
    <!-- slide -->
    <div class="slide"></div>
    <!-- end slide -->

    <!-- under-slide -->
    <div class="under-slide">
      <ul>
        <li>
          <div class="icon">
            <img src="https://imua.com.vn//images/Logo/ho-tro-247--1.png" />
          </div>
          <div class="info">
           <b> Hỗ trợ 24/7</b> <br />
            0326111435
          </div>
        </li>
        <li>
          <div class="icon">
            <img src="https://imua.com.vn/images/Logo/thong-tin--1.png" />
          </div>
          <div class="info">
            <b>THÔNG TIN</b> <br />
            Bảo mật tuyệt đối
          </div>
        </li>
        <li>
          <div class="icon">
            <img src="https://imua.com.vn//images/Logo/qua-tang--1.png" />
          </div>
          <div class="info">
            <b>QUÀ TẶNG</b> <br />
            Mua là có quà
          </div>
        </li>
        <li>
          <div class="icon">
            <img src="https://imua.com.vn/images/Logo/hoan-tra-tien--1.png" />
          </div>
          <div class="info">
            <b>HOÀN TRẢ TIỀN</b><br />
            Trong 7 ngày
          </div>
        </li>
        <li>
          <div class="icon">
            <img src="https://imua.com.vn/images/Logo/thanh-toan--1.png" />
          </div>
          <div class="info">
            <b>THANH TOÁN</b> <br />
            Khi nhận hàng
          </div>
        </li>
        <li>
          <div class="icon">
            <img src="https://imua.com.vn/images/Logo/giao-hang--1.png" />
          </div>
          <div class="info">
            <b>GIAO HÀNG</b> <br />
            Tận nơi toàn quốc
          </div>
        </li>
      </ul>
    </div>
    <!-- end under-slide -->
    <!-- hot-product -->
    <div class="hot-product">
        <div class="header-hot-product cl-b">
             SẢN PHẨM BÁN CHẠY
        </div>
       <div class="content-hot-product">
           <div @click="productClick(product.id)" v-for="product in lstHotProduct" :key="product" class="content-hot-product-detail">
               <img height="210" width="192" :src="'data:image/png;base64,' + product.Image" >
               <div class="text-center">{{product.ProductName}}</div>
               <div class="text-center"><span class="cl-b f-w-b"> {{product.Price-(product.Price*product.Sale/100)}}</span> - <span class="line-through">{{product.Price}}</span> </div>
               <div class="addCart"><Button @click="addCart(product.ProductCode)">Thêm giỏ hàng</Button> </div>
           </div>
       </div>
    </div>
    <!-- end hot-product -->
    <!-- danh muc sp -->
    <div class="category" >
      <div class="header-category">
          <div style="color:white" class="category-name">
            MỸ PHẨM TRANG ĐIỂM
          </div>
          <div class="btn-category-detail">
            <button>Son Môi</button>
            <button>Kem Nền</button>
            <button>Phấn Nước</button>
            <button>Che Khuyết Điểm</button>
          </div>
      </div>
      <div class="content-category">
        <div class="content-category-left">
          <img width="90%" height="480" src="https://imua.com.vn/images/danh-muc/my-pham-trang-diem-menu-left.jpg" />
        </div>
        <div class="content-category-right">
          <div class="product" >
              <img height="80%" width="80%" src="https://imua.com.vn//images/Product/Album/Son-Sophia-Ampoule-Matte-Lipstick-2126.jpg" >
              <div class="product-name">  Son Sophia Ampoule</div>
              <div class="product-salary">250.000</div>
          </div>
          <div class="product" >
              <img height="80%" width="80%" src="https://imua.com.vn//images/Product/Album/Son-Sophia-Ampoule-Matte-Lipstick-2126.jpg" >
              <div class="product-name">  Son Sophia Ampoule</div>
              <div class="product-salary">250.000</div>
          </div>
          <div class="product" >
              <img height="80%" width="80%" src="https://imua.com.vn//images/Product/Album/Son-Sophia-Ampoule-Matte-Lipstick-2126.jpg" >
              <div class="product-name">  Son Sophia Ampoule</div>
              <div class="product-salary">250.000</div>
          </div>
          <div class="product" >
              <img height="80%" width="80%" src="https://imua.com.vn//images/Product/Album/Son-Sophia-Ampoule-Matte-Lipstick-2126.jpg" >
              <div class="product-name">  Son Sophia Ampoule</div>
              <div class="product-salary">250.000</div>
          </div>
          <div class="product" >
              <img height="80%" width="80%" src="https://imua.com.vn//images/Product/Album/Son-Sophia-Ampoule-Matte-Lipstick-2126.jpg" >
              <div class="product-name">  Son Sophia Ampoule</div>
              <div class="product-salary">250.000</div>
          </div>
          <div class="product" >
              <img height="80%" width="80%" src="https://imua.com.vn//images/Product/Album/Son-Sophia-Ampoule-Matte-Lipstick-2126.jpg" >
              <div class="product-name">  Son Sophia Ampoule</div>
              <div class="product-salary">250.000</div>
          </div>
          <div class="product" >
              <img height="80%" width="80%" src="https://imua.com.vn//images/Product/Album/Son-Sophia-Ampoule-Matte-Lipstick-2126.jpg" >
              <div class="product-name">  Son Sophia Ampoule</div>
              <div class="product-salary">250.000</div>
          </div>
          <div class="product" >
              <img height="80%" width="80%" src="https://imua.com.vn//images/Product/Album/Son-Sophia-Ampoule-Matte-Lipstick-2126.jpg" >
              <div class="product-name">  Son Sophia Ampoule</div>
              <div class="product-salary">250.000</div>
          </div>
          <div class="product" >
              <img height="80%" width="80%" src="https://imua.com.vn//images/Product/Album/Son-Sophia-Ampoule-Matte-Lipstick-2126.jpg" >
              <div class="product-name">  Son Sophia Ampoule</div>
              <div class="product-salary">250.000</div>
          </div>
        </div>
      </div>
    </div>
    <!-- end danh muc sp -->
  </BasePage>
</template>
<script>
import BasePage from "@/components/BasePage.vue";
import ProductsAPI from "@/api/ProductsAPI.js";
import axios from 'axios'
export default {
  name: "HomePage",
  components: {
    BasePage
  },
  data(){
      return{
          lstHotProduct:  [],
      }
  },
  created(){
    var me = this;
    ProductsAPI.getAll().then(res => {
      me.lstHotProduct = res.data;
    }).catch(err => {
    })
  },
  convertBlod(){

  },
  methods:{
    productClick(id){
      this.$router.push("/product-detail/1");
    },
    addCart(id){
    },
    convertBase64(img){
      return img? atob(img) : "";
    }
  }

};
</script>

<style lang="scss" scoped>
.slide {
  height: 403px;
  width: 90%;
  margin: 20px auto;
  background-image: url("https://imua.com.vn/images/logo/mua-xuan-2020-0.jpg");
}
.under-slide {
  height: 50px;
  width: 90%;
  margin-left: 1%;
  ul{
       width: 100%;
       
      display: flex;
      justify-content: space-between;
      li{
          padding: 0px 10px;
          border-right: 1px solid black;
        list-style: none;
        .icon{
            float: left;
        }
        .info{
            margin-left: 55px;
        }
      }
  }
}
.hot-product{
    height: 100%;
    width: 90%;
    margin: auto;
    .header-hot-product{
        padding: 15px;
        border-top: 2px solid #F27922;
        border-bottom: 1px solid  #e5e5e5;
        margin-top: 10px;
    }
    .content-hot-product{
    padding: 10px;
    display: flex;
    justify-content: space-between;
        .content-hot-product-detail{
            height: 100%;
            width: 15%;
        }
    }
}
.category{
  margin-top: 20px;
  .header-category{
    height: 50px;
    width: 90%;
    margin: auto;
    border-top: 2px solid #F27922;
    background-color: #F27922;
    .category-name{
        height: 100%;
        width: 20%;
        float: left;
        text-align: center;
        padding-top: 1%;
    }
    .btn-category-detail{
      height: 100%;
      width: 80%;
      background-color: white;
      margin-left: 20%;
      padding: 1% 20px;
      button{
        padding: 5px 10px;
      }
    }
  }
  .content-category{
    margin-top: 5px;
    width: 90%;
    height: 500px;
    margin: auto;
    .content-category-left{
      height: 100%;
      width: 20%;
      margin-left: -20%;
      float: left;
      img{
        margin-left: 10px;
        margin-top: 10px;
      }
    }
    .content-category-right{
      height: 100%;
      width: 80%;
      margin-left: 20%;
      .product{ 
        height: 50%;
        width: 18%;
        float: left;
        border-right:1px solid #e5e5e5 ;
        border-top:1px solid #e5e5e5 ;
        .product-name{
          text-align: center;
        }
        .product-salary{
          text-align: center;

        }
      }
    }
  }
}
</style>