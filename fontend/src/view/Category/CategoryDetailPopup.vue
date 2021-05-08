<template>
  <div>
    <cc-popup
      v-model="active"
      :width="400"
      :title="title"
      :height="250"
      :value="true"
    >
      <div>
        Mã danh mục con: <cc-input v-model="CategoryDetail.CategoryDetailCode"></cc-input>
      </div>
      <div>
        Tên danh mục con: <cc-input v-model="CategoryDetail.CategoryDetailName"></cc-input>
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
    CategoryDetail: {
      Object : Object,
      default: {
        CategoryDetailID: 1,
        CategoryID: 1,
        CategoryDetailCode: "",
        CategoryDetailName: "",
      }
    },
    // 1-add new  2- edit
    formMode: {
      type: Number,
      default: 1
    }
  },
  created(){
    this.formMode == 1? this.title = "Thêm mới danh mục con" : this.title = "Sửa danh mục con";
  },
  methods: {
    open() {
      this.active = true;
    },
    saveClick() {
      this.$emit("saveClick",this.CategoryDetail);
    },
    handleClose() {
      this.$emit("close",false);
    },
    closePopup() {
      this.active = false;
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