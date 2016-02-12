angular.module('app').factory('WorkOrderResource', function (apiUrl, $resource) {
    return $resource(apiUrl + '/workorders/:workOrderId', { workOrderId: '@WorkOrderId' },
      {
          'update': {
              method: 'PUT'
               },
           'high': { method: 'GET', url: apiUrl + '/workorders/highPriority'
              }
      });
});