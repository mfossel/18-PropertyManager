angular.module('app').controller('RegisterController', function ($scope, $timeout, AuthenticationService) {
    $scope.registration = {};

    $scope.register = function () {
        AuthenticationService.register($scope.registration).then(
            function (response) {
                alert("Registration successful!");
                $timeout(function () {
                    location.replace('/#/login');
                }, 2000);

            },
            function (error) {
                alert("Failure.");

            }
         )

    };

});