angular.module('SPR')
.config(function($routeProvider){
    $routeProvider
    .when('/', {
        templateUrl: 'app/SPR/index.html',
        controller: 'sprController'
    })
    .otherwise({
        templateUrl: 'app/SPR/index.html',
        controller: 'sprController'
    });
});