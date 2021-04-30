<template>
    <div>
        <div class="btnAdd"> <button @click="addNew">Them moi</button></div>
        <table>
            <tr>
                <th>Mã sản phẩm</th>
                <th>Tên sản phẩm</th>
                <th>Hình ảnh</th>
                <th>Giá</th>
                <th>Tỷ lệ giảm giá</th>
                <th>Mô tả</th>
                <th>Mã danh mục</th>
            </tr>
            <tr>
                <td>SP001</td>
                <td>SP001</td>
                <td><img height="100" width="80" src="https://imua.com.vn//images/Product/Album/Son-Sophia-Ampoule-Matte-Lipstick-2126.jpg"></td>
                <td>SP001</td>
                <td>SP001</td>
                <td>SP001</td>
                <td>SP001</td>
            </tr>
        </table>
        <PopupAdd
            v-if="isAdd"
            v-model="isAdd"
        ></PopupAdd>
    </div>
</template>
<script>
import PopupAdd from "@/components/PopupAdd.vue";
export default {
    components:{
        PopupAdd
    },
    data(){
        return{
            lstHeader: [],
            isAdd: false
        }
    },
    methods:{
        addNew(){
            this.isAdd = true;
        }
    }
}
</script>
<style lang="scss" scoped>
table{
    margin-top: 20px;
    border-collapse: collapse;
    width: 100%;
    th, td{
        padding: 10px;
        text-align: left;
        border-bottom: 1px solid black;

    }
    tr{
        border-bottom: 1px solid black;
    }
}
.btnAdd{
    margin-top: 10px;
    button{
        padding: 10px;
    }
}
</style>