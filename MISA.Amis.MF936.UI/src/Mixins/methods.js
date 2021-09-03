export default {
	methods: {
		/**
		 * So sánh 2 object
		 * @param {Object} object1
		 * @param {Object} object2
		 * CreatedBy: NTDUNG (03/09/2021)
		 */
		compareObjects(object1, object2) {
			// Mặc định là trùng
			var duplicate = true;

			// Duyệt từng thuộc tính của object 1
			// Khi có một giá trị khác thì break và gán là false
			for (var prop in object1) {
				if (prop.includes("Date")) {
					// Trường hợp là date

					// Khi cả 2 giá trị đều khách null
					if (object1[prop] && object2[prop]) {
						// Chỉ so sánh ngày tháng năm
						if (
							object1[prop].substring(0, 10) !== object2[prop].substring(0, 10)
						) {
							duplicate = false;
							break;
						}
						// Khi một trong 2 bằng null
					} else if (
						(!object1[prop] &&
						object2[prop]) ||
						(object1[prop] && !object2[prop])
					) {
						duplicate = false;
						break;
					}
				} else {
					// Trường hợp bình thường

					// Khi cả 2 giá trị đều khách null
					if (object1[prop] && object2[prop]) {
						if (object1[prop] != object2[prop]) {
							duplicate = false;
							break;
						}
						// Khi một trong 2 bằng null
					} else if (
						(!object1[prop] &&
						object2[prop]) ||
						(object1[prop] && !object2[prop])
					) {
						duplicate = false;
						break;
					}
				}
			}
			return duplicate;
		},
		/**
		 * Hàm tính ra element cha chứa lớp được truyền vào
		 * @param {Element} childE
		 * @param {String} parentClass
		 */
		findParentByClass(childE, parentClass) {
			var parentE = childE;
			// Nếu không chứa class thì tiếp tục vòng lặp
			while (parentE.classList.contains(parentClass) == false) {
				// Đi ra một element cha
				parentE = parentE.parentElement;

				// Khi đã duyệt hết mà không có thì set null và thoát vòng lặp
				if (parentE.tagName == "BODY") {
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
	},
};
