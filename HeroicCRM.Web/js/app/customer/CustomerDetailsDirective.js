(function () {
    'use strict';

    window.app.directive('customerDetails', customerDetails);
    function customerDetails() {
        return {
            scope: {
                customer: '='
            },
            templateUrl: '/customer/template/customerDetails.tmpl.cshtml',
            controller: controller,
            controllerAs: 'vm'
        }
    }

    controller.$inject = ['$scope', '$modal'];
    function controller($scope, $modal) {
        var vm = this;

        vm.customer = $scope.customer;
        vm.selectedView = 'details';
        vm.setView = setView;
        vm.edit = edit;
        vm.addWish = addWish;
        vm.addProduct = addProduct;
        vm.customer = $scope.customer;

        function setView(view) {
            vm.selectedView = view;
        }


        function edit() {
            $modal.open({
                template: '<edit-customer customer="customer" />',
                scope: angular.extend($scope.$new(true), { customer: vm.customer })
            });
        }

        function addWish() {
            $modal.open({
                template: '<add-wish customer="customer" />',
                scope: angular.extend($scope.$new(true), { customer: vm.customer })
            });
        }

        function addProduct() {
            $modal.open({
                template: '<add-product customer="customer" />',
                scope: angular.extend($scope.$new(true), { customer: vm.customer })
            });
        }
    }
})();