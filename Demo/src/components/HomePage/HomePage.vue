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
      <div class="header-hot-product cl-b">SẢN PHẨM BÁN CHẠY</div>
      <div class="content-hot-product">
        <div
          @click="productClick(product.id)"
          v-for="product in lstHotProduct"
          :key="product"
          class="content-hot-product-detail"
        >
          <img
            height="210"
            width="192"
            :src="'data:image/png;base64,' + product.Image"
          />
          <div class="text-center">{{ product.ProductName }}</div>
          <div class="text-center">
            <span class="cl-b f-w-b">
              {{ product.Price - (product.Price * product.Sale) / 100 }}</span
            >
            - <span class="line-through">{{ product.Price }}</span>
          </div>
          <div class="addCart">
            <Button @click="addCart(product.ProductID)">Thêm giỏ hàng</Button>
          </div>
        </div>
      </div>
    </div>
    <!-- end hot-product -->
    <!-- danh muc sp -->
    <div v-for="(category, index) in lstCategory" :key="index" class="category">
      <div class="header-category">
        <div style="color: white" class="category-name">
          {{ toUpperCase(category.CategoryName) }}
        </div>
        <div class="btn-category-detail">
          <button
            v-for="(subCategory, index) in getListSubCategoryById(category.CategoryID)"
            :key="index"
          >
            {{ subCategory.CategoryDetailName }}
          </button>
        </div>
      </div>
      <div class="content-category">
        <div class="content-category-left">
          <img
            width="90%"
            height="480"
            src="https://imua.com.vn/images/danh-muc/my-pham-trang-diem-menu-left.jpg"
          />
        </div>
        <div class="content-category-right">
          <div v-for="(product, index) in getProductByCategoryID(category.CategoryID)" :key="index" class="product">
            <img
              height="80%"
              width="80%"
              :src="'data:image/png;base64,' + product.Image"
            />
            <div class="product-name">{{ product.ProductName }}</div>
            <div class="product-salary">
              <span class="cl-b">{{ product.Price }}</span>-<span class="line-through">{{product.Price - (product.Price * product.Sale) / 100}}</span>
            </div>
            <div class="addCart"><button @click="addCart(product.ProductID)" >them gio hang</button></div>
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
import CategoryAPI from "@/api/CategoryAPI.js";
import CategoryDetailAPI from "@/api/CategoryDetailAPI.js";
export default {
  name: "HomePage",
  components: {
    BasePage,
  },
  data() {
    return {
      lstHotProduct: [],
      lstProduct: [],
      lstCategory: [],
      lstCategoryDetail: [],
    };
  },
  async created() {
    var me = this;
    await CategoryDetailAPI.getAll()
      .then((res) => {
        me.lstCategoryDetail = res.data;
      })
      .catch((err) => {});
    await ProductsAPI.getHotProduct()
      .then((res) => {
        me.lstHotProduct = res.data;
      })
      .catch((err) => {});
    await ProductsAPI.getAll()
      .then((res) => {
        me.lstProduct = res.data;
      })
      .catch((err) => {});
    await CategoryAPI.getAll()
      .then((res) => {
        me.lstCategory = res.data;
      })
      .catch((err) => {});
  },
  methods: {
    getProductByCategoryID(id) {
      var me = this;
      var lstSubCategory = this.getListSubCategoryById(id);
      var lstProduct = [];
      lstSubCategory.forEach(item =>{
        me.lstProduct.filter(ele => {
          if(item.CategoryDetailID == ele.CategoryDetailID){
            lstProduct.push(ele);
          }
        })
      });
      return lstProduct;
    },
    getListSubCategoryById(id) {
      return this.lstCategoryDetail.filter(item => item.CategoryID ==id)
    },
    productClick(id) {
      this.$router.push("/product-detail/1");
    },
    addCart(id) {
      var data = localStorage.dataCart;
      if(data){
        var oldData = JSON.parse(data);
        var check = false;
        oldData.map(item => {
          if(item.ID==id)
          {
            item.Quanlity ++;
            check =true;
          } 
        });
        if(!check){
          var infoProduct = {
            ID: id,
            Quanlity: 1
          }
          oldData.push(infoProduct);
        }
        data = JSON.stringify(oldData);
      }
      else{
        data = [];
         var infoProduct = {
        ID: id,
        Quanlity: 1
        }
        data.push(infoProduct);
        data = JSON.stringify(data);
      }
      localStorage.dataCart = data;
    },
    toUpperCase(str) {
      return str.toUpperCase();
    },
  },
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
  ul {
    width: 100%;

    display: flex;
    justify-content: space-between;
    li {
      padding: 0px 10px;
      border-right: 1px solid black;
      list-style: none;
      .icon {
        float: left;
      }
      .info {
        margin-left: 55px;
      }
    }
  }
}
.hot-product {
  height: 100%;
  width: 90%;
  margin: auto;
  .header-hot-product {
    padding: 15px;
    border-top: 2px solid #f27922;
    border-bottom: 1px solid #e5e5e5;
    margin-top: 10px;
  }
  .content-hot-product {
    padding: 10px;
    display: flex;
    justify-content: space-between;
    .content-hot-product-detail {
      height: 100%;
      width: 15%;
    }
  }
}
.category {
  margin-top: 20px;
  .header-category {
    height: 50px;
    width: 90%;
    margin: auto;
    border-top: 2px solid #f27922;
    background-color: #f27922;
    .category-name {
      height: 100%;
      width: 20%;
      float: left;
      text-align: center;
      padding-top: 1%;
    }
    .btn-category-detail {
      height: 100%;
      width: 80%;
      background-color: white;
      margin-left: 20%;
      padding: 1% 20px;
      button {
        padding: 5px 10px;
      }
    }
  }
  .content-category {
    margin-top: 5px;
    width: 90%;
    height: 500px;
    margin: auto;
    .content-category-left {
      height: 100%;
      width: 20%;
      margin-left: -20%;
      float: left;
      img {
        margin-left: 10px;
        margin-top: 10px;
      }
    }
    .content-category-right {
      height: 100%;
      width: 80%;
      margin-left: 20%;
      .product {
        height: 50%;
        width: 18%;
        float: left;
        border-right: 1px solid #e5e5e5;
        border-top: 1px solid #e5e5e5;
        .product-name {
          text-align: center;
        }
        .product-salary {
          text-align: center;
        }
      }
    }
  }
}
</style>