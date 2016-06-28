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

        $(document).on('click', '#NewStaff', function () {
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
                    $.ajax({
                        type: "POST",
                        url: "/AdminPortal/Staff/AddStaff?firstName=" + encodeURIComponent(data.FirstName) + "&lastName=" + encodeURIComponent(data.LastName)
                            + "&email=" + encodeURIComponent(data.Email) + '&tempPassword=' + encodeURIComponent(data.Password),
                        contentType: 'application/json',
                        success: function (response) {
                            if (response.Success) {
                                toastr.success('Add Successful', 'General Settings');
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

        $(document).on('click', '.edit-listing', function () {
            var self = $(this);
            var id = $(self).attr('data-id');
            $.makeAjaxGet('/AdminPortal/Staff/EditStaff?id=' + id, null).then(function (response) {
                $.showDialogModal('Edit Staff',
                    '<input name=\"FirstName\" type=\"text\" placeholder=\"First Name\" class=\"half\" value=\"' + response.Data.UserAccount.FirstName + '\" required />' +
                    '<input name=\"LastName\" type=\"text\" placeholder=\"Last Name\" class=\"half\" value=\"' + response.Data.UserAccount.LastName + '\" required />' +
                    '<input name=\"Email\" type=\"text\" placeholder=\"Email\" class=\"full\" value=\"' + response.Data.UserAccount.Email + '\" required />',
                    [
                        $.extend({}, vex.dialog.buttons.YES, { text: 'Save' }), $.extend({}, vex.dialog.buttons.NO, { text: 'Cancel' })
                    ], function (data) {
                        if (data === false) {
                            return false;
                        } else {
                            $.ajax({
                                type: "POST",
                                url: "/AdminPortal/Staff/AddStaff?firstName=" + encodeURIComponent(data.FirstName) + "&lastName=" + encodeURIComponent(data.LastName)
                                    + "&email=" + encodeURIComponent(data.Email) + '&userId=' + encodeURIComponent(id),
                                contentType: 'application/json',
                                success: function (response) {
                                    if (response.Success) {
                                        toastr.success('Save Successful', 'General Settings');
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
        });

        $(document).on('click', '.delete-listing', function () {
            var self = $(this);
            var id = $(self).attr('data-id');
            $.showConfirmModal('Are you sure you want to delete your staff member?', function (ok) {
                if (ok) {
                    $.makeAjaxPost('/AdminPortal/Staff/DeleteStaff?userId=' + id, null).then(function () {
                        toastr.success('Delete Successful', 'Staff Update');
                        loadStaff();
                    });
                }
            });
        });

        $(document).on('click', '.permission-button', function () {
            var self = $(this);
            $(self).toggleClass('check');
            var role = $(self).attr('data-role');
            var id = $(self).attr('data-id');
            var active = $(self).hasClass('check');

            $.makeAjaxPost('/AdminPortal/Staff/UpdateRole?role=' + encodeURIComponent(role) + '&id=' + encodeURIComponent(id) + '&active=' + encodeURIComponent(active), null).then(function(response) {
                toastr.success('Save Successful', 'Staff Role');
            });
        });

        

        initTable();
    });


})();