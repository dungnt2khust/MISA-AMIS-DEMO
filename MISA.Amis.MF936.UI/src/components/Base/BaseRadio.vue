<template lang="">
	<div class="radio">
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
				currIdx: 0,
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
			}
		},
		watch: {
			// currIdx: function(options) {
			// 	this.$emit('selectedARadio', options);
			// }
			/**
			 * Bắt sự kiện thay đổi giá trị truyền vào
			 * @param {number} value
			 * CreatedBy: NTDUNG (31/08/2021)
			 */
			value: function(value) {
				if (value !== null)
					this.currIdx = value;
			}
		}
	};
</script>
<style lang=""></style>
