(function (app) {
    'use strict';
    app.controller('manageContactsCtrl', manageContactsCtrl);
    manageContactsCtrl.$inject = ['$scope', 'apiService', 'notificationService', '$rootScope', '$location', '$http'];
    function manageContactsCtrl($scope, apiService, notificationService, $rootScope, $location, $http) {
        $scope.contactsData = {
            "contactInfos":[{"name":"sridhar",
                "primaryEmail":"sridhar@gmail.com",
                "secondaryEmail":"",
                "addressPermanent":"",
                "addressCorrespondance":"",
                "primaryContactNumber":"9902738900",
                "secondaryContactNumber":"9902700000"
                }]
        };


        //$scope.userHomeData.user = sessionStorage.getItem('userName');
        $scope.AddContacts = function () {
            var dataObj=$scope.contactsData;

            var accesstoken = sessionStorage.getItem('accessToken');

            var authHeaders = {};
            if (accesstoken) {
                authHeaders.Authorization = 'Bearer ' + accesstoken;
            }
            var response = $http({
                url: "/ProjectWork/api/manageContacts/PostContactInfo",
                method: "POST",
                data: dataObj,
                headers: authHeaders
            }).then(function (response) {
                alert('addition successfull');
            }, function (response) {
                alert('error');
            });
            
        }

        

    }

})(angular.module('common.core'));
