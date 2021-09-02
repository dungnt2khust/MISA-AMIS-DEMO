<template lang="">
	<div id="content">
		<div class="content__header">
			<div class="content__name">
				Nhân viên
			</div>
			<div
				@click="contentAddOnClick()"
				class="button button--green button--large"
			>
				Thêm mới nhân viên
			</div>
		</div>
		<div class="table-wrapper">
			<div class="table__control">
				<div class="table__search">
					<input
						v-model="filterString"
						@input="searchOnInput()"
						ref="inputSearch"
						type="text"
						class="table__search-input"
						placeholder="Tìm theo mã, tên nhân viên"
					/>
				</div>
				<div
					@click="changePageInfo({ filterString: '' })"
					v-on="tooltipListeners('Tải lại dữ liệu')"
					class="table__reload"
				>
					<div class="table__reload-icon"></div>
				</div>
				<div
					v-on="tooltipListeners('Xuất file Excel')"
					@click="exportData()"
					class="table__export"
				>
					<div class="table__export-icon"></div>
				</div>
			</div>
			<base-table
				:tableId="tableId"
				:tableStyle="tableEmployeeStyle"
				:tableData="tableData"
				:tableLoading="tableLoading"
				:tableError="tableError"
				:controller="controller"
			/>
			<base-pagination
				:totalPage="totalPage"
				:totalRecord="totalRecord"
				:currPage="currPage"
				:currOption="currOption"
				:paginationData="paginationData"
				@changePageInfo="changePageInfo($event)"
			/>
		</div>
	</div>
</template>
<script>
	// LIBRARY
	import employeeAPI from "../../../js/components/employeeAPI";
	import Table from "../../../Mixins/table.js";
	import listeners from "../../../Mixins/listeners.js";

	// COMPONENT
	import BaseTable from "../../Base/BaseTable.vue";
	import BasePagination from "../../Base/BasePagination.vue";

	export default {
		name: "EmployeePage",
		mixins: [Table, listeners],
		components: {
			BaseTable,
			BasePagination,
		},
		data() {
			return {
				inputTimeout: null,
				filterString: "",
				tableData: [],
				tableId: "EmployeeId",
				controller: "Employees",
				tableLoading: false,
				tableError: false,
				totalPage: 0,
				totalRecord: 0,
				currPage: 1,
				currOption: 0,
				paginationData: [
					{ PaginationId: 20, PaginationName: "20 bản ghi trên 1 trang" },
					{ PaginationId: 30, PaginationName: "30 bản ghi trên 1 trang" },
					{ PaginationId: 40, PaginationName: "40 bản ghi trên 1 trang" },
					{ PaginationId: 50, PaginationName: "50 bản ghi trên 1 trang" },
					{ PaginationId: 100, PaginationName: "100 bản ghi trên 1 trang" },
				],
			};
		},
		created() {
			this.$bus.$on('reloadData', () => {
				this.getTableData(this.currOption, this.currPage, this.filterString);
			});
		},
		mounted() {
			// Lấy dữ liệu
			this.getTableData(this.currOption, this.currPage, this.filterString);
		},
		computed: {
			/**
			 * Thông tin pagination
			 * @returns {Object}
			 * CreatedBy: NTDUNG (01/09/2021)
			 */
			currInfo() {
				return {
					currPage: this.currPage,
					currOption: this.currOption,
				};
			},
		},
		methods: {
			/**
			 * Sự kiện nhập vào input search
			 * CreatedBy: NTDUNG (01/09/2021)
			 */
			searchOnInput() {
				// Bỏ timeout
				clearTimeout(this.inputTimeout);
				// Đặt timeout nếu sau 500ms không nhập thì chạy
				this.inputTimeout = setTimeout(() => {
					this.changePageInfo({});
				}, 500);
			},
			/**
			 * Thông tin thay đổi - load lại dữ liệu
			 * @param {Object} data
			 * CreatedBy: NTDUNG (01/09/2021)
			 */
			changePageInfo(data) {
				// Nếu dữ liệu truyền vào tồn tại thì đổi nếu không thì giữ nguyên
				this.currOption = data["currOption"]
					? data["currOption"]
					: this.currOption;
				this.currPage = data["currPage"] ? data["currPage"] : this.currPage;
				this.filterString =
					data["filterString"] !== undefined
						? data["filterString"]
						: this.filterString;

				// Khi filterString khác rỗng thì khi load lại dữ liệu sẽ về trang đầu
				if (this.filterString != "") {
					this.currPage = 1;
				}
				// Lấy dữ liệu
				this.getTableData(this.currOption, this.currPage, this.filterString);
			},
			/**
			 * Lấy dữ liệu đổ vào table
			 * @param {Number} currOption
			 * @param {Number} currPage
			 * @param {String} filterString
			 * CreatedBy: NTDUNG (01/09/2021)
			 */
			getTableData(currOption, currPage, filterString) {
				// Bật loading
				this.turnOnLoading();
				// Tắt báo lỗi đi
				this.tableError = false;
				// Lấy dữ liệu bảng từ API
				employeeAPI
					.getEmployeeFilter(
						this.paginationData[currOption]["PaginationId"],
						currPage,
						filterString
					)
					.then((res) => {
						// Gán dữ liệu vào biến prop sang BaseTable
						this.tableData = res.data.Data;
						this.totalPage = res.data.TotalPage;
						this.totalRecord = res.data.TotalRecord;
						// Tắt loading
						this.tableLoading = false;
						// Focus ô tìm kiếm
						this.$refs.inputSearch.focus();
					})
					.catch((res) => {
						// Tắt loading
						this.tableLoading = false;
						this.tableError = true;
						this.tableData = [];
						console.log(res);
					});
			},
			/**
			 * export dữ liệu nhân viên
			 * CreatedBy: NTDUNG (01/09/2021)
			 */
			exportData() {
				// Gọi đến API export 
				employeeAPI.export()
					.then((res) => {
						// Tạo một thẻ a
						const link = document.createElement("a");
						// Gán link để download cho thẻ ạ
						link.href = window.URL.createObjectURL(new Blob([res.data]));
						// Tạo thuộc tính tên tải xuống cho link
						link.setAttribute("download", "Danh_sach_nhan_vien.xlsx");
						// Thêm vào trang hiện tại
						document.body.appendChild(link);
						// Nhấn vào link
						link.click();
					})
					.catch((res) => console.log(res));
			},
			/**
			 * Sự kiện nhấn vào nút Add
			 * CreatedBy: NTDUNG (29/08/2021)
			 */
			contentAddOnClick() {
				this.$bus.$emit("showForm", { mode: "add" });
			},
			/**
			 * Bật loading
			 * CreatedBy: NTDUNG (01/09/2021)
			 */
			turnOnLoading() {
				// Hiện loading
				this.tableLoading = true;

				// Nếu table rỗng thì thêm các bản ghi rỗng vào
				this.tableData = [];
				var emptyRecord = {};
				for (var i = 0; i < 15; i++) {
					this.tableData.push(emptyRecord);
				}
			},
		}
	};
</script>
<style lang=""></style>
