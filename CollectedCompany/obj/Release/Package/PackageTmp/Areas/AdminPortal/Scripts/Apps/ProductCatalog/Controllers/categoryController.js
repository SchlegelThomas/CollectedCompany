(function () {
    'use strict';

    function categoryController(dataService, $stateParams) {
        var vm = this;
        vm.LookupId = $stateParams.id;



        function activate() {

        };


        activate();

    };

    angular.module('ProductCatalog').controller('categoryController', categoryController);

    categoryController.$inject = ['dataService', '$stateParams'];



})();