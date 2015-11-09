(function () {
    'use strict';

    window.app.directive('addWish', addWish);

    function addWish() {
        return {
            scope: {
                customer: "="
            },
            templateUrl: '/wish/template/addWish.tmpl.cshtml',
            controller: controller,
            controllerAs: 'vm'
        }
    }

    controller.$inject = ['$scope', '$http'];
    function controller($scope, $http) {
        var vm = this;

        vm.saving = false;
        vm.wish = {
            customerId: $scope.customer.id
        }

        vm.add = add;

        function add() {
            vm.saving = true;

            $http.post('/Wish/Add', vm.wish)
				.success(function (data) {
				    $scope.customer.wishes.push(data);
				    //Close the modal
				    $scope.$parent.$close();
				})
				.error(function (data) {
				    vm.errorMessage = "There was a problem adding the wish: " + data;
				})
				.finally(function () {
				    vm.saving = false;
				});
        }
    }
})();