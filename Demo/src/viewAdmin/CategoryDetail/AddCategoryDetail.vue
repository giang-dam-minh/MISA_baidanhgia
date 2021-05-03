<template>
    <div class="content-add-category">
        <div class="title f-s-20 f-w-b cl-b">
       Quản lý danh mục con
        </div>
       <div class="category-code">Mã danh mục con: <input v-model="CategoryDetail.CategoryDetailCode" /></div>
       <div class="category-name">
            Danh mục cha:
            <select v-model="CategoryDetail.CategoryID">
                <option :value="category.CategoryID" v-for="(category,index) in lstCategory" :key="index">{{category.CategoryName}}</option>
            </select>
        </div>
       <div class="sub-category">Tên danh mục con: <input v-model="CategoryDetail.CategoryDetailName" /></div>
       <div class="btn-group">
            <button @click="addClick">Thêm mới</button>
            <button @click="updateClick">Cập nhật</button>
       </div>
    </div>
</template>
<script>
import PopupAdd from "@/components/PopupAdd.vue";
import CategoryDetailAPI from "@/api/CategoryDetailAPI.js";
import CategoryAPI from "@/api/CategoryAPI.js";
export default {
    components:{
        PopupAdd
    },
    data(){
        return{
            lstHeader: [],
            isAdd: false,
            lstCategory: []
        }
    },
    props:{
        CategoryDetail:{
            type:Object,
            default:{
                CategoryDetailID: "1",
                CategoryDetailCode : "",
                CategoryDetailName : "",
                CategoryID : ""
            }
        }
    },
    created(){
        var me = this;
        CategoryAPI.getAll().then(res=>{
            me.lstCategory = res.data;
        }).catch(err =>{

        })
    },
    methods:{
        addNew(){
            this.isAdd = true;
        },
        addClick(){
            var param = {
                CategoryDetailCode: this.CategoryDetail.CategoryDetailCode,
                CategoryDetailName: this.CategoryDetail.CategoryDetailName,
                CategoryID: this.CategoryDetail.CategoryID
            };
            CategoryDetailAPI.insert(param).then(res => {
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