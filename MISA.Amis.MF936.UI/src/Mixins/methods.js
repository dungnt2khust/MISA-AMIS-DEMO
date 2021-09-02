export default {
    methods: {
        /**
         * Hàm tính ra element cha chứa lớp được truyền vào
         * @param {Element} childE
         * @param {String} parentClass
         */
        findParentByClass(childE, parentClass) {
            var parentE = childE;
            // Nếu không chứa class thì tiếp tục vòng lặp
            while (parentE.classList.contains(parentClass) == false) {
                // Đi ra một elemnt cha
                parentE = parentE.parentElement;

                // Khi đã duyệt hết mà không có thì set null và thoát vòng lặp
                if (parentE.tagName == 'BODY') {
                    parentE = null;
                    break;
                }
            }
            // Trả về kết quả
            return parentE;
        },
        /**
         * Format dữ liệu ngày tháng
         * @param {string} value
         * CreatedBy: NTDUNG (01/09/2021)
         */
        formatDate(value) {
            if (value) {
                var currDate = new Date(value);
                var date = currDate.getDate();
                var month = currDate.getMonth() + 1;
                var year = currDate.getFullYear();

                return `${date}/${month}/${year}`;
            }
            return null;
        },
    }
}