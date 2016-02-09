angular.module('app').factory('PropertyResource', function (apiUrl, $resource) {
    return $resource(apiUrl + '/properties/:propertyId', { propertyId: '@PropertyId' },
        {
            'update': {
                method: 'PUT'
            }

        });
});