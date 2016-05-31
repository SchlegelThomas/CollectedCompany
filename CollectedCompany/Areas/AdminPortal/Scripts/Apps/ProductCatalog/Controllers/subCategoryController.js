(function () {
    'use strict';

    function subCategoryController(dataService, $stateParams) {
        var vm = this;
        vm.LookupId = $stateParams.id;



        function activate() {

        };


        activate();

    };

    angular.module('ProductCatalog').controller('subCategoryController', subCategoryController);

    subCategoryController.$inject = ['dataService', '$stateParams'];



})();