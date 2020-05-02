var FollowingService = function () {
    var follow = function (userId, done, fail) {
        $.post("/api/followings", { followeeId: userId })
            .done(done)
            .fail(fail);
    };

    var unfollow = function (userId, done, fail) {
        $.ajax({
            url: "/api/followings/" + userId,
            method: "DELETE"
        })
            .done(done)
            .fail(fail);
    };

    return {
        follow: follow,
        unfollow: unfollow
    }
}();