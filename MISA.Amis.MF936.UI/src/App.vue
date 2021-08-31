<template>
  <div id="app">
    <the-loading
      :loadingState="loadingState"
    />
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
    <base-dialog/> 
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
  import BaseDialog from './components/Base/BaseDialog.vue'
  import TheLoading from './components/Layout/TheLoading.vue'

  export default {
    name: 'App',
    components: {
      EmployeeMenu: TheMenu,
      EmployeeHeader: TheHeader,
      EmployeeContent: TheContent,
      BaseTooltip,
      BaseForm,
      BaseDialog,
      TheLoading
    }, 
    data() {
      return {
        menuState: true,
        loadingState: false
      }
    },  
    mounted () {
      this.loadingState = true;
      setTimeout(() => {
        this.loadingState = false;
      }, 500);
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
