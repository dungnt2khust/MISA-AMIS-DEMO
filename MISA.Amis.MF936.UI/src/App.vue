<template>
  <div id="app">
    <employee-menu 
      :menuState="menuState"
      @toggleMenu="toggleMenu"/>
    <div id="wrapper">
      <employee-header 
      :menuState="menuState"
      @toggleMenu="toggleMenu"/>
      <employee-content/>
    </div>
    <base-tooltip/>
    <base-form/>
  </div>
</template>

<script>
  // LIBRARY
  // COMPONENT
  import TheMenu from './components/Layout/TheMenu.vue'
  import TheHeader from './components/Layout/TheHeader.vue'
  import TheContent from './components/Layout/TheContent.vue'
  import BaseTooltip from './components/Base/BaseTooltip.vue'
  import BaseForm from './components/Base/BaseForm.vue'

  export default {
    name: 'App',
    components: {
      EmployeeMenu: TheMenu,
      EmployeeHeader: TheHeader,
      EmployeeContent: TheContent,
      BaseTooltip,
      BaseForm
    }, 
    data() {
      return {
        menuState: true
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
        this.menuState = !this.menuState;
      }
    }
  }
</script>
<style>
  @import url('./css/main.css');
</style>
