angular.module('app').controller('LeaseCreateController', function ($scope, $stateParams, LeaseResource, TenantResource, PropertyResource) {
    $scope.lease = {};
    $scope.newLease = {};
    $scope.tenants = TenantResource.query();
    $scope.properties = PropertyResource.query();
    $scope.createLease = function () {
        LeaseResource.save($scope.newLease, function () {
            $scope.newLease = {};
            toastr.success('Lease Created!');
        });
    };
});