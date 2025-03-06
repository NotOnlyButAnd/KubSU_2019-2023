import Vue from 'vue'
import VueRouter from 'vue-router'
import Home from '../views/Home.vue'
import NewArticle from '../views/NewArticle.vue'
import Article from '../components/Article.vue'
import state from '../store'

Vue.use(VueRouter)

const routes = [
  {
    path: '/',
    name: 'Home',
    component: Home
  },
  {
    path: '/about',
    name: 'About',
    component: () => import(/* webpackChunkName: "about" */ '../views/About.vue')
  },
  { 
    path: '/article/:id',
    component: Article,
    props: (route) => state.articles.find((x) => x.id == route.params.id)
  },
  {
    path: '/new',
    name: 'Add new article',
    component: NewArticle
  },
]

const router = new VueRouter({
  mode: 'history',
  base: process.env.BASE_URL,
  routes
})

export default router
