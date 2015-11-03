(function() {
	'use strict';

	if (Array.prototype.addRange) return;

	Array.prototype.addRange = function (target) {
		this.push.apply(this, target);
	};
})();