<template>
    <div class="cc-navbar">
        <div class="block-left">
            <div class="app-store">
                <div class="icon-chocolate2"></div>
            </div>
            <img class="logo m-r-12" src="@/assets/icon/sidebar/logo-2.png"/>
            <div class="f-logo pointer m-r-24">
                Quản lý Website
            </div>
            <div v-for="(item,index) in listHeader" :key="index">
                <div @click="changeRouter(item)" class="item-navbar m-r-16" :class='{"active": item.Active}'>
                    {{item.Name}}
                </div>
            </div>
        </div>
        <div class="block-right">
            <img class="logo m-r-24" src="@/assets/icon/sidebar/user.svg"/>
        </div>
    </div>
</template>
<script>
export default {
    data(){
        return{
            listHeader: [
                {
                    ID: 1,
                    Name: "Tổng quan",
                    Router: "",
                    Active: false
                },
                {
                    ID: 2,
                    Name: "Danh mục sản phẩm",
                    Router: "/category",
                    Active: false
                },
                {
                    ID: 3,
                    Name: "Danh mục sản phẩm con",
                    Router: "/category-",
                    Active: false
                },
                {
                    ID: 4,
                    Name: "Sản phẩm",
                    Router: "/product",
                    Active: false
                },
                {
                    ID: 5,
                    Name: "Giỏ hàng",
                    Router: "",
                    Active: false
                },
                {
                    ID: 6,
                    Name: "Giỏ hàng chi tiết",
                    Router: "",
                    Active: false
                }
            ]
        }
    },
    methods: {
        changeRouter(data){
            this.listHeader.map(item =>{
                item.ID == data.ID? item.Active=true: item.Active=false
            });
            this.$router.push(data.Router);
        }
    }
}
</script>
<style lang="scss" scoped>
.cc-navbar{
    position: relative;
    display: flex;
    align-items: center;
    top: 0px;
    left: 0px;
    right: 0px;
    height: 60px;
    box-shadow: 0 2px 4px rgba(0,0,0,.175);
    z-index: 10;
    .block-left{
        position: absolute;
        left: 0;
        display: flex;
        align-items: center;
        .app-store{
            display: flex;
            align-items: center;
            justify-content: center;
            width: 34px;
            height: 34px;
            border-radius: 50px;
            margin-left: 35px;
            margin-right: 12px;
            cursor: pointer;
            &:hover{
                background-color: #f5f5f5;
            }
        }
        .logo{
            width: 34px;
            height: 34px;
            cursor: pointer;
        }
    }
    .block-right{
        position: absolute;
        right: 0;
        display: flex;
        align-items: center;
        .logo{
            width: 34px;
            height: 34px;
            cursor: pointer;
        }
        .ico-notify{
            display: flex;
            align-items: center;
            justify-content: center;
            width: 34px;
            height: 34px;
            border-radius: 50px;
            cursor: pointer;
            &:hover{
                background-color: #f5f5f5;
            }
        }
    }
    .item-navbar{
        display: flex;
        align-items: center;
        padding: 0 24px;
        border-radius: 50px;
        height: 34px;
        &:hover{
            color: #fff;
            background-color: #5884fd;
        }
    }
    .active{
        color: #fff;
        background-color: #5884fd;
    }
}
</style>