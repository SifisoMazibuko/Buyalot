AngularApp.controller('AdminController',
['$scope', '$location', '$window', 'AccountService',
    function ($scope, $location , $window, AccountService) {
        $scope.adminModel = {
            adminID: '',
            adminName: '',
            email: '',
            password: ''
        };
        $scope.submitForm = function(){
            
            $scope.$broadcast('show-errors-check-validity');

             if($scope.adminForm.$invalid)
                return;
                 
             if ($scope.adminForm.$valid) {

                 AccountService.adminLogin($scope.adminModel.email,
                                        $scope.adminModel.adminName,
                                        $scope.adminModel.password).then(

                     function (result) {
                         $location.path('/addProduct');
                     },

                     function (error) {
                         $scope.hasError = true;
                         $scope.errorMessage = error.statusText;
                     }
                 );
             }

        }
        $scope.adminForm = function () {
            $location.path('/AdminLogin');
        };

        $scope.successMessage = "Successfully logged In!";

        $scope.resetForm = function () {
            $scope.$broadcast('show-errors-reset');
        }

    }

]);