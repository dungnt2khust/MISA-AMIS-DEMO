<template lang="">
	<div v-show="dialogState" class="dialog" :class="'dialog--' + dialogType">
		<div class="dialog__main">
			<div class="dialog__content">
				<div class="dialog__icon"></div>
				<div class="dialog__message" v-html="dialogMessage">
				</div>
			</div>
			<div class="dialog__separate"></div>
			<div class="dialog__control">
				<div
					@click="confirm('CANCEL')"
					v-if="dialogType != 'warn'"
					class="dialog__cancel button"
					:class="{'button--green': dialogType == 'error'}"
				>
					{{ dialogType == 'warnCancel' ? 'Huỷ' : 'Đóng'}}
				</div>
				<div class="dialog__answer">
					<div
						v-if="dialogType != 'error'"
						@click="confirm('NO')"
						class="dialog__no button"
					>
						Không
					</div>
					<div
						v-if="dialogType != 'error'"
						@click="confirm('YES')"
						class="dialog__yes button button--green"
					>
						Có
					</div>
				</div>
			</div>
		</div>
	</div>
</template>
<script>
	export default {
		name: "BaseDialog",
		data() {
			return {
				dialogType: "error",
				dialogState: false,
                dialogMessage: ''
			};
		},
		created() {
			this.$bus.$on("showDialog", (data) => {
				// Bật dialog
				this.dialogState = true;

				// Đặt kiểu cho dialog
				this.dialogType = data.type;

				// Gán thông điệp
				this.dialogMessage= data.message;
			});
		},
		methods: {
			/**
			 * Bắt sự kiện nhấn vào nút không hoặc có
			 * @param {boolean} answer kết quả của dialog (false: không , true: có)
			 * CreatedBy: NTDUNG (31/08/2021)
			 */
			confirm(answer) {
				// Ẩn dialog 
				this.dialogState = false;

				// Gửi kết quả trả về 
				this.$bus.$emit('dialogConfirm', answer);
			}	
		}
	};
</script>
<style lang=""></style>
