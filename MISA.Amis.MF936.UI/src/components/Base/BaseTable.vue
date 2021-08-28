<template lang="">
	<div class="table-wrapper">
		<!-- TABLE CONTROL -->
		<div class="table__control">
			<div class="table__search">
				<input
					type="text"
					class="table__search-input"
					placeholder="Tìm theo mã, tên nhân viên"
				/>
			</div>
			<div v-on="tooltipListeners('Tải lại dữ liệu')" class="table__reload">
				<div class="table__reload-icon"></div>
			</div>
			<div v-on="tooltipListeners('Thêm mới từ file Excel')" class="table__import">
				<div class="table__import-icon"></div>
			</div>
		</div>
		<!-- TABLE -->
		<table class="table">
			<!-- TABLE HEAD -->
			<thead class="table__header">
				<tr class="table__row">
					<td class="table__data">
						<input type="checkbox" name="" id="" class="table__checkbox" />
					</td>
					<td
						v-for="(item, index) in tableStyle"
						class="table__data"
						:key="index"
					>
						{{ item["name"] }}
					</td>
					<td class="table__data">Chức năng</td>
				</tr>
			</thead>
			<!-- TABLE BODY -->
			<tbody class="table__body">
				<tr v-for="(item, index) in tableData" class="table__row" :key="index">
					<td class="table__data table__data--checkbox">
						<input type="checkbox" name="" id="" class="table__checkbox" />
					</td>
					<td v-for="(itm, idx) in tableStyle" class="table__data" :key="idx">
						{{ item[itm["field"]] }}
					</td>
					<td class="table__data">
						<div class="table__function">
							<div class="table__update">
								Sửa
							</div>
							<div
								tabindex="1"
								@blur="menuPopupOnBlur($event)"
								@click="menuPopupOnClick($event, index)"
								class="menu-popup"
							>
								<div class="menu-popup__icon"></div>
							</div>
						</div>
					</td>
				</tr>
			</tbody>
			<base-menu-popup
				:menuPopupState="menuPopupState"
				:menuPopupTop="menuPopupTop"
				:menuPopupLeft="menuPopupLeft"
				:menuPopupType="menuPopupType"
			/>
		</table>
		<base-pagination />
	</div>
</template>
<script>
	// COMPONENTS
	import BasePagination from "./BasePagination.vue";
	import BaseMenuPopup from "./BaseMenuPopup.vue";
	export default {
		name: "BaseTable",
		components: {
			BasePagination,
			BaseMenuPopup,
		},
		props: {
			tableStyle: {
				type: Array,
				default: function() {
					return [];
				},
			},
			tableData: {
				type: Array,
				default: function() {
					return [];
				},
			},
		},
		data() {
			return {
				menuPopupState: false,
				menuPopupLeft: 0,
				menuPopupTop: 0,
				menuPopupIndex: -1,
				menuPopupType: "",
			};
		},
		methods: {
			/**
			 * Xử lý sự kiện click vào menu popup
			 * @param {event} event
			 * @param {number} index chỉ số của dòng dữ liệU
			 * CreatedBy: NTDUNG (28/08/2021)
			 */
			menuPopupOnClick(event, index) {
				// Thêm focus border khi click vào menu popup
				if (event.target.classList.contains("menu-popup"))
					event.target.classList.toggle("menu-popup--selected");
				else
					event.target.parentElement.classList.toggle("menu-popup--selected");

				/**
				 * 1. Nếu đang hiển thị thì kiểm tra có trùng với nút menu cũ không
				 * 1.1. Nếu không trùng thì hiển thị ở một vị trí mới
				 * 1.2. Nếu trùng với nút menu cũ thì ẩn menu popup đi
				 * 2. Chưa hiển thì thì chỉ việc hiển thị menu popup lên
				 */

				if (this.menuPopupState) {
					if (this.menuPopupIndex != index) {
						this.showMenuPopup(event.clientX, event.clientY, index);
					} else {
						this.hideMenuPopup();
					}
				} else {
					this.showMenuPopup(event.clientX, event.clientY, index);
				}
			},
			/**
			 * Xử lý sự kiện blur khỏi nút menu popup
			 * @param {event} event
			 * CreatedBy: NTDUNG (28/08/2021)
			 */
			menuPopupOnBlur(event) {
				this.menuPopupState = false;
				event.target.classList.remove('menu-popup--selected');
			},
			/**
			 * Hiển thị menu popup
			 * @param {number} clientX
			 * @param {number} clientY
			 * @param {number} index chỉ số của dòng
			 * CreatedBy: NTDUNG (28/08/2021)
			 */
			showMenuPopup(clientX, clientY, index) {
				// Kiểm tra vị trí chuột để show loại menu popup đúng (DOWN/ UP)
				if (
					clientY + this.paginationHeight + this.menuPopupTable <=
					window.innerHeight
				) {
					this.menuPopupType = "down";
				} else {
					this.menuPopupType = "up";
				}

				// Hiển thị menu popup
				this.menuPopupIndex = index;
				this.menuPopupState = true;
				this.menuPopupLeft = clientX;
				this.menuPopupTop = clientY;
			},
			/**
			 * Ẩn menu popup
			 * CreatedBy: NTDUNG (28/08/2021)
			 */
			hideMenuPopup() {
				this.menuPopupState = false;
			},
		},
	};
</script>
<style lang=""></style>
