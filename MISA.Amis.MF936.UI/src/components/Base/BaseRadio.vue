<template lang="">
	<div class="radio">
		<div style="display: none"> {{ defaultIndex()}} </div>
		<div v-if="label != ''" class="label">{{ label }}</div>
		<div class="radio__list fx">
			<div
				v-for="(item, index) in options"
				class="radio__item fx"
				:class="{ 'radio__item--selected': index == currIdx }"
                @click="currIdx = index"
				@keydown="radioItemOnKeydown($event, index)"
				:key="index"
				tabindex="0"
				:ref="'radio' + index"
			>
				<div class="radio__border">
					<div class="radio__main">
						<div class="radio__icon"></div>
					</div>
				</div>
				<div class="radio__value">{{ item }}</div>
			</div>
		</div>
	</div>
</template>
<script>
	export default {
		name: "BaseRadio",
		props: {
			options: {
				type: Array,
				default: function() {
					return [];
				},
			},
			label: {
				type: String,
				default: "",
			},
			value: {
				type: Number,
				default: null
			}	
		},
		data() {
			return {
				currIdx: this.value !== null ? this.value : -1
			};
		},
		methods: {
			/**
			 * Bắt sự kiện nhấn phím mũi tên để di chuyển
			 * @param {event} event 
			 * @param {number} index
			 * CreatedBy: NTDUNG (30/08/2021)
			 */
			radioItemOnKeydown(event, index) {
				switch(event.key) {
					case 'ArrowRight':
						if (this.currIdx != this.options.length - 1) 
							this.currIdx++;
						else 
							this.currIdx = 0;
						this.$refs['radio' + this.currIdx][0].focus();
						break;
					case 'ArrowLeft':
						if (this.currIdx != 0)
							this.currIdx--;
						else 
							this.currIdx = this.options.length - 1;	
						this.$refs['radio' + this.currIdx][0].focus();
						break;
					case 'Enter':
						this.currIdx = index;
						break;
				}
			},
			/**
			 * Đặt giá trị mặc định cho radio khi không có giá trị truyền vào
			 * @return {Number} Giá trị mặc định
			 * CreatedBy: NTDUNG (03/09/2021)
			 */
			defaultIndex() {
				if (this.value == null) {
					this.$emit('input', 0);
				}
				return 0;
			}
		},
		watch: {
			/**
			 * Khi thay đổi giá trị hiện tại thì emit ra ngoài component cha
			 * @param {Number} option lựa chọn hiện tại
			 * CreatedBy: NTDUNG (02/09/2021)
			 */	
			currIdx: function(option) {
				this.$emit('input', option);
			},
			/**
			 * Bắt sự kiện thay đổi giá trị truyền vào
			 * @param {number} value
			 * CreatedBy: NTDUNG (31/08/2021)
			 */
			value: function(value) {
				if (value !== null)
					this.currIdx = value;
				else 
					this.currIdx = 0;
			}
		}
	};
</script>
<style lang=""></style>
