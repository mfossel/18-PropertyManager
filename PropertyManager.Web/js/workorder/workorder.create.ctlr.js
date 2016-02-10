angular.module('app').controller('WorkOrderCreateController', function ($scope, $stateParams, WorkOrderResource) {
    $scope.workOrder = WorkOrderResource.get({ workOrderId: $stateParams.id });

    $scope.newWorkOrder = {};

    $scope.createWorkOrder = function () {


        WorkOrderResource.save($scope.newWorkOrder, function () {
            $scope.newWorkOrder = {};
        });
    };
});