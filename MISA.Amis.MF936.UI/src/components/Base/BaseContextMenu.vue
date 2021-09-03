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
import employeeAPI from '../../js/components/employeeAPI.js';

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
				// Bỏ s ở controller
				var id = this.recordInfo.data[this.controller.slice(0, -1) + "Id"];
				var code = this.recordInfo.data[this.controller.slice(0, -1) + "Code"];
				var entityAPI = new baseAPI(this.controller);

				switch (this.contextMenuData[index]) {
					case "Nhân bản":
						this.callDialog('warn', `Bạn có chắc muốn nhân bản <b>${code}</b> không ?`)
						.then(answer => {
							if (answer == "YES") {
								var dataClone = this.recordInfo.data;
								delete dataClone[this.controller.slice(0, -1) + "Id"];
								this.$bus.$emit("showLoading");
								// Lấy mã mới
								employeeAPI.getNewEmployeeCode()
									.then((res) => {
										this.$set(dataClone, this.controller.slice(0, -1) + "Code", res.data.Data);	
										// Tạo mới
										employeeAPI.post(dataClone)
											.then(() => {
												// Load lại dữ liệu
												this.$bus.$emit("reloadData");
											})
											.catch(res => {
												// Báo lỗi
												this.callDialog('error', res.response.data.Msg);
											});
									})
									.catch(res => {
										// Báo lỗi
										this.callDialog('error', res.response.data.Msg);
									});		
							}
						});
						break;
					case "Xoá":
						this.callDialog(
							"warn",
							`Bạn có chắc muốn xoá <b>${code}</b> không ?`
						).then((answer) => {
							if (answer == "YES") {
								this.$bus.$emit("showLoading");
								entityAPI
									.delete(id)
									.then((res) => {
										console.log(res);
										this.$bus.$emit("reloadData");
									})
									.catch((res) => {
										this.callDialog("error", res.response.data.userMsg);
									});
							}	
						});
						break;
					case "Ngừng sử dụng":
						this.callDialog('error', 'Chức năng đang được hoàn thiện');
						break;
				}

				this.$emit("input", false);
			},
		},
	};
</script>
<style lang=""></style>
