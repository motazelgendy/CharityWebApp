var datatable;
$(document).ready(function () {
 datatable =   $('#DT_load').DataTable({
        "ajax": {
         "url": "/api/OrderList",
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "id", "width": "15%" },
            { "data": "orderTotal", "width": "15%" },
            { "data": "status", "width": "15%" },
            { "data": "appUser.firstName", "width": "15%" },
            { "data": "appUser.lastName", "width": "15%" },
            { "data": "orderDate", "width": "15%" },

            {
                "data": "id",
                "render": function (data) {
                    return `<div class="w-75 btn-group" >
                            <a href="/Admin/Order/OrderDetails?id=${data}"  class="btn btn-success text-white mx-2">
                            <i class="bi bi-pencil-square"></i>  </a>
                            
                            </div>`
                    
                },
                "width": "15%"
            }
           ],
        "width": "100%",
        "language": {
            "sProcessing": "جارٍ التحميل...",
            "sLengthMenu": "أظهر _MENU_ مدخلات",
            "sZeroRecords": "لم يعثر على أية سجلات",
            "sInfo": "إظهار _START_ إلى _END_ من أصل _TOTAL_ مدخل",
            "sInfoEmpty": "يعرض 0 إلى 0 من أصل 0 سجل",
            "sInfoFiltered": "(منتقاة من مجموع _MAX_ مُدخل)",
            "sInfoPostFix": "",
            "sSearch": "بحث:",
            "sUrl": "",
            "oPaginate": {
                "sFirst": "الأول",
                "sPrevious": "السابق",
                "sNext": "التالي",
                "sLast": "الأخير"
            }
        }
    });
});

