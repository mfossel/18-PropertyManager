angular.module('app').controller('TenantCreateController', function ($scope, $stateParams, TenantResource) {
    $scope.tenant = {};

    $scope.newTenant= {};

    $scope.createTenant = function () {
        TenantResource.save($scope.newTenant, function () {
            $scope.newTenant = {};
        });
    };
});