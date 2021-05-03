<template>
  <div>
    <div class="left">
      <AddCatrgoryDetail
        @addClick="listenAddClick"
        :Category="Category"
      ></AddCatrgoryDetail>
    </div>
    <div class="right">
      <table border="1px solid #e5e5e5">
        <tr>
          <th style="width: 50px">Mã danh mục con</th>
          <th style="width: 50px">Danh mục cha</th>
          <th style="width: 50px">Tên danh mục con</th>
          <th style="width: 50px"></th>
        </tr>
        <tr
          @click="rowClick(item)"
          v-for="(item, index) in dataSourceX"
          :key="index"
        >
          <td style="width: 50px">{{ item.CategoryDetailCode }}</td>
          <td style="width: 50px">{{ getCategoryNameById(item.CategoryID) }}</td>
          <td style="width: 50px">{{ item.CategoryDetailName }}</td>
          <td style="width: 50px">
            <button @click="deleteRow(item.CategoryID)">Xoa</button>
          </td>
        </tr>
      </table>
      <div class="paging">
        <a href="#">&laquo;</a>
        <a
          v-if="pagingRequest.pageIndex > 1"
          @click="changePageIndex(pagingRequest.pageIndex - 1)"
          >{{ pagingRequest.pageIndex - 1 }}</a
        >
        <a @click="changePageIndex(pagingRequest.pageIndex)">{{
          pagingRequest.pageIndex
        }}</a>
        <a @click="changePageIndex(pagingRequest.pageIndex + 1)">{{
          pagingRequest.pageIndex + 1
        }}</a>
        <a
          v-if="pagingRequest.pageIndex == 1"
          @click="changePageIndex(pagingRequest.pageIndex + 2)"
          >{{ pagingRequest.pageIndex + 2 }}</a
        >
        <a href="#">&raquo;</a>
      </div>
    </div>
  </div>
</template>
<script>
import AddCatrgoryDetail from "@/viewAdmin/CategoryDetail/AddCategoryDetail.vue";
import CategoryDetailAPI from "@/api/CategoryDetailAPI.js";
import CategoryAPI from "@/api/CategoryAPI.js";
export default {
  components: {
    AddCatrgoryDetail,
  },
  data() {
    return {
      api: CategoryDetailAPI,
      addMode: true,
      lstHeader: null,
      isAdd: false,
      dataSourceX: null,
      Category: {
        CategoryID: "",
        CategoryCode: "",
        CategoryName: "",
        SubCategory: "",
      },
      pagingRequest: {
        pageIndex: 1,
        pageSize: 10,
        searchValue: "string",
      },
      lsSelect: "",
      lstCategory: []
    };
  },
  created() {
    this.getData();
    CategoryAPI.getAll().then(res => {
        this.lstCategory = res.data;
    })
  },
  methods: {
    getCategoryNameById(id){
        return this.lstCategory.filter(item => item.CategoryID == id)[0].CategoryName;
    },
    deleteRow(id) {
      this.api
        .delete(id)
        .then((res) => {
          this.getData();
        })
        .catch((err) => {});
    },
    rowClick(data) {
      this.Category = data;
    },
    addNew() {
      this.addMode = true;
    },
    listenAddClick() {
      this.getData();
    },
    getData() {
      CategoryDetailAPI.paging(this.pagingRequest)
        .then((res) => {
          this.dataSourceX = res.data;
        })
        .catch((err) => console.log(err));
    },
    changePageIndex(index) {
      this.pagingRequest.pageIndex = index;
      this.getData();
    },
  },
  watch: {
    dataSourceX(val) {},
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