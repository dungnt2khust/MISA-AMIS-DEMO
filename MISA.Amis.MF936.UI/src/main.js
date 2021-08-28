import Vue from 'vue'
import App from './App.vue'

Vue.config.productionTip = false;

export const EventBus = new Vue();

Vue.mixin({
  data() {
    return {
      paginationHeight: 46,
      menuPopupTable: 98
    }
  },
  methods: {
    /**
     * Lắng nghe sự kiện hiển thị và ẩn input (hover event)
     * @param {string} message
     * CreatedBy: NTDUNG (28/08/2021)
     */
    tooltipListeners(message) {
      return Object.assign({}, this.$listener, {
          mouseenter: (event) => {
            setTimeout(() => {
              // Truyền nội dung và vị trí cho tooltip
              var tooltipStyle = {
                message: message,
                top: event.clientY,
                left: event.clientX
              };
              // Hiện tooltip
              EventBus.$emit('showTooltip', tooltipStyle);  
            }, 200); 
          },
          mouseleave: () => {
            // Ẩn tooltip
            EventBus.$emit('hideTooltip');
          }
      });
    }
  }
});

new Vue({
  render: h => h(App),
}).$mount('#app')

