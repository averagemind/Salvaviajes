
$(document).ready(function () {

    Salvaviajes.Initialize();

    if ($(".issue-details").length > 0) {

        Issue.Initialize();
    }

    if ($("#map").length > 0) {

        Map.Initialize();
    }
});

var Salvaviajes = {

    Initialize: function() {

        if ($("#body ul#nav").length == 0) {

            $("#body").css("background-color", "#fff");
        }
    }
}

var Map = {

    Initialize: function () {

        $.getJSON("/api/Issue", function (data) {

            if (data != null && data.length > 0) {

                Map.populateMap(data);
            }
        });

        $(window).resize(function () { Map.resizeMap(); })
        Map.resizeMap();
    },

    populateMap: function (data) {

        var map = new google.maps.Map(document.getElementById('map'), {

            zoom: 5,
            center: new google.maps.LatLng(data[0].Lat, data[0].Lon),
            mapTypeId: google.maps.MapTypeId.ROADMAP
        });

        var infowindow = new google.maps.InfoWindow();
        var marker;

        $(data).each(function (e, t) {

            marker = new google.maps.Marker({

                position: new google.maps.LatLng(this.Lat, this.Lon),
                map: map,
                title: this.CategoryDescription
            });

            google.maps.event.addListener(marker, "click", (function (marker) {

                return function () {

                    infowindow.setContent(this.IssueDescription);
                    infowindow.open(map, marker);
                }
            }));
        });
    },

    resizeMap: function () {

        var headlineHeight = $("header").height() + $("#nav").height();
        var winHeight = window.innerHeight - headlineHeight;

        $("#map").height(winHeight - headlineHeight - 80)
                 .width($(".content-wrapper").width())
                 .css({ position: "relative" });
    }
}

var Issue = {

    Initialize: function () {

        $("#IssueCategory").val($("#SelectedCategory").val());

        $("#IssueCategory").change(function () {

            $("#SelectedCategory").val($(this).val());
        });

        $("#searchBox input[type='button']").click(function () {

            var searchTerm = $("#searchBox input[type='text']").val();

            if (searchTerm.length > 2) {

                $.get("/Issues/Search", { searchTerm: searchTerm }, function (results) {

                    if (results != null && $.trim(results).length > 0) {

                        $("#searchResults").empty().html(results);
                    }
                    else {

                        $("#searchResults").empty().html("<h2>No matching issues found</h2>");
                    }

                    $("#searchResults").next().empty();
                });
            }
        });
    }
}

function createGuid() {

    return 'xxxxxxxx-xxxx-4xxx-yxxx-xxxxxxxxxxxx'.replace(/[xy]/g, function (c) {

        var r = Math.random() * 16 | 0, v = c === 'x' ? r : (r & 0x3 | 0x8);
        return v.toString(16);
    });
}

