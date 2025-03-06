<template>
  <div class="home">
    <ArticleList msg="Welcome to Your Vue.js App"/>
  </div>
</template>


<script>

// @ is alias to src
import ArticleList from '@/components/ArticleList.vue'

export default {
  name: 'HomeItem',
  components: {
    ArticleList
  }
}
</script>
