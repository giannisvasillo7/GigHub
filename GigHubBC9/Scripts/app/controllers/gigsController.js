let GigsController = function (attendanceService) {
    let button;

    let initial = function (container) {
        $(container).on("click", ".js-toggle-attendance", toggleAttendance);
        //$(".js-toggle-attendance").click(toggleAttendance);
    };

    let toggleAttendance = function (e) {
        button = $(e.target);
        let gigId = button.attr("data-gig-id");
        if (button.hasClass("btn-default"))
            attendanceService.createAttendance(gigId, done, fail);
        else
            attendanceService.deleteAttendance(gigId, done, fail);
    };

    let done = function () {
        let text = button.text() === "Going" ? "Going?" : "Going";
        button.toggleClass("btn-info").toggleClass("btn-default").text(text);
    };

    let fail = function () {
        alert("Something failed");
    };

    return {
        initial: initial
    };
}(AttendanceService);