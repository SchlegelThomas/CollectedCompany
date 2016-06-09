(function () {
    'use strict';


    angular.module('ProductCatalog').component('dimparenthover',
       function () {
           return {
               link: function (scope, element, attrs) {
                   element.bind('mouseenter', function () {
                       $('#FocusSection').addClass('dim');
                   });
                   element.bind('mouseleave', function () {
                       $('#FocusSection').removeClass('dim');
                   });
               }
           };
       });

});