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
            address: '',
            city: '',
            postalCode: '',
            state: 'active'


        };


        //$scope.registerModel.customerID = $routeParams.customerID;

        //if ($scope.registerModel.customerID > 0) {
        //    ProductService.GetProfile($scope.registerModel.customerID).then(
        //        function (result) {

        //            $scope.registerModel.customerID = result.data.customerID;
        //            $scope.registerModel.firstName = result.data.firstName;
        //            $scope.registerModel.lastName = result.data.lastName;
        //            $scope.registerModel.phone = result.data.phone;
        //            $scope.registerModel.email = result.data.email;
        //            $scope.registerModel.password = result.data.password;
        //            $scope.registerModel.confirmPassword = result.data.productImage;
        //            $scope.registerModel.address = result.data.state;
        //            $scope.registerModel.city = result.data.city;
        //            $scope.registerModel.postalCode = result.data.postalCode;


        //        },

        //        function (error) {
        //            handleError(error);
        //        });
        //};


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
                                                $scope.registerModel.address,
                                                $scope.registerModel.city,
                                                $scope.registerModel.postalCode,
                                                $scope.registerModel.state).then(

                    function (result) {
                        $location.path('/login');
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