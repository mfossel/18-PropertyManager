angular.module('app').factory('LeaseResource', function (apiUrl, $resource) {
    return $resource(apiUrl + '/leases/:leaseId', { leaseId: '@LeaseId' },
     {
         'update': {
             method: 'PUT'
         }

     });
});