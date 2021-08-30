<template lang="">
	<div class="radio">
		<div v-if="label != ''" class="label">{{ label }}</div>
		<div class="radio__list fx">
			<div
				v-for="(item, index) in value"
				class="radio__item fx"
				:class="{ 'radio__item--selected': index == currIdx }"
                @click="currIdx = index"
				:key="index"
				:tabindex="tabindex + index"
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
	};
</script>
<style lang=""></style>
