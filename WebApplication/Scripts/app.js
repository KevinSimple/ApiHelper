var app = angular.module('myApp', ['ngRoute', 'ui.grid', 'ui.grid.edit', 'ui.grid.rowEdit' ]);

//Set up the routing 
app.config(function ($routeProvider) {
    $routeProvider

    .when('/', {
        templateUrl: '../../Static/App/Home.html',
        controller: 'HomeController'
    })

    .when('/Client', {
        templateUrl: '../../Static/App/Client.html',
        controller: 'ClientController'
    })

    .when('/ServerLogin', {
        templateUrl: '../../Static/App/ServerLogin.html',
        controller: 'ServerLoginController'
    })

    .otherwise({ redirectTo: '/' });
});

app.controller('HomeController', function ($scope) {
    $scope.message = 'Hello from HomeController';
});


//Define Client Controller
app.controller('ClientController',  function ($scope, $http, $location, $window, $q,$interval) {
    $scope.helloMessage = 'Hello from ClientController';
    $scope.cust = {};
    $scope.message = '';
    $scope.result = "color-default";
    $scope.isViewLoading = false;

    //get called when user submits the form
    $scope.submitForm = function () {
        $scope.isViewLoading = true;
        console.log('Form is submitted with:', $scope.cust);

        //$http service that send or receive data from the remote server
        $http({
            method: 'POST',
            url: '../../Client/CreateClient',
            data: $scope.cust
        }).success(function (data, status, headers, config) {
            $scope.errors = [];
            if (data.success === true) {
                $scope.cust = {};
                $scope.message = 'Form data Submitted!';
                $scope.result = "color-green";
                $location.path(data.redirectUrl);
                $window.location.reload();
            }
            else {
                $scope.errors = data.errors;
            }
        }).error(function (data, status, headers, config) {
            $scope.errors = [];
            $scope.message = 'Unexpected Error while saving data!!';
        });
        $scope.isViewLoading = false;
    }

    //Set up grid
    $scope.gridOptions = {
        enableSorting: true,
        columnDefs: [
              { name: 'Id', field: 'Id' },
          { name: 'FirstName', field: 'FirstName' },
          { name: 'LastName', field: 'LastName' },
          { name: 'CompanyName', field: 'CompanyName' },
           { name: 'Email', field: 'Email' }, {
               name: 'Action',
               cellTemplate: '<button class="btn primary" ng-click="grid.appScope.deleteRow(row)">Delete Me</button>'
           }
        ],
        onRegisterApi: function (gridApi) {
        $scope.gridApi = gridApi;
        gridApi.rowEdit.on.saveRow($scope, $scope.saveRow);}
    };

    //Define how to delete a row
    $scope.deleteRow = function (row) {
        var index = $scope.gridOptions.data.indexOf(row.entity);
        $scope.gridOptions.data.splice(index, 1);

        //Call DeleteClient
        $http({
            method: 'POST',
            url: '../../Client/DeleteClient',
            data: row.entity
        }).success(function (data, status, headers, config) {
            $scope.errors = [];
            if (data.success === true) {
              //Show message when succeded If needed
            }
            else {
                $scope.errors = data.errors;
            }
        }).error(function (data, status, headers, config) {
            $scope.errors = [];
            $scope.message = 'Unexpected Error while deleting data!!';
        });
    };


    //Define how to save a row
    $scope.saveRow = function (rowEntity) {
        var promise = $q.defer();
        $http.post('../../Client/EditClient', rowEntity).success(function () {
            $interval(function() {
                promise.resolved();
            }, 3000, 1);
        }).error(promise.reject);

        $scope.gridApi.rowEdit.setSavePromise($scope.gridApi.grid, rowEntity, promise);
    };

    //Get All clients for grid
    $http({
        method: 'GET',
        url: '../../Client/GetAllClient',
        data: $scope.cust
    }).success(function (data, status, headers, config) {
        $scope.errors = [];
        $scope.gridOptions.data = data;

    }).error(function (data, status, headers, config) {
        $scope.errors = [];
        $scope.message = 'Unexpected Error while saving data!!';
    });
});

app.controller('ServerLoginController', function ($scope) {
    $scope.message = 'Hello from ServerLoginController';
});
