<template lang="">
    <div class="selectbox">
        <span class="selectbox__value">{{ selectboxData[currIdx] }}</span>
        <ul class="selectbox__list">
            <li v-for="(item, index) in selectboxData" class="selectbox__item" :key="index">
                {{ item }}
            </li>
        </ul>
    </div>
</template>
<script>
export default {
    name: 'BaseSelectBox',
    data() {
        return {
            currIdx: 1,
            selectboxData: [
                '20 bản ghi trên 1 trang',
                '30 bản ghi trên 1 trang',
                '40 bản ghi trên 1 trang',
                '50 bản ghi trên 1 trang',
                '60 bản ghi trên 1 trang',
            ]
        }
    }
}
</script>
<style lang="">
    
</style>