<template>
    <div class="cc-input"
    >
        <DxTextBox :value="value"
            :mode="mode"
            :placeholder="placeholderInput"
            @value-changed="valueChanged"
        />
    </div>
</template>
<script>
import DxTextBox from 'devextreme-vue/text-box';
export default {
    components: {
        DxTextBox
    },
    props: {
        value: {
            Type: String,
            default: null
        },
        mode: {
            Type: String,
            default: "text"
        },
        placeholderInput: {
            Type: String,
            default: null
        },
        icon: {
            Type: String,
            default: null
        }
    },
    data() {
        return{
            
        }
    },
    watch: {

    },
    methods: {
        valueChanged(data){
            this.$emit("input", data.value);
        }
    }
}
</script>
<style lang="scss" scoped>
.cc-input{
    width: 100%;
    height: 36px;
    border-radius: 4px;
    input{
        width: calc(100% - 16px);
        height: 34px;
        border: none;
        outline: none;
        border-radius: 4px;
        padding: 0 8px;
    }
}
</style>