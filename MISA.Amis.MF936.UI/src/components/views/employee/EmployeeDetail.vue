<template lang="">
	<div v-show="formState" class="form">
		<div
			ref="form"
			v-on="formListeners"
			:style="positionOfForm"
			class="form__main"
		>
			<div class="form__header">
				<div class="form__header-content">
					<div class="form__title">Thông tin nhân viên</div>
					<div class="form__checklist fx">
						<base-checkbox :state="data['IsCustomer']" label="Là khách hàng" />
						<base-checkbox :state="data['IsSupplier']" label="Là nhà cung cấp" />
					</div>
				</div>
				<div class="form__action">
					<div class="form__help"></div>
					<div @click="hideForm()" class="form__cancel"></div>
				</div>
			</div>
			<div class="form__body">
				<div class="form__body-item fx">
					<base-input
						label="Mã"
						ref="InputCode"
						:required="true"
						:value="data['EmployeeCode']"
						v-model="data['EmployeeCode']"
						class="w-40"
					/>
					<base-input
						label="Tên"
						:required="true"
						:value="data['FullName']"
						v-model="data['FullName']"
						class="w-60"
					/>
				</div>
				<div class="form__body-item fx">
					<base-input-date
						label="Ngày sinh"
						:value="data['DateOfBirth']"
						v-model="data['DateOfBirth']"
						class="w-40"
					/>
					<base-radio
						label="Giới tính"
						:options="['Nam', 'Nữ', 'Khác']"
						:value="data['Gender']"
						v-model="data['Gender']"
					/>
				</div>
				<div class="form__body-item">
					<base-combobox
						label="Đơn vị"
						:required="true"
						:comboboxData="departmentData"
						field="Department"
						:value="data['DepartmentId']"
						v-model="data['DepartmentId']"
						:passIndex="false"
					/>
				</div>
				<div class="form__body-item fx">
					<base-input
						label="Số CMND"
						:value="data['IdentityNumber']"
						v-model="data['IdentityNumber']"
						class="w-60"
					/>
					<base-input-date
						label="Ngày cấp"
						:value="data['IdentityDate']"
						v-model="data['IdentityDate']"
						class="w-40"
					/>
				</div>
				<div class="form__body-item">
					<base-input
						label="Chức danh"
						:value="data['PossitionName']"
						v-model="data['PossitionName']"
					/>
				</div>
				<div class="form__body-item">
					<base-input
						label="Nơi cấp"
						:value="data['IdentityPlace']"
						v-model="data['IdentityPlace']"
					/>
				</div>
				<div class="form__body-item fx-100">
					<base-input
						label=" Địa chỉ"
						:value="data['Address']"
						v-model="data['Address']"
					/>
				</div>
				<div class="form__body-item fx fx-100">
					<base-input
						label="ĐT di động"
						:value="data['PhoneNumber']"
						v-model="data['PhoneNumber']"
						field="PhoneNumber"
						class="w-25"
					/>
					<base-input
						label="ĐT cố định"
						:value="data['LandlineNumber']"
						v-model="data['LandlineNumber']"
						class="w-25"
					/>
					<base-input
						label="Email"
						:value="data['Email']"
						field="Email"
						class="w-25"
					/>
				</div>
				<div class="form__body-item fx fx-100">
					<base-input
						label="Tài khoản ngân hàng"
						:value="data['BankAccount']"
						v-model="data['BankAccount']"
						class="w-25"
					/>
					<base-input
						label="Tên ngân hàng"
						:value="data['BankName']"
						v-model="data['BankName']"
						class="w-25"
					/>
					<base-input
						label="Chi nhánh"
						:value="data['BankBranch']"
						v-model="data['BankBranch']"
						class="w-25"
					/>
				</div>
			</div>
			<div class="form__footer">
				<div @click="hideForm()" class="form__button-cancel button">
					Huỷ
				</div>
				<div class="form__control">
					<div @click="update()" class="button">Cất</div>
					<div class="button button--green">Cất và thêm</div>
				</div>
			</div>
		</div>
	</div>
