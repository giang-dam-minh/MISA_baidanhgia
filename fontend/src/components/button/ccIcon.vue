<template>
    <div>
        <button
            :class="['btn-common','btn-' + type]"
            @click="handleClick"
        >
            <div :class="icon"></div>
        </button>
    </div>
</template>
<script>
export default {
    name: 'ccButton',
    props: {
        type: {
            Type: String,
            default: "primary"
        },
        icon: {
            Type: String,
            default: "add-white"
        }
    },
    methods: {
        handleClick(){
            this.$emit("handleClick");
        }
    }
}
</script>
<style lang="scss" scoped>
@import '@/styles/var-color.scss';
.btn-common{
    height: 36px;
    padding: 0 16px;
    display: flex;
    align-items: center;
    justify-content: center; 
    border-radius: 4px;
    outline: none;
    min-width: 80px;
    cursor: pointer;
}
.btn-primary{
    color: #ffffff;
    background-color: $primary;
    border: none;
    &:hover{
        background-color: $primary-hover;
    }
    &:active{
        background-color: $primary-active;
    }
}
</style>
