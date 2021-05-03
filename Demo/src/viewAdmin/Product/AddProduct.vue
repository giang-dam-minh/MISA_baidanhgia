<template>
  <div>
    <div class="content-add-product">
      <div class="title f-s-20 f-w-b cl-b">Quản lý sản phẩm > {{title}}</div>
      <div class="content">
        <div class="flex">Mã sản phẩm: <input v-model="Product.ProductCode" /></div>
        <div class="flex">Tên sản phẩm: <input v-model="Product.ProductName" /></div>
        <div class="flex">Hình ảnh: <input @change="onChangeImage"  type="file" /></div>
        <div class="flex">Giá: <input v-model="Product.Price" /></div>
        <div class="flex">Tỷ lệ giảm giá: <input  v-model="Product.Sale" /></div>
        <div class="flex">Mô tả: <input v-model="Product.Description" /></div>
        <div  class="flex">
            Danh mục sản phẩm:
            <select v-model="Product.CategoryDetailID">
                <option :value="item.CategoryDetailID" v-for="(item,index) in lstCategory" :key="index">{{item.CategoryDetailName}}</option>
            </select>
         </div>
      </div>
      <div class="btn-group">
        <button @click="addClick">Lưu</button>
      </div>
    </div>
    <div class="preview-img">
        <img width="300px" height="480" :src="item.imageUrl?item.imageUrl: 'data:image/png;base64,' + Product.Image" />
    </div>
  </div>
</template>
<script>
import ProductsAPI from "@/api/ProductsAPI.js";
import CategoryDetailAPI from "@/api/CategoryDetailAPI.js";

export default {
  components: {
    
  },
  data() {
    return {
      api: ProductsAPI,
      lstHeader: [],
      isAdd: false,
      item: {
        image: null,
        imageUrl: null,
      },
      lstCategory: "",
      title: ""
    };
  },
  props: {
    Product: {
      type: Object,
      default: {
        ProductID: "1",
        ProductCode: "",
        ProductName: "",
        Price: "",
        Sale: "",
        Image: "",
        Description: "",
        CategoryDetailID: 12,
      },
    },
     formMode: {
        default: 1,
        type: Number
      },
  },
  created(){
    this.getLstCategory();
    this.formMode==1?this.title="Thêm mới":this.title="Sửa";

  },
  methods: {
    onChangeImage(e){
      const file = e.target.files[0];
      this.item.imageUrl = URL.createObjectURL(file);
    },
    addNew() {
      this.isAdd = true;
    },
   async addClick() {
      var me = this;
      if(this.formMode == 1){
        await this.toDataUrl(this.item.imageUrl, function (dataUrl){
            me.Product.Image = dataUrl.substring(dataUrl.indexOf(",") + 1);
            me.api.insert(me.Product);
        });
      }
      else{
        if(this.item.imageUrl)
        {
          await this.toDataUrl(this.item.imageUrl, function (dataUrl){
              me.Product.Image = dataUrl.substring(dataUrl.indexOf(",") + 1);
              me.api.update1(me.Product);
          });
        }
        else{
          me.api.update1(me.Product);
        }
      }
    },
    updateClick() {
      var param = {
        CategoryID: this.Category.CategoryID,
        CategoryCode: this.Category.CategoryCode,
        CategoryName: this.Category.CategoryName,
        SubCategory: this.Category.SubCategory,
      };
      CategoryAPI.update1(param).then((res) => {
        this.$emit("updateClick");
      });
    },
    toDataUrl(url, callback) {
      var xhr = new XMLHttpRequest();
      xhr.onload = function () {
        var reader = new FileReader();
        reader.onloadend = function () {
          callback(reader.result);
        };
        reader.readAsDataURL(xhr.response);
      };
      xhr.open("GET", url);
      xhr.responseType = "blob";
      xhr.send();
    },
    getLstCategory(){
        var me = this;
        CategoryDetailAPI.getAll().then(res => {
            me.lstCategory = res.data;
        }).catch(err => {

        });
    }
  },
};
</script>
<style lang="scss" scoped>
.content-add-product {
  float: left;
  width: 50%;
  .content {
    width: 100%;
    padding: 20px;
    input {
      padding: 10px 15px;
      width: 300px;
    }
    div {
      margin-top: 10px;
    }
    select{
        padding: 10px 15px;
      width: 331px;
    }
  }
}
.preview-img {
  margin-left: 60%;
  img {
    margin-top: 40px;
  }
}
.btn-group{
    button{
        padding: 10px 40px;
        margin-left: 43%;
        background-color: #F27922;
        color: white;
    }
}
</style>