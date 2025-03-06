<template>
  <div id="addArticleForm">
      <h1>Форма добавления статей!!!</h1>
      <form>
        <div><input type="text" v-model="article.title" placeholder="Заголовок"></div>
        <div><input type="text" v-model="article.author" placeholder="Автор"></div>
        <div><textarea v-model="article.body" placeholder="Текст статьи"></textarea></div>
        <div><label><input type="checkbox" v-model="article.isPublicated" placeholder="Title">Опубликовано</label></div>
        <div><input type="submit" value="Add" v-on:click.prevent="$emit('add-article',article)" /></div>
      </form>
  </div>
</template>

<script>
import { ref, watchEffect } from "vue";

export default {
  name: 'ArticleForm',
  props: {
    title:String,
    body:String,
    author:String,
    isPublicated:Boolean
  },
  data(){
    return{
      article:{
        title: this.title,
        author: this.author,
        body: this.body,
        isPublicated: this.isPublicated
      }
    }
  },
  setup(){
      const name = ref('');
      watchEffect(() =>{
          console.log(this.isPublicated.value);
      })
      return {name};
  }
}
</script>

<style>
#addArticleForm {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
  margin-top: 60px;
}
</style>