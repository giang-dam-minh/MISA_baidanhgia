import Vue from 'vue'
import Router from 'vue-router'

Vue.use(Router)

export default new Router({
  routes: [
    {
      path: '/',
      redirect: '/organization-unit'
    },
    {
      path: '/login',
      name: 'Login',
      component:  () => import('../login/Login')
    },
    {
      path: '/home',
      name: 'Home',
      component:  () => import('../view/Home/Home')
    },
    {
      path: '/organization-unit',
      name: 'OrganizationUnit',
      component:  () => import('../view/OrganizationUnit/OrganizationUnit')
    },
    {
      path: '/category',
      name: 'Category',
      component: () => import('../view/Category/Category.vue')
    },
    {
      path: '/category-detail/:code',
      name: 'CategoryDetail',
      component: () => import('../view/Category/CategoryDetail.vue')
    },
    {
      path: '/product',
      name: 'Product',
      component: () => import('../view/Product/Product.vue')
    }
  ]
})
