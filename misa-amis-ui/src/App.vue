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
  methods: {
    toggleOnClick() {
      this.toggleMenu = !this.toggleMenu;
    }
  }
}
</script>

<style>
  @import url('./css/main.css');
</style>
