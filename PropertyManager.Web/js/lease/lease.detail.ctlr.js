angular.module('app').controller('LeaseDetailController', function ($scope, $stateParams, LeaseResource) {
    $scope.workOrder = LeaseResource.get({ workOrderId: $stateParams.id });

    $scope.saveLease = function () {
        $scope.lease.$update(function () {
            alert('save successful')
        }
          );
    }
});