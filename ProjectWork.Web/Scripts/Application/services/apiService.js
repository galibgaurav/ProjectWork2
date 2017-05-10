(function (app) {
    'use strict';

    app.factory('apiService', apiService);

    apiService.$inject = ['$http', '$location', 'notificationService', '$rootScope'];

    function apiService($http, $location, notificationService, $rootScope) {
        var service = {
            get: get,
            post: post
        };

        function get(url, success, failure) {

            var accesstoken = sessionStorage.getItem('accessToken');
            var headers = {};
            if (headers) {
                headers.Authorization = 'Bearer ' + accesstoken;
            }

            return $http.get(url, headers)
                    .then(function (result) {
                        debugger;
                        success(result);
                    }, function (error) {
                        debugger;
                        if (error.status == '401') {
                            notificationService.displayError('Authentication required.');
                            $rootScope.previousState = $location.path();
                            $location.path('/login');
                        }
                        else if (failure != null) {
                            failure(error);
                        }
                    });
        }

       
        function post(url, data, headers, success, failure) {

            var accesstoken = sessionStorage.getItem('accessToken');

            if (headers) {
                headers.Authorization = 'Bearer ' + accesstoken;
            }
            return $http.post(url, data, headers)
                    .then(function (result) {
                        success(result);
                    }, function (error) {
                        if (error.status == '401') {
                            notificationService.displayError('Authentication required.');
                            $rootScope.previousState = $location.path();
                            $location.path('/login');
                        }
                        else if (failure != null) {
                            failure(error);
                        }
                    });
        }

        return service;
    }

})(angular.module('common.core'));