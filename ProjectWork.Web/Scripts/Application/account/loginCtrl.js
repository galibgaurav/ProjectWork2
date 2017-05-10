(function (app) {
    'use strict';
    
    app.controller('loginCtrl', loginCtrl);

    loginCtrl.$inject = ['$scope', 'membershipService', 'notificationService', '$rootScope', '$location'];

    function loginCtrl($scope, membershipService, notificationService, $rootScope, $location) {
        $scope.pageClass = 'page-login';
        $scope.login = login;
        $scope.user = {};
       

        function login() {
            var userLogin = {
                grant_type: 'password',
                username: $scope.user.username,
                password: $scope.user.password
            };
            membershipService.login(userLogin, loginCompleted)
        }
       
        function loginCompleted(result) {
            debugger;
            if (result.status === 200) {
                
                $scope.user.username = result.data.userName;
                //Store the token information in the SessionStorage
                //So that it can be accessed for other views
                sessionStorage.setItem('userName', result.data.userName);
                sessionStorage.setItem('accessToken', result.data.access_token);
                sessionStorage.setItem('refreshToken', result.data.refresh_token);
                membershipService.saveCredentials($scope.user);
                notificationService.displaySuccess('Hello ' + $scope.user.username);
                $scope.userData.displayUserInfo();
                if ($rootScope.previousState)
                    $location.path($rootScope.previousState);
                else{
                    debugger;
               
                }
                $location.path('/userHome');
                  
            }
            else {
                notificationService.displayError('Login failed. Try again.');
            }
        }
    }

})(angular.module('common.core'));