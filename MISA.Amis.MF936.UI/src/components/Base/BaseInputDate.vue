<template lang="">
	<div class="input-wrapper">
		<span class="label">
			{{ label }} <span v-if="required" class="text-red">*</span></span
		>
		<div class="input__main">
			<input
				v-on="inputDateListeners"
				type="text"
				placeholder="DD/MM/YYYY"
				:value="resolvedValue"
				class="input input--date"
			/>
			<!-- @blur="datePickerState = false" -->
			<span
				tabindex="0"
				@click="datePickerState = !datePickerState"
				class="input__icon"
			></span>
			<base-date-picker
				:datePickerState="datePickerState"
				@selectedADate="selectedADate($event)"
				@hideDatepicker="datePickerState = false"
			/>
		</div>
	</div>
</template>
<script>
	// COMPONENTS
	import BaseDatePicker from "./BaseDatePicker.vue";

	export default {
		name: "BaseInputDate",
		components: {
			BaseDatePicker,
		},
		props: {
			label: {
				type: String,
				default: "",
			},
			required: {
				type: Boolean,
				default: false,
			},
		},
		data() {
			return {
				datePickerState: false,
				currValue: "",
                defaultValue: "__/__/____"
			};
		},
        computed: {
            /**
             * Lắng nghe sự kiện input
             * @return {object}
             * CreatedBy: NTDUNG (30/08/2021)
             */
            inputDateListeners: function() {
                return Object.assign({}, this.$listener, {
                    input: (event) => {
                        if (event.key )
                        console.log('inputting', event.key);
                    },
                    blur: (event) => {
						this.$emit('selectedADate', event.target.value);
                        console.log('blured');
                    }
                })
            },
            /**
             * Xử lý giá trị để in lên input
             * @return {string}
             */
            resolvedValue() {
                // Kiểm tra value
                if (this.currValue)
                    return this.currValue;
                return this.defaultValue;
            }
        },
		methods: {
			/**
			 * Xử lý sự kiện chọn một ngày
			 * @param {object} newVal
			 * CreatedBy: NTDUNG (30/08/2021)
			 */
			selectedADate(newVal) {
				this.currValue = `${newVal.date}/${newVal.month}/${newVal.year}`;
			},
		},
		watch: {},
	};
</script>
<style lang=""></style>
