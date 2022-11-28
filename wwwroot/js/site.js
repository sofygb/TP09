// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


function mostrarinfolibrosencard(intlib)
{
    $.ajax(
        {
            type: 'GET',
            dataType: 'JSON',
            url: '/Home/VerDetalleLibroAjax',
            data: { IdLibro: intlib },
            success:
                function (response)
                {
                    $("#TituloPrincipal").text(response.nombre);
                    let body= "<b>Autor: </b>" + response.autor + "<br> <b>Sinopsis: </b>" + response.descripción + "<br>";
                        $("#Cuerpo").html(body);
                    
                }
        });
}

//mostrarComentatios y calificarLibro TIENEN QUE SER LA MISMA FUNCIÓN
function mostrarComentatios(comment)
{
    $.ajax(
        {
            type: 'GET',
            dataType: 'JSON',
            url: '/Home/calificacionLibroAjax',
            data: {comentarios: comment},
            success: function (response)
                {
                    $("#Comentarios").text(response.comentarios);
                    let body= response.comentarios;
                        $("#Cuerpo").html(body);
                    }
        });
}

function mostrarCaificacionesLibro(IdL)
{
    $.ajax(
        {
            type: 'GET',
            dataType: 'JSON',
            url: '/Home/calificacionLibroAjax',
            data: {IdLibro: IdL},
            success: function (response)
                {
                    $("#Calificacion").text(response.estrellas);
	            $("#Comentarios").text(response.comentarios);
                    let body= response.comentarios;
                    $("#Cuerpo").html(body);
                    }
        });
}

$(function() {

    $('#login-form-link').click(function(e) {
		$("#login-form").delay(100).fadeIn(100);
 		$("#register-form").fadeOut(100);
		$('#register-form-link').removeClass('active');
		$(this).addClass('active');
		e.preventDefault();
	});
	$('#register-form-link').click(function(e) {
		$("#register-form").delay(100).fadeIn(100);
 		$("#login-form").fadeOut(100);
		$('#login-form-link').removeClass('active');
		$(this).addClass('active');
		e.preventDefault();
	});

});

function jsCancelSubmission()
{
   
}
