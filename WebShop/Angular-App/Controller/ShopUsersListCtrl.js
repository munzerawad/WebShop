//(function()

//{
'use strict'
app.controller('ShopUsersListCtrl', function ($scope, $http) {
    $scope.usersList = [];
    $http.get("/ShopUser/ShopUsers",{cache:false}).then(function (response) {

        angular.copy(response.data, $scope.usersList);
    }

    );
    console.log("v ShopUsersListCtrl");
    //$scope.selectedOrder = 'FullName';
    $scope.selectOrderBy = function (select) {
        $scope.selectedOrder = select;
    }


}
    );
//console.log(app);
//}

//)();
