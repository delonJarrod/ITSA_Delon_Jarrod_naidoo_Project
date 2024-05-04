
// Search Logic Admin/Index Start
//********************************************************************************************/
$(document).ready(function () {
    $("#searchForm").submit(function (event) {
        event.preventDefault();
        var UserID = $("#Search").val();
        $("#preloader").show();
        $.ajax({
            url: "/Admin/SearchResults",
            method: "POST",
            data: { searchItem: UserID },
            success: function (data) {
                $("#SearchResult").html(data);
                $("#preloader").hide();
            },
            error: function (xhr, status, error) {
                console.error(xhr.responseText);
                $("#preloader").hide();
            }
        });
    });

});


// Search Logic Admin/Index END
//********************************************************************************************/
