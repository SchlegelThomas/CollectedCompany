(function () {

    function setCategoryName(val) {
        $('#Category').html(val + '<span class="fa fa-caret-down"></span>');
    };

    function setResponseGroup(val) {
        $('#ResponseGroup').html(val + '<span class="fa fa-caret-down"></span>');
    };

    $(document).ready(function () {

        $(document).on('click', '#Search', function () {
            var category = $('#CategoryId').val();
            var terms = $('#SearchTerms').val();
            var response = $('#ResponseGroupId').val();

            $('#SearchResults').load('/AdminPortal/Amazon/Search?searchTerms=' + encodeURIComponent(terms) + '&category=' + category, function () {
                $('#SearchResultsTable').DataTable({
                    responsive: true
                });

            });

        });


        $(document).on('click', '.category-select', function () {
            var self = $(this);
            $('.category-select').removeClass('selected');
            $(self).addClass('selected');
            $('#CategoryId').val($(self).attr('data-id'));
            setCategoryName($(self).text());
        });

        $(document).on('click', '.response-select', function () {
            var self = $(this);
            $('.response-select').removeClass('selected');
            $(self).addClass('selected');
            $('#ResponseGroupId').val($(self).attr('data-id'));
            setResponseGroup($(self).text());
        });

    });


})();
