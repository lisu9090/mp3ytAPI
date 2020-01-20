const youtubeStream = require('youtube-audio-stream');

module.exports = function (result, vid) {

    const requestUrl = 'http://youtube.com/watch?v=' + vid;

    try {
        youtubeStream(requestUrl).pipe(result.stream);
    }
    catch (exception) {
        console.log(exception);
    }

}