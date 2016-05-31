(function () {
    'use strict';

    function productController(dataService, $stateParams) {
        var vm = this;
        vm.lookupId = $stateParams.id;
        vm._model = {};

        function getProduct(id) {
            return dataService.getProductById(id)
                .then(function (data) {
                    vm._model = data.data.Data;
                    return vm._model;
                });
        };


        function activate() {
            return getProduct(vm.lookupId).then(function () {

            });
        };


        activate();

    };

    angular.module('ProductCatalog').controller('productController', productController);

    productController.$inject = ['dataService', '$stateParams'];

    

})();