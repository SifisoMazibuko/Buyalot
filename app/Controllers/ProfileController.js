AngularApp.controller('ProfileController',
    ['$scope', '$location', '$window', '$routeParams', 'AccountService',

    function ($scope, $location, $window, $routeParams, AccountService) {

        $scope.profileModel = {
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

        $scope.profileModel.customerID = $routeParams.customerID;

        if ($scope.profileModel.customerID > 0) {
            ProductService.profileGet($scope.profileModel.customerID).then(
                function (result) {

                    $scope.profileModel.customerID = result.data.customerID;
                    $scope.profileModel.firstName = result.data.firstName;
                    $scope.profileModel.lastName = result.data.lastName;
                    $scope.profileModel.phone = result.data.phone;
                    $scope.profileModel.email = result.data.email;
                    $scope.profileModel.password = result.data.password;
                    $scope.profileModel.confirmPassword = result.data.confirmPassword;
                    $scope.profileModel.address = result.data.state;
                    $scope.profileModel.city = result.data.city;
                    $scope.profileModel.postalCode = result.data.postalCode;


                },

                function (error) {
                    handleError(error);
                });
        };

        $scope.submitForm = function () {

            $scope.$broadcast('show-errors-check-validity');

            if ($scope.profileForm.$invalid)
                return;

            if ($scope.profileForm.$valid) {

                AccountService.profile($scope.profileModel.firstName,
                                                  $scope.profileModel.lastName,
                                                  $scope.profileModel.phone,
                                                  $scope.profileModel.email,
                                                  $scope.profileModel.password,
                                                  $scope.profileModel.confirmPassword,
                                                  $scope.profileModel.address,
                                                  $scope.profileModel.city,
                                                  $scope.profileModel.postalCode).then(

                    function (result) {
                        $location.path('/profile');
                        $scope.handleSuccess = true;
                        $scope.successMessage = "Successfully Update!";
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

        $scope.profileForm = function () {
            $location.path('/Profile');
        };
        //$scope.profile = function () {
        //    $location.path('/profile');
        //};

        $scope.profile = function () {
            $location.path("/GetProfile/0");
        };

        $scope.resetForm = function () {
            $scope.$broadcast('show-errors-reset');
        };


    }
]);