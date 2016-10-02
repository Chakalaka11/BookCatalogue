
var server = "http://localhost:54382/";
var actionUrl = ["home/index/","home/addbook"];


app.controller('MainController', function ($scope, $http) {
    $scope.books = [];
    $scope.title = 'Book Catalogue';

    $scope.goto = function (event) {
       
    };
    
    function request() {
        $http.post(url, { 
            path: $scope.absolutePath 
        }).success(function (data, status, headers, config) {
            $scope.directories = data.Directories;
            $scope.files = data.Files;
            $scope.group = data.SizeGroups;
        }).error(function (data, status, headers, config) {
            console.log(data);
            console.log(status);
        });
    }

    $http.get( (server+actionUrl[0]) ).success(function (data) {          
        $scope.books = data;
        for (var i = 0; i < $scope.books.length; i++) {
            $scope.books[i].Price = $scope.books[i].Price.toFixed(2);
        }
        console.log($scope.books);
    }).error(function (data, status, headers, config) {        
        console.log(data);
        console.log(status);
    });
});