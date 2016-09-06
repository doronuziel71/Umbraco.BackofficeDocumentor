(function (angular) {
    var dir = '/App_Plugins/UmbracoBackofficeVisualizer/';
    angular.module('umbraco').directive('backofficeDocumentorComments', backofficeDocumentorComments);

    function backofficeDocumentorComments() {
        return {
            templateUrl: dir + 'directives/backofficeDocumentorComments.html',
            scope: {
                comments:'='
            },
            controller:function($scope) {
                
                $scope.add = function (comment) {
                    if (!$scope.comments) {
                        return;
                    }
                    $scope.comments.push(comment);
                    $scope.newValue = '';

                }
                $scope.del= function(index) {
                    if (!$scope.comments) {
                        return;
                    }
                    $scope.splice(index, 1);

                }
            }
        }
    }
})(angular)