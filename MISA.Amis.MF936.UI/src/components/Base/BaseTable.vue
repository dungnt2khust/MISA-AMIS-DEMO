<template lang="">
    <div class="table-wrapper">
        <!-- TABLE CONTROL -->
        <div class="table__control">
            <input type="text" class="table__search">
            <div class="table__reload"></div>
        </div>
        <!-- TABLE -->
        <table class="table">
            <thead class="table__header">
                <tr class="table__row">
                    <td class="table__data">
                        <input type="checkbox" name="" id="" class="table__checkbox">
                    </td>
                    <td v-for="(item, index) in tableStyle" class="table__data" :key="index">
                        {{ item["name"] }}
                    </td>
                    <td class="table__data">Chức năng</td>
                </tr>
            </thead>
            <tbody class="table__body">
                <tr v-for="(item, index) in tableData" class="table__row" :key="index">
                    <td class="table__data table__data--checkbox">                    
                        <input type="checkbox" name="" id="" class="table__checkbox">
                    </td>
                    <td v-for="(itm, idx) in tableStyle"  class="table__data" :key="idx">
                        {{ item[itm["field"]] }}
                    </td>
                    <td class="table__data">
                        <div class="table__function">Sửa</div>
                    </td>
                </tr>
            </tbody> 
        </table>
    </div>
</template>
<script>
export default {
    name: 'BaseTable', 
    props: {
        tableStyle: {
            type: Array,
            default: function() {
                return [];
            }
        },
        tableData: {
            type: Array,
            default: function() {
                return [];
            }
        }
    }
}
</script>
<style lang="">
    
</style>