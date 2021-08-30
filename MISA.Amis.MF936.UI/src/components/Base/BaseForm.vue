<template lang="">
	<div v-show="formState" class="form">
		<div class="form__overlay"></div>
		<div class="form__main">
			<div class="form__header">
				<div class="form__header-content">
					<div class="form__title">Thông tin nhân viên</div>
					<div class="form__checklist fx">
						<base-checkbox value="Là khách hàng"/>
						<base-checkbox value="Là nhà cung cấp"/>
					</div>
				</div>
				<div class="form__action">
					<div class="form__help"></div>
					<div @click="formState = false" class="form__cancel"></div>
				</div>
			</div>
			<div class="form__body">
                <div class="form__body-item fx">
                    <base-input label="Mã" :required="true" class="w-40" />
                    <base-input label="Tên" :required="true" class="w-60" />
                </div>
                <div class="form__body-item fx">
                    <base-input-date label="Ngày sinh" class="w-40" />
					<base-radio
						label="Giới tính"
						:value="['Nam', 'Nữ', 'Khác']"
					/>
                </div>
                <div class="form__body-item">
                    <base-combobox label="Đơn vị" :required="true" />
                </div>
                <div class="form__body-item fx">
                    <base-input label="Số CMND" class="w-60" />
                    <base-input-date label="Ngày cấp" class="w-40" />
                </div>
                <div class="form__body-item">
                    <base-input label="Chức danh" />
                </div>
                <div class="form__body-item">
                    <base-input label="Nơi cấp" />
                </div>
                <div class="form__body-item fx-100">
                    <base-input label=" Địa chỉ"/>
                </div>
                <div class="form__body-item fx fx-100">
                    <base-input label="ĐT di động" class="w-25"/>
                    <base-input label="ĐT cố định" class="w-25"/>
                    <base-input label="Email" class="w-25"/>
                </div>
                <div class="form__body-item fx fx-100">
                    <base-input label="Tài khoản ngân hàng" class="w-25"/>
                    <base-input label="Tên ngân hàng" class="w-25"/>
                    <base-input label="Chi nhánh" class="w-25"/>
                </div>
			</div>
			<div class="form__footer">
				<div @click="formState = false" class="form__button-cancel button">
					Huỷ
				</div>
				<div class="form__control">
					<div class="button">Cất</div>
					<div class="button button--green">Cất và thêm</div>
				</div>
			</div>
		</div>
	</div>
</template>
<script>
	// COMPONENTS
	import BaseInput from "./BaseInput.vue"
	import BaseInputDate from './BaseInputDate.vue'
	import BaseCombobox from "./BaseCombobox.vue"
	import BaseCheckbox from './BaseCheckbox.vue'
	import BaseRadio from './BaseRadio.vue'

	export default {
		name: "BaseForm",
		components: {
			BaseInput,
			BaseCombobox,
			BaseInputDate,
			BaseCheckbox,
			BaseRadio
		},
		data() {
			return {
				formState: false,
			};
		},
		created() {
			/**
			 * Lắng nghe sự kiện hiển thị form
			 * @param {object} data
			 * CreatedBy: NTDUNG (29/08/2021)
			 */
			this.$bus.$on("showForm", (data) => {
				this.formState = true;
				console.log(data);
			});
			/**
			 * Lắng nghe sự kiện ẩn form
			 * CreatedBy: NTDUNG (29/08/2021)
			 */
			this.$bus.$on("hideForm", () => {
				this.formState = false;
			});
		},
	};
</script>
<style lang=""></style>
