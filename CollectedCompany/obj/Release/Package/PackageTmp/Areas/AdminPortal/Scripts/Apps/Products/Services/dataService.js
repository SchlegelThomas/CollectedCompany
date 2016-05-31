(function () {
    'use strict';

    function dataService($http) {

        function onSuccess(response) {
            return response;
        };

        function onFail(response) {
            alert(response.Success);
        };

        function getProducts() {

            return $http.get('/AdminPortal/ProductCatalog/GetProducts', { cache: true })
            .then(onSuccess)
            .catch(onFail);

        };

        function getCategories() {

            return $http.get('/AdminPortal/ProductCatalog/GetCategories', { cache: true })
            .then(onSuccess)
            .catch(onFail);

        };

        function getSubCategories() {

            return $http.get('/AdminPortal/ProductCatalog/GetSubCategories', { cache: true })
                .then(onSuccess)
                .catch(onFail);

        };

        function getTags() {

            return $http.get('/AdminPortal/ProductCatalog/GetTags', { cache: true })
                .then(onSuccess)
                .catch(onFail);

        };


        function getProductById(productId) {
            
            return $http.get('/AdminPortal/ProductCatalog/GetProductById?id='+encodeURIComponent(productId))
                .then(onSuccess)
                .catch(onFail);

        };

        function getCategoryById(productId) {

            return $http.get('/AdminPortal/ProductCatalog/GetCategoryById?id=' + encodeURIComponent(productId))
                .then(onSuccess)
                .catch(onFail);

        };

        function getSubCategoryById(productId) {

            return $http.get('/AdminPortal/ProductCatalog/GetSubCategoryById?id=' + encodeURIComponent(productId))
                .then(onSuccess)
                .catch(onFail);

        };

        function getTagById(productId) {

            return $http.get('/AdminPortal/ProductCatalog/GetTagById?id=' + encodeURIComponent(productId))
                .then(onSuccess)
                .catch(onFail);

        };

        


        return {
            getProducts: getProducts,
            getCategories: getCategories,
            getSubCategories: getSubCategories,
            getTags: getTags,
            getProductById: getProductById,
            getCategoryById: getCategoryById,
            getSubCategoryById: getSubCategoryById,
            getTagById: getTagById,
        };

    };

    angular.module('ProductCatalog').factory('dataService', dataService);

    dataService.$inject = ['$http'];

    

})();