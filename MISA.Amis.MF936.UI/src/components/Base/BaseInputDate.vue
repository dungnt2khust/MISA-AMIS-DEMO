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
			<span
				tabindex="0"
				@blur="blurInputDate($event)"
				@click="datePickerState = !datePickerState"
				class="input__icon"
			></span>
			<base-date-picker
				:value="currDate"
				v-model="currDate"
				:datePickerState="datePickerState"
				@hideDatepicker="datePickerState = false"
			/>
		</div>
	</div>
</template>
<script>
	// LIBRARY
	import methods from "../../Mixins/methods"
	// COMPONENTS
	import BaseDatePicker from "./BaseDatePicker.vue";

	export default {
		name: 'BaseInputDate',
		mixins: [methods],
		components: {
			BaseDatePicker,
		},
		props: {
			label: {
				type: String,
				default: '',
			},
			required: {
				type: Boolean,
				default: false,
			},
			value: {
				type: String,
				default: null
			}
		},
		data() {
			return {
				datePickerState: false,
				currDate: null,
                defaultValue: '__/__/____'
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
                })
            },	
            /**
             * Xử lý giá trị để in lên input
             * @return {string}
             */
            resolvedValue() {
				// Nếu có ngày thì hiển thị
                if (this.currDate)
                    return this.formatDate(this.currDate);
                return '';
            }
        },
		methods: {
			/**
			 * Blur ô input
			 * @param {event} event
			 * CreatedBy: NTDUNG (03/09/2021)
			 */
			blurInputDate() {
				setTimeout(() => {
					this.datePickerState = false;
				}, 100);
			},	
		},
		watch: {
			/**
			 * Sự kiện khi đã pick được 1 ngày mới
			 * @param {String} newDate
			 * CreatedBy: NTDUNG (02/09/2021)
			 */
			currDate: function(newDate) {
				if (newDate)
					this.$emit('input', `${newDate}T00:00:00`);
			},
			/**
			 * Bắt sự kiện thay đổi value thì cập nhật ngày hiện tại
			 * @param {String} newValue
			 * CreatedBy: NTDUNG (02/09/2021)
			 */
			value: function(newValue) {
				if (newValue)
					this.currDate = newValue.substring(0, 10)
				else 
					this.currDate = null;
			}
		},
	};
</script>
<style lang=""></style>
