(function (angular) {
    angular.module('umbraco').controller('backofficeDocumentorList', controller);


    function controller($scope, snapshots, notificationsService) {
        $scope.files = [];




        activate();


        $scope.del=function(index) {
            snapshots.del($scope.files[index])
                .then(notifyDelete($scope.files[index]))
                .then($scope.files.splice(index,1));
        }

        function activate() {
            snapshots.list().then(function (f) { $scope.files = f; });
        }

        function notifyDelete() {
            return function (filename) {
                notificationsService.success("Success", filename + " deleted");
            }
        }


    }


})(angular)