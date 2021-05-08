<template>
  <div>
    <cc-popup
      v-model="open"
      :width="700"
      :title="title"
      :height="500"
    >
        <div class="left">
            <div >
                Mã sản phẩm: <cc-input v-model="Product.ProductCode"></cc-input>
            </div>
            <div>
                Tên sản phẩm:
                <cc-input v-model="Product.ProductName"></cc-input>
                
            </div>
            <div>
                Danh mục: <br>
                <select v-model="Product.CategoryDetailID">
                    <option :value="cartgoryDetail.CategoryDetailID" v-for="(cartgoryDetail,index) in lstCategoryDetail" :key="index">{{cartgoryDetail.CategoryDetailName}}</option>
                </select>
            </div>
            <div>
                Giá: <cc-input v-model="Product.Price"></cc-input>
            </div>
            <div>
                Tỷ lệ giảm giá: <cc-input v-model="Product.Sale"></cc-input>
            </div>
            <div>
                Mô tả:<br> <textarea style="height: 110px;width: 314px;" v-model="Product.Description"></textarea >
            </div>
        </div>
        <div class="right">
            <div>
                Hình ảnh:
                <div>
                    <input type="file" accept="image/*" @change="onChange" />
                    <div id="preview">
                        <img height="200" width="150" v-if="item.imageUrl" :src="item.imageUrl" />
                        <img height="200" width="150" v-else-if="Product.Image" :src="'data:image/png;base64,' + Product.Image" />
                    </div>
                </div>
            </div>
        </div>
        <div class="flex footer">
            <cc-button class="m-r-12" type="secondary-border" @click="handleClose">Hủy</cc-button>
            <cc-button type="delete" @click="saveClick">Lưu</cc-button>
        </div>
    </cc-popup>
  </div>
</template>
<script>
import CategoryDetailAPI from "@/api/CategoryDetailAPI.js";
export default {
  data() {
    return {
      title: "Thêm mới sản phẩm",
      active: false,
      type: 1,
      content: "",
      callbackDelete: null,
      dataCallbackDelete: null,
      callbackClose: null,
      dataCallbackClose: null,
      item: {
        image: null,
        imageUrl: null,
      },
      lstCategoryDetail: []
    };
  },
  props: {
    Product: {
      Object : Object,
      default: {
         ProductID: 1,
         ProductCode: "",
         ProductName: "",
         Image: "",
         Price: "",
         Sale: "",
         Description: "",
         CategoryDetailID: "",
      },
      open:{
        type: Boolean,
        default: false
      }
    },
    // 1-add new  2- edit
    formMode: {
      type: Number,
      default: 1
    }
  },
  created(){
    var me = this;
    this.formMode == 1? this.title = "Thêm mới sản phẩm" : this.title = "Sửa sản phẩm";
    CategoryDetailAPI.getAll().then(res => {
        me.lstCategoryDetail = res.data;
    })
  },
  methods: {
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
    onChange(e) {
      const file = e.target.files[0];
      this.image = file;
      this.item.imageUrl = URL.createObjectURL(file);
    },
    async saveClick() {
      var me = this;
      if(this.item.imageUrl)
      {
        await this.toDataUrl(this.item.imageUrl, function (dataUrl){
            me.Product.Image = dataUrl.substring(dataUrl.indexOf(",") + 1);
            me.$emit("saveClick",me.Product);
        });
      }
      else{
        me.$emit("saveClick",me.Product);
      }
      
    },
    handleClose() {
      this.$emit("close",false);
    },
    confirmDelete(
      title = "Cảnh báo xóa",
      content = "Bạn có chắc chắn muốn xóa không?",
      callbackDelete = null,
      dataCallbackDelete = null,
      callbackClose = null,
      dataCallbackClose = null
    ) {
      this.title = title;
      this.content = content;
      this.callbackDelete = callbackDelete;
      this.dataCallbackDelete = dataCallbackDelete;
      this.callbackClose = callbackClose;
      this.dataCallbackClose = dataCallbackClose;
      this.type = 3;
      this.open();
    },
  },
};
</script>
<style lang="scss">
.footer {
  float: right;
  padding: 12px 0px 4px 0px;
}
.left{
    margin-right: 20px;
    width: 50%;
    float: left;
}
.right{
    margin-left: 20px;
    height: 356px;
}
select{
    height: 34px;
    width: 311px;
    outline: none;
    border: 1px solid #e5e5e5;
    border-radius: 5px;
}
</style>