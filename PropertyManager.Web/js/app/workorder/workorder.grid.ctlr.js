angular.module('app').controller('WorkOrderGridController', function ($scope, WorkOrderResource) {

    function activate() {
        $scope.workorders = WorkOrderResource.query();
    }

    activate();

    $scope.deleteWorkOrder = function (workorder) {
        workorder.$remove(function (data) {
            toastr.error('Workorder Deleted');
            activate();
        })

    };




});