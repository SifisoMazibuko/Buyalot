AngularApp.controller('RegisterController',
    ['$scope', '$location', '$window', 'AccountService',

    function ($scope, $location, $window, AccountService) {

        $scope.registerModel = {
            customerID: '',
            firstName: '',
            lastName: '',
            phone: '',
            email: '',
            password: '',
            confirmPassword: '',
            state: ''

        };



        $scope.submitForm = function ()
        {

            $scope.$broadcast('show-errors-check-validity');

            if ($scope.registerForm.$invalid)
                return;

            if ($scope.registerForm.$valid) {

                AccountService.register($scope.registerModel.firstName,
                                                $scope.registerModel.lastName,
                                                $scope.registerModel.phone,
                                                $scope.registerModel.email,
                                                $scope.registerModel.password,
                                                $scope.registerModel.confirmPassword,
                                                $scope.registerModel.state).then(

                    function (result) {
                        $location.path('/home');
                    },

                    function (error) {
                        $scope.hasError = true;
                        $scope.errorMessage = error.statusText;
                    }
                );
            }

        }

        $scope.registerForm = function () {
            $location.path('/Register');
        };

        $scope.resetForm = function () {
            $scope.$broadcast('show-errors-reset');
        };
    }
 ]);