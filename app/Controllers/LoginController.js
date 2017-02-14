AngularApp.controller('LoginController',
            ['$scope', '$location', '$window', 'AccountService', 
    function ($scope, $location, $window, AccountService) {

        $scope.loginModel = {
            customerID: '',
            email: '',
            password: '',
        };


        $scope.submitForm = function () {
            $scope.$broadcast('show-errors-check-validity');

            if ($scope.loginForm.$invalid)
                return;

            if ($scope.loginForm.$valid) {

                AccountService.login($scope.loginModel.email,
                                        $scope.loginModel.password).then(

                    function (result) {
                        $location.path('/home');
                        $scope.handleSuccess = true;
                        $scope.successMessage = "You're Successfully logged In!";
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


        $scope.loginForm = function () {
            $location.path('/login');
        };

        $scope.resetForm = function () {
            $scope.$broadcast('show-errors-reset');
        };
    }
]);



