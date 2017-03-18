angular.module('SPR')
.controller('sprController', function(
    $scope,
    $uibModal,
    $window,
    $filter,
    $location,
    $anchorScroll,
    $timeout,
    sprService
){
    $scope.showLoading = true;
    $scope.currentPage = 1;
    $scope.pagingOpt = {
        maxSize: 5,
        itemsPerPage: 5
    }

    $scope.clearFilter = function() {
        $scope.filter = {
            penyetujuan: '',
            adaDetail: '',
            status: ''
        };
    };

    $scope.showFilter = function(){        
        console.log('Filter', $scope.filter);
        console.log('Filtered Data', $scope.filteredHeaders);
    }

    $scope.pageChanged = function() {
        console.log('Current Page', $scope.currentPage);
    };
    
    $scope.loadModule = function() {
        sprService.getSPRHeader().then(
            function onSuccess(response){
                $scope.showLoading = false;
                $scope.headers = response.data;
                $scope.headersView = [];
                console.log('Retrieved Headers', $scope.headers);
                angular.forEach($scope.headers, function(header, headerKey) {
                    // Nama Zona                    
                    header.Nama_Zona = header.Kode_Zona == '00' ? 'ALL' : '';

                    // Jumlah Penyetujuan
                    if(header.Status_Disetujui1 && header.Status_Disetujui2) {
                        header.jumlahPenyetujuan = 2;
                    } else if (header.Status_Disetujui1 || header.Status_Disetujui2) {
                        header.jumlahPenyetujuan = 1;
                    } else {
                        header.jumlahPenyetujuan = 0;
                    }

                    // Detail exists
                    header.detailExists = header.Details.length > 0 ? true : false;

                    // Status
                    header.status = true;
                });
                   
                $scope.mainFilter = function(header) {
                    var filter = $scope.filter.main ? $scope.filter.main.toLowerCase() : '';
                    header.Kode_Spr = header.Kode_Spr ? header.Kode_Spr : '';
                    header.Nama_Zona = header.Nama_Zona ? header.Nama_Zona : '';
                    header.Tujuan_SPR = header.Tujuan_SPR ? header.Tujuan_SPR : '';
                    header.Nama_Peminta = header.Nama_Peminta ? header.Nama_Peminta : '';
                    header.Nama_Penyetuju1 = header.Nama_Penyetuju1 ? header.Nama_Penyetuju1 : '';
                    header.Nama_Penyetuju2 = header.Nama_Penyetuju2 ? header.Nama_Penyetuju2 : '';
                    var formatedTanggalSpr = $filter('date')(header.Tanggal_Spr, "dd-MMM-yyyy").toLowerCase();
                    return header.Kode_Spr.toLowerCase().indexOf(filter) > -1
                        || header.Nama_Zona.toLowerCase().indexOf(filter) > -1
                        || formatedTanggalSpr.indexOf(filter) > -1
                        || header.Tujuan_SPR.toLowerCase().indexOf(filter) > -1
                        || header.Nama_Peminta.toLowerCase().indexOf(filter) > -1
                        || header.Nama_Penyetuju1.toLowerCase().indexOf(filter) > -1
                        || header.Nama_Penyetuju2.toLowerCase().indexOf(filter) > -1
                };
                
                //$scope.pageChanged();
            }, function onError(response){
                console.log(response);
            }
        );
    };

    $scope.openModal = function (configuration, param) {
        var modalOptions = {
            size: configuration.size,
            templateUrl: configuration.templateUrl,
            controller: configuration.controller,
            backdrop: configuration.backdrop,
            resolve: {
            	param: function() {
            		return param;
            	}
            }
        };

        $scope.modalInstance = $uibModal.open(modalOptions);
        $scope.modalInstance.result.then(function onSuccess(result) {
			$window.alert("Save success.");
            $scope.loadModule();
        }, function onError(reason) {
            // Do something
        });
    };

    $scope.addSPR = function() {
        var configuration = {
            size: 'lg',
            templateUrl: '/Web/app/SPR/sprHeader.modal.html',
            backdrop: true,
            controller: 'sprHeaderModalController'
        };

        var param = {};
        $scope.openModal(configuration, param);
    };

    $scope.AddDetail = function(header) {
        var configuration = {
            size: 'lg',
            templateUrl: '/Web/app/SPR/sprDetail.modal.html',
            backdrop: true,
            controller: 'sprDetailModalController'
        };

        var param = {
            Kode_Spr: header.Kode_Spr
        };
        $scope.openModal(configuration, param);
    };

    $scope.EditHeader = function(header) {
        var configuration = {
            size: 'lg',
            templateUrl: '/Web/app/SPR/sprHeader.modal.html',
            backdrop: true,
            controller: 'sprHeaderModalController'
        };

        var param = header;
        $scope.openModal(configuration, param);
    }

    $scope.Delete = function(header) {
        var result = $window.confirm('Delete this data?');
        if(result) {
            sprService.deleteSPRHeader(header).then(
            function onSuccess(response) {
                $window.alert('Data has been deleted');
                $scope.loadModule();
            }, function onError(response) {
                // Do something
            });
        }
    };

    $scope.showDetail = function(headerId, details) {
        $scope.detailShown = true;        
        $scope.selectedDetailHeader = headerId;
        $scope.selectedDetails = details;
        angular.forEach($scope.selectedDetails, function (detail, detailKey){
            if(detail.Jenis_Material == '01') {
                detail.NamaJenisMaterial = 'Pokok'
            } else {
                detail.NamaJenisMaterial = 'Non-Pokok'
            }
        });
        $timeout(function (){
            $location.hash('detail');
            $anchorScroll();            
        });
    };

    $scope.loadModule();
    $scope.clearFilter();
});
