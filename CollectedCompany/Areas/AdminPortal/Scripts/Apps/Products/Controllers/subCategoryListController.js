(function () {
    'use strict';

    function subCategoryListController(dataService, $stateParams) {
        var vm = this;
        vm._subcategories = [];
        vm.search = { $: $stateParams.queryString };


        function getSubCategories() {
            return dataService.getSubCategories()
                .then(function (data) {
                    vm._subcategories = data.data.Data;
                    return vm._subcategories;
                });
        };


        function activate() {
            return getSubCategories().then(function () {

            });
        };


        activate();

    };


    angular.module('ProductCatalog').controller('subCategoryListController', subCategoryListController);

    subCategoryListController.$inject = ['dataService', '$stateParams'];



})();