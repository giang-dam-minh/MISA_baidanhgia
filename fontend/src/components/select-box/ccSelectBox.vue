<template>
    <div class="cc-select-box"
    >
        <DxSelectBox
            :data-source="dataSource"
            :value="value"
            :placeholder="placeholderInput"
            :display-expr="displayField"
            :value-expr="valueField"
            @selectionChanged="changeSelect"
          />
    </div>
</template>
<script>
import DxSelectBox from 'devextreme-vue/select-box';
export default {
    components: {
        DxSelectBox
    },
    props: {
        value: {
            Type: String,
            default: null
        },
        displayField: {
            Type: String,
            default: null
        },
        valueField: {
            Type: String,
            default: null
        },
        placeholderInput: {
            Type: String,
            default: null
        },
        dataSource: {
            Type: Array,
            default: () => []
        }
    },
    data() {
        return{
            
        }
    },
    watch: {

    },
    methods: {
        changeSelect(data){
            this.$emit("input", data.value[valueField]);
            this.$emit("selected", data.value);
        }
    }
}
</script>
<style lang="scss">
.cc-select-box{
    width: 100%;
}
</style>