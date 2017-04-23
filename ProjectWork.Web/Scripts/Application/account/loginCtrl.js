(function (app) {
    'use strict';
    
    app.controller('loginCtrl', loginCtrl);

    loginCtrl.$inject = ['$scope', 'membershipService', 'notificationService', '$rootScope', '$location'];

    function loginCtrl($scope, membershipService, notificationService, $rootScope, $location) {
        $scope.pageClass = 'page-login';
        $scope.login = login;
        $scope.user = {};
       

        function login() {
            
            membershipService.login($scope.user, loginCompleted)
        }

        function externalLogin()
        {

        }
        function loginCompleted(result) {
           
            if (result.status === 200) {
                debugger;
                membershipService.saveCredentials($scope.user, result.data.m_roles);
                notificationService.displaySuccess('Hello ' + $scope.user.username);
                $scope.userData.displayUserInfo();
                if ($rootScope.previousState)
                    $location.path($rootScope.previousState);
                else
                    $location.path('/');
            }
            else {
                notificationService.displayError('Login failed. Try again.');
            }
        }
    }

})(angular.module('common.core'));