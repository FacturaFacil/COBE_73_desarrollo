var lst_permisos = [];
$(document).ready(function () {

    validarBotonera();
});

function validarBotonera() {
    if ($('#tblPermisosRoles').find('tbody tr').length > 0) {
        $('.botonera').show();
    } else {
        $('.botonera').hide();
    }
}

$(document).on('click', '#btnBuscar', function () {
    
    $('.cb_todos').prop('checked', false);
    $('.cb_t').prop('checked', false);
    if ($('#rolesPermisos_Id_Rol').val() != "") {
        $.ajax({
            //  async: false,
            method: "GET",
            url: "/Admin/GEN_RolesPermisos/GetAll",
            //contentType: "application/json; charset=utf-8",
            data: { id_modulo: $('#rolesPermisos_Id_Modulo').val() + "|" + $('#cb_tipo').val() + "|" + $('#rolesPermisos_Id_Rol').val() },
            dataType: "json",
            beforeSend: function () {
            },
            success: function (data) {
                var objPermisos;
                $("#tblPermisosRoles tbody tr").remove();
                data.dataOpciones.forEach(function (opciones, index) {
                    
                    var newRow = "<tr>" +
                        "<td>" + opciones.id + "</td>" +
                        "<td>" + opciones.descripcion + "</td>" +
                        //"<td><input   class='input-name' type='text' value='" + employee.name + "'/></td>" +
                        "<td><div class='checkbox checkbox-primary'><input type = 'checkbox' class='cb_todosAccesar cb_t' id = 'cb_todosAccesar_" + opciones.id + "'><label></label></div></td>" +
                        "<td><div class='checkbox checkbox-primary'><input type = 'checkbox' class='cb_todosNuevo cb_t' id = 'cb_todosNuevo_" + opciones.id + "'><label></label></div></td>" +
                        "<td><div class='checkbox checkbox-primary'><input type = 'checkbox' class='cb_todosModificar cb_t' id = 'cb_todosModificar_" + opciones.id + "'><label></label></div></td>" +
                        "<td><div class='checkbox checkbox-primary'><input type = 'checkbox' class='cb_todosEliminar cb_t' id = 'cb_todosEliminar_" + opciones.id + "'><label></label></div></td>" +
                        "<td><div class='checkbox checkbox-primary'><input type = 'checkbox' class='cb_todosImprimir cb_t' id = 'cb_todosImprimir_" + opciones.id + "'><label></label></div></td>" +
                        "</tr>";
                                    
                    $("#tblPermisosRoles").append(newRow);

                objPermisos = data.dataPermisos.find(function (element) { return element.id_Opciones == opciones.id; });
                    if (objPermisos != undefined) {
                        if (objPermisos.accesar) {
                            $('#cb_todosAccesar_' + opciones.id).prop('checked', true);
                        }
                        if (objPermisos.nuevo) {
                            $('#cb_todosNuevo_' + opciones.id).prop('checked', true);
                        }
                        if (objPermisos.modificar) {
                            $('#cb_todosModificar_' + opciones.id).prop('checked', true);
                        }
                        if (objPermisos.eliminar) {
                            $('#cb_todosEliminar_' + opciones.id).prop('checked', true);
                        }
                        if (objPermisos.imprimir) {
                            $('#cb_todosImprimir_' + opciones.id).prop('checked', true);
                        }

                    };
                });
                validarBotonera();

            }, error: function (xhr, ajaxOptions, thrownError) {
                throw new Error('Error al cargar...');
            }, complete: function () {
            }
        });
    } else {
        swal("Error!","Selecciona un rol para continuar", "warning");
    }
  
   
});

$(document).on('click', '#btnGuardar', function () {

    $("#tblPermisosRoles tbody tr").each(function (index) {
        lst_permisos.length = 0;
       var x = $(this).find("input.name").val();
        var $tds = $(this).find('td');
        alert("Id: " + $tds.eq(0).text());
        //if ($(this).find(".cb_todosAccesar").is(':checked')) "True" else "False"
              
        var objPermiso = {
            id_dist : 0,
            id_rol : $('#rolesPermisos_Id_Rol').val(),
            id_modulo: $('#rolesPermisos_Id_Modulo').val(),
            accesar: $(this).find(".cb_todosAccesar").is(':checked') ? "True" : "False",
            nuevo: $(this).find(".cb_todosNuevo").is(':checked') ? "True" : "False",
            modificar: $(this).find(".cb_todosModificar").is(':checked') ? "True" : "False",
            eliminar: $(this).find(".cb_todosEliminar").is(':checked') ? "True" : "False",
            imprimir: $(this).find(".cb_todosImprimir").is(':checked') ? "True" : "False"
        }
        lst_permisos.push(objPermiso);
    });


});

$(document).on('change', '#cb_todosAccesar', function () {

    if (this.checked) {
        $('.cb_todosAccesar').prop('checked', true);
    } else {
        $('.cb_todosAccesar').prop('checked', false);
    }
   
});

$(document).on('change', '#cb_todosNuevo', function () {

    if (this.checked) {
        $('.cb_todosNuevo').prop('checked', true);
    } else {
        $('.cb_todosNuevo').prop('checked', false);
    }

});
$(document).on('change', '#cb_todosModificar', function () {

    if (this.checked) {
        $('.cb_todosModificar').prop('checked', true);
    } else {
        $('.cb_todosModificar').prop('checked', false);
    }

});
$(document).on('change', '#cb_todosEliminar', function () {

    if (this.checked) {
        $('.cb_todosEliminar').prop('checked', true);
    } else {
        $('.cb_todosEliminar').prop('checked', false);
    }

});
$(document).on('change', '#cb_todosImprimir', function () {

    if (this.checked) {
        $('.cb_todosImprimir').prop('checked', true);
    } else {
        $('.cb_todosImprimir').prop('checked', false);
    }

});
$(document).on('change', '#cb_todos', function () {

    if (this.checked) {
        $('.cb_t').prop('checked', true);
    } else {
        $('.cb_t').prop('checked', false);
    }

});