(function (app) {
    'use strict';
    app.controller('userHomeCtrl', userHomeCtrl);
    userHomeCtrl.$inject = ['$scope', 'apiService', 'notificationService', '$rootScope', '$location', '$http'];
    function userHomeCtrl($scope, apiService, notificationService, $rootScope, $location, $http) {
        $scope.userHomeData = {};
        $scope.userHomeData.user = sessionStorage.getItem('userName');
        $scope.GetProjects = function ()
        {
            //apiService.get('/ProjectWork/api/UserHome/GetProjects',
            //completed,
            //registrationFailed);

            var accesstoken = sessionStorage.getItem('accessToken');

            var authHeaders = {};
            if (accesstoken) {
                authHeaders.Authorization = 'Bearer ' + accesstoken;
            }

            var response = $http({
                url: "/ProjectWork/api/UserHome/GetProjects",
                method: "GET",
                headers: authHeaders
            }).then(function (response) {
                alert('hi');
            });
        }

        function completed()
        {
            alert('hi');
        }
        function registrationFailed() {
            alert('not hi');
        }

    }

})(angular.module('common.core'));
