<template>
  <div>
    <div class="btnAdd"><button @click="addNew">Them moi</button></div>
    <table>
      <tr>
        <th>Mã sản phẩm</th>
        <th>Tên sản phẩm</th>
        <th>Hình ảnh</th>
        <th>Giá</th>
        <th>Tỷ lệ giảm giá</th>
        <th>Mô tả</th>
        <th>Mã danh mục</th>
        <th></th>
        <th></th>
      </tr>
      <tr @click="editProduct(product)" v-for="(product,index) in lstProduct" :key="index">
        <td>{{product.ProductCode}}</td>
        <td>{{product.ProductName}}</td>
        <td>
          <img
            height="100"
            width="100"
            :src="'data:image/png;base64,' + product.Image"
          />
        </td>
        <td>{{product.Price}}</td>
        <td>{{product.Sale}}</td>
        <td>{{product.Description}}</td>
        <td>{{product.CategoryID}}</td>
        <td><button @click="deleteProduct(product.ProductID)">Xóa</button></td>
        <td><button @click="editProduct(product)">Sửa</button></td>
      </tr>
    </table>
  </div>
</template>
<script>
import ProductsAPI from "@/api/ProductsAPI.js";

export default {
  components: {},
  data() {
    return {
      api: ProductsAPI,
      lstHeader: [],
      isAdd: false,
      pagingRequest: {
        pageIndex: 1,
        pageSize: 10,
        searchValue: "string",
      },
      lstProduct: "",
    };
  },
  created(){
      this.getData();
  },
  methods: {
    addNew() {
      this.$emit("addNew");
    },
    getData() {
      ProductsAPI.paging(this.pagingRequest)
        .then((res) => {
          this.lstProduct = res.data;
        })
        .catch((err) => console.log(err));
    },
    deleteProduct(id){
        this.api
        .delete(id)
        .then((res) => {
          this.getData();
        })
        .catch((err) => {});
    },
    editProduct(data){
        this.$emit("editProduct",data);
    }
  },
};
</script>
<style lang="scss" scoped>
table {
  margin-top: 20px;
  border-collapse: collapse;
  width: 100%;
  th,
  td {
    padding: 10px;
    text-align: left;
    border-bottom: 1px solid black;
  }
  tr {
    border-bottom: 1px solid black;
  }
}
.btnAdd {
  margin-top: 10px;
  button {
    padding: 10px;
  }
}
</style>