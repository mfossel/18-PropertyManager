angular.module('app').controller('PropertyGridController', function ($scope, PropertyResource) {
   
    function activate() {
        $scope.properties = PropertyResource.query();
    }

    activate();

});