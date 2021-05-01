<template>
  <div>
    <input type="file" accept="image/*" @change="onChange" />
    <div id="preview">
      <img v-if="item.imageUrl" :src="item.imageUrl" />
    </div>
    <div><button @click="add">import</button></div>
  </div>
</template>
<script>
import ProductsAPI from "@/api/ProductsAPI.js";
export default {
  name: "imageUpload",
  data() {
    return {
      item: {
        //...
        image: null,
        imageUrl: null,
      },
      url: ""
    };
  },
  methods: {
    onChange(e) {
      const file = e.target.files[0];
      this.image = file;
      this.item.imageUrl = URL.createObjectURL(file);
    },
    toDataUrl(url, callback) {
      var xhr = new XMLHttpRequest();
      xhr.onload = function () {
        var reader = new FileReader();
        reader.onloadend = function () {
          callback(reader.result);
        };
        reader.readAsDataURL(xhr.response);
      };
      xhr.open("GET", url);
      xhr.responseType = "blob";
      xhr.send();
    },
  },
};
</script>
<style lang="scss" scoped>
</style>