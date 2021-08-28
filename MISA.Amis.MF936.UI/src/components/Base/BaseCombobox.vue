<template lang="">
	<div class="combobox" :class="{ 'combobox--up': comboboxType == 'up', 'combobox--show': comboboxState }">
		<div class="combobox__value">
			<input
				type="text"
				class="combobox__input"
				:value="comboboxData[currIdx]"
			/>
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
				{{ item }}
			</li>
		</ul>
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
		},
		data() {
			return {
				currIdx: 1,
				comboboxData: [
					"20 bản ghi trên 1 trang",
					"30 bản ghi trên 1 trang",
					"40 bản ghi trên 1 trang",
					"50 bản ghi trên 1 trang",
					"60 bản ghi trên 1 trang",
				],
				comboboxState: false,
			};
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
            }
        }
	};
</script>
<style lang=""></style>
