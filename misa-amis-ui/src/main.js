import Vue from 'vue'
import App from './App.vue'

Vue.config.productionTip = false

Vue.mixin({
  data(){
    return {
      icons: {
        'grid-normal': {
          position: '-1157px -32px'
        },
        'grid-light': {
          position: '-428px -92px'
        },
        'Logo': {
          position: '-1746px -881px'
        }
      }
    }
  }
})

new Vue({
  render: h => h(App),
}).$mount('#app')
