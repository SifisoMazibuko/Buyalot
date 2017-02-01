var AngularApp = angular.module('AngularApp', ['ngRoute', 'ui.bootstrap', 'validation.match', 'ui.bootstrap.showErrors', 'chieffancypants.loadingBar', 'ngAnimate']);
AngularApp.config(
    ['$routeProvider', '$httpProvider', '$locationProvider',
    function ($routeProvider, $httpProvider, $locationProvider) {

         $routeProvider
         .when("/home", {
             templateUrl: "app/Views/Home/Home.html",
             controller: "HomeController"
         })
         .when("/login", {
             templateUrl: "app/Views/Account/Login.html",
             controller: "LoginController"
         })
         .when("/register", {
             templateUrl: "app/Views/Account/Register.html",
             controller: "RegisterController"
         })
        .when("/adminLogin", {
            templateUrl: "app/Views/Account/AdminLogin.html",
            controller: "AdminController"
        })
        .when("/trackOrder", {
            templateUrl: "app/Views/Product/Order.html",
            controller: "ProductController"
        })
         .when("/addProduct", {
             templateUrl: "app/Views/Product/AddProduct.html",
             controller: "ProductController"
         })
          .when("/profile", {
             templateUrl: "app/Views/Account/Profile.html",
             controller: "RegisterController"
         })


     .otherwise({
         redirectTo: '/home'
     });
         // enable html5Mode for pushstate
         $locationProvider.html5Mode({
             enabled: true,
             requireBase: false
         });

     }]);


