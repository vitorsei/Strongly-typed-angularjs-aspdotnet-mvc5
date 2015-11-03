(function() {
	'use strict';

	window.app.directive('addRisk', addRisk);

	function addRisk() {
		return {
			scope: {
				customer: "="
			},
			templateUrl: '/js/app/risk/templates/addRisk.tmpl.html',
			controller: controller,
			controllerAs: 'vm'
		}
	}

	controller.$inject = ['$scope', '$http'];
	function controller($scope, $http) {
		var vm = this;

		vm.saving = false;
		vm.risk = {
			customerId: $scope.customer.Id
		}

		vm.add = add;

		function add() {
			vm.saving = true;

			$http.post('/Risk/Add', vm.risk)
				.success(function (data) {
					$scope.customer.Risks.push(data);
					//Close the modal
					$scope.$parent.$close();
				})
				.error(function (data) {
					vm.errorMessage = 'There was a problem adding the risk: ' + data;
				})
				.finally(function () {
					vm.saving = false;
				});
		}
	}
})();