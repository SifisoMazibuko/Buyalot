AngularApp.factory('HomeService',
    ['$http',
    function ($http) {

        var getUser = function (id) {
            return {
                id: id,
                firstName: "Sifiso",
                surname: "Mazibuko"
            };
        }



    }

 ]);