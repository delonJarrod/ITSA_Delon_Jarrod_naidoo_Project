// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


$(document).ready(function () {
    var $window = $(window);
    var didScroll,
        lastScrollTop = 0,
        delta = 5,
        $mainNav = $("#sticky"),
        $mainNavHeight = $mainNav.outerHeight(),
        scrollTop;

    $window.on("scroll", function () {
        didScroll = true;
        scrollTop = $(this).scrollTop();
    });

    setInterval(function () {
        if (didScroll) {
            hasScrolled();
            didScroll = false;
        }
    }, 200);

    function hasScrolled() {
        if (Math.abs(lastScrollTop - scrollTop) <= delta) {
            return;
        }
        if (scrollTop > lastScrollTop && scrollTop > $mainNavHeight) {
            $mainNav.css("top", -$mainNavHeight);
        } else {
            if (scrollTop + $(window).height() < $(document).height()) {
                $mainNav.css("top", 0);
            }
        }
        lastScrollTop = scrollTop;
    }

    //sticky header
    function navbarFixed() {
        if ($("#sticky").length) {
            $(window).scroll(function () {
                var scroll = $(window).scrollTop();
                if (scroll) {
                    $("#sticky").addClass("navbar_fixed");
                } else {
                    $("#sticky").removeClass("navbar_fixed");
                }
            });
        }
    }
    navbarFixed();

    $(".navbar-nav > li .mobile_dropdown_icon").on("click", function (e) {
        $(this).parent().find("ul").first().toggle(300);
        $(this).parent().siblings().find("ul").hide(300);
    });

    if ($(".submenu").length) {
        $(".submenu > .dropdown-toggle").on("click", function () {
            var location = $(this).attr("href");
            window.location.href = location;
            return false;
        });
    }


    //initialize smmothscroll
    if ($("header").length) {
        $("header").smoothScroll();
    }

    if ($("#banner_animation").length > 0) {
        $("#banner_animation").parallax({
            scalarX: 10.0,
            scalarY: 7.0,
        });
    }
    if ($("#banner_animation2").length > 0) {
        $("#banner_animation2").parallax({
            scalarX: 10.0,
            scalarY: 0.0,
        });
    }
    if ($("#card_area_animation").length > 0) {
        $("#card_area_animation").parallax({
            scalarX: 10.0,
            scalarY: 0.0,
        });
    }
    if ($("#MouseMoveAnimation").length > 0) {
        $("#MouseMoveAnimation").parallax({
            scalarX: 5.0,
            scalarY: 10.0,
        });
    }

    if ($("#readOnlyClose").length) {
        $("#readOnlyClose").on("click", function () {
            $("#locationSelect").val("");
            $("#locationSelect").focus();
        });
    }

    // === Back to Top Button
    var back_top_btn = $("#back-to-top");

    $(window).scroll(function () {
        if ($(window).scrollTop() > 300) {
            back_top_btn.addClass("show");
        } else {
            back_top_btn.removeClass("show");
        }
    });

    back_top_btn.on("click", function (e) {
        e.preventDefault();
        $("html, body").animate({ scrollTop: 0 }, "300");
    });

    /*------------ Added Dark Mode ------------*/
    function createCookie(name, value, days) {
        var expires = "";
        if (days) {
            var date = new Date();
            date.setTime(date.getTime() + days * 24 * 60 * 60 * 1000);
            expires = "; expires=" + date.toUTCString();
        }
        document.cookie = name + "=" + value + expires + "; path=/";
    }

    function readCookie(name) {
        var nameEQ = name + "=";
        var ca = document.cookie.split(";");
        for (var i = 0; i < ca.length; i++) {
            var c = ca[i];
            while (c.charAt(0) == " ") c = c.substring(1, c.length);
            if (c.indexOf(nameEQ) == 0) return c.substring(nameEQ.length, c.length);
        }
        return null;
    }

    var prefersDark =
        window.matchMedia &&
        window.matchMedia("(prefers-color-scheme: dark)").matches;
    var selectedNightTheme = readCookie("body_dark");

    if (
        selectedNightTheme == "true" ||
        (selectedNightTheme === null && prefersDark)
    ) {
        applyNight();
        $(".dark_mode_switcher").prop("checked", true);
    } else {
        applyDay();
        $(".dark_mode_switcher").prop("checked", false);
    }

    function applyNight() {
        if ($(".js-darkmode-btn .ball").length) {
            $(".js-darkmode-btn .ball").css("left", "26px");
        }
        $("body").addClass("body_dark");
    }

    function applyDay() {
        if ($(".js-darkmode-btn .ball").length) {
            $(".js-darkmode-btn .ball").css("left", "3px");
        }
        $("body").removeClass("body_dark");
    }

    $(".dark_mode_switcher").change(function () {
        if ($(this).is(":checked")) {
            applyNight();

            createCookie("body_dark", true, 999);
        } else {
            applyDay();
            createCookie("body_dark", false, 999);
        }
    });
        // End of Dark Mode



    //initialize niceselect
    if ($("#select-lang").length) {
        $("#select-lang").niceSelect();
    }
    if ($("#select-loan-type").length) {
        $("#select-loan-type").niceSelect();
    }
    if ($("#loandetails01").length) {
        $("#loandetails01").niceSelect();
    }
    if ($("#loandetails02").length) {
        $("#loandetails02").niceSelect();
    }
    if ($("#dob-d").length) {
        $("#dob-d").niceSelect();
    }
    if ($("#dob-m").length) {
        $("#dob-m").niceSelect();
    }
    if ($("#dob-y").length) {
        $("#dob-y").niceSelect();
    }
    if ($("#sort-select").length) {
        $("#sort-select").niceSelect();
    }


});