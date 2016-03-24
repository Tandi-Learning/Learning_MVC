$(function() {
    $('#GetData').click(function () {
        var GetMovies = $.getJSON(getMoviesURL);
        var GetMusic = $.getJSON(getMusicURL);

        // ** Ex 1 **
        //GetMovies
        //    .done(fnGetMoviesDone)
        //    .fail(fnFail)
        //    .always(fnAlways);

        //GetMusic
        //    .done(fnGetMusicDone)
        //    .fail(fnFail)
        //    .always(fnAlways);

        // ** Ex 2 **
        $.when(GetMovies, GetMusic).done(fnDone(GetMovies, GetMusic))
    })
    
    function fnGetMoviesDone(response) {
        if (response != null) {
            $("#MovieList li").remove();
            for (var i = 0; i < response.length; i++) {
                $("#MovieList").append("<li>" + response[i].Title + " - " + response[i].Genre + " (" + response[i].Year + ")</li>")
            }
        }
    }

    function fnGetMusicDone(response) {
        if (response != null) {
            $("#MusicList li").remove();
            for (var i = 0; i < response.length; i++) {
                $("#MusicList").append("<li>" + response[i].Title + " - " + response[i].Genre + " (" + response[i].Year + ")</li>")
            }
        }
    }
    
    function fnDone(GetMovies, GetMusic)
    {
        GetMovies
            .done(fnGetMoviesDone)
            .fail(fnFail)
            .always(fnAlways);

        GetMusic
            .done(fnGetMusicDone)
            .fail(fnFail)
            .always(fnAlways);
    }

    function fnFail(response)
    {
        alert('fail');
    }
    
    function fnAlways(response)
    {
        $("#result").html(new Date($.now()) + " Finish");
    }

})