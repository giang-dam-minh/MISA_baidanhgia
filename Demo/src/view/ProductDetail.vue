<template>
    <BasePage>
    <div class="m-t-10 f-w-b f-s-30 m-b-10 m-l-20">Thong tin san pham:</div>
    <div class="content-product-detail m-t-10">
        <div class="img">
            <img height="522" width="435" src="http://imua.com.vn/images/Product/Album/Sua-Bot-Ensure-Original-Nutrition-Powder-My-3880.jpg">
        </div>
            <div class="detail">
                <div class="product-name f-w-b f-s-20">
                    Sữa Ensure Original Nutrition Powder Hàng Chính Hãng USA Mỹ
                </div>
                <div class="intro">- Sữa Ensure Original được nhập khẩu chính hãng USA Mỹ
- Sữa bột Ensure Original Nutrition Powder cung cấp nguồn dinh dưỡng, bổ sung vitamin, chất khoáng, protein ngăn ngừa bệnh tật giúp cơ thể luôn khỏe mạnh.
- Sữa Ensure của Mỹ chính đã được bộ y tế Mỹ kiểm định chất lượng và an toàn của sản phẩm.
                </div>
                <div class="price">Gia ban: <span class=" f-s-20 f-w-b cl-b">390.000</span> </div>

                <div class="info-other">
                    <div>Nhập khẩu chính hãng USA Mỹ.</div>
                    <div>Nhập khẩu chính hãng USA Mỹ.</div>
                    <div>Nhập khẩu chính hãng USA Mỹ.</div>
                    <div>Nhập khẩu chính hãng USA Mỹ.</div>
                    <div>Nhập khẩu chính hãng USA Mỹ.</div>
                </div>
                <div class="clear"></div>
                <div class="group-btn">
                    <span class="m-t-10 ">So luong: </span>
                    <input  type="number" value="0" id="quantity" name="quantity" min="0" max="100">
                    <button>Dat Hang Ngay</button>
                    <button>Them Vao Gio Hang</button>
                </div>
            </div>
    </div>
    <div class="info-detail">
        <div class="m-t-10 f-s-20 f-w-b m-b-10">Thong tin bo sung</div>
        <div>Sức khỏe luôn là yếu tố quan trọng hàng đầu, khi còn trẻ chúng ta thường quan trọng vấn đề làm sao để kiếm được nhiều tiền để lo cho cuộc sống, nhưng khi đến 1 giai đoạn bạn sẽ nhận ra sức khỏe mới là quan trọng nhất. Bỏ "sức khỏe ra có thể đổi lấy bằng tiền, nhưng không phải có tiền là có thể mua lại sức khỏe", vì vậy hôm nay hãy lo cho sức khỏe của bạn, người thân và gia đình bạn trước khi quá trễ.

  Vậy thì ngay lúc này đây bạn không thể không lựa chọn cho gia đình mình dòng sữa Ensure Original Nutrition Powder  được nhập khẩu chính hãng USA Mỹ dòng sản phẩm bổ sung dinh dưỡng số 1 trên thị trường Mỹ hiện nay. 

- Sữa Ensure Original là thức uống bổ dưỡng, bổ sung cho cơ thể đầy đủ các vitamin, đạm quý, canxi, khoáng chất và dinh dưỡng cao cấp... giúp hồi phục tổn thương, ngăn ngừa bệnh tật, giúp cơ thể luôn khỏe mạnh.</div>
    </div>
    </BasePage>
</template>

<script>
import BasePage from '@/components/BasePage.vue'
export default {
  name: "ProductDetail",
  components:{ BasePage },
  created(){
  }
}
</script>

<style lang="scss" scoped>
.content-product-detail{
    width: 90%;
    height: 100%;
    margin: auto;
    border: 1px solid #e5e5e5;
    border-radius: 5px;
    .img{
        float: left;
    }
    .detail{
        margin-left: 435px;
        padding: 20px;
        .product-name{
            font-weight: b;

        }
        .intro{
            width: 50%;
            padding: 20px;
        }
        .price{
            margin-top: 30px;
            padding: 15px;
            width: 90%;
            border-top: 1px solid #e5e5e5;
            border-bottom: 1px solid #e5e5e5;
        }
        .info-other{
            margin-top: 10px;
            padding: 5px;
        }
        .group-btn{
            position: absolute;
            top: 100%;
            width: 40%;
            display: flex;
            padding: 15px;
            justify-content: space-between;
             border-top: 1px solid #e5e5e5;
            border-bottom: 1px solid #e5e5e5;
            margin-top: 20px;
            button{
                padding: 10px;
                
                background-color: #F27922;
                color: white;
            }
        }
    }
}
.info-detail{
    width:90%;
    margin: auto;
}
</style>