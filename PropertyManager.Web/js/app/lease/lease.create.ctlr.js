angular.module('app').controller('LeaseCreateController', function ($scope, $stateParams, LeaseResource) {
    $scope.lease = {};
    $scope.newLease = {};

    $scope.createLease = function () {
        LeaseResource.save($scope.newLease, function () {
            $scope.newLease = {};
        });
    };
});