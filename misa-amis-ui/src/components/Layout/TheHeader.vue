<template lang="">
    <div id="header">
        <div class="header__left">
            <div @click="$emit('toggleOnClick')" class="header__toggle">
                <div class="header__toggle-icon"></div>
            </div>
            <div class="header__dropdown">HEADER DROPDOWN</div>
        </div>
        <div class="header__right">
            <div class="header__notify">
                <div class="header__notify-icon"></div>
            </div>
            <div class="header__account">
                <div class="header__avatar"></div>
                <div class="header__name">Nguyễn Tiến Dũng</div>
                <div class="header__account-dropdown"></div>
            </div>
        </div>
    </div>
</template>
<script>
export default {
    name: 'TheHeader'
}
</script>
<style lang="">
    
</style>