<template lang="">
	<div
		class="menu-popup-container"
		:class="{ 'selectbox--show': menuPopupState, 'selectbox--up': menuPopupType == 'up' }"
		:style="setPositionOfMenuPopup"
	>
		<ul class="selectbox__list">
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
	export default {
		name: "BaseMenuPopup",
		props: {
			menuPopupState: {
				type: Boolean,
				default: false,
			},
			menuPopupTop: {
				type: Number,
				default: 0,
			},
			menuPopupLeft: {
				type: Number,
				default: 0,
			},
			menuPopupType: {
				type: String,
				default: ''
			}
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
				// Thêm khoảng cách của position để cách menu popup một khoảng vừa đủ
				var distance = this.menuPopupType == 'up' ? -8 : 8;
				return { top: this.menuPopupTop + distance + 'px', left: this.menuPopupLeft + 8 + 'px' };
			}
		},
		watch: {
			menuPopupType: function(value) {
				console.log(value);
			}	
		},
	};
</script>
<style lang=""></style>
