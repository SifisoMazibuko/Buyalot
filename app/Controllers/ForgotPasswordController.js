AngularApp.controller('ForgotPasswordController',
            ['$scope', '$location', '$window', 'AccountService',
    function ($scope, $location, $window, AccountService) {

        $scope.forgotPasswordModel = {
            customerID: '',
            email: '',
        };


        $scope.submitForm = function () {
            $scope.$broadcast('show-errors-check-validity');

            if ($scope.forgotPasswordForm.$invalid)
                return;

            if ($scope.forgotPasswordForm.$valid) {

                AccountService.forgotPassword($scope.forgotPasswordModel.email).then(

                    function (result) {
                        $location.path('/forgotPassword');
                        $scope.handleSuccess = true;
                        $scope.successMessage = "Email will be sent to you shortly!";
                        $scope.email = '';
                        var txt = $scope.successMessage;
                        alert(txt);
                    },

                    function (error) {
                        $scope.hasError = true;
                        $scope.errorMessage = error.statusText;

                    }
                );
            }

        }


        $scope.forgotPasswordForm = function () {
            $location.path('/forgotPassword');
        };

        $scope.resetForm = function () {
            $scope.$broadcast('show-errors-reset');
        };
    }
 ]);



