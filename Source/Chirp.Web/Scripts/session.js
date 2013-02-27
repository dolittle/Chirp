Bifrost.namespace("Chirp", {
    sessionManager: Bifrost.Type.extend(function () {
        var self = this;
        var chirpUserIdKey = "chirpUserId";
        var chirpUserNameKey = "chirpUserName";

        this.getCurrentUserId = function () {
            //            return "03F1D667-063B-4D15-B892-06F89818E9A8";
            var currentUserId = $.cookies.get(chirpUserIdKey);
            return currentUserId;
        }

        this.setSessionId = function (userId, userName) {
            $.cookies.set(chirpUserIdKey, userId);
            $.cookies.set(chirpUserNameKey, userName);
        }

        this.clearSession = function () {
            $.cookies.delete(chirpUserIdKey);
        }

        this.getCurrentUserName = function () {
            var currentUserName = $.cookies.get(chirpUserNameKey);
            return currentUserName;
        }

        this.isUserLoggedIn = function () {
            var currentUserId = self.getCurrentUserId();
            var currentUserName = self.getCurrentUserName();

            if(!currentUserName || currentUserName == "")
                return false;

            if (!currentUserId || currentUserId == Bifrost.Guid.empty)
                return false;
            return true;
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