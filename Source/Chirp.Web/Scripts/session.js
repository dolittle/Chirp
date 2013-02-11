Bifrost.namespace("Chirp", {
    sessionManager: Bifrost.Type.extend(function () {
        var self = this;
        var chirpUserIdKey = "chirpUserId";

        this.getCurrentUserId = function () {
            //            return "03F1D667-063B-4D15-B892-06F89818E9A8";
            var currentUserId = $.cookies.get(chirpUserIdKey);
            return currentUserId;
        }

        this.setSessionId = function (userId) {
            $.cookies.set(chirpUserIdKey, userId);
        }

        this.clearSession = function () {
            $.cookies.delete(chirpUserIdKey);
        }

        this.getUserIdFor = function (userName) {
            var promise = Bifrost.execution.Promise.create();

            if (userName[0] != "@")
                userName = "@" + userName;

            $.get("/User/GetUserId", { userName: userName }, function (userId) {
                promise.signal(userId);
            });

            return promise;
        }

    })
});