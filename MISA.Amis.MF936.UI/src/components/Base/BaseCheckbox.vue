<template lang="">
    <div class="checkbox" :class="{'checkbox--selected': checkboxState}">
        <div class="checkbox__border">
            <div @click="checkboxState = !checkboxState" class="checkbox__main">
                <div class="checkbox__icon"></div>
            </div> 
        </div> 
        <span v-if="value != ''" class="checkbox__value"> {{ value }}</span>
    </div> 
</template>
<script>
export default {
    name: 'BaseCheckbox',
    props: {
        value: {
            type: String,
            default: ''
        }
    },
    data() {
        return {
            checkboxState: false
        }
    }
}
</script>
<style lang="">
    
</style>