(function(angular) {
    angular.module('umbraco').directive('backofficeSnapshot', backofficeSnapshot);
    var dir = '/App_Plugins/UmbracoBackofficeVisualizer/';


    function backofficeSnapshot() {
        
        return {
            templateUrl: dir + 'directives/backofficeSnapshot.html',
            scope: {
                data:'='
            }
        }
    }


})(angular);