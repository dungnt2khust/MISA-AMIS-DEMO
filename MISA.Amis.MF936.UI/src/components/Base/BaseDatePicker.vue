<template lang="">
	<div v-if="datePickerState" class="datepicker">
		<div class="datepicker__head">
			<div @click="prevOnClick()" class="datepicker__prev"></div>
			<div class="datepicker__currmonth">
				Tháng {{ curr.month }} {{ curr.year }}
			</div>
			<div @click="nextOnClick()" class="datepicker__next"></div>
		</div>
		<table class="datepicker__table">
			<thead class="datepicker__thead">
				<tr class="datepikcer__tr">
					<th v-for="(item, index) in days" class="datepicker__th" :key="index">
						{{ item }}
					</th>
				</tr>
			</thead>
			<tbody class="datepicker__tbody">
				<tr
					v-for="idxRow in Math.ceil(getDates.length / 7)"
					class="datepicker__tr"
					:key="idxRow"
				>
					<td
						v-for="idxData in 7"
						class="datepicker__td"
						@click="dateOnClick(getDates[(idxRow - 1) * 7 + idxData - 1])"
						:class="{
							'datepicker--selected':
								getDates[(idxRow - 1) * 7 + idxData - 1] == selected.date &&
								curr.month == selected.month &&
								curr.year == selected.year,
						}"
						:style="{
							visibility: getDates[(idxRow - 1) * 7 + idxData - 1]
								? 'visible'
								: 'hidden',
						}"
						:key="idxData"
					>
						{{ getDates[(idxRow - 1) * 7 + idxData - 1] }}
					</td>
				</tr>
			</tbody>
		</table>
		<div @click="todayOnClick()" class="datepicker__footer fx-center">
			Hôm nay
		</div>
	</div>
</template>
<script>
	export default {
		name: "BaseDatePicker",
		props: {
			datePickerState: {
				type: Boolean,
				default: false,
			},
		},
		data() {
			return {
				days: ["T2", "T3", "T4", "T5", "T6", "T7", "CN"],
				curr: {
					year: new Date().getFullYear(),
					month: new Date().getMonth() + 1,
					date: new Date().getDate(),
				},
				selected: {
					year: new Date().getFullYear(),
					month: new Date().getMonth() + 1,
					date: new Date().getDate(),
				},
			};
		},
		computed: {
			/**
			 * Lấy thông tin cần thiết để in ra ngày
			 * @returns {object}
			 * CreatedBy: NTDUNG (30/08/2021)
			 */
			getInfos() {
				// Số ngày trong một tháng
				var daysInMonth = new Date(
					this.curr.year,
					this.curr.month,
					0
				).getDate();

				// Nyày đầu tiên là thứ mấy
				var dayBegin = new Date(
					`${this.curr.year}-${this.curr.month}-1`
				).getDay();
				dayBegin = dayBegin == 0 ? 7 : dayBegin;

				return { dayBegin: dayBegin, daysInMonth: daysInMonth };
			},
			/**
			 * Tạo ra mảng dữ liệu để in lên bảng
			 * @returns {array}
			 * CreatedBy: NTDUNG (30/08/2021)
			 */
			getDates() {
				var dates = [];
				var dayBegin = this.getInfos["dayBegin"];
				var daýsInMonth = this.getInfos["daysInMonth"];

				// Thêm những phần tử rỗng
				for (var i = 0; i < dayBegin - 1; i++) {
					dates.push("");
				}

				// Thêm những phần tử chính
				for (var j = 1; j <= daýsInMonth; j++) {
					dates.push(j);
				}
				return dates;
			},
		},
		methods: {
			/**
			 * Bắt sự kiện nút next
			 * CreatedBy: NTDUNG (30/08/2021)
			 */
			nextOnClick() {
				if (this.curr.month == 12) {
					this.curr.year++;
					this.curr.month = 1;
				} else {
					this.curr.month++;
				}
			},
			/**
			 * Bắt sự kiện nút prev
			 * CreatedBy: NTDUNG (30/08/2021)
			 */
			prevOnClick() {
				if (this.curr.month == 1) {
					this.curr.year--;
					this.curr.month = 12;
				} else {
					this.curr.month--;
				}
			},
			/**
			 * Bắt sự kiện nút hôm nay
			 * CreatedBy: NTDUNG (30/08/2021)
			 */
			todayOnClick() {
				var currDate = new Date();
				this.curr.date = currDate.getDate();
				this.curr.month = currDate.getMonth() + 1;
				this.curr.year = currDate.getFullYear();

				this.selected.date = currDate.getDate();
				this.selected.month = currDate.getMonth() + 1;
				this.selected.year = currDate.getFullYear();
			},
			/**
			 * Sự kiện nhấn vào một ngày
			 * @param {number} date
			 * CreatedBy: NTDUNG (30/08/2021)
			 */
			dateOnClick(date) {
				this.$set(this.selected, 'date', date);
				this.$set(this.selected, 'month', this.curr.month);
				this.$set(this.selected, 'year', this.curr.year);
			},
		},
		watch: {
			/**
			 * Theo dõi sự thay đổi của ngày được pick và xử lý sự kiện
			 * @param {object} value
			 * CreatedBy: NTDUNG (30/08/2021)
			 */	
			selected: {
				handler(newVal){  
					this.$emit('selectedADate', newVal);
					this.$emit('hideDatepicker');
				},
				deep: true,
				// immediate: true
			}
		}
	};
</script>
<style lang=""></style>
