<template lang="">
    <div v-if="loadingState" class="loading">
        <div class="loading__icon"></div> 
    </div>
</template>
<script>
export default {
    name: 'TheLoading',
    props: {
        loadingState: {
            type: Boolean,
            default: false
        }
    }
}
</script>
<style lang="">
    
</style>