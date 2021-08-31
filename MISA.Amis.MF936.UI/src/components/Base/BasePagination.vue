<template lang="">
	<div class="pagination">
		<div class="pagination__desc">
			Tổng số: <span class="text-bold">54</span> bản ghi
		</div>
		<div class="pagination__control">
			<base-combobox
				:comboboxData="comboboxData"
				field="Pagination"
				class="pagination__select"
				:default="defaultOption"
				comboboxType="up"
			/>
			<div class="pagination__redirect">
				<div
					class="pagination__prev non-select-text"
					:class="{ 'pagination--disable': currIdx == 1 }"
					@click="paginationPrevOnClick()"
				>
					Trước
				</div>
				<div
					v-for="index in numDisplayPage"
					class="pagination__index non-select-text"
					:class="{ 'pagination__index--selected': index == currIdx }"
					@click="currIdx = index"
					:key="index"
				>
					{{ index }}
				</div>
				<div
					class="pagination__next non-select-text"
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
			BaseCombobox,
		},
		data() {
			return {
				currIdx: 1,
				numDisplayPage: 3,
				totalPage: 3,
				comboboxData: [
					{ PaginationId: 20, PaginationName: "20 bản ghi trên 1 trang" },
					{ PaginationId: 30, PaginationName: "30 bản ghi trên 1 trang" },
					{ PaginationId: 40, PaginationName: "40 bản ghi trên 1 trang" },
					{ PaginationId: 50, PaginationName: "50 bản ghi trên 1 trang" },
				],
				defaultOption: 0
			};
		},
		methods: {
			/**
			 * Xử lý sự kiện click vào nút Prev
			 * CreatedBy: NTDUNG (28/08/2021)
			 */
			paginationPrevOnClick() {
				if (this.currIdx != 1) this.currIdx--;
			},
			/**
			 * Xử lý sự kiện click vào nút Next
			 * CreatedBy: NTDUNG (28/08/2021)
			 */
			paginationNextOnClick() {
				if (this.currIdx != this.totalPage) this.currIdx++;
			},
		},
	};
</script>
<style lang=""></style>
