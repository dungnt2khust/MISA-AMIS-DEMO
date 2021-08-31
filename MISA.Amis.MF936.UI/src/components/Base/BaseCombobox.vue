<template lang="">
	<div
		class="combobox"
		:class="{
			'combobox--up': comboboxType == 'up',
			'combobox--show': comboboxState,
		}"
	>
		<span v-if="label != ''" class="label">
			{{ label }} <span v-if="required" class="text-red">*</span>
		</span>
		<div class="combobox__main">
			<div class="combobox__value">
				<input type="text" class="combobox__input" :value="comboboxValue" />
			</div>
			<div @click="comboboxState = !comboboxState" class="combobox__button">
				<div class="combobox__button-icon"></div>
			</div>
			<ul class="combobox__list">
				<li
					v-for="(item, index) in comboboxData"
					class="combobox__item"
					:class="{ 'combobox__item--selected': index == currIdx }"
					@click="comboboxItemOnClick(index)"
					:key="index"
				>
					{{ item[field + "Name"] }}
				</li>
			</ul>
		</div>
	</div>
</template>
<script>
	export default {
		name: "BaseComboboxBox",
		props: {
			comboboxType: {
				type: String,
				default: "down",
			},
			label: {
				type: String,
				default: "",
			},
			required: {
				type: Boolean,
				default: false,
			},
			comboboxData: {
				type: Array,
				default: function() {
					return [];
				},
			},
			field: {
				type: String,
				default: "",
			},
			value: {
				type: String,
				default: "",
			},
			default: {
				type: Number,
				default: -1
			}
		},
		data() {
			return {
				currIdx: -1,
				comboboxState: false,
			};
		},
		computed: {
			comboboxValue() {
				// Nếu có giá trị mặc định thì sử dụng
				if (this.default != -1)
					this.comboboxItemOnClick(this.default);
					
				// Nếu index = -1 thì đưa về mặc định
				// Còn lại lấy giá trị trong mảng
				return this.currIdx == -1
					? `Chọn ${this.label}`
					: this.comboboxData[this.currIdx][this.field + "Name"];
			},
		},
		methods: {
			/**
			 * Xử lý sự kiện click vào combobox item
			 * CreatedBy: NTDUNG (28/08/2021)
			 * @param {number} index chỉ số của item
			 */
			comboboxItemOnClick(index) {
				this.currIdx = index;
				this.comboboxState = false;
			},
		},
		watch: {
			/**
			 * Khi chuyển giá trị mới thì đổi currI;dx
			 * @param {string} value
			 * CreatedBy: NTDUNG (31/08/2021)
			 */
			value: function(value) {
				this.currIdx = this.comboboxData.findIndex((item) => {
					return item[this.field + "Id"] == value;
				});
			},
			/**
			 * Khi thay đổi currIdx thì cập nhật giá trị mới
			 * @param {number} value
			 * CreatedBy: NTDUNG (31/08/2021)
			 */
			// currIdx: function(value) {
			// 	// Gọi đến sự kiện phía cha
			// 	console.log(value);
			// },
		},
	};
</script>
<style lang=""></style>
