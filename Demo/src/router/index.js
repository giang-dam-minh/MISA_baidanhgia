import Vue from 'vue'
import Router from 'vue-router'
import HomePage from "@/components/HomePage/HomePage.vue"
import ProductDetail from "@/view/ProductDetail.vue";
import Category from "@/view/Category.vue";
import Cart from "@/view/Cart.vue";
import HomePageAdmin from "@/viewAdmin/HomePageAdmin.vue";
Vue.use(Router)

export default new Router({
  routes: [
    {
      path: '/',
      name: 'HomePage',
      component: HomePage
    },
    {
      path: "/product-detail/:id",
      name: "ProductDeail",
      component: ProductDetail
    },
    {
      path:"/category/:id",
      name: "Category",
      component: Category
    },
    {
      path:"/cart",
      name: "Cart",
      component: Cart
    },
    {

      path: "/admin",
      name: "HomePageAdmin",
      component: HomePageAdmin
    }
  ]
})
