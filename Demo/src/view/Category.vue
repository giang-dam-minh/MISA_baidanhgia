<template>
  <BasePage>
    <div class="m-t-10 m-b-10 m-l-20"> MỸ PHẨM TRANG ĐIỂM</div>
    <div class="category m-auto">
      <div class="header-category">
        <div>SON MÔI</div>
      </div>
      <div class="content-category">
        <div class="product">
          <img
            height="192"
            width="160"
            src="https://imua.com.vn//images/Product/Album/Son-Sophia-Ampoule-Matte-Lipstick-2126.jpg"
          />
          <div class="product-name">Son Sophia Ampoule</div>
          <div class="product-salary cl-b">250.000</div>
        </div>
        <div class="product">
          <img
            height="192"
            width="160"
            src="https://imua.com.vn//images/Product/Album/Son-Sophia-Ampoule-Matte-Lipstick-2126.jpg"
          />
          <div class="product-name">Son Sophia Ampoule</div>
          <div class="product-salary">250.000</div>
        </div>
        <div class="product">
          <img
            height="192"
            width="160"
            src="https://imua.com.vn//images/Product/Album/Son-Sophia-Ampoule-Matte-Lipstick-2126.jpg"
          />
          <div class="product-name">Son Sophia Ampoule</div>
          <div class="product-salary">250.000</div>
        </div>
        <div class="product">
          <img
            height="192"
            width="160"
            src="https://imua.com.vn//images/Product/Album/Son-Sophia-Ampoule-Matte-Lipstick-2126.jpg"
          />
          <div class="product-name">Son Sophia Ampoule</div>
          <div class="product-salary">250.000</div>
        </div>
        <div class="product">
          <img
            height="192"
            width="160"
            src="https://imua.com.vn//images/Product/Album/Son-Sophia-Ampoule-Matte-Lipstick-2126.jpg"
          />
          <div class="product-name">Son Sophia Ampoule</div>
          <div class="product-salary">250.000</div>
        </div>
        <div class="product">
          <img
            height="192"
            width="160"
            src="https://imua.com.vn//images/Product/Album/Son-Sophia-Ampoule-Matte-Lipstick-2126.jpg"
          />
          <div class="product-name">Son Sophia Ampoule</div>
          <div class="product-salary">250.000</div>
        </div>
        <div class="product">
          <img
            height="192"
            width="160"
            src="https://imua.com.vn//images/Product/Album/Son-Sophia-Ampoule-Matte-Lipstick-2126.jpg"
          />
          <div class="product-name">Son Sophia Ampoule</div>
          <div class="product-salary">250.000</div>
        </div>
        <div class="product">
          <img
            height="192"
            width="160"
            src="https://imua.com.vn//images/Product/Album/Son-Sophia-Ampoule-Matte-Lipstick-2126.jpg"
          />
          <div class="product-name">Son Sophia Ampoule</div>
          <div class="product-salary">250.000</div>
        </div>
        <div class="product">
          <img
            height="192"
            width="160"
            src="https://imua.com.vn//images/Product/Album/Son-Sophia-Ampoule-Matte-Lipstick-2126.jpg"
          />
          <div class="product-name">Son Sophia Ampoule</div>
          <div class="product-salary">250.000</div>
        </div>
      </div>
      <div class="clear"></div>
    </div>
  </BasePage>
</template>
<script>
import BasePage from "@/components/BasePage.vue";
export default {
  name: "Category",
  components: {
    BasePage,
  },
};
</script>

<style lang="scss" scoped>
.category {
  width: 90%;
  border: 1px solid #e5e5e5;
  border-radius: 5px;
  margin-top: 20px;
  .header-category {
    width: 91.6%;
    padding: 15px 50px;
    border-bottom: 1px solid #e5e5e5;
  }
  .content-category {
    width: 100%;
    height: 100%;
    padding: 20px;
    .product {
      width: 160px;
      float: left;
      .product-name {
        text-align: center;
      }
      .product-salary {
        text-align: center;
      }
      &:hover{
        cursor: pointer;
        color: orange;
      }
    }
  }
}
</style>