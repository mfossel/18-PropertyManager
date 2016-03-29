angular.module('app').controller('DashboardController', function ($scope, AuthenticationService, DashboardResource) {

function activate() {
    DashboardResource.getHighPriority().then(function (response) {
        $scope.highPriorityWorkorders = response;


    });

    DashboardResource.getPropertyCount().then(function (response) {
        $scope.propertyCount = response;


    });

    DashboardResource.getTenantCount().then(function (response) {
        $scope.tenantCount = response;


    });

    DashboardResource.getLeaseCount().then(function (response) {
        $scope.leaseCount = response;


    });

    DashboardResource.getNewTenants().then(function (response) {
        $scope.newTenants = response;


    });


    DashboardResource.getNewProperties().then(function (response) {
        $scope.newProperties = response;


    });

   
}

    activate();


    $scope.logout = function () {
        AuthenticationService.logout().then(
            function () {
                location.replace('/#/app/home')
            }
        );
    };
});