<template lang="">
	<div class="pagination">
		<div class="pagination__desc">
			Tổng số: <span class="text-bold">54</span> bản ghi
		</div>
		<div class="pagination__control">
			<pagination-select class="pagination__select" comboboxType="up" />
			<div class="pagination__redirect">
				<div
					class="pagination__prev"
					:class="{ 'pagination--disable': currIdx == 1 }"
					@click="paginationPrevOnClick()"
				>
					Trước
				</div>
				<div
					v-for="index in numDisplayPage"
					class="pagination__index"
					:class="{ 'pagination__index--selected': index == currIdx }"
					@click="currIdx = index"
					:key="index"
				>
					{{ index }}
				</div>
				<div
					class="pagination__next"
					:class="{ 'pagination--disable': currIdx == totalPage }"
					@click="paginationNextOnClick()"
				>
					Sau
				</div>
			</div>
		</div>
	</div>
</template>
<script>
	// COMPONENTS
	import BaseCombobox from "./BaseCombobox.vue";
	export default {
		name: "BasePagination",
		components: {
			PaginationSelect: BaseCombobox,
		},
		data() {
			return {
				currIdx: 1,
				numDisplayPage: 3,
				totalPage: 3,
			};
		},
		methods: {
			/**
			 * Xử lý sự kiện click vào nút Prev
			 * CreatedBy: NTDUNG (28/08/2021)
			 */
			paginationPrevOnClick() {
				if (this.currIdx != 1) 
					this.currIdx--;
			},
			/**
			 * Xử lý sự kiện click vào nút Next
			 * CreatedBy: NTDUNG (28/08/2021)
			 */
			paginationNextOnClick() {
				if (this.currIdx != this.totalPage)
					this.currIdx++;
			}
		}
	};
</script>
<style lang=""></style>
