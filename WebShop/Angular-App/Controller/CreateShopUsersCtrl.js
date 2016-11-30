app.controller('CreateShopUsersCtrl', function ($scope, $http) {

    $scope.newUser = {};
    console.log("Create User Controller");
    $scope.CreateUser = function (newUser)
    {
        console.log(newUser.Photo);
        var file = $scope.userPhoto;
        console.log(file);
        $scope.newUser.Photo = file;
        console.log($scope.newUser);
        //var fd = new FormData();

        //fd.append('newUser',angular.toJson($scope.newUser,true));
        $http({
            method: 'POST',
            url: "ShopUser/Create",
            //headers: { 'Content-Type': false },
            data: $scope.newUser
        });
    }

});