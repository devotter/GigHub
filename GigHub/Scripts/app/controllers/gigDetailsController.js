var GigDetailsController = function (followingService) {

    var button;

    var init = function (container) {
        $(container).on("click", ".js-toggle-follow", toggleFollow);
    };

    var toggleFollow = function(e) {
        button = $(e.target);

        var userId = button.attr("data-user-id");

        if (button.hasClass("btn-default"))
            followingService.follow(userId, done, fail);
        else
            followingService.unfollow(userId, done, fail);
    };

    var done = function () {
        var text = (button.text() == "Follow") ? "Following" : "Follow";
        button.toggleClass("btn-default").toggleClass("btn-info").text(text);
    };

    var fail = function () {
        alert("Something failed!");
    };

    return {
        init: init
    }


}(FollowingService);