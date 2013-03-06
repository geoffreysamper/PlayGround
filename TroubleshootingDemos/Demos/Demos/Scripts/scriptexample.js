(function () {
    $(document).ready(function () {
        var callback = function (data) {
            var $container = $("#container");
            for (var i = 0; i < data.length; i++) {
                var h = "<div>" + data[i] + "</div>";
                $container.append($(h));
            }
        }


        $.getJSON("/Home/GetNumbers", {}, callback);


        $("#button").click(function () {
            console.log("testje");

        });

    });



})();