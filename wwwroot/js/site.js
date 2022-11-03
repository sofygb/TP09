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