<template>
  <div id="app">
    <employee-menu 
      :menuShow="menuShow"
      @toggleMenu="toggleMenu"/>
    <div id="wrapper">
      <employee-header 
      :menuShow="menuShow"
      @toggleMenu="toggleMenu"/>
      <employee-content/>
    </div>
    <base-tooltip/>
  </div>
</template>

<script>
// LIBRARY
// COMPONENT
import TheMenu from './components/Layout/TheMenu.vue';
import TheHeader from './components/Layout/TheHeader.vue';
import TheContent from './components/Layout/TheContent.vue';
import BaseTooltip from './components/Base/BaseTooltip.vue';

export default {
  name: 'App',
  components: {
    EmployeeMenu: TheMenu,
    EmployeeHeader: TheHeader,
    EmployeeContent: TheContent,
    BaseTooltip
  }, 
  data() {
    return {
      menuShow: true
    }
  },
  mounted() {
    // this.setTooltipEvent();
  },
  methods: {
    /**
     * Toggle menu 
     * CreatedBy: NTDUNG (28/08/2021)
     * ModifiedBy: NTDUNG (28/08/2021)
     */
    toggleMenu() {
      this.menuShow = !this.menuShow;
    },
    /**
     * Đặt sự kiện cho những phần có tooltip trong app
     * CreatedBy: NTDUNG (28/08/2021)
     */
    setTooltipEvent() {
      // Lắng nghe sự kiện chuột của những thành phần dùng tooltip
      var elementHaveTooltip = document.querySelectorAll('.have-tooltip');
      elementHaveTooltip.forEach((element) => {
        var tooltip = element.querySelector('.tooltip');
        element.addEventListener('mouseenter', (event) => {
          tooltip.style.display = 'block';
          tooltip.style.left = event.clientX + 'px';
          tooltip.style.top = event.clientY + 'px';
        });
        element.addEventListener('mouseleave', () => {
          tooltip.style.display = 'none';
        });
      });
    }
  }
}
</script>

<style>
  @import url('./css/main.css');
</style>
