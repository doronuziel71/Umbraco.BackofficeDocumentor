(function (angular) {
    var dir = '/App_Plugins/UmbracoBackofficeVisualizer/';
    angular.module('umbraco').controller('backofficeDocumentorCtrl', backofficeDocumentorCtrl).filter('noextension',noExtensionFilter);

    function backofficeDocumentorCtrl($scope, dialogService, snapshots, notificationsService) {
        $scope.obj = null;
        $scope.file = {
            name: '',
            oldName:''
        };
        $scope.makeSnapshot=function() {
            snapshots
                .add()
                .then(notifySaved)
                .then(function (file) { init(file); });
        }

        $scope.showList = function() {
            dialogService.open({
                template: pathTo('list/list.html'),
                show: true,
                callback:init

            });
        }

        $scope.rename=function() {

                if ($scope.file.name) {
                    snapshots.rename($scope.file.oldName, $scope.file.name, $scope.obj).then(function (file) {
                        $scope.file.oldName = file;
                        $scope.file.name = file;
                        notificationsService.success("Success", "File has been saved");
                    });
                }

        }

        $scope.del = function () {
            if (confirm("Are You Sure")) {
                snapshots.del($scope.file.name).then(function () {
                    $scope.obj = null;
                    $scope.file = {
                        name: '',
                        oldName: ''
                    };
                });
            }
           
        }

        function init(file) {

            snapshots.get(file).then(function (obj) {
                $scope.file.name = file;
                $scope.file.oldName = file;
                 $scope.obj = obj;
            });

        }

        function notifySaved(filename) {
            notificationsService.success("Success", filename + " created");
            return filename;

        }

        function pathTo(file) {
            return dir + file;
        }
    }

    function noExtensionFilter() {
        
        return function(str) {
            if (!str || !angular.isString(str)) {
                return str;
            }

            return str.replace(/\.[^/.]+$/, "");
        }
    }


})(window.angular);