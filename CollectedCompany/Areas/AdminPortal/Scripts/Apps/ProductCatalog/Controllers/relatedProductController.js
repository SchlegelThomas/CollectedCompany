(function () {
    'use strict';

    function relatedProductController(dataService, $stateParams) {
        var vm = this;
        vm.lookupId = $stateParams.id;
        vm._relatedProducts = [];


        function getRelatedProducts() {
            return dataService.getProducts()
                .then(function (data) {
                    vm._relatedProducts = data.data.Data;
                    return vm._relatedProducts;
                });
        };


        function activate() {
            return getRelatedProducts().then(function () {

            });
        };


        activate();

    };


    angular.module('ProductCatalog').controller('relatedProductController', relatedProductController);

    relatedProductController.$inject = ['dataService', '$stateParams'];



})();