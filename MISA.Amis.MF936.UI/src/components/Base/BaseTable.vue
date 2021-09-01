<template lang="">	
	<table class="table">
		<thead>
			<tr>
				<th>
					<base-checkbox 
						:state="checkAll"
						v-model="checkAll"
					/>
				</th>
				<th v-for="(item, index) in tableStyle" :key="index">
					{{ item["name"] }}
				</th>
				<th>Chức năng</th>
			</tr>
		</thead>
		<tbody>
			<tr
				@dblclick="trOnDbClick($event, itemData[tableId])"
				v-for="(itemData, indexData) in tableData"
				:key="indexData"
			>
				<td>
					<base-checkbox />
				</td>
				<td
					v-for="(itemStyle, indexStyle) in tableStyle"
					:class="tdClass(itemStyle)"
					:key="indexStyle"
				>
					{{ tdValue(itemData, itemStyle) }}
					<base-checkbox
						:disable="true"
						v-if="itemStyle['type'] == 1"
						:state="itemData[itemStyle['field']]"
					/>
				</td>
				<td>
					<div
						class="table__function"
						:class="{ 'table--loading': tableLoading }"
					>
						<div class="table__update">
							Sửa
						</div>
						<div
							tabindex="1"
							@blur="contextMenuOnBlur($event)"
							@click="contextMenuOnClick($event, indexData)"
							class="context-menu"
						>
							<div class="context-menu__icon"></div>
						</div>
					</div>
				</td>
			</tr>
		</tbody>
		<base-context-menu
			:contextMenuState="contextMenuState"
			:contextMenuPosition="contextMenuPosition"
		/>
	</table>	
</template>
<script>
	// LIBRARY
	import Table from "../../Mixins/table.js"
	import methods from "../../Mixins/methods"

	// COMPONENTS	
	import BaseContextMenu from "./BaseContextMenu.vue"
	import BaseCheckbox from "./BaseCheckbox.vue"

	export default {
		name: "BaseTable",
		mixins: [Table, methods],
		components: {
			BaseContextMenu,
			BaseCheckbox,
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
			tableLoading: {
				type: Boolean,
				default: false,
			},
			tableId: {
				type: String,
				default: ""
			}
		},
		data() {
			return {
				contextMenuState: false,
				contextMenuIndex: -1,
				contextMenuPosition: {},
				checkAll: false
			};
		},	
		methods: {
			/**
			 * Tính class cho ô dữ liệu
			 * @param {object} style
			 * CreatedBy: NTDUNG (01/09/2021)
			 */
			tdClass(style) {
				var classes = {};
				// Khi table đang loading
				if (this.tableLoading)
					classes['table--loading'] = true;
				
				// Đặt vị trí text
				classes[this.getTdPos(style['pos'])] = true;
				
				return classes;
			},
			/**
			 * Xử lý sự kiện dblclick vào một bản ghi
			 * @param {event} event
			 * @param {string} id
			 * CreatedBy: NTDUNG (30/08/2021)
			 * ModifiedBy: NTDUNG (01/09/2021)
			 */
			trOnDbClick(event, id) {
				// Lấy ra element checkbox bị dblclick vào
				var checkbox = this.findParentByClass(event.target, 'checkbox');
				// Nếu dblclick vào td hoặc một checkbox disable thì hiển thì form
				if (event.target.tagName == 'TD' || checkbox.classList.contains('checkbox--disable'))		
					this.$bus.$emit("showForm", { mode: "update", id: id });
			},
			/**
			 * Xử lý sự kiện click vào context menu
			 * @param {event} event
			 * @param {number} index chỉ số của dòng dữ liệu
			 * CreatedBy: NTDUNG (28/08/2021)
			 */
			contextMenuOnClick(event, index) {
				// Thêm focus border khi click vào context menu
				var contextMenu = this.findParentByClass(event.target, 'context-menu');	
				contextMenu.classList.toggle('context-menu--selected');
	
				if (this.contextMenuState) {
					// Kiểm tra trùng với element khác không
					if (this.contextMenuIndex != index) {
						// Không thì show lên
						this.showContextMenu(event, index);
					} else {
						// Trùng element cũ thì ẩn đi
						this.hideContextMenu();
					}
				} else {
					// Chưa hiện thì hiện lên
					this.showContextMenu(event, index);
				}
			},
			/**
			 * Xử lý sự kiện blur khỏi nút context menu
			 * @param {event} event
			 * CreatedBy: NTDUNG (28/08/2021)
			 */
			contextMenuOnBlur(event) {
				this.contextMenuState = false;
				event.target.classList.remove("context-menu--selected");
			},
			/**
			 * Hiển thị context menu
			 * @param {event} event
			 * @param {number} index chỉ số của dòng
			 * CreatedBy: NTDUNG (28/08/2021)
			 */
			showContextMenu(event, index) {
				// Lấy ra phần tử context menu
				var element = this.findParentByClass(event.target, 'context-menu'); 

				// Gán toạ độ lấy được từ event
				var elementRect = element.getBoundingClientRect();
				this.contextMenuPosition = {
					top: elementRect.top,
					bottom: elementRect.bottom,
					right: elementRect.right,
					left: elementRect.left,
				};

				// Hiển thị context menu
				this.contextMenuIndex = index;
				this.contextMenuState = true;
			},
			/**
			 * Ẩn context menu
			 * CreatedBy: NTDUNG (28/08/2021)
			 */
			hideContextMenu() {
				this.contextMenuState = false;
			},
		},
	};
</script>
<style lang=""></style>
