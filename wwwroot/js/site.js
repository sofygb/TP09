// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function calificarLibro(cal)
{
    $.ajax(
        {
            type: 'GET',
            dataType: 'JSON',
            url: '/Home/calificacionLibroAjax',
            data: {likes: cal},
            success: function (response)
                {
                    $("#Calificacion").text(response.likes);
                    let body= response.likes;
                        $("#Cuerpo").html(body);
                    }
        });
}
