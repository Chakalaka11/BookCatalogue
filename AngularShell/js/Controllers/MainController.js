
var server = "http://localhost:54146/";
var actionUrl = ["home/getall/","home/addbook/"];


app.controller('MainController', function ($scope, $http) {
    $scope.books = [];
    $scope.title = 'Book Catalogue';

    $scope.click = function (event) {
        document.getElementsByClassName("outer")[0].style.display = "block";
    }
    $scope.Match = function (pattern) {
       return function( item ) {
        if(pattern!=null){
          if(item.Name.toLowerCase().indexOf(pattern.toLowerCase())!=-1)
          {
            return item;
          }
          if(item.Author.toLowerCase().indexOf(pattern.toLowerCase())!=-1)
          {
            return item;
          }
        }
        else
        {
         return item ;
        }
      };
    }
     $scope.addbook = function () {
        $http.post((server+actionUrl[1]), { 
            name: document.getElementById("name").value,
            author : document.getElementById("author").value,
            price : document.getElementById("price").value
        }).success(function (data, status, headers, config) {
           alert(data);
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
    }).error(function (data, status, headers, config) {        
        console.log(data);
        console.log(status);
    });
});