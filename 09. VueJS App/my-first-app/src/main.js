import Vue from 'vue'
import App from './App.vue'
import router from './router'
import state from './store'
import CustomInput from './components/CustomInput.vue'

Vue.config.productionTip = false

Vue.component('CustomInput', CustomInput);

new Vue({
  router,
  data: state,
  render: h => h(App),
}).$mount('#app')
