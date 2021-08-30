<template lang="">
	<div class="radio">
		<div v-if="label != ''" class="label">{{ label }}</div>
		<div class="radio__list fx">
			<div
				v-for="(item, index) in value"
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
			value: {
				type: Array,
				default: function() {
					return [];
				},
			},
			label: {
				type: String,
				default: "",
			},
			tabindex: {
				type: Number,
				default: 0
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
						if (this.currIdx != this.value.length - 1) 
							this.currIdx++;
						else 
							this.currIdx = 0;
						this.$refs['radio' + this.currIdx][0].focus();
						break;
					case 'ArrowLeft':
						if (this.currIdx != 0)
							this.currIdx--;
						else 
							this.currIdx = this.value.length - 1;	
						this.$refs['radio' + this.currIdx][0].focus();
						break;
					case 'Enter':
						this.currIdx = index;
						break;
				}
			}
		}
	};
</script>
<style lang=""></style>
