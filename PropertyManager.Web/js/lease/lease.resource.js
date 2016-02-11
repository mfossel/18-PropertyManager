angular.module('app').factory('LeaseResource', function (apiUrl, $resource) {
    return $resource(apiUrl + '/leases/:leaseId', { tenantId: '@LeaseId' },
     {
         'update': {
             method: 'PUT'
         }

     });
});