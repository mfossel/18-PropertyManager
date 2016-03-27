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