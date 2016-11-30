//(function()
//{
   // var app = angular.module("WebShop", ["ngRoute"]);
    app.config(function ($routeProvider)
    {
        $routeProvider.when("/", {
            template: "<h1>Main Route Angular</h1>"

        }).when("/Users", {
            templateUrl: "/ShopUser/",
           // controller: "ShopUsersListCtrl"


        }
        ).otherwise({

            template:"<h1>Otherwise From Angular Route</h1>"
        });
    }
    );
//}

//)();