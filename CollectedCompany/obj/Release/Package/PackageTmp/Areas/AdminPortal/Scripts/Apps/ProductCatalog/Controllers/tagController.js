(function () {
    'use strict';

    function tagController(dataService, $stateParams) {
        var vm = this;
        vm.LookupId = $stateParams.id;



        function activate() {

        };


        activate();

    };

    angular.module('ProductCatalog').controller('tagController', tagController);

    tagController.$inject = ['dataService', '$stateParams'];



})();