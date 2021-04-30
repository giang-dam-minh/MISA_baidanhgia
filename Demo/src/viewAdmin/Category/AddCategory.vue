<template>
    <div class="content-add-category">
        <div class="title f-s-20 f-w-b cl-b">
       Them moi danh muc san pham
        </div>
       <div class="category-code">Ma danh muc: <input v-model="Category.CategoryID" /></div>
       <div class="category-name">Ten danh muc: <input v-model="Category.CategoryName" /></div>
       <div class="sub-category">Danh muc con: <input v-model="Category.SubCategory" /></div>
       <div class="btn-group">
            <button @click="addClick">Them</button>
            <button >Huy bo</button>
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
            Category :{
                CategoryID : "",
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
                CategoryID: this.Category.CategoryID,
                CategoryName: this.Category.CategoryName,
                SubCategory: this.Category.SubCategory
            };
            CategoryAPI.insert(param).then(res => {
                this.$emit("addClick");
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
    .btn-group{
        width: 100%;
        margin: 20px auto;
        button{
            padding: 10px 20px;
            
        }
    }
}
</style>