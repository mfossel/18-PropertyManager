angular.module('app').controller('AppController', function ($scope, AuthenticationService) {
    $scope.logout = function () {
        AuthenticationService.logout().then(
            function () {
                location.replace('/#/app/home')
            }
        );
    };

});