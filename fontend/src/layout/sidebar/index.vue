<template>
    <div class="cc-sidebar">
        <div v-if="type == 2">
            <DxTreeView
                ref="treeViewOrg"
                :data-source="dataSource"
                :select-by-click="true"
                data-structure="plain"
                key-expr="OrganizationUnitID"
                parent-id-expr="ParentID"
                selection-mode="single"
                display-expr="OrganizationUnitName"
                @item-click="selectItem"
            />
        </div>
    </div>
</template>
<script>
import DxTreeView from 'devextreme-vue/tree-view';
export default {
    components:{
        DxTreeView
    },
    props: {
        type: {
            Type: Number,
            default: 2
        }
    },
    data(){
        return{
            value: [],
            dataSource: [
                {
                    OrganizationUnitID: 1,
                    OrganizationUnitName: "ĐHQG Hà Nội",
                    ParentID: 0
                },
                {
                    OrganizationUnitID: 2,
                    OrganizationUnitName: "ĐHQG Hà Nội",
                    ParentID: 1
                },
                {
                    OrganizationUnitID: 3,
                    OrganizationUnitName: "ĐHQG Hà Nội",
                    ParentID: 1
                },
                {
                    OrganizationUnitID: 4,
                    OrganizationUnitName: "ĐHQG Hà Nội",
                    ParentID: 2
                }
            ],
        }
    },
    methods: {
        selectItem(e){

        }
    },
    created(){
       
    }
}
</script>
<style lang="scss">
.cc-sidebar{
    position: absolute;
    top: 0px;
    left: 0px;
    bottom: 0px;
    width: 200px;
    border-right: 1px solid #DDDDDD;
    padding: 12px 16px;
    background-color: #fff;
    .dx-treeview-item{
        display: flex;
        vertical-align: middle;
        height: 34px;
        padding: 5px 8px;
        border-radius: 4px;
        margin-bottom: 2px;
    }
    .dx-treeview-item-without-checkbox.dx-state-selected > .dx-treeview-item{
        color: #524aff !important;
        background-color: #d7e2ff !important;
        font-weight: 500;
    }
    .dx-treeview-item-without-checkbox.dx-state-focused > .dx-treeview-item{
        color: #524aff ;
        background-color: #d7e2ff ;
    }
    .dx-treeview-item.dx-state-hover{
        color: #212121 ;
        background-color: #d7e2ff ;
    }
}
</style>