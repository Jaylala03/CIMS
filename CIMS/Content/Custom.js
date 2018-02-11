$(".Tableview th").click(function () {

    if ($(this)[0].innerText == "Media" || $(this)[0].innerText == "Image" || $(this)[0].innerText == "Action") return;

    var thx = $(".Tableview").find('th');

    $.each(thx, function (i, j) {
        $(this).removeClass('headerSortDown');
    });

    $(this).addClass('headerSortDown');

});

var jsArray = {};

function loadScript(scriptName, callback) {
    debugger
    if (!jsArray[scriptName]) {
        jsArray[scriptName] = true;

        // adding the script tag to the head as suggested before
        var body = document.getElementsByTagName('body')[0];
        var script = document.createElement('script');
        script.type = 'text/javascript';
        script.src = scriptName;

        // then bind the event to the callback function
        // there are several events for cross browser compatibility
        //script.onreadystatechange = callback;
        script.onload = callback;

        // fire the loading
        body.appendChild(script);

    } else if (callback) {// changed else to else if(callback)
        //console.log("JS file already added!");
        //execute function
        callback();
    }

}