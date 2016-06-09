(function () {

    function initTable() {
        $('#StaffTable').DataTable({
            "lengthChange": false,
            "searching": true,
            "pageLength": 10,
            "oLanguage": {
                "sSearch": "",
                "sInfo": "_START_ to _END_ of _TOTAL_ "
            },
            "pagingType": "simple_numbers",
            "language": {
                "info": "_PAGE_ of _PAGES_"
            }
        });
    };

    function loadStaff() {

        $('#FocusSection').load('/AdminPortal/Staff/StaffList', function () {
            initTable();
        });

    };


    $(document).ready(function () {

        $(document).on('click', '#NewStaff', function() {
            $.showDialogModal('Add new staff',
                    '<input name=\"FirstName\" type=\"text\" placeholder=\"First Name\" class=\"half\" required />' +
                    '<input name=\"LastName\" type=\"text\" placeholder=\"Last Name\" class=\"half\" required />' +
                    '<input name=\"Password\" type=\"password\" placeholder=\"******\" class=\"half\" required />' +
                    '<input name=\"Email\" type=\"text\" placeholder=\"Email\" class=\"full\" required />',
            [
                $.extend({}, vex.dialog.buttons.YES, { text: 'Save' }), $.extend({}, vex.dialog.buttons.NO, { text: 'Cancel' })
            ], function (data) {
                if (data === false) {
                    return false;
                } else {
                    var model = {
                        BusinessEmail: data.Email,
                        ContactFirstName: data.FirstName,
                        ContactLastName: data.LastName
                    };
                    $.ajax({
                        type: "POST",
                        url: "/AdminPortal/Staff/AddStaff?firstName=" + encodeURIComponent(data.FirstName) + "&lastName=" + encodeURIComponent(data.LastName)
                            + "&email=" + encodeURIComponent(data.Email) + '&tempPassword=' + encodeURIComponent(data.Password),
                        contentType: 'application/json',
                        success: function (response) {
                            if (response.Success) {
                                loadStaff();
                            } else {
                                
                                $.showAlertModal(response.Errors, $.noop);
                            }
                        },
                        error: function (jqXHR, textStatus, errorThrown) {
                            $.showAlertModal('Error saving staff : (', $.noop);
                        }
                    });

                }
            });

        });

        $(document).on('click', '.permission-button', function() {
            var self = $(this);
            $(self).toggleClass('check');
        });

        initTable();
    });


})();