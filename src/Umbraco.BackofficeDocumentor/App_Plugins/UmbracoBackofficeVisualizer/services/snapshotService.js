(function (angular) {
    angular.module('umbraco').factory('snapshots', snapshots);

    function snapshots($http) {
        var endpoint = '/umbraco/backoffice/api/snapshots/';

        return {
            list: list,
            get: get,
            del: del,
            save: save,
            add: add,
            rename:rename
        }


        function list() {
            return $http.get(url('list')).then(unpack);
        }

        function rename(oldname, newname, snapshot) {

            return $http.post(url('rename'), { oldName: oldname, newName: newname,snapshot:snapshot }).then(unpack).then(cleanPar);
        }

        function get(name) {
            return $http.get(url('get') + '?name=' + name)
                .then(unpack);

        }

        function del(name) {
            return $http.post(url('delete?file=' + name)).then(unpack);
        }

        function save(name, snapshot) {

        }

        function add() {
            return $http.post(url('new')).then(unpack).then(cleanPar);
        }


        function url(action) {
            return endpoint + action;
        }

        function unpack(response) {
            return response.data;
        }

        function cleanPar(file) {
            return file.substr(1, file.length - 2);
        }
    }

})(window.angular);