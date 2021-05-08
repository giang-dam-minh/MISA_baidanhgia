<template>
    <div class="home">
        <div class="header">
            <div>
                <span class="title">Quản lý sản phẩm</span>
                <span><cc-input v-model="Product.Sale"></cc-input></span>
            </div>
            <div>
                <cc-button type="primary" @click="addNewClick">Thêm mới</cc-button>
            </div>
        </div>
        <div class="table">
            <cc-table
                :listHeader="listHeader"
                :dataSource="dataSource"
                @clickDelete="clickDelete"
                @clickEdit="clickEdit"
            >
            <template v-slot:Image="{data}">
               <img height="100" width="100" v-if="data.Image" :src="'data:image/png;base64,' + data.Image" >
            </template>
            <template v-slot:CategoryDetailID="{data}">
                {{getCategoryDetailById(data.CategoryDetailID)}}
            </template>
            </cc-table>
        </div>
        <ProductPopup
            v-if="open"
            @saveClick="saveClick"
            @close="close"
            :Product="Product"
            :formMode="formMode"
        ></ProductPopup>
    </div>
</template>
<script>
import ProductAPI from "@/api/ProductAPI.js";
import CategoryDetailAPI from "@/api/CategoryDetailAPI.js";
import ProductPopup from "@/view/Product/ProductPopup.vue";
import Base from "@/view/Base/Base.vue";
export default {
    extends: Base,
    components:{
        ProductPopup,
    },
    data(){
        return{
            open: false,
            api: ProductAPI,
            Product: {},
            formMode: 1,
            lstCategoryDetail: [],
            listHeader: [
                {
                    dataField: "ProductCode",
                    caption: "Mã sản phẩm",
                    dataType: "text"
                },
                {
                    dataField: "ProductName",
                    caption: "Tên danh mục con",
                    dataType: "text"
                },
                {
                    dataField: "Image",
                    caption: "Hình ảnh",
                    dataType: "text"
                },
                {
                    dataField: "Price",
                    caption: "Giá",
                    dataType: "text"
                },
                {
                    dataField: "Sale",
                    caption: "Tỷ lệ giảm giá",
                    dataType: "text"
                },
                {
                    dataField: "Description",
                    caption: "Mô tả",
                    dataType: "text"
                },
                {
                    dataField: "CategoryDetailID",
                    caption: "Danh mục",
                    dataType: "text"
                },

            ],
            dataSource: [],
        }
    },
    created(){
        var me = this;
       this.getData();
       CategoryDetailAPI.getAll().then(res => {
           me.lstCategoryDetail = res.data;
       })
    },
    methods: {
        getCategoryDetailById(id){
            if(this.lstCategoryDetail)
            {
                var name = "";
                this.lstCategoryDetail.filter(item => {
                    if(item.CategoryDetailID == id){
                        name += item.CategoryDetailCode + " - " + item.CategoryDetailName;
                    }
                })
                return name;
            }
        },
        clickEdit(data){
            this.Product = data;
            this.formMode = 2;
            this.open = true;
        },
        addNewClick(){
            this.formMode = 1;
            this.Product = {};
            this.open = true;
        },
        saveClick(data){
            data["State"] = this.formMode;
            debugger
            this.save(data);
        },
       clickDelete(data){
           var me = this;
           this.api.deleteById(data.CategoryDetailID).then(res => {
               me.getByPropertyValue
           });
       },
       close(){
           this.open = false;
       }
    },
    
}
</script>
<style lang="scss" scoped>
.home{
    height: 100%;
    .header{
        height: 40px;
        width: 100%;
        margin-bottom: 16px;
        display: flex;
        justify-content: space-between;
        align-items: center;
        .title{
            font-weight: 700;
            font-size: 20px;
        }
    }
    .table{
        height: calc(100% - 56px);
    }
}
.custom{
    font-style: italic;
    color: #0075FF;
    cursor: pointer;
}
</style>