<template lang="">
	<div
		class="menu-popup-container"
		:class="{ 'selectbox--show': menuPopupState }"
		:style="{ top: menuPopupTop + 8 +  'px', left: menuPopupLeft + 8 + 'px'}"
	>
		<ul class="selectbox__list">
			<li class="selectbox__item">Nhân bản</li>
			<li class="selectbox__item">Xoá</li>
			<li class="selectbox__item">Ngừng sử dụng</li>
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
		},
		watch: {
			menuPopupLeft: function(newValue){
				console.log('change position: ', newValue);
			},
			menuPopupTop: function(newValue){
				console.log('change position: ', newValue);
			},
			menuPopupState: function(newValue) {
				if (newValue)
					console.log('show')
				else 
					console.log('hide')
			}
		}
	};
</script>
<style lang=""></style>
