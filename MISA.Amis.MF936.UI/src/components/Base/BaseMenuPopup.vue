<template lang="">
	<div
		class="menu-popup-container"
		:class="{ 'selectbox--show': menuPopupState, 'selectbox--up': isUp }"
		:style="setPositionOfMenuPopup"
	>
		<ul ref="menuPopup" class="selectbox__list">
			<li
				v-for="(item, index) in menuPopupData"
				class="selectbox__item"
				:key="index"
			>
				{{ item }}
			</li>
		</ul>
	</div>
</template>
<script>
	// LIBRARY
	import Mixin from "../../Mixins/Mixin.js"

	export default {
		name: "BaseMenuPopup",
		mixins: [Mixin],
		props: {
			menuPopupState: {
				type: Boolean,
				default: false,
			},
			menuPopupPosition: {
				type: Object,
				default: function() {
					return {};
				},
			},
		},
		data() {
			return {
				menuPopupData: ["Nhân bản", "Xoá", "Ngừng sử dụng"],
			};
		},
		computed: {
			/**
			 * Tính toàn vị trí của menu popup
			 * CreatedBy: NTDUNG (28/08/2021)
			 */
			setPositionOfMenuPopup() {
				// Tính toán vị trí của menu popup
				var top = this.isUp
					? this.menuPopupPosition["top"] + "px"
					: this.menuPopupPosition["bottom"] + "px";
				return { top: top, left: this.menuPopupPosition["right"] + "px" };
			},
			/**
			 * Kiểm tra là up hay down
			 * CreatedBy: NTDUNG (30/08/2021)
			 */
			isUp() {
				// Vị trí bottom của nút bấm
				var btnBottom = this.menuPopupPosition["bottom"];
				// Chiều cao của menu popup
				var menuPopupHeight = 90; 
				// Chiều cao khả dụng của cửa sổ trình duyệt
				var windowHeight = window.innerHeight;
				
				return btnBottom + menuPopupHeight + this.paginationHeight >= windowHeight;
			},
		}
	};
</script>
<style lang=""></style>
