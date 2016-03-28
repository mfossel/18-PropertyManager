﻿angular.module('app').controller('PropertyCreateController', function ($scope, $stateParams, PropertyResource) {

    $scope.newProperty= {};

    $scope.createProperty = function () {
        PropertyResource.save($scope.newProperty, function () {
            $scope.newProperty = {};
            toastr.success('Property Created!');
        });
    };
});