$(function () {
    var monitor = $.connection.monitorHub;
    monitor.client.AddRequest = function (request) {
        var $request = $('<div class="request"/>')
            .append($('<div class="time">').html(request.Time))
            .append($('<pre class="info">').html(request.Info));
        if (request.Content)
            $request.append($('<pre class="content">').html(request.Content));

        $request.prependTo('.requests')
            .slideDown('slow');
    };
    $.connection.hub.start()
        .done(function () {
            monitor.server.monitor(window.location.search.replace(/^\?/, ""))
                .done(function (channel) {
                    history.pushState(null, null, '?' + channel);
                    var monitorLink = window.location.href;
                    var apiLink = monitorLink.replace(/\?/, "");
                    $('.help .api').attr('href', apiLink).html(apiLink);
                    $('.monitor-link').attr('href', monitorLink);
                    $('.help').show();
                });
        });
});