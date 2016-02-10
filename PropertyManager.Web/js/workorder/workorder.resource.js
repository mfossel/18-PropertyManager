angular.module('app').factory('WorkOrderResource', function (apiUrl, $resource) {
    return $resource(apiUrl + '/workorders/:workOrderId', { tenantId: '@WordOrderId' },
      {
          'update': {
              method: 'PUT'
          }

      });
});