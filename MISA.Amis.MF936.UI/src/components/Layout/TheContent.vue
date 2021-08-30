<template lang="">
    <div id="content">
        <div class="content__header">
            <div class="content__name">
                Nhân viên
            </div>
            <div @click="contentAddOnClick()" class="button button--green button--large" >
                Thêm mới nhân viên
            </div> 
        </div>
        <base-table
            :tableStyle="tableStyle"
            :tableData="tableData"
        />
    </div>
</template>
<script>
    // LIBRARY
    import axios from 'axios'

    // COMPONENT
    import BaseTable from '../Base/BaseTable.vue'

    export default {
        name: 'TheContent',
        components: {
            BaseTable
        },
        data() {
            return {
                tableStyle: [
                    {name: 'Mã nhân viên', field: 'EmployeeCode', style: 1},
                    {name: 'Tên nhân viên', field: 'FullName', style: 1},
                    {name: 'Giới tính', field: 'Gender', style: 1},
                    {name: 'Ngày sinh', field: 'DateOfBirth', style: 1},
                    {name: 'Số CMND/ CCCD', field: 'IdentityNumber', style: 1},
                    {name: 'Chức danh', field: 'PossitionName', style: 1},
                    {name: 'Tên đơn vị', field: 'DepartmentName', style: 1},
                    {name: 'Số tài khoản', field: 'BankAccount', style: 1},
                    {name: 'Tên ngân hàng', field: 'BankName', style: 1},
                    {name: 'Chi nhánh ngân hàng', field: 'BankBranch', style: 1}
                ],
                tableData: []
            }
        },
        mounted() {
            // Lấy dữ liệu bảng từ API
            axios.get('https://localhost:44342/api/v1/employees')
                .then(res => {
                    // Gán dữ liệu vào biến prop sang BaseTable
                    console.log(res);
                    this.tableData = res.data;
                })
                .catch(res => {
                    console.log(res);
                })
        },
        methods: {
            func() {
                this.func2();
            },
            func2() {
                this.func3();
            },
            func3() {
                console.log('end')
            },
            /**
             * Sự kiện nhấn vào nút Add
             * CreatedBy: NTDUNG (29/08/2021)
             */
            contentAddOnClick() {
                this.$bus.$emit('showForm', 'Add');
            }
        }
    }
</script>
<style lang="">
    
</style>