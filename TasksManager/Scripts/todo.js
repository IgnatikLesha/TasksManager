$(function () {
    var $id = $(".TaskId").text();
    var $thisBtn = $("#btnDone");
    $thisBtn.on("click", done($thisBtn));
    var passTask = $(".btn-primary").css("cursor");
    if (passTask === "pointer") {
        $.ajax({
            url: "/api/home/SETDONE/" + $id
        });
    }

});

function done(btn) {

    btn.off("click");
    btn.css({ "color": "red", "cursor": "default" });

}