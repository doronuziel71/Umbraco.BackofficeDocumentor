(function (angular) {
    "use strict";
    var dir = '/App_Plugins/UmbracoBackofficeVisualizer/';
    angular.module('umbraco').directive('datatypeDescriptor', datatypeDescriptor);

    function datatypeDescriptor() {
        return {
            templateUrl: dir + 'directives/datatypeDescriptor.html',
            scope: {
                data: '='
            },
            controller:function($scope) {
                $scope.isJson = function (str) {
                    if (!str) {
                        return false;
                    }
                   return !!(/^[\],:{}\s]*$/.test(str.replace(/\\["\\\/bfnrtu]/g, '@').replace(/"[^"\\\n\r]*"|true|false|null|-?\d+(?:\.\d*)?(?:[eE][+\-]?\d+)?/g, ']').replace(/(?:^|:|,)(?:\s*\[)+/g, '')));
               }
            }
        }
    }
})(angular);