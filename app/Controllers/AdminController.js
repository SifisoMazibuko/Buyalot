AngularApp.controller('AdminController',
['$scope', '$locationProvider', '$window', 'AccountService',
    function($scope, $locationProvider, $window, AccountService){
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

                 AccountService.admin($scope.adminModel.email,
                                        $scope.adminModel.adminName,
                                        $scope.adminModel.password).then(

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
        $scope.adminForm = function () {
            $location.path('/adminLogin');
        };

        $scope.successMessage = "Successfully logged In!";

        $scope.resetForm = function () {
            $scope.$broadcast('show-errors-reset');
        }

    }

]);