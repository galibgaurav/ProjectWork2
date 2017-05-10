(function (app) {
    'use strict';

    app.factory('membershipService', membershipService);

    membershipService.$inject = ['apiService', 'notificationService', '$cookieStore', '$http', '$base64', '$rootScope'];

    function membershipService(apiService, notificationService,$cookieStore, $http, $base64,  $rootScope) {

        var service = {
            login: login,
            register: register,
            saveCredentials: saveCredentials,
            removeCredentials: removeCredentials,
            isUserLoggedIn: isUserLoggedIn,
            getUserRole: getUserRole
        }

       
        function login(user,completed) {
            
            apiService.post('/ProjectWork/TOKEN', $.param({ grant_type: 'password', username: user.username, password: user.password }),
            { 'Content-Type': 'application/x-www-form-urlencoded' },
            completed,
            loginFailed);
        }

        function register(userRegistrationInfo, completed) {
            debugger;
            apiService.post('/ProjectWork/api/account/register', userRegistrationInfo,
            null,
            completed,
            registrationFailed);
        }
        
            //function saveCredentials(user, userRoles) {
            function saveCredentials(user) {
            //debugger;
            var membershipData = $base64.encode(user.username + ':' + user.password);
           
            $rootScope.repository = {
                loggedUser: {
                    username: user.username,
                    authdata: membershipData,
                    //userRoles: userRoles
                }
            };

            $http.defaults.headers.common['Authorization'] = 'Basic ' + membershipData;
            $cookieStore.put('repository', $rootScope.repository);
        }

        function removeCredentials() {
            $rootScope.repository = {};
            $cookieStore.remove('repository');
            $http.defaults.headers.common.Authorization = '';
        };

        function loginFailed(response) {
            notificationService.displayError(response.data);
        }

        function registrationFailed(response) {

            notificationService.displayError('Registration failed. Try again.');
        }

        function isUserLoggedIn() {
            
            if ($rootScope.repository === undefined)
            {
                return false;
            }
            else
            return $rootScope.repository.loggedUser != null;//bug1
            
        }
        function getUserRole() {
            if ($rootScope.repository === undefined) {
                debugger;
                return false;
            }
            else
                if ($rootScope.repository.loggedUser != undefined) {
                    return $rootScope.repository.loggedUser.userRoles.indexOf('Admin') > -1;
                }
                else
                    return false;
        }

        return service;
    }



})(angular.module('common.core'));