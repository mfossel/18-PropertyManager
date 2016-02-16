angular.module('app').factory('TenantResource', function (apiUrl, $resource) {
    return $resource(apiUrl + '/tenants/:tenantId', { tenantId: '@TenantId' },
      {
          'update': {
              method: 'PUT'
          }

      });
});