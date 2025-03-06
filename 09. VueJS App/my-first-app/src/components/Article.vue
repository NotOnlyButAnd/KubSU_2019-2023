<template>
  <div class="article" v-bind:class="{nonPublicated: !isPublicated}">
    <h1 v-if="id">
      ID: {{ id }}        
    </h1>
    <h3 v-if="body">{{ title }}</h3>
    <h3 v-else v-bind:class="classObject">
      <router-link :to="articleUrl">{{ title }}</router-link>
    </h3>
    <p v-if="author" v-bind:style="{'font-weight': isPublicatedFont}">
      {{ upperName }}
      <!-- {{isPublicatedFont()}} -->
    </p>

  </div>
</template>

<script>

export default {
  name: 'ArticleItem',
  props: {
    msg: String,
    title: String,
    body: String,
    id: Number,
    isPublicated: Boolean,
    author: String,
  },
  computed:{
    articleUrl: function() {
      return '/article/' + this.id;
    },
    isPublicatedFont(){
      if (this.isPublicated){
        return 800;
      }
      else{
        return 100;
      } 
    },
    upperName(){
      return this.author.toUpperCase();
    }
  }
}
</script>

<style scoped>
.article{
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
  margin-top: 30px;
}
h1{
    color: #2c503a;
    font-size: 1em;
}
.nonPublicated{
  background-color: #995252;
}
</style>