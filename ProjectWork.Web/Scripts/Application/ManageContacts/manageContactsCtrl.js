(function (app) {
    'use strict';
    app.controller('manageContactsCtrl', manageContactsCtrl);
    manageContactsCtrl.$inject = ['$scope', 'apiService', 'notificationService', '$rootScope', '$location', '$http'];
    function manageContactsCtrl($scope, apiService, notificationService, $rootScope, $location, $http) {
        $scope.contactsData = 
           [{"Name":"sridhar",
           "PrimaryEmail":"sridhar@gmail.com",
           "SecondaryEmail":"",
           "AddressPermanent":"",
           "AddressCorrespondance":"",
           "PrimaryContactNumber":"9902738900",
           "SecondaryContactNumber":"9902700000"
           },
           {
               "Name": "abcd",
               "PrimaryEmail": "abcd@gmail.com",
               "SecondaryEmail": "",
               "AddressPermanent": "",
               "AddressCorrespondance": "",
               "PrimaryContactNumber": "8888738900",
               "SecondaryContactNumber": "8888700000"
           }];
      
        //$scope.userHomeData.user = sessionStorage.getItem('userName');
        $scope.AddContacts = function () {
            debugger;
            
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
