<template>
  <div>
    <div class="menu-admin">
      <div class="logo"><img src="https://imua.com.vn//images/logo.png" /></div>
      <div class="">Quan ly website</div>
      <ul>
        <li>Danh muc san pham</li>
        <li>San pham</li>
        <li>Gio hang</li>
      </ul>
    </div>
    <div class="header-admin">
      <input placeholder="Tim kiem" />
      <div class="user-info">
        <div class="avatar"><img height="24" style="border-radius:50%" width="24"  src="@/assets/icons/avatar6.png" ></div>
        <div class="user-name">Dam Minh Giang</div>
      </div>
    </div>

    <div class="content-admin">
      <EditProduct v-if="false"></EditProduct>
      <EditCategory></EditCategory>
    </div>
  </div>
</template>
<script>
import EditProduct from "@/viewAdmin/EditProduct.vue"
import EditCategory from "@/viewAdmin/Category/EditCategory.vue"
export default {
  components:{
    EditProduct,
    EditCategory
  }
};
</script>
<style lang="scss" scoped>
.header-admin {
  height: 50px;
  width: 81%;
  margin-left: 19%;
  border-bottom: 1px solid black;
  display: flex;
  justify-content: space-between;
  input{
    width: 250px;
    padding: 10px;
    height: 10px;
  }
  .user-info{
    width: 200px;
    .avatar{
    float: left;
    margin-right: 10px;
  }
  }
  
}
.menu-admin {
  height: 90vh;
  width: 15%;
  float: left;
  background-color: rgb(230, 230, 247);
  padding: 20px;
  border-radius: 5px;
  ul {
    margin-left: -46px ;
    li {
      border-bottom: 1px solid white;
      border-radius: 5px;
      margin: 2px 0px;
      list-style: none;
      padding: 10px 20px;
      background-color: rgb(214, 104, 41);
      color: white;
    }
  }
}
.content-admin {
  height: calc(80vh - 80px);
  width: 82%;
  margin-left: 19%;
}
</style>