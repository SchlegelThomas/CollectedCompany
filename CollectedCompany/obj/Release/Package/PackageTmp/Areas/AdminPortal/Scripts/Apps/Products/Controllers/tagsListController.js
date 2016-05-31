(function () {
    'use strict';

    function tagListController(dataService, $stateParams) {
        var vm = this;
        vm._tags = [];
        vm.search = { $: $stateParams.queryString };


        function getTags() {
            return dataService.getTags()
                .then(function (data) {
                    vm._tags = data.data.Data;
                    return vm._tags;
                });
        };


        function activate() {
            return getTags().then(function () {

            });
        };


        activate();

    };


    angular.module('ProductCatalog').controller('tagListController', tagListController);

    tagListController.$inject = ['dataService', '$stateParams'];



})();