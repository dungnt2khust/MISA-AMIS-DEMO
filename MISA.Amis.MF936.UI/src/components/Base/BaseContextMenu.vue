<template lang="">
	<div
		class="context-menu-container"
		:class="{ 'selectbox--show': contextMenuState, 'selectbox--up': isUp }"
		:style="setPositionOfContextMenu"
	>
		<ul ref="contextMenu" class="selectbox__list">
			<li
				v-for="(item, index) in contextMenuData"
				@click="choose(index)"
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
	import listeners from "../../Mixins/listeners.js";
	import baseAPI from "../../js/base/baseAPI.js";

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
			recordInfo: {
				type: Object,
				default: function() {
					return {};
				},
			},
			controller: {
				type: String,
				default: "",
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

				return (
					btnBottom + contextMenuHeight + this.paginationHeight >= windowHeight
				);
			},
		},
		methods: {
			/**
			 * Xử lý khi chọn chức năng
			 * @param {Number} index
			 * CreatedBy: NTDUNG (02/09/2021)
			 */
			choose(index) {
				var entityAPI = new baseAPI(this.controller);

				switch (this.contextMenuData[index]) {
					case "Nhân bản":
						console.log("Nhân bản", this.recordInfo["Id"]);
						break;
					case "Xoá":
						this.callDialog(
							"warn",
							`Bạn có chắc muốn xoá <b>${this.recordInfo["Name"]} - ${this.recordInfo["Code"]}</b> không ?`
						).then((answer) => {
							if (answer == 'YES')
								entityAPI
									.delete(this.recordInfo["Id"])
									.then((res) => {
										console.log(res);
										this.$bus.$emit("reloadData");
									})
									.catch((res) => {
										console.log(res);
									});
						});
						break;
					case "Ngừng sử dụng":
						console.log("Ngừng sử dụng", this.recordInfo["Id"]);
						break;
				}

				this.$emit("input", false);
			},
		},
	};
</script>
<style lang=""></style>
