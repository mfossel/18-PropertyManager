angular.module('app', ['ngResource', 'ui.router']);

angular.module('app').value('apiUrl', 'http://localhost:61209/api');

angular.module('app').config(function ($stateProvider, $urlRouterProvider) {

    $stateProvider.state('dashboard', { url: '/dashboard', templateUrl: '/templates/dashboard/dashboard.html', controller: 'DashboardController' })

         .state('properties', { url: '/properties', abstract: true, template: '<ui-view/>' })
             .state('properties.grid', { url: '/grid', templateUrl: '/templates/property/property.grid.html', controller: 'PropertyGridController' })
             .state('properties.detail', { url: '/detail/:id', templateUrl: '/templates/property/property.detail.html', controller: 'PropertyDetailController' })
              .state('properties.create', { url: '/create/', templateUrl: '/templates/property/property.create.html', controller: 'PropertyCreateController' })

         .state('tenants', { url: '/tenants', abstract:true, template: '<ui-view/>' })
           .state('tenants.grid', { url: '/grid', templateUrl: '/templates/tenant/tenant.grid.html', controller: 'TenantGridController' })
           .state('tenants.detail', { url: '/detail/:id', templateUrl: '/templates/tenant/tenant.detail.html', controller: 'TenantDetailController' })
           .state('tenants.create', { url: '/create/', templateUrl: '/templates/tenant/tenant.create.html', controller: 'TenantCreateController' })

         .state('workorders', { url: '/workorders', abstract:true, template: '<ui-view/>' })
           .state('workorders.grid', { url: '/grid', templateUrl: '/templates/workorder/workorder.grid.html', controller: 'WorkOrderGridController' })
           .state('workorders.detail', { url: '/detail/:id', templateUrl: '/templates/workorder/workorder.detail.html', controller: 'WorkOrderDetailController' })
           .state('workorders.create', { url: '/create/', templateUrl: '/templates/workorder/workorder.create.html', controller: 'WorkOrderCreateController' })

         .state('leases', { url: '/leases', abstract:true, template: '<ui-view/>' })
          .state('leases.grid', { url: '/grid', templateUrl: '/templates/lease/lease.grid.html', controller: 'LeaseGridController' })
          .state('leases.detail', { url: '/detail/:id', templateUrl: '/templates/lease/lease.detail.html', controller: 'LeaseDetailController' })
         .state('leases.create', { url: '/create/', templateUrl: '/templates/lease/lease.create.html', controller: 'LeaseCreateController' })
});