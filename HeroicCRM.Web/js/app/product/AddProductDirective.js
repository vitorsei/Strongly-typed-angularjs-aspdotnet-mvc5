(function () {
    'use strict';

    window.app.directive('addProduct', addProduct);

    function addProduct() {
        return {
            scope: {
                customer: "="
            },
            templateUrl: '/product/template/addProduct.tmpl.cshtml',
            controller: controller,
            controllerAs: 'vm'
        }
    }

    controller.$inject = ['$scope', '$http'];
    function controller($scope, $http) {
        var vm = this;

        vm.saving = false;
        vm.product = {
            customerId: $scope.customer.id
        }

        vm.add = add;

        function add() {
            vm.saving = true;

            $http.post('/Product/Add', vm.product)
				.success(function (data) {
				    $scope.customer.products.push(data);
				    //Close the modal
				    $scope.$parent.$close();
				})
				.error(function (data) {
				    vm.errorMessage = 'There was a problem adding the product: ' + data;
				})
				.finally(function () {
				    vm.saving = false;
				});
        }
    }
})();