angular.module('app').factory('LeaseResource', function ($resource) {
    return $resource(apiUrl + '/leases/:leaseId', { tenantId: '@LeaseId' },
     {
         'update': {
             method: 'PUT'
         }

     });
});