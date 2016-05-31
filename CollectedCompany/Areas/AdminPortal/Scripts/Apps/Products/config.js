(function () {
    'use strict';


    angular.module('ProductCatalog').config(function ($stateProvider, $urlRouterProvider) {
        var viewsLocation = '/Areas/AdminPortal/Scripts/Apps/ProductCatalog/Views/';
        // For any unmatched url, send to /route1
        $urlRouterProvider.otherwise("/CategoryList?Categories");

        $stateProvider
            .state('ProductList', {
                url: '/ProductList?:{queryString}&:{queryType}',
                controller: 'productListController',
                views: {
                    "main": {
                        templateUrl: viewsLocation + "ProductList.html"
                    }
                }
            })
            .state('CategoryList', {
                url: '/CategoryList',
                controller: 'categoryListController',
                views: {
                    "main": {
                        templateUrl: viewsLocation + "CategoryList.html"
                    }
                }
            })
            .state('SubCategoryList', {
                url: '/SubCategoryList',
                controller: 'subCategoryListController',
                views: {
                    "main": {
                        templateUrl: viewsLocation + "SubCategoryList.html"
                    }
                }

            })
            .state('TagList', {
                url: '/TagList',
                controller: 'tagListController',
                views: {
                    "main": {
                        templateUrl: viewsLocation + "TagsList.html"
                    }
                }
            })
            .state('Product', {
                url: '/Product?:{id}',
                controller: 'productController',
                views: {
                    "main": {
                        templateUrl: viewsLocation + "Product.html"
                    },
                    "test": {
                        templateUrl: viewsLocation + "RelatedProduct.html",
                        controller: 'relatedProductController'
                    }
                }
            })
            .state('Category', {
                url: '/Category?:{id}',
                controller: 'categoryController',
                views: {
                    "main": {
                        templateUrl: viewsLocation + "Category.html"
                    }
                }
            })
            .state('SubCategory', {
                url: '/SubCategory?:{id}',
                controller: 'subCategoryController',
                views: {
                    "main": {
                        templateUrl: viewsLocation + "SubCategory.html"
                    }
                }
            })
            .state('Tag', {
                url: '/Tag?:{id}',
                controller: 'tagController',
                views: {
                    "main": {
                        templateUrl: viewsLocation + "Tag.html"
                    }
                }
            });

    });


})();