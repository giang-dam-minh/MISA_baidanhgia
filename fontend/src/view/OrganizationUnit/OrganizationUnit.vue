<template>
    <div class="body-organization-unit">
        <sidebar></sidebar>
        <div class="body-content">
            <div class="header flex">
                <div class="flex">
                    <div class="tilte">Đơn vị hiện tại</div>
                </div>
                <div>
                    <cc-button type="primary">Upload File</cc-button>
                </div>
            </div>
            <div class="content">
                <div v-for="(item,index) in listFolder" :key="index" class="item">
                    <div class="item-folder">
                        <div>

                        </div>
                        <div class="flex justify-center m-b-16">
                            <img class="img-folder" src="@/assets/image/icon-file.png"/>
                        </div>
                        <div class="flex justify-center">
                            {{item.FileName}}
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</template>
<script>
import sidebar from "../../layout/sidebar";
export default {
    components: {
        sidebar
    },
    data(){
        return{
            listFolder: [
                {
                    FileID: 1,
                    FileName: "Thư mục 1"
                },
                {
                    FileID: 1,
                    FileName: "Thư mục 2"
                },
                {
                    FileID: 1,
                    FileName: "Thư mục 3"
                },
                {
                    FileID: 1,
                    FileName: "Thư mục 4"
                },
                {
                    FileID: 1,
                    FileName: "Thư mục 5"
                },
                {
                    FileID: 1,
                    FileName: "Thư mục 6"
                },
                {
                    FileID: 1,
                    FileName: "Thư mục 7"
                },
                {
                    FileID: 1,
                    FileName: "Thư mục 8"
                }
            ]
        }
    }
}
</script>
<style lang="scss" scoped>
.body-organization-unit{
    width: 100%;
    height: 100%;
    .body-content{
        position: absolute;
        top: 0;
        right: 0;
        bottom: 0;
        left: 233px;
        padding: 0 24px 24px 24px;
        .header{
            display: flex;
            align-items: center;
            
            padding: 12px 24px;
            justify-content: space-between;
            .tilte{
                font-weight: 500;
                font-size: 18px;
            }
        }
        .content{
            display: flex;
            flex-wrap: wrap;
            .item{
                .item-folder{
                    padding: 16px;
                    width: 150px;
                    height: auto;
                    background-color: #ffffff;
                    margin: 0 24px 24px 0;
                    border-radius: 8px;
                    .img-folder{
                        width: 100px;
                        height: 80px;
                    }
                }
            }
        }
    }
}
</style>