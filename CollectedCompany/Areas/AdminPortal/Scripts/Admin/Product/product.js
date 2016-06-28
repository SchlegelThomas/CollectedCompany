(function () {

    function emptyGuid() {

        var blankGuid = $('#EmptyGuid').val();

        return blankGuid;
    };


    function initTable() {
        $('#ProductListingTable').DataTable({
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

    function loadProductsListing() {

        $('#FocusSection').load('/AdminPortal/Product/ProductListing', function () {
            initTable();
        });

    };

    function deleteProduct(id) {
        $.makeAjaxPost('/AdminPortal/Product/DeleteProduct?productId=' + encodeURIComponent(id), null).then(function () {
            loadProductsListing();
        });
    };

    function loadProductDetails(id) {

        $('#FocusSection').load('/AdminPortal/Product/ProductDetails?productId=' + encodeURIComponent(id), function (response) {
            var productId = $('#ProductId').val();
            var blankGuid = emptyGuid();
            if (productId != blankGuid) {
                $('#ImageUpload').fadeIn();
                $('#ImageDropZone').dropzone({ url: '/AdminPortal/Product/SaveImageToGallery?productId=' + productId, uploadMultiple: true, createImageThumbnails: true });
                $('#MainImageDropDown').dropzone({ url: '/AdminPortal/Product/SaveImage?productId=' + productId, uploadMultiple: false, createImageThumbnails: true, dictDefaultMessage: 'Drop or click to upload' });
            }
        });

    };


    $(document).ready(function () {

        $(document).on('click', '#AddNewProduct', function () {

            loadProductDetails(emptyGuid());
        });

        $(document).on('click', '.fa-edit', function () {
            var self = $(this);
            var id = $(self).attr('data-id');

            loadProductDetails(id);

        });

        $(document).on('click', '.delete-product', function () {
            var self = $(this);
            var id = $(self).attr('data-id');
            $.showConfirmModal('Are you sure you want to delete this product', function (ok) {
                if (ok) {
                    deleteProduct(id);
                }
            });

        });


        $(document).on('click', '#SaveProduct', function () {
            var title = $('#Title').val();
            var description = $('#Description').val();

            $.makeAjaxPost('/AdminPortal/Product/SaveProduct?title=' + encodeURIComponent(title) + '&description=' + encodeURIComponent(description), null).then(function (response) {
                $('#ProductId').val(response.Id);
                $('#ImageUpload').fadeIn();
                $('#ImageDropZone').dropzone({ url: '/AdminPortal/Product/SaveImageToGallery?productId=' + response.Id, uploadMultiple: true, createImageThumbnails: true });
                $('#MainImageDropDown').dropzone({ url: '/AdminPortal/Product/SaveImage?productId=' + response.Id, uploadMultiple: false, createImageThumbnails: true, dictDefaultMessage: 'Drop or click to upload' });
            });
        });

        $(document).on('click', '#BackToProducts', function () {
            loadProductsListing();
        });


        loadProductsListing();
    });


})();