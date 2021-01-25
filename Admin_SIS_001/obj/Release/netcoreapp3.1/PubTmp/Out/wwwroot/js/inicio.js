
$(document).ready(function () {
    eventosclick();
    new jBox('Tooltip', { attach: '#btnTraerUsuarios', title: "Cargar todos los usuarios" });
}); 

function forceLower(strInput) {
    strInput.value = strInput.value.toLowerCase();
}

function eventosChange() {
    $('#selectUsers').change(function () {
        $('#hf_username').val($("#selectUsers option:selected").text());
    });
}
function eventosclick() {
    $('#btnTraerUsuarios').click(function () {
        var usuarios = $("#selectUsers");
        $.ajax({
            //  async: false,
            method: "GET",
            url: "/Login/Login/GetDistribuidor",
            contentType: "application/json; charset=utf-8",
            data: { rfc : $('.txtrfc').val() },
            dataType: "json",
            beforeSend: function () {
            },
            success: function (data) {
                if (data.success) {
                    usuarios.find('option').remove();
                    //usuarios.append('<option value="' + 0 + '">Administrador</option>');
                    $(data.data).each(function (i, v) { // indice, valor
                        usuarios.append('<option value="' + v.id + '">' + v.username + '</option>');
                    });
                    $('#hf_id_dist').val(data.data[0].id_Dist);
                    $('#hf_username').val(data.data[0].username);
                } else {
                    usuarios.find('option').remove();
                    usuarios.append('<option value="S">Sin registros</option>');
                }
            }, error: function (xhr, ajaxOptions, thrownError) {
                alert('ERROR...');              
            }, complete: function () {
            }
        });

        return false;
    });


    $('#btnLogin').click(function (e) {
        e.preventDefault();

        var usuario = {
            id: parseInt($('#selectUsers').val()),
            Username: $("#selectUsers option:selected").text(),
            Password: $('.txtPassword').val(),
            Id_Dist: $('#hf_id_dist').val()
        }  


        $.ajax({
            method: "POST",
            url: "/Login/Login/Login",
            contentType: "application/json; charset=utf-8",
            data: JSON.stringify(usuario),
            dataType: "json",
            beforeSend: function () {
            },
            success: function (data) {
                if (data.success) {
                    var str = window.location.pathname;
                    if (str.indexOf("Cliente") >= 0) {
                        window.location.href = 'Home';
                    } else {
                        window.location.href = 'Cliente/Home';
                    }
                   
                } else {
                    swal("Ocurrio un error!", data.message, "warning")
                }
            }, error: function (xhr, ajaxOptions, thrownError) {
                alert('error...');
                throw new Error('Error al cargar...');
            }, complete: function () {
            }
        });
    });

    $('.btnSalir').click(function () {
        swal({
            title: "Está seguro de que desea salir de la aplicación?",
            text: "Perdera la sesión",
            type: "warning",
            showCancelButton: true,
            confirmButtonColor: "#DD6B55",
            confirmButtonText: "Si, Continuar!",
            closeOnConfirm: true
        }, function () {
            $.ajax({
                type: 'GET',
                url: window.location.origin +'/Cliente/Home/CerrarSessiones',
                success: function (data) {
                    if (data.success) {
                        window.location.href = window.location.origin +'/Login';
                    } 
                }

            })

        }
        );
    });
}


$(".txtrfc").on('keyup', function (e) {
   
    if (e.key === 'Enter' || e.keyCode === 13) {
        $('#btnTraerUsuarios').trigger("click");
        return false;
    }
});

$(document).keypress(
    function (event) {
        if (event.which == '13') {
           
        }
    });

$("form").keypress(function (e) {
    //Enter key
    if (e.which == 13) {
        return false;
    }
});