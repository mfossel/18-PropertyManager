angular.module('app').controller('WorkOrderCreateController', function ($scope, $stateParams, WorkOrderResource) {
    $scope.workOrder = {};

    $scope.newWorkOrder = {};

    $scope.createWorkOrder = function () {
        WorkOrderResource.save($scope.newWorkOrder, function () {
            $scope.newWorkOrder = {};
        });
    };
});