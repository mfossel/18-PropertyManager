angular.module('app').controller('DashboardController', function ($scope, WorkOrderResource) {

    function activateDash() {
        $scope.workordershigh = WorkOrderResource.high();
    }

    activateDash();

});