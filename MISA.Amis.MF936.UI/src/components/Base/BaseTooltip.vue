<template lang="">
	<div
		v-show="tooltipState"
		class="tooltip"
		:style="{ top: tooltipTop + 20 + 'px', left: tooltipLeft + 'px' }"
	>
		{{ tooltipContent }}
	</div>
</template>
<script>
	// LIBRARY
	import { EventBus } from "../../main.js";

	export default {
		name: "BaseTooltip",
		data() {
			return {
				tooltipContent: "Nguyễn Tiến Dũng",
				tooltipState: false,
				tooltipTop: -100,
				tooltipLeft: -100,
			};
		},
		created() {
			/**
			 * Lắng nghe sự kiện hiển thị tooltip
			 * CreatedBy: NTDUNG (28/08/2021)
			 */
			EventBus.$on("showTooltip", (data) => {
				console.log(data);
				this.tooltipState = true;
				this.tooltipContent = data['message'];
                this.tooltipTop = data['top'];
                this.tooltipLeft = data['left'];
			});
			/**
			 * Lắng nghe sự kiện ẩn tooltip
			 * CreatedBy: NTDUNG (28/08/2021)
			 */
			EventBus.$on("hideTooltip", () => {
				this.tooltipState = false;
			});
		},
		destroy() {
			// Huỷ các sự kiện
			EventBus.$off("hideTooltip");
			EventBus.$off("showTooltip");
		},
	};
</script>
<style lang=""></style>
