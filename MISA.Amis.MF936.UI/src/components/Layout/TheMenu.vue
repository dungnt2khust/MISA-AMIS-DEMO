<template lang="">
	<div id="menu" :class="{ 'menu--small': !menuState }">
		<div class="menu__home" :class="{ 'fx-center': !menuState }">
			<div v-show="menuState" class="menu__grid"></div>
			<div
				v-show="!menuState"
				@click="$emit('toggleMenu')"
				class="menu__toggle"
			>
				<div class="menu__toggle-icon"></div>
			</div>
			<div class="menu__logo" v-show="menuState"></div>
		</div>
		<div class="menu__list">
			<a
				v-for="(item, index) in menuList"
				href="#"
				class="menu__item"
				:class="{ 'fx-center': !menuState }"
				v-on="tooltipListeners(item['name'])"
				:key="index"
			>
				<div class="menu__icon-wrapper">
					<div
						class="menu__icon"
						:style="{
							'background-position': item.position,
							width: item.width,
							height: item.height,
						}"
					></div>
				</div>
				<span class="menu__label" v-show="menuState"> {{ item["name"] }} </span>
			</a>
		</div>
	</div>
</template>
<script>
	// LIBRARY
	import listeners from "../../Mixins/listeners.js";

	export default {
		name: "TheMenu",
		mixins: [listeners],
		props: {
			menuState: {
				type: Boolean,
				default: false,
			},
		},
		data() {
			return {
				menuList: [
					{
						name: "Tổng quan",
						position: "-33px -1630px",
						width: "18px",
						height: "20px",
					},
					{
						name: "Tiền mặt",
						position: "-78px -1631px",
						width: "14px",
						height: "18px",
					},
					{
						name: "Tiền gửi",
						position: "-121px -1633px",
						width: "16px",
						height: "18px",
					},
					{
						name: "Mua hàng",
						position: "-165px -1632px",
						width: "16px",
						height: "18px",
					},
					{
						name: "Bán hàng",
						position: "-206px -1631px",
						width: "20px",
						height: "18px",
					},
					{
						name: "Quản lý hoá đơn",
						position: "-254px -1632px",
						width: "14px",
						height: "17px",
					},
					{
						name: "Kho",
						position: "-294px -1632px",
						width: "18px",
						height: "17px",
					},
					{
						name: "Công cụ dụng cụ",
						position: "-339px -1633px",
						width: "17px",
						height: "17px",
					},
					{
						name: "Tài sản cố định",
						position: "-382px -1631px",
						width: "17px",
						height: "18px",
					},
					{
						name: "Thuế",
						position: "-427px -1634px",
						width: "16px",
						height: "16px",
					},
					{
						name: "Giá thành",
						position: "-471px -1633px",
						width: "17px",
						height: "17px",
					},
					{
						name: "Tổng hợp",
						position: "-514px -1633px",
						width: "15px",
						height: "16px",
					},
					{
						name: "Ngân sách",
						position: "-382px -1664px",
						width: "16px",
						height: "16px",
					},
					{
						name: "Báo cáo",
						position: "-552px -1636px",
						width: "14px",
						height: "13px",
					},
					{
						name: "Phân tích tài chính",
						position: "-207px -1667px",
						width: "17px",
						height: "14px",
					},
				],
			};
		},
	};
</script>
<style></style>
