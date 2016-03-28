angular.module('app').controller('WorkOrderDetailController', function ($scope, $stateParams, WorkOrderResource) {
    $scope.workOrder= WorkOrderResource.get({ workOrderId: $stateParams.id });

    $scope.saveWorkOrder = function () {
        $scope.workOrder.$update(function () {
            toastr.success('Save Successful.');
        }
          );
    }
});