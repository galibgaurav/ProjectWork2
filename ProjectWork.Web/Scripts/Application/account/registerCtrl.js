(function (app) {
    'use strict';

    app.controller('registerCtrl', registerCtrl);

    registerCtrl.$inject = ['$scope', 'membershipService', 'notificationService', '$rootScope', '$location'];

    function registerCtrl($scope, membershipService, notificationService, $rootScope, $location) {
        $scope.pageClass = 'page-login';
        $scope.register = register;
        $scope.user = {};

        function register() {
            
            var userRegistrationInfo = {
                Email: $scope.user.username,
                Password: $scope.user.password,
                ConfirmPassword: $scope.user.confirmpassword
            };
            membershipService.register(userRegistrationInfo, registerCompleted)
        }

        function registerCompleted(result) {
            
            if (result.data.success) {
                
                notificationService.displaySuccess('User ' + $scope.user.username + ' registered successfully');            
                membershipService.saveCredentials($scope.user);
                $scope.userData.displayUserInfo();
                debugger;
                $location.path('/');
            }
            else {
                notificationService.displayError('Registration failed. Try again.');
            }
        }
    }

})(angular.module('common.core'));