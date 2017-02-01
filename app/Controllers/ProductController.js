//AngularApp.controller('ProductController',
//            ['$scope', '$location', 'ProductService', 
//    function ($scope, $location, ProductService) {

//        $scope.productModel = {
//            productID: '',
//            productName: '',
//            productDescription: '',
//            price: '',
//            vendor: '',
//            quantityInStock: '',
//            productImage
//        };


//        $scope.submitForm = function () {

//            $scope.$broadcast('show-errors-check-validity');
//            if(!$scope.productForm.$valid)
//                return;

//            if ($scope.productForm.$valid) {
//                AccountService.saveProduct($scope.productModel.productName,
//                                           $scope.productModel.productDescription,
//                                           $scope.productModel.price,
//                                           $scope.productModel.vendor,
//                                           $scope.productModel.quantityInStock,
//                                           $scope.productModel.productImage).then(

//                  function (result) {
//                      $location.path('/home');
//                  }                
//                 ),               
             
//             };
        
//            $scope.resetForm = function () {
//                $scope.$broadcast('show-errors-reset');
//            }
//        }
//    }
//]);

