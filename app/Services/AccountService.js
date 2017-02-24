AngularApp.factory('AccountService',
    ['$http',
    function ($http) {
        var login = function (email, password) {
            return $http.post("/Account/Login", {
                Email: email,
                Password: password
            });
        };
        var logout = function () {
            return $http.post("/Account/Logout", {
            });
        };
        var forgotPassword = function (email, password) {
            return $http.post("/Account/ForgotPassword", {
                Email: email
            });
        };
        var register = function (firstName, lastName, phone, email, password, confirmPassword, address, city, postalCode, state) {
            return $http.post("/Account/Register", {
                FirstName: firstName,
                LastName: lastName,
                Phone: phone,
                Email: email,
                Password: password,
                ConfirmPassword: confirmPassword,
                Address: address,
                City: city,
                PostalCode: postalCode,
                State: state
           });

        }
        var adminLogin = function (email, adminName, password){
            return $http.post("/Account/AdminLogin",
                {
                    Email: email,
                    AdminName: adminName,
                    Password: password
                });
        }

        var addProduct = function (productName, productDescription, price, vendor, quantityInStock, productImage) {
            return $http.post("/Product/AddProduct", {
                ProductName: productName,
                ProductDescription: productDescription,
                Price: price,
                Vendor: vendor,
                QuantityInStock: quantityInStock,
                ProductImage: productImage
            });
        }

        var profile = function (firstName, lastName, phone, email, password, confirmPassword, address, city, postalCode, state) {
            return $http.post("/Account/GetProfile", {
                FirstName: firstName,
                LastName: lastName,
                Phone: phone,
                Email: email,
                Password: password,
                ConfirmPassword: confirmPassword,
                Address: address,
                City: city,
                PostalCode: postalCode,
                State: state
            });

        }

        var profileGet = function (customerId) {
            return $http.get("/Account/GetProfile/" + customerId);
        }

        return {
            login: login,
            register: register,
            logout: logout,
            forgotPassword: forgotPassword,
            addProduct: addProduct,
            adminLogin: adminLogin,
            profileGet: profileGet,
            profile: profile
        }
    }
]);