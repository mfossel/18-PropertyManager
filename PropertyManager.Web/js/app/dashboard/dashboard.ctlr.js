angular.module('app').controller('DashboardController', function ($scope, AuthenticationService) {
    $scope.logout = function () {
        AuthenticationService.logout().then(
            function () {
                location.replace('/#/app/home')
            }
        );
    };
});