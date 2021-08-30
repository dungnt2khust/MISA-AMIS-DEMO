<template lang="">
    <div class="input-wrapper">
        <span class="label"> {{ label }} <span v-if="required" class="text-red">*</span></span> 
        <div class="input__main">
            <input type="text" placeholder="DD/MM/YYYY" class="input input--date">
<!-- @blur="datePickerState = false" -->
            <span tabindex="0"  @click="datePickerState = !datePickerState" class="input__icon"></span>
            <base-date-picker
                :datePickerState="datePickerState"
            /> 
        </div>
    </div>
</template>
<script>
    // COMPONENTS
    import BaseDatePicker from './BaseDatePicker.vue'
    export default {
        name: 'BaseInputDate',
        components: {
            BaseDatePicker
        },
        props: {
            label: {
                type: String, 
                default: ''
            },
            required: {
                type: Boolean,
                default: false
            }
        },
        data() {
            return {
                datePickerState: false
            }
        },
        watch: {
            
        }
    }
</script>
<style lang="">
    
</style>