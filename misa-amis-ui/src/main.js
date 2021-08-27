import Vue from 'vue'
import App from './App.vue'

Vue.config.productionTip = false

Vue.mixin({
  data(){
    return {
      icons: {
        'toggle-black': {
          position: '-847px -35px',
          width: '16px',
          height: '14px'
        },
        'toggle-light': {
          position: '-316px -37px',
          width: '16px',
          height: '14px'
        },
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
