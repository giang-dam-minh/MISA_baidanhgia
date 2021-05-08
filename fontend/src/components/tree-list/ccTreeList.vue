<template>
  <DxTreeList
    id="tree-list"
    :data-source="dataSource"
    :show-borders="true"
    :column-auto-width="true"
    :word-wrap-enabled="true"
    :key-expr="keyField"
    :parent-id-expr="parentKey"
  >
    <DxColumn
        v-for="(item,index) in listHeader"
        :key="index"
        :data-field="item.dataField"
        :caption="item.caption"
        :width="item.width"
        :min-width="item.minWidth"
    />
    <DxColumn
        :width="60"
        cell-template="btn-delete"
    />
    <template #btn-delete>
        <div class="btn-icon-3 hover-block">
          <div class="icon-delete"></div>
        </div>
    </template>
  </DxTreeList>
</template>
<script>

import {
  DxTreeList,
  DxColumn
} from 'devextreme-vue/tree-list';

export default {
  components: {
    DxTreeList,
    DxColumn
  },
  props: {
      keyField: {
          type: String,
          default: null
      },
      parentKey: {
          type: String,
          default: null
      },
      listHeader: {
          type: Array,
          default: () => []
      },
      dataSource: {
          type: Array,
          default: () => []
      }
  },
  data() {
    return {
    };
  },
  computed: {
  },
  methods: {
  },
};
</script>
<style lang="scss">
.dx-treelist-borders > .dx-treelist-headers{
    border: none;
    color: #142142;
    font-size: 14px;
    font-weight: 500;
}
.dx-header-row > td{
    height: 48px;
    padding: 16px !important;
}
.dx-treelist .dx-column-lines > td{
    border: none;
}
.dx-treelist-rowsview .dx-row > td{
    height: 48px;
    padding: 0 16px;
    color: #142142;
    border-top: 1px solid #dddddd;
}
.dx-treelist-borders .dx-treelist-rowsview, .dx-treelist-headers + .dx-treelist-rowsview{
    border: none !important;
}
.dx-treelist{
    height: 100%;
    .dx-treelist-container{
        border-radius: 8px;
    }
}
.dx-treelist-content .dx-treelist-table .dx-row > td{
  vertical-align: middle;
}
.dx-treelist-rowsview .dx-row:hover{
  background-color: #f5f9ff;
  .hover-block{
    display: flex;
  }
}
.hover-block{
  display: none;
}
.dx-treelist-rowsview .dx-row:last-child{
  background-color: #ffffff !important;
}
</style>
