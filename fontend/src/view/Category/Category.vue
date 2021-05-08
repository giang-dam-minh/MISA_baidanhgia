<template>
    <div class="home">
        <div class="header">
            <div>
                <span class="title">Quản lý danh mục sản phẩm</span>
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
                @onRowClick="onRowClick"
            >
           <template v-slot:ImageCategory="{data}">
               <img height="100" width="100" v-if="data.ImageCategory" :src="'data:image/png;base64,' + data.ImageCategory" >
            </template>
            </cc-table>
        </div>
        <CategoryPopup
            v-if="open"
            v-model="open"
            @close="close"
            @saveClick="saveClick"
            :Category="Category"
            :formMode="formMode"
        ></CategoryPopup>
    </div>
</template>
<script>
import CategoryAPI from "@/api/CategoryAPI.js"
import CategoryPopup from "@/view/Category/CategoryPopup.vue"
import Base from "@/view/Base/Base.vue";
export default {
    extends: Base,
    components:{
        CategoryPopup,
    },
    data(){
        return{
            open: false,
            api: CategoryAPI,
            Category: {
                CategoryCode: "",
                CategoryName: "",
                ImageCategory: "",
            },
            formMode: 1,
            listHeader: [
                {
                    dataField: "CategoryCode",
                    caption: "Mã danh mục",
                    dataType: "text"
                },
                {
                    dataField: "CategoryName",
                    caption: "Tên danh mục",
                    dataType: "text"

                },
                {
                    dataField: "ImageCategory",
                    caption: "Hình ảnh danh mục",
                    dataType: "image"

                }
            ],
            dataSource: [],
        }
    },
    async created(){
       
       this.getData();
    },
    methods: {
        onRowClick(data){
            this.$router.push(`/category-detail/${data.CategoryID}`);
        },
        clickEdit(data){
            this.Category = data;
            this.formMode = 2;
            this.open = true;
        },
        addNewClick(){
            this.formMode = 1;
            this.Category = {};
            this.open = true;
        },
        saveClick(data){
            data["State"] = this.formMode;
            this.save(data);
        },
       clickDelete(data){
           this.deleteById(data.CategoryID);
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