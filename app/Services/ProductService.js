AngularApp.factory('ProductService'
    ['$http',

    function ($http) {
        
        var addproduct = function (productName, productDescription, price, vendor, quantityInStock, productImage) {
            return $http.post("AddProduct/Product", {
                productName: productName,
                productDescription: productDescription,
                price: price,
                vendor: vendor,
                quantityInStock: quantityInStock,
                productImage: productImage
           });

        }

        return {
            addproduct: addproduct
        }
    }
]);