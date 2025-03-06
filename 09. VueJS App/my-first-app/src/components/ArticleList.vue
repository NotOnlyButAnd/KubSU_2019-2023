<template>
  <div id="articleList">
        <h1> {{ msg }} </h1> 

        <!-- Добавление статей - кнопка и переход на новую страницу -->
        <button name="add_article">
            Добавить статью
        </button> 

        <ul v-if="this.$root.$data.articles.length">
            <Article
                v-for="article in articles"
                v-bind:key="article.id"
                v-bind:id="article.id"
                v-bind:title="article.title"
                v-bind:body="article.body"
                v-bind:isPublicated="article.isPublicated"
                v-bind:author="article.author"
            >
            </Article>
        </ul>
        <p v-else>
            No articles in list
        </p>
        <ArticleForm title="New title" body="" author="" isPublicated=""
        v-on:add-article="addArticle" />
  </div>
</template>

<script>
import Article from './Article.vue'
import ArticleForm from './ArticleForm.vue'
//import Articles from './Articles.json'

// const routes = [
//     { path: '/Articles.json', component: Articles}
// ]

// const router = new VueRouter({routes})

export default {
  name: 'ArticleList',
  props: {
    msg: String
  },
  components:{
    Article,
    ArticleForm
  },
  methods:{
      addArticle: function(article){
          let newArticle = {
              id: this.articles.length+1,
              ...article
          }
          this.articles.push(newArticle);
          console.log(article.title);
      }
  },
  data() {
      return{
          articles: []
      }
  },
  beforeMount: function(){
        fetch('/Articles.json')
        .then(response => response.json())
        .then(articles => this.articles = articles);
        console.log("Fetch data");
      }
}
</script>

<style>
#articleList {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
  margin-top: 40px;
}
</style>