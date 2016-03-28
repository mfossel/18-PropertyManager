angular.module('app').controller('TenantDetailController', function ($scope, $stateParams, TenantResource) {
    $scope.tenant = TenantResource.get({ tenantId: $stateParams.id });

    $scope.saveTenant = function () {
        $scope.tenant.$update(function () {
            toastr.success('Save Successful.');
        }
          );
    }
});