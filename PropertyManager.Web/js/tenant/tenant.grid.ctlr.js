angular.module('app').controller('TenantGridController', function ($scope, TenantResource) {
    function activate() {
        $scope.tenants = TenantResource.query();
    }

    activate();

    $scope.deleteTenant = function (tenant) {
        tenant.$remove(function (data) {
            activate();
        })

    };


});