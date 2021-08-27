<template lang="">
	<div id="menu">
		<a class="menu__home" href="">
			<div
				class="menu__grid"
				:style="{ 'background-position': icons['grid-light']['position'] }"
			></div>
			<img
				class="menu__logo"
				src="https://actappg1.misacdn.net/img/Logo_Module_TiengViet_White.66947422.svg"
				alter="Logo"
			/>
		</a>
		<div class="menu__list">
			<a
				v-for="(item, index) in menuList"
				href="#"
				class="menu__item"
				:key="index"
			>
				<div
					class="menu__icon"
					:style="{ 'background-position': item.position }"
				></div>
				<span class="menu__label"> {{ item["name"] }} </span>
			</a>
		</div>
	</div>
</template>
<script>
	export default {
		name: "TheMenu",
		mounted() {
			console.log(this.icons);
		},
		data() {
			return {
				menuList: [
					{ name: "Tổng quan", position: "-33px -1630px" },
					{ name: "Tiền mặt", position: "-78px -1631px" },
					{ name: "Tiền gửi", position: "-121px -1633px" },
					{ name: "Mua hàng", position: "-165px -1632px" },
					{ name: "Bán hàng", position: "-206px -1631px" },
					{ name: "Quản lý hoá đơn", position: "-254px -1632px" },
					{ name: "Kho", position: "-294px -1632px" },
					{ name: "Công cụ dụng cụ", position: "-294px -1631px" },
					{ name: "Tài sản cố định", position: "-382px -1631px" },
					{ name: "Thuế", position: "-427px -1634px" },
					{ name: "Giá thành", position: "-471px -1633px" },
					{ name: "Tổng hợp", position: "-514px -1633px" },
					{ name: "Ngân sách", position: "-552px -1636px" },
					{ name: "Báo cáo", position: "-592px -1631px" },
					{ name: "Phân tích tài chính", position: "-636px -1631px" },
				],
			};
		},
	};
</script>
<style></style>
