import Vue from 'vue'
import App from './App.vue'
import drag from 'v-drag'

Vue.config.productionTip = false;

// V-DRAG
Vue.use(drag);

// EVENT BUS
const EventBus = new Vue();
Object.defineProperties(Vue.prototype, {
  $bus: {
    get: function() {
      return EventBus;
    }
  }
});

new Vue({
  render: h => h(App),
}).$mount('#app');

