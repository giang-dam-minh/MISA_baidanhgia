<template>
    <div class="content-add-category">
        <div class="title f-s-20 f-w-b cl-b">
       Quản lý danh mục sản phẩm
        </div>
       <div class="category-code">Mã danh mục: <input v-model="Category.CategoryCode" /></div>
       <div class="category-name">Tên danh mục: <input v-model="Category.CategoryName" /></div>
       <div class="sub-category">Danh mục con: <input v-model="Category.SubCategory" /></div>
       <div class="btn-group">
            <button @click="addClick">Thêm mới</button>
            <button @click="updateClick">Cập nhật</button>
       </div>
    </div>
</template>
<script>
import PopupAdd from "@/components/PopupAdd.vue";
import CategoryAPI from "@/api/CategoryAPI.js";

export default {
    components:{
        PopupAdd
    },
    data(){
        return{
            lstHeader: [],
            isAdd: false,
        }
    },
    props:{
        Category:{
            type:Object,
            default:{
                CategoryID: "",
                CategoryCode : "",
                CategoryName : "",
                SubCategory : ""
            }
        }
    },
    methods:{
        addNew(){
            this.isAdd = true;
        },
        addClick(){
            var param = {
                CategoryCode: this.Category.CategoryCode,
                CategoryName: this.Category.CategoryName,
                SubCategory: this.Category.SubCategory
            };
            CategoryAPI.insert(param).then(res => {
                this.$emit("addClick");
            });
        },
        updateClick(){
            var param = {
                CategoryID: this.Category.CategoryID,
                CategoryCode: this.Category.CategoryCode,
                CategoryName: this.Category.CategoryName,
                SubCategory: this.Category.SubCategory
            };
            CategoryAPI.update1(param).then(res => {
                this.$emit("updateClick");
            });
        }
    }
}
</script>
<style lang="scss" scoped>
.content-add-category{
    margin: 20px;
    width: 100%;
    .title{
        margin: 10px;
    }
    .category-code{
        margin: 10px 20px;
        display: flex;
        justify-content: space-between;
    }
     .category-name{
        margin: 10px 20px;
        justify-content: space-between;
        display: flex;

    }
     .sub-category{
        margin: 10px 20px;
        justify-content: space-between;
        display: flex;

    }
    input{
        padding: 10px;
    }
    .btn-group{
        width: 100%;
        margin: 20px auto;
        button{
            padding: 10px 20px;
            margin:0px 30px;
        }
    }
}
</style>