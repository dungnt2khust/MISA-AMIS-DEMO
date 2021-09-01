<template lang="">
	<div class="input-wrapper">
		<span class="label">
			{{ label }} <span v-if="required" class="text-red">*</span></span
		>
		<input
			v-on="inputListeners"
			:title="isError ? label + ' ' + errorMsg : ''"
			:value="value"
            :class="{'border-error': isError}"
			type="text"
			class="input"
		/>
	</div>
</template>
<script>
	export default {
		name: "BaseInput",
		props: {
			label: {
				type: String,
				default: "",
			},
			required: {
				type: Boolean,
				default: false,
			},
			value: {
				type: String,
				default: "",
			},
		},
		data() {
			return {
				isError: false,
				errorMsg: '',
			};
		},
        computed: {
            inputListeners: function() {
                return Object.assign({}, this.$listener, {
                    input: () => {
                        // Khi nhập thì bỏ hiện lỗi đi
                        this.isError = false;
                        this.errorMsg = '';
                    },
                    blur: (event) => {
                        // Validate dữ liệu
                        this.validateInput(event.target.value);
                        // Đưa dữ liệu ra phía cha
                        this.$emit('input', event.target.value);
                    }
                });
            }
        },
        methods: {
            /**
             * validate các ô input
             * @param {string} value
             * CreatedBy: NTDUNG (05/08/2021)
             * ModifiedBy: NTDUNG (06/08/2021)
             */
            validateInput(value) {
                if (value === null || value === '') {
                    if (this.required) {
                        this.errorMsg = 'không được để trống';
                        this.isError = true;
                    }
                } else {
                    switch (this.field) {
                        case 'Email':
                            if (!this.validEmail(value)) {
                                this.errorMsg = 'sai định dạng';
                                this.isError = true;
                            }
                            break;
                        case 'PhoneNumber':
                            if (!this.validPhone(value)) {
                                this.errorMsg = 'sai định dạng';
                                this.isError = true;
                            }
                            break;
                        default:
                    }
                }
            },
            /**
             * validate email đúng định dạng
             * @param {String} email xâu email người dùng nhập vào
             * @returns {Boolean} true nếu đúng định dạng
             * CreatedBy: NTDUNG (31/08/2021)
             * ModifiedBy: NTDUNG (31/08/2021)
             */
            validEmail: function (email) {
                var regEmail =
                    /^(([^<>()[\]\\.,;:\s@"]+(\.[^<>()[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
                return regEmail.test(email);
            },
            /**
             * validate số điện thoại đúng định dạng
             * @param {String} phone sdt người dùng nhập vào
             * @returns {Boolean} true nếu đúng định dạng
             * CreatedBy: NTDUNG (31/08/2021)
             * ModifiedBy: NTDUNG (31/08/2021)
             */
            validPhone: function (phone) {
                var regPhone = /^[+]?[\s./0-9]*[(]?[0-9]{1,4}[)]?[-\s./0-9]*$/g;
                return regPhone.test(phone);
            },
        }
	};
</script>
<style lang=""></style>
