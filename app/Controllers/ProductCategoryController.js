AngularApp.controller('ProductCategoryController',
    ['$scope', '$location', '$window', '$routeParams', 'AccountService',

    function ($scope, $location, $window, $routeParams, AccountService) {

        $scope.categoryModel = {
            prodCategoryID: '',
            categoryName: '',
           


        };


        $scope.categoryModel.prodCategoryID = $routeParams.prodCategoryID;

        if ($scope.categoryModel.prodCategoryID > 0) {
            AccountService.GetCategoryName($scope.categoryModel.prodCategoryID).then(
                function (result) {

                    $scope.categoryModel.prodCategoryID = result.data.prodCategoryID;
                    $scope.categoryModel.categoryName = result.data.categoryName;
    


                },

                function (error) {
                    handleError(error);
                });
        };


    }
]);