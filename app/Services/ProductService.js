AngularApp.factory('ProductService'
    ['$http',

    function ($http) {
        
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

        return {
            addProduct: addProduct
        }
    }
]);