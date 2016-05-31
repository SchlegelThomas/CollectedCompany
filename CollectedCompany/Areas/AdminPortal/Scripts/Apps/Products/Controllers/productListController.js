(function () {
    'use strict';

    function productListController(dataService, $stateParams) {
        var vm = this;
        vm._products = [];
        vm.search = { $: "" };
        vm.categorySearch = { $: $stateParams.queryType == 'Category' ? $stateParams.queryString : ""};
        vm.subCategorySearch = { $: $stateParams.queryType == 'SubCategory' ? $stateParams.queryString : "" };
        vm.tagSearch = { $: $stateParams.queryType == 'Tag' ? $stateParams.queryString : "" };
        vm.searchType = $stateParams.queryType || "";
        vm.classicSearch = false;
        vm.toggleClassicSearch = function() {
            vm.classicSearch = !vm.classicSearch;
        };


        function getProducts() {
            return dataService.getProducts()
                .then(function (data) {
                    vm._products = data.data.Data;
                    return vm._products;
                });
        };


        function activate() {
            
            return getProducts().then(function () {

            });
            
        };


        activate();

    };

    
    angular.module('ProductCatalog').controller('productListController', productListController);

    productListController.$inject = ['dataService', '$stateParams'];



})();