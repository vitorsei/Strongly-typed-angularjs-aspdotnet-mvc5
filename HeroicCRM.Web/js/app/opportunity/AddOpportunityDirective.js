(function() {
	'use strict';

	window.app.directive('addOpportunity', addOpportunity);

	function addOpportunity() {
		return {
			scope: {
				customer: "="
			},
			templateUrl: '/js/app/opportunity/templates/addOpportunity.tmpl.html',
			controller: controller,
			controllerAs: 'vm'
		}
	}

	controller.$inject = ['$scope', '$http'];
	function controller($scope, $http) {
		var vm = this;

		vm.saving = false;
		vm.opportunity = {
			customerId: $scope.customer.Id
		}

		vm.add = add;

		function add() {
			vm.saving = true;

			$http.post('/Opportunity/Add', vm.opportunity)
				.success(function (data) {
					$scope.customer.Opportunities.push(data);
					//Close the modal
					$scope.$parent.$close();
				})
				.error(function (data) {
					vm.errorMessage = "There was a problem adding the opportunity: " + data;
				})
				.finally(function () {
					vm.saving = false;
				});
		}
	}
})();