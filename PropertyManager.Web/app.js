angular.module('app', ['ngResource', 'ui.router', 'LocalStorageModule']);

//Internet Host
angular.module('app').value('apiUrl', 'https://propzpropertyapi.azurewebsites.net/api');


//Local Host
//angular.module('app').value('apiUrl', 'https://localhost:61209/api');

angular.module('app').config(function ($stateProvider, $urlRouterProvider, $httpProvider) {
    $urlRouterProvider.otherwise('home');

    $httpProvider.interceptors.push('AuthenticationInterceptor');

    $stateProvider
        .state('home', { url: '/home', templateUrl: '/templates/home/home.html', controller: "HomeController" })
        .state('register', { url: '/register', templateUrl: '/templates/register/register.html', controller: "RegisterController" })
        .state('login', { url: '/login', templateUrl: '/templates/login/login.html', controller: "LoginController" })
        .state('app', { url: '/app', templateUrl: '/templates/app/app.html', controller: "AppController" })

        .state('app.dashboard', { url: '/dashboard', templateUrl: '/templates/app/dashboard/dashboard.html', controller: 'DashboardController' })

           .state('app.properties', { url: '/properties', abstract: true, template: '<ui-view/>' })
               .state('app.properties.grid', { url: '/grid', templateUrl: '/templates/app/property/property.grid.html', controller: 'PropertyGridController' })
               .state('app.properties.detail', { url: '/detail/:id', templateUrl: '/templates/app/property/property.detail.html', controller: 'PropertyDetailController' })
               .state('app.properties.create', { url: '/create/', templateUrl: '/templates/app/property/property.create.html', controller: 'PropertyCreateController' })

           .state('app.tenants', { url: '/tenants', abstract: true, template: '<ui-view/>' })
               .state('app.tenants.grid', { url: '/grid', templateUrl: '/templates/app/tenant/tenant.grid.html', controller: 'TenantGridController' })
               .state('app.tenants.detail', { url: '/detail/:id', templateUrl: '/templates/app/tenant/tenant.detail.html', controller: 'TenantDetailController' })
               .state('app.tenants.create', { url: '/create/', templateUrl: '/templates/app/tenant/tenant.create.html', controller: 'TenantCreateController' })

           .state('app.workorders', { url: '/workorders', abstract: true, template: '<ui-view/>' })
               .state('app.workorders.grid', { url: '/grid', templateUrl: '/templates/app/workorder/workorder.grid.html', controller: 'WorkOrderGridController' })
               .state('app.workorders.detail', { url: '/detail/:id', templateUrl: '/templates/app/workorder/workorder.detail.html', controller: 'WorkOrderDetailController' })
               .state('app.workorders.create', { url: '/create/', templateUrl: '/templates/app/workorder/workorder.create.html', controller: 'WorkOrderCreateController' })

          .state('app.leases', { url: '/leases', abstract: true, template: '<ui-view/>' })
              .state('app.leases.grid', { url: '/grid', templateUrl: '/templates/app/lease/lease.grid.html', controller: 'LeaseGridController' })
              .state('app.leases.detail', { url: '/detail/:id', templateUrl: '/templates/app/lease/lease.detail.html', controller: 'LeaseDetailController' })
              .state('app.leases.create', { url: '/create/', templateUrl: '/templates/app/lease/lease.create.html', controller: 'LeaseCreateController' })
});

angular.module('app').run(function (AuthenticationService) {
    AuthenticationService.initialize();
});