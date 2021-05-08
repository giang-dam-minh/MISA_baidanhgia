<template>
  <div>
    <cc-popup
      v-model="open"
      :width="400"
      :title="title"
      :height="500"
    >
      <div>
        Mã danh mục: <cc-input v-model="Category.CategoryCode"></cc-input>
      </div>
      <div>
        Tên danh mục: <cc-input v-model="Category.CategoryName"></cc-input>
      </div>
      <div>
        Hình ảnh danh mục:
        <div>
          <input type="file" accept="image/*" @change="onChange" />
          <div id="preview">
            <img height="200" width="150" v-if="item.imageUrl" :src="item.imageUrl" />
            <img height="200" width="150" v-else-if="Category.ImageCategory" :src="'data:image/png;base64,' + Category.ImageCategory" />
          </div>
        </div>
      </div>
      <div class="flex footer">
        <cc-button class="m-r-12" type="secondary-border" @click="handleClose"
          >Hủy</cc-button
        >
        <cc-button type="delete" @click="saveClick">Lưu</cc-button>
      </div>
    </cc-popup>
  </div>
</template>
<script>
export default {
  data() {
    return {
      title: "Thêm mới danh mục sản phẩm",
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
    };
  },
  props: {
    Category: {
      Object : Object,
      default: {
         CategoryCode: "",
         CategoryName: "",
         ImageCategory: "",
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
    this.formMode == 1? this.title = "Thêm mới sản phẩm" : this.title = "Sửa sản phẩm";
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
      await this.toDataUrl(this.item.imageUrl, function (dataUrl){
        me.Category.ImageCategory = dataUrl.substring(dataUrl.indexOf(",") + 1);
        me.$emit("saveClick",me.Category);
      });
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
</style>