angular.module('app').controller('LeaseDetailController', function ($scope, $stateParams, LeaseResource) {

    $scope.lease = LeaseResource.get({ leaseId: $stateParams.id });

    $scope.saveLease = function () {
        $scope.lease.$update(function () {
            alert('save successful')
        }
          );
    }

});