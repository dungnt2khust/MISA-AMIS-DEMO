<template>
  <div id="app">
    <employee-menu :toggleMenu="toggleMenu"/>
    <div id="wrapper">
      <employee-header @toggleOnClick="toggleOnClick"/>
      <employee-content/>
    </div>
  </div>
</template>

<script>
// LIBRARY
// COMPONENT
import TheMenu from './components/Layout/TheMenu.vue';
import TheHeader from './components/Layout/TheHeader.vue';
import TheContent from './components/Layout/TheContent.vue';

export default {
  name: 'App',
  components: {
    EmployeeMenu: TheMenu,
    EmployeeHeader: TheHeader,
    EmployeeContent: TheContent
  }, 
  data() {
    return {
      toggleMenu: false
    }
  },
  mounted() {
    // this.setTooltipEvent();
  },
  methods: {
    /**
     * Toggle menu 
     * CreatedBy: NTDUNG (28/08/2021)
     */
    toggleOnClick() {
      this.toggleMenu = !this.toggleMenu;
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
