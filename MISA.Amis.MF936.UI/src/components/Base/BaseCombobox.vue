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
				type: [String, Number],
				default: null
			},
			passIndex: {
				type: Boolean,
				default: true,
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
				if (this.currIdx == -1) {
					// Nếu không có giá trị truyền vào
					if (this.value == null)
						return `Chọn ${this.label}`;
					// Nếu có thì kiểm tra là giá trị hay index
					else {
						// Là index thì gán vào index hiện tại
						if (this.passIndex) 
							this.comboboxItemOnClick(this.value);
						else {
							// Nếu là giá trị thì so sánh với phần tử trong mảng để tìm ra index
							var foundIdx = this.comboboxData.findIndex(item => {
								return item[this.field + "Id"] == this.value;
							});
							this.comboboxItemOnClick(foundIdx);
						}		
						return this.comboboxData[this.currIdx][this.field + "Name"];
					}
				} else {
					return this.comboboxData[this.currIdx][this.field + "Name"];
				}
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
			 * Khi thay đổi currIdx thì cập nhật giá trị mới
			 * @param {number, string} value
			 * CreatedBy: NTDUNG (31/08/2021)
			 * ModifiedBy: NTUDNG (01/09/2021)
			 */
			currIdx: function(value) {
				// Nếu là index thì emit index
				if (this.passIndex) {
					this.$emit('input', value);
				}
				// Nếu là giá trị thì emit giá trị
				else {
					this.$emit('input', this.comboboxData[value][this.field + 'Id']);
				}
			},
		},
	};
</script>
<style lang=""></style>
