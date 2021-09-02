<template>
	<div id="app">
		<the-menu :menuState="menuState" @toggleMenu="toggleMenu" />
		<div id="wrapper">
			<the-header :menuState="menuState" @toggleMenu="toggleMenu" />
			<employee-page/>
		</div>
		<employee-detail/>
		<base-tooltip />
		<base-dialog />
		<the-loading :loadingState="loadingState" />
	</div>
</template>

<script>
	// LIBRARY
	// COMPONENT
	import TheMenu from "./components/Layout/TheMenu.vue";
	import TheHeader from "./components/Layout/TheHeader.vue";
	import BaseTooltip from "./components/Base/BaseTooltip.vue";
	import BaseDialog from "./components/Base/BaseDialog.vue";
	import TheLoading from "./components/Layout/TheLoading.vue";

	import EmployeeDetail from "./components/views/employee/EmployeeDetail.vue";
	import EmployeePage from "./components/views/employee/EmployeePage.vue";

	export default {
		name: "App",
		components: {
			EmployeePage,
			EmployeeDetail,
			TheMenu,
			TheHeader,
			TheLoading,
			BaseTooltip,
			BaseDialog,
		},
		data() {
			return {
				menuState: true,
				loadingState: false,
				reloadTable: false,
			};
		},
		mounted() {
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
		},
	};
</script>
<style>
	@import url("./css/main.css");
</style>
