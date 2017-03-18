angular.module('SPR')
.factory('sprService', function(
    $q,
    $http
){
    var sprService = {
        getSPRHeader: function() {
            var deferred = $q.defer();
            return $http({
                method: 'GET',
                url: '/api/SPRHeader'
            }, function onSuccess(response) {
                deferred.resolve(response)
                return deferred.promise;
            }, function onError(response) {
                deferred.resolve(response)
                return deferred.promise;
            });
        },
        addSPRHeader: function(header) {
            var deferred = $q.defer();
            return $http({
                method: 'POST',
                url: '/api/SPRHeader/add',
                data: JSON.stringify(header),
                headers: { 'Content-Type': 'application/json' }
            }, function onSuccess(response) {
                deferred.resolve(response)
                return deferred.promise;
            }, function onError(response) {
                deferred.resolve(response)
                return deferred.promise;
            });
        },
        deleteSPRHeader: function(header) {
            var deferred = $q.defer();
            return $http({
                method: 'POST',
                url: '/api/SPRHeader/delete',
                data: JSON.stringify(header),
                headers: { 'Content-Type': 'application/json' }
            }, function onSuccess(response) {
                deferred.resolve(response)
                return deferred.promise;
            }, function onError(response) {
                deferred.resolve(response)
                return deferred.promise;
            });
        },
        editSPRHeader : function(header){
            var deferred = $q.defer();
            return $http({
                method: 'POST',
                url: '/api/SPRHeader/edit',
                data: JSON.stringify(header),
                headers: { 'Content-Type': 'application/json' }
            }, function onSuccess(response) {
                deferred.resolve(response)
                return deferred.promise;
            }, function onError(response) {
                deferred.resolve(response)
                return deferred.promise;
            });
        },
        getMaterial : function(){
            var deferred = $q.defer();
            return $http({
                method: 'GET',
                url: '/api/Materials'
            }, function onSuccess(response) {
                deferred.resolve(response)
                return deferred.promise;
            }, function onError(response) {
                deferred.resolve(response)
                return deferred.promise;
            });
        },
        getMaterialNonPokok : function(){
            var deferred = $q.defer();
            return $http({
                method: 'GET',
                url: '/api/MaterialNonPokok'
            }, function onSuccess(response) {
                deferred.resolve(response)
                return deferred.promise;
            }, function onError(response) {
                deferred.resolve(response)
                return deferred.promise;
            });
        },
        getUnit : function(){
            var deferred = $q.defer();
            return $http({
                method: 'GET',
                url: '/api/Unit'
            }, function onSuccess(response) {
                deferred.resolve(response)
                return deferred.promise;
            }, function onError(response) {
                deferred.resolve(response)
                return deferred.promise;
            });
        }
    };

    return sprService;
});