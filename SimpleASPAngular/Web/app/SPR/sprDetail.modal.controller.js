angular.module('SPR')
.controller('sprDetailModalController', function(
    $scope, 
    $uibModalInstance,
    param, 
    sprService
){
    $scope.detail = angular.copy(param);
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
    $scope.validation = {
        error: false,
        Kode_Material: 'Material harus dipilih',
        Volume: 'Volume harus diisi'
    };
    $scope.jenisMaterial = {
        pokok: '01',
        nonPokok: '02'
    };
    
    if(param.Kode_Material == null){
        $scope.detail.Tanggal_Rencana_Terima = new Date(param.Tanggal_Spr);
        $scope.detail.Tanggal_Rencana_Terima.setDate($scope.detail.Tanggal_Rencana_Terima.getDate() + 14);
        $scope.detail.Status_Disetujui = false;
    } else {
        $scope.detail.Tanggal_Rencana_Terima = new Date(param.Tanggal_Rencana_Terima);
    }
    
    console.log('Detail', $scope.detail);

    $scope.checkMaterialType = function(type) {
        if(type == '01'){
            sprService.getMaterial().then(
                function onSuccess(response) {
                    $scope.materials = response.data;
                }, function onError(response) {
                    // do something
                }
            );
        } else if(type == '02') {
            sprService.getMaterialNonPokok().then(
                function onSuccess(response) {
                    $scope.materials = response.data;
                }, function onError(response) {
                    // do something
                }
            );
        }
    }

    sprService.getUnit().then(
        function onSuccess(response) {
            $scope.units = response.data;
        }, function onError(response) {
            // do something
        }
    );

    $scope.save = function(detail) {
        console.log('Saved Detail', detail);
        if(!$scope.detail.Kode_Material || $scope.detail.Kode_Material == '' 
        || !$scope.detail.Volume || $scope.detail.Volume == '') {
            $scope.validation.error = true;
            return;
        }
        if(param.Kode_Material == null){
            sprService.addSPRDetail(detail).then(
            function onSuccess(response) {
                $uibModalInstance.close(response);
            }, function onError(response) {
                $scope.cancel(response);
            });
        } else {
            sprService.editSPRDetail(detail).then(
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

    $scope.checkMaterialType($scope.detail.Jenis_Material);
});