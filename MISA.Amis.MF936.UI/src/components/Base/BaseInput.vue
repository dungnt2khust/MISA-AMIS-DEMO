<template lang="">
    <div class="input-wrapper">
        <span class="label"> {{ label }} <span v-if="required" class="text-red">*</span></span> 
        <input :title="isError ? label + error : ''" type="text" class="input">
    </div>
</template>
<script>
export default {
    name: 'BaseInput',
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
            isError: true,
            error: ' không được để trống'
        }
    }
}
</script>
<style lang="">
    
</style>