angular.module('app').controller('PropertyGridController', function ($scope, PropertyResource) {
   
    function activate() {
        $scope.properties = PropertyResource.query();
    }

    activate();

    $scope.deleteProperty = function (property) {
        property.$remove(function (data) {
            toastr.error('Property Deleted');
            activate();
        })

    };


   

});