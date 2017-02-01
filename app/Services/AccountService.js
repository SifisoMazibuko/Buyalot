AngularApp.factory('AccountService',
    ['$http',
    function ($http) {
        var login = function (email, password) {
            return $http.post("/Account/Login", {
                Email: email,
                Password: password
            });
        };
        var register = function (firstName, lastName, phone, email, password, confirmPassword, state) {
            return $http.post("Account/Register", {
                FirstName: firstName,
                LastName: lastName,
                Phone: phone,
                Email: email,
                Password: password,
                ConfirmPassword: confirmPassword,
                State: state
           });

        }
        var adminLogin = function (email, adminName, password){
            return $http.post("Account/AdminLogin",
                {
                    Email: email, AdminName: adminName, Password: password
                });
        }

        return {
            login: login,
            register: register,
            adminLogin: adminLogin
        }
    }
]);