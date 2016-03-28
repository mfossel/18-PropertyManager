angular.module('app').controller('WorkOrderCreateController', function ($scope, $stateParams, WorkOrderResource, TenantResource, PropertyResource) {
    $scope.tenants = TenantResource.query();
    $scope.properties = PropertyResource.query();

    $scope.newWorkOrder = {};

    $scope.createWorkOrder = function () {
        WorkOrderResource.save($scope.newWorkOrder, function () {
            $scope.newWorkOrder = {};
            toastr.success('Work Order Created!');
        });
    };
});