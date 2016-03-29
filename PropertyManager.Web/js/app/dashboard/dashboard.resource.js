angular.module('app').factory('DashboardResource', function (apiUrl, $http) {
    function getHighPriority() {
        return $http.get(apiUrl + '/workorders/highpriority')
                    .then(function (response) {
                        return response.data;
                    });
    }

    function getTenantCount() {
        return $http.get(apiUrl + '/tenants/count')
                    .then(function (response) {
                        return response.data;
                    });
    }

    function getPropertyCount() {
        return $http.get(apiUrl + '/properties/count')
                    .then(function (response) {
                        return response.data;
                    });
    }

    function getLeaseCount() {
        return $http.get(apiUrl + '/leases/count')
                    .then(function (response) {
                        return response.data;
                    });
    }

    function getNewTenants() {
        return $http.get(apiUrl + '/tenants/new')
                    .then(function (response) {
                        return response.data;
                    });
    }


    function getNewProperties() {
        return $http.get(apiUrl + '/properties/new')
                    .then(function (response) {
                        return response.data;
                    });
    }

    return {
        getHighPriority: getHighPriority,
        getTenantCount: getTenantCount,
        getPropertyCount: getPropertyCount,
        getLeaseCount: getLeaseCount,
        getNewTenants: getNewTenants,
        getNewProperties: getNewProperties
    };

});

