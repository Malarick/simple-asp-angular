angular.module('SPR')
.controller('sprHeaderModalController', function(
    $scope, 
    $uibModalInstance,
    param, 
    sprService
){
    $scope.header = param;

    $scope.dateFormat = 'dd-MMM-yyyy';
    $scope.dateOptions = {
        dateDisabled: false,
        formatYear: 'yyyy',
        maxDate: new Date(2050, 5, 22),
        startingDay: 1
    };
    $scope.popup1 = {
        opened: false
    }
    $scope.open1 = function() {
        $scope.popup1.opened = true;
    };
    
    if(param.Kode_Spr == null){
        $scope.header.Kode_Proyek = '1283';
        $scope.header.Kode_Zona = '00';
        $scope.header.Tanggal_Spr = new Date();
        $scope.header.Status_Disetujui1 = false;
        $scope.header.Status_Disetujui2 = false;
    } else {
        $scope.header.Tanggal_Spr = new Date(param.Tanggal_Spr);
    }

    $scope.save = function(header) {
        if(param.Kode_Spr == null){
            sprService.addSPRHeader(header).then(
            function onSuccess(response) {
                $uibModalInstance.close(response);
            }, function onError(response) {
                $scope.cancel(response);
            });
        } else {
            sprService.editSPRHeader(header).then(
            function onSuccess(response) {
                $uibModalInstance.close(response);
            }, function onError(response) {
                $scope.cancel(response);
            });
        }
    };

    $scope.cancel = function(msg){
        $uibModalInstance.dismiss(msg);
    };
});