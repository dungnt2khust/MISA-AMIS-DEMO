<template lang="">
	<div
		class="context-menu-container"
		:class="{ 'selectbox--show': contextMenuState, 'selectbox--up': isUp }"
		:style="setPositionOfContextMenu"
	>
		<ul ref="contextMenu" class="selectbox__list">
			<li
				v-for="(item, index) in contextMenuData"
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
	import listeners from "../../Mixins/listeners.js"

	export default {
		name: "BaseContextMenu",
		mixins: [listeners],
		props: {
			contextMenuState: {
				type: Boolean,
				default: false,
			},
			contextMenuPosition: {
				type: Object,
				default: function() {
					return {};
				},
			},
		},
		data() {
			return {
				contextMenuData: ["Nhân bản", "Xoá", "Ngừng sử dụng"],
			};
		},
		computed: {
			/**
			 * Tính toàn vị trí của context menu
			 * CreatedBy: NTDUNG (28/08/2021)
			 */
			setPositionOfContextMenu() {
				// Tính toán vị trí của context menu
				var top = this.isUp
					? this.contextMenuPosition["top"] + "px"
					: this.contextMenuPosition["bottom"] + "px";
				return { top: top, left: this.contextMenuPosition["right"] + "px" };
			},
			/**
			 * Kiểm tra là up hay down
			 * CreatedBy: NTDUNG (30/08/2021)
			 */
			isUp() {
				// Vị trí bottom của nút bấm
				var btnBottom = this.contextMenuPosition["bottom"];
				// Chiều cao của context menu
				var contextMenuHeight = 90; 
				// Chiều cao khả dụng của cửa sổ trình duyệt
				var windowHeight = window.innerHeight;
				
				return btnBottom + contextMenuHeight + this.paginationHeight >= windowHeight;
			},
		}
	};
</script>
<style lang=""></style>
