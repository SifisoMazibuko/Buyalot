AngularApp.controller('ProductController',
    ['$scope', '$location', '$window', 'AccountService',

    function ($scope, $location, $window, AccountService) {

        $scope.productModel = {
            productName: '',
            productDescription: '',
            price: '',
            vendor: '',
            quantityInStock: '',
            productImage: ''


        };

       
        $scope.submitForm = function (){

            $scope.$broadcast('show-errors-check-validity');

            if ($scope.productForm.$invalid)
                return;

            if ($scope.productForm.$valid) {

                AccountService.addProduct($scope.productModel.productName,
                                               $scope.productModel.productDescription,
                                               $scope.productModel.price,
                                               $scope.productModel.vendor,
                                               $scope.productModel.quantityInStock,
                                               $scope.productModel.productImage).then(

                    function (result) {
                        $location.path('/viewProduct');
                    },

                    function (error) {
                        $scope.hasError = true;
                        $scope.errorMessage = error.statusText;
                    }
                );
            }

        }
      
        $scope.productForm = function () {
            $location.path('/AddProduct');
        };

        $scope.resetForm = function () {
            $scope.$broadcast('show-errors-reset');
        };
     }
]);
