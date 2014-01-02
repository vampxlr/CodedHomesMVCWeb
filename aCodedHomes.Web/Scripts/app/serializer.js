var serializer = (function() {

    var
        serialize = function(obj) {

            if (_.isArray(obj)) {
                _.each(obj, function(v, i) {
                    obj[i] = JSON.stringify(v);
                });
            }

            return JSON.stringify(obj);
        },

        deserialize = function(str) {
            var
                root = JSON.parse(str);

            if (_.isArray(root)) {
                _.each(root, function(v, i) {
                    root[i] = JSON.parse(v);
                });
            }

            return root;
        };

    return {
        serialize: serialize,
        deserialize: deserialize
    }
})();