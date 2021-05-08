<template>
  <div class="app">
    <navbar></navbar>
    <div class="body">
      <router-view></router-view>
    </div>
  </div>
</template>

<script>
import navbar from "./layout/navbar";
export default {
  name: 'App',
  components: {
    navbar
  }
}
</script>

<style lang="scss">
body{
  margin: 0px;
}
.app{
  padding: 0px;
  position: absolute;
  top: 0;
  left: 0;
  bottom: 0;
  right: 0;
  background-color: #f5f5f5;
  .body{
    padding: 0px;
    position: absolute;
    top: 60px;
    left: 0;
    bottom: 0;
    right: 0;
    background-color: #f5f5f5;
  }
}
</style>
