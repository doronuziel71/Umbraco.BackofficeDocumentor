(function(angular) {
    "use strict";
    var dir = '/App_Plugins/UmbracoBackofficeVisualizer/';
    angular.module('umbraco').directive('doctypeDescriptor', doctypeDescriptor);

    function doctypeDescriptor() {
        
        return {
            templateUrl: dir + 'directives/doctypeDescriptor.html',
            scope: {
                data:'='
            }
        }
    }
})(angular);