</template>
<script>
	// LIBRARY
	import listeners from "../../../Mixins/listeners.js";
    import employeeAPI from "../../../js/components/employeeAPI"
    import baseAPI from "../../../js/base/baseAPI"

	// COMPONENTS
	import BaseInput from "../../Base/BaseInput.vue";
	import BaseInputDate from "../../Base/BaseInputDate.vue";
	import BaseCombobox from "../../Base/BaseCombobox.vue";
	import BaseCheckbox from "../../Base/BaseCheckbox.vue";
	import BaseRadio from "../../Base/BaseRadio.vue";

	export default {
		name: "EmployeeDetail",
		mixins: [listeners],
		components: {
			BaseInput,
			BaseCombobox,
			BaseInputDate,
			BaseCheckbox,
			BaseRadio,
		},
		data() {
			return {
				formState: false,
				data: [],
				departmentData: [],
				dragState: false,
				distanceX: 0,
				distanceY: 0,
				departmentAPI: new baseAPI('Departments')
			};
		},
		computed: {
            /**
             * Lắng nghe sự kiện trên form
             * CreatedBy: NTDUNG (31/08/2021)
             */
			formListeners: function() {
				var posXBegin, posXEnd, posYBegin, posYEnd;
				return Object.assign({}, this.$listener, {
					// Nhấn xuống thì đặt vị trí bắt đầu và bật mode drag
					mousedown: (event) => {
						this.dragState = true;
						posXBegin = event.clientX;
						posYBegin = event.clientY;
					},
					// Tắt mode drag khi nhấc chuột
					mouseup: () => {
						this.dragState = false;
					},
					// Tắt mode drag khi ra khỏi form
					mouseleave: () => {
						this.dragState = false;
					},
					// Khi trong mode drag thì tìm ra offset và đặt position
					mousemove: (event) => {
						if (this.dragState) {	
							// Gán vị trí mới
							posXEnd = event.clientX;
							posYEnd = event.clientY;
							this.distanceY= posYEnd - posYBegin;
							this.distanceX = posXEnd - posXBegin;
						}
					},
				});
			},
			/**
			 * Đặt vị trí cho form
			 * CreatedBy: NTDUNG (31/08/2021)
			 */
			positionOfForm() {
				return { top: this.distanceY + "px", left: this.distanceX + "px" };
			},
		},
		created() {
			/**
			 * Lắng nghe sự kiện hiển thị form
			 * @param {object} data
			 * CreatedBy: NTDUNG (29/08/2021)
			 */
			this.$bus.$on("showForm", (data) => {
				// Lấy dữ liệU cho combobox
				this.getComboboxData();

				// Kiểm tra với các trường hợp show
				switch (data.mode) {
					case "update":
						// Lấy dữ liệu đẩy lên form
						this.getData(data.id);
						break;
					case "add":
						// Xoá dữ liệu cũ
						for (var prop in this.data) {
							this.$set(this.data, prop, null);
						}
						// Lấy mã mới
						this.getNewCode();
						break;
					default:
				}
				// Hiển thị form
				this.formState = true;
			});
		},
		methods: {
			/**
			 * Lấy dữ liệu đưa lên form
			 * @param {string} id
			 * CreatedBy: NTDUNG (30/08/2021)
			 */
			getData(id) {
                employeeAPI.getById(id)
					.then((res) => {
						// Gán dữ liệu vào mảng chứa
						this.data = res.data;
					})
					.catch((res) => {
						console.log(res);
					});
			},
			/**
			 * Lấy mã mới
			 * CreatedBy: NTDUNG (31/08/2021)
			 */
			getNewCode() {
				employeeAPI.getNewEmployeeCode()
					.then((res) => {
						// Gán code mới vào mảng
						this.$set(this.data, "EmployeeCode", res.data.Data);
					})
					.catch((res) => {
						console.log(res);
					});
			},
			/**
			 * Lấy dữ liệu đổ vào combobox
			 * CreatedBy: NTDUNG (31/08/2021)
			 */
			getComboboxData() {	
				this.departmentAPI.getAll()
					.then((res) => {
						// Gán dữ liệu vào mảng chứa
						if (res.status == 200) this.departmentData = res.data;
					})
					.catch((res) => {
						console.log(res);
					});
			},
			/**
			 * Xử lý sự kiện ẩn form
			 * CreatedBy: NTDUNG (31/08/2021)
			 */
			hideForm() {
				// Gọi đến dialog
				this.callDialog(
					"warn",
					"Dữ liệu đã bị thay đổi. Bạn có muốn cất không?"
				).then((answer) => {
					// YES
					if (answer) this.formState = false;
					// NO
					else this.formState = false;
				});
			},
			/**
			 * Cập nhật thông tin
			 * CreatedBy: NTDUNG (31/08/2021)
			 */
			update() {
				console.log(this.data);
			},
		},
		watch: {
			/**
			 * Khi form được bật thì focus vào ô đầu tiên
			 * @param {boolean} value
			 * CreatedBy: NTDUNG (31/08/2021)
			 */
			formState: function() {
				setTimeout(() => {
					// Focus first input
					this.$refs.InputCode.$el.lastChild.focus();
				}, 1);
			},
		},
	};
</script>
<style lang=""></style>
