<template>
  <ArticleForm title="New title" body="" author="" isPublished=""
      v-on:add-article="addArticle" />
</template>

<script>
import ArticleForm from '@/components/ArticleForm.vue'
import state from '../store'

export default {
  components: {
    ArticleForm
  },
  methods: {
    addArticle: function(article) {
      let newArticle = {
        id: this.$root.$data.articles.length + 1,
        ...article
      }
      this.$root.$data.articles.push(newArticle);
      console.log(article.title);
      console.log(state);
      // go to front page
      this.$router.push('/');
    }
  }
}
</script>
