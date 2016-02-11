angular.module('app').controller('LeaseDetailController', function ($scope, $stateParams, LeaseResource) {
    $scope.workOrder = {};

    $scope.saveLease = function () {
        $scope.lease.$update(function () {
            alert('save successful')
        }
          );
    }
});