AngularApp.controller('RegisterController',
    ['$scope', '$location', '$window', '$routeParams', 'AccountService',

    function ($scope, $location, $window, $routeParams, AccountService) {

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

        $scope.registerModel.customerID = $routeParams.customerID;

        if ($scope.registerModel.customerID > 0) {
            ProductService.GetProfile($scope.registerModel.customerID).then(
                function (result) {

                    $scope.registerModel.customerID = result.data.customerID;
                    $scope.registerModel.firstName = result.data.firstName;
                    $scope.registerModel.lastName = result.data.lastName;
                    $scope.registerModel.phone = result.data.phone;
                    $scope.registerModel.email = result.data.email;
                    $scope.registerModel.password = result.data.password;
                    $scope.registerModel.confirmPassword = result.data.productImage;
                    $scope.registerModel.address = result.data.state;
                    $scope.registerModel.city = result.data.city;
                    $scope.registerModel.postalCode = result.data.postalCode;


                },

                function (error) {
                    handleError(error);
                });
        };
    }
]);