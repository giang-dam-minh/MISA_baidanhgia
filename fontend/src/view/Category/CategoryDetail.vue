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
            >
            </cc-table>
        </div>
        <CategoryDetailPopup
            v-if="open"
            @saveClick="saveClick"
            @close="close"
            :CategoryDetail="CategoryDetail"
            :formMode="formMode"
        ></CategoryDetailPopup>
    </div>
</template>
<script>
import CategoryDetailAPI from "@/api/CategoryDetailAPI.js";
import CategoryDetailPopup from "@/view/Category/CategoryDetailPopup.vue";
import Base from "@/view/Base/Base.vue";
export default {
    extends: Base,
    components:{
        CategoryDetailPopup,
    },
    data(){
        return{
            open: false,
            api: CategoryDetailAPI,
            CategoryDetail: {},
            formMode: 1,
            listHeader: [
                {
                    dataField: "CategoryDetailCode",
                    caption: "Mã danh mục con",
                    dataType: "text"
                },
                {
                    dataField: "CategoryDetailName",
                    caption: "Tên danh mục con",
                    dataType: "text"
                },
            ],
            dataSource: [],
        }
    },
    created(){
       var MasterID = this.$route.params.code;
       this.CategoryDetail["CategoryID"] = MasterID;
       this.MasterID=MasterID;
       this.property = "CategoryID";
       this.getByPropertyValue('categoryid',MasterID);
    },
    methods: {
        clickEdit(data){
            this.CategoryDetail = data;
            this.formMode = 2;
            this.open = true;
        },
        addNewClick(){
            this.formMode = 1;
            this.CategoryDetail = {};
            this.open = true;
        },
        saveClick(data){
            data["State"] = this.formMode;
            data['CategoryID'] = parseInt(this.CategoryDetail["CategoryID"]);
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