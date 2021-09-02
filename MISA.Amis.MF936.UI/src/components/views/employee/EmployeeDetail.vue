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
						<base-checkbox
							:state="data['IsCustomer']"
							v-model="data['IsCustomer']"
							label="Là khách hàng"
						/>
						<base-checkbox
							:state="data['IsSupplier']"
							v-model="data['IsSupplier']"
							label="Là nhà cung cấp"
						/>
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
						:formValidate="formValidate"
						:formState="formState"
						@inputError="inputErrorHandle($event)"
						class="w-40"
					/>
					<base-input
						label="Tên"
						:required="true"
						:value="data['FullName']"
						v-model="data['FullName']"
						:formValidate="formValidate"
						:formState="formState"	
						@inputError="inputErrorHandle($event)"
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
						:formValidate="formValidate"
						:formState="formState"
						@inputError="inputErrorHandle($event)"
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
						:formValidate="formValidate"
						:formState="formState"
						@inputError="inputErrorHandle($event)"
					/>
				</div>
				<div class="form__body-item">
					<base-input
						label="Nơi cấp"
						:value="data['IdentityPlace']"
						v-model="data['IdentityPlace']"
						:formValidate="formValidate"
						:formState="formState"
						@inputError="inputErrorHandle($event)"
					/>
				</div>
				<div class="form__body-item fx-100">
					<base-input
						label=" Địa chỉ"
						:value="data['Address']"
						v-model="data['Address']"
						:formValidate="formValidate"
						:formState="formState"
						@inputError="inputErrorHandle($event)"
					/>
				</div>
				<div class="form__body-item fx fx-100">
					<base-input
						label="ĐT di động"
						:value="data['PhoneNumber']"
						v-model="data['PhoneNumber']"
						field="PhoneNumber"
						:formValidate="formValidate"
						:formState="formState"
						@inputError="inputErrorHandle($event)"
						class="w-25"
					/>
					<base-input
						label="ĐT cố định"
						:value="data['LandlineNumber']"
						v-model="data['LandlineNumber']"
						field="PhoneNumber"
						:formValidate="formValidate"
						:formState="formState"
						@inputError="inputErrorHandle($event)"
						class="w-25"
					/>
					<base-input
						label="Email"
						:value="data['Email']"
						v-model="data['Email']"
						field="Email"
						:formValidate="formValidate"
						:formState="formState"
						@inputError="inputErrorHandle($event)"
						class="w-25"
					/>
				</div>
				<div class="form__body-item fx fx-100">
					<base-input
						label="Tài khoản ngân hàng"
						:value="data['BankAccount']"
						v-model="data['BankAccount']"
						:formValidate="formValidate"
						:formState="formState"
						@inputError="inputErrorHandle($event)"
						class="w-25"
					/>
					<base-input
						label="Tên ngân hàng"
						:value="data['BankName']"
						v-model="data['BankName']"
						:formValidate="formValidate"
						:formState="formState"
						@inputError="inputErrorHandle($event)"
						class="w-25"
					/>
					<base-input
						label="Chi nhánh"
						:value="data['BankBranch']"
						v-model="data['BankBranch']"
						:formValidate="formValidate"
						:formState="formState"
						@inputError="inputErrorHandle($event)"
						class="w-25"
					/>
				</div>
			</div>
			<div class="form__footer">
				<div @click="hideForm()" class="form__button-cancel button">
					Huỷ
				</div>
				<div class="form__control">
					<div @click="store()" class="button">Cất</div>
					<div @click="storeAndAdd()" class="button button--green">
						Cất và thêm
					</div>
				</div>
			</div>
		</div>
	</div>
</template>
<script>
	// LIBRARY
	import listeners from "../../../Mixins/listeners.js";
	import employeeAPI from "../../../js/components/employeeAPI";
	import baseAPI from "../../../js/base/baseAPI";

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
				formValidate: false,
				formState: false,
				errMsg: '',
				id: "",
				mode: "",
				data: {},
				departmentData: [],
				dragState: false,
				distanceX: 0,
				distanceY: 0,
				departmentAPI: new baseAPI("Departments"),
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
						if (event.target.tagName != 'INPUT') {
							this.dragState = true;
							posXBegin = event.clientX;
							posYBegin = event.clientY;
						}
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
							this.distanceY = posYEnd - posYBegin;
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
				// Reset lỗi
				this.errMsg = '';
				// Gán id và mode cho form
				this.id = data.id;
				this.mode = data.mode;
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
				employeeAPI
					.getById(id)
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
				employeeAPI
					.getNewEmployeeCode()
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
				this.departmentAPI
					.getAll()
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
					"warnCancel",
					"Dữ liệu đã bị thay đổi. Bạn có muốn cất không?"
				).then(answer => {
					// YES
					if (answer == 'YES') this.formState = false;
					// NO
					else this.formState = false;
				});
			},
			/**
			 * Cập nhật thông tin
			 * CreatedBy: NTDUNG (31/08/2021)
			 * ModifiedBy: NTDUNG (02/09/2021)
			 */
			store() {
				// Reset lại lỗi để validate lại
				this.errMsg = '';
				this.formValidate = !this.formValidate;

				// Chờ validate lại
				setTimeout(() => {
					// Khi vẫn còn lỗi
					if (this.checkValidForm()) {
						// Hiển thị dialog cảnh báo trước khi cất
						this.callDialog(
							'warnCancel',
							'Hãy kiểm tra lại dữ liệu trước khi Cất. Bạn có muốn cất luôn?'
						).then(answer => {
							// Tắt form
							this.formState = false;
							if (answer == 'YES') {
								this.repository();
							} 
						});
					} else {
						if (this.errMsg)
							this.callDialog('error', this.errMsg)
								.then(answer => {
									if (answer == 'NO')
										this.errMsg = '';
								})
					}	
				}, 20)	
			},
			/**
			 * Hàm tương tác thêm xoá
			 * CreatedBy: NTDUNG (02/09/2021)
			 */
			repository() {
				switch (this.mode) {
					case "add":
						employeeAPI
							.post(this.data)
							.then((res) => {
								console.log(res);
								this.$bus.$emit("reloadData");
							})
							.catch((res) => {
								console.log(res);
							});
						break;
					case "update":
						employeeAPI.put(this.id, this.data)
							.then((res) => {
								console.log(res);
								this.$bus.$emit("reloadData");
							})
							.catch((res) => {
								console.log(res);
							});
						break;
				}
			},
			/**
			 * Hàm kiểm tra form đã đúng chưa (nếu có một input là error thì chưa hợp lệ
			 * CreatedBy: NTDUNG (02/09/2021)
			 */
			checkValidForm() {
				var check = true;
				var inputs = this.$el.querySelectorAll('input');
				inputs.forEach(input => {
					if (input.classList.contains('border-error')) {
						check = false;
					}
				});
				return check;
			},
			/**
			 * Bắt sự kiện input báo lỗi (lấy lỗi đầu tiên)
			 * @param {String} errMsg thông báo lỗi 
			 * CreatedBy: NTDUNG (02/09/2021)
			 */
			inputErrorHandle(errMsg) {
				// nếu đã tồn tại lỗi thì không lấy lỗi sau nữa
				if (!this.errMsg) {
					this.errMsg = errMsg;	
				}
			}
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
