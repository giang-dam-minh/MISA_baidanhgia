<template>
  <div>
    <div class="left">
      <AddCatrgory @addClick="listenAddClick"></AddCatrgory>
    </div>
    <div class="right">
      <table border="1px solid #e5e5e5">
        <tr>
          <th><input type="checkbox" /></th>
          <th>Mã danh mục</th>
          <th>Tên danh mục</th>
          <th>Danh mục con</th>
        </tr>
        <tr v-for="(item, index) in dataSourceX" :key="index">
          <td><input type="checkbox" /></td>
          <td>{{ item.CategoryID }}</td>
          <td>{{ item.CategoryName }}</td>
          <td>{{ item.SubCategory }}</td>
        </tr>
      </table>
      <div class="paging">
        <a href="#">&laquo;</a>
        <a href="#">{{pagingRequest.pageIndex}}</a>
        <a href="#">{{pagingRequest.pageIndex +1 }}</a>
        <a href="#">{{pagingRequest.pageIndex +2}}</a>
        <a href="#">&raquo;</a>
      </div>
    </div>
  </div>
</template>
<script>
import AddCatrgory from "@/viewAdmin/Category/AddCategory.vue";
import CategoryAPI from "@/api/CategoryAPI.js";
export default {
  components: {
    AddCatrgory,
  },
  data() {
    return {
      addMode: true,
      lstHeader: null,
      isAdd: false,
      dataSourceX: null,
      pagingRequest:{
        "pageIndex": 1,
        "pageSize": 10,
        "searchValue": "string"
      }
    };
  },
  created() {
    this.getData();
  },
  methods: {
    addNew() {
      this.addMode = true;
    },
    listenAddClick() {
      this.getData();
    },
    getData() {
      CategoryAPI.paging(this.pagingRequest)
        .then((res) => {
          this.dataSourceX = res.data;
        })
        .catch((err) => console.log(err));
    },
  },
  watch: {
    dataSourceX(val) {
      debugger;
    },
  },
};
</script>
<style lang="scss" scoped>
.left {
  height: calc(90vh - 51px);
  width: 30%;
  float: left;
  .btnAdd {
    margin-top: 10px;
    button {
      padding: 10px;
    }
  }
}
.right {
  height: calc(90vh - 51px);
  width: 60%;
  margin-left: 35%;
  margin-top: 20px;
  table {
    width: 100%;
    border-collapse: collapse;

    th {
      padding: 5px 10px;
    }
    td {
      padding: 5px 10px;
    }
  }
  .paging {
    display: inline-block;
    a {
      color: black;
      float: left;
      padding: 8px 16px;
      text-decoration: none;
    }
  }
}
</style>