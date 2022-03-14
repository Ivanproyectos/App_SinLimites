var Banco_Grilla = 'Banco_Grilla';
var Banco_Barra = 'Banco_Barra';

function Banco_Cerrar() {
    $('#myModalNuevo').modal('hide');
    jQuery("#myModalNuevo").html('');
}

function Banco_Limpiar() {
    $("#Banco_Desc_Banco").val('');
    $('#Banco_Estado').val(2);

    Banco_CargarGrilla();
}

function Banco_ConfigurarGrilla() {
    $("#" + Banco_Grilla).GridUnload();
    var colNames = ['Editar', 'Eliminar', 'Estado', 'codigo', 'ID', 'Banco',
        'flg_estado', 'Fecha Creación', 'Usuario Creación', 'Fecha Modificación', 'Usuario Modificación'];
    var colModels = [
            { name: 'EDITAR', index: 'EDITAR', align: 'center', width: 60, hidden: false, formatter: Banco_actionEditar, sortable: false },
            { name: 'ELIMINAR', index: 'ELIMINAR', align: 'center', width: 80, hidden: false, formatter: Banco_actionEliminar, sortable: false },
            { name: 'ACTIVO', index: 'ACTIVO', align: 'center', width: 70, hidden: false, sortable: true, formatter: Banco_actionActivo, sortable: false },
            { name: 'CODIGO', index: 'CODIGO', align: 'center', width: 100, hidden: true, },
            { name: 'ID_BANCO', index: 'ID_BANCO', width: 100, hidden: true, key: true },
            { name: 'DESC_BANCO', index: 'DESC_BANCO', width: 250, hidden: false, align: "left" },
            { name: 'FLG_ESTADO', index: 'FLG_ESTADO', width: 300, hidden: true, align: "left" },
            { name: 'FEC_CREACION', index: 'FEC_CREACION', width: 150, hidden: false, align: "left" },
            { name: 'USU_CREACION', index: 'USU_CREACION', width: 150, hidden: false, align: "left" },
            { name: 'FEC_MODIFICACION', index: 'FEC_MODIFICACION', width: 150, hidden: false, align: "left" },
            { name: 'USU_MODIFICACION', index: 'USU_MODIFICACION', width: 150, hidden: false, align: "left" },
    ];
    var opciones = {
        GridLocal: true, multiselect: false, CellEdit: false, Editar: false, nuevo: false, eliminar: false, search: false, rowNumber: 50, rowNumbers: [50, 100, 200, 300, 500],
    };
    SICA.Grilla(Banco_Grilla, Banco_Barra, Banco_Grilla, 400, '', "Lista de Banco", '', 'ID_BANCO', colNames, colModels, '', opciones);
    jqGridResponsive($(".jqGrid"));
}

function Banco_actionActivo(cellvalue, options, rowObject) {
    var check_ = 'check';
    if (rowObject.FLG_ESTADO == 1)
        check_ = 'checked';

    var _btn = " <label class=\"content_toggle_1\">"
            + "<input id=\"Banco_chk_" + rowObject.ID_BANCO + "\" class=\"toggle_Beatiful_1\" type=\"checkbox\" onchange=\"Banco_Estado(" + rowObject.ID_BANCO + ",this)\" " + check_ + ">"
            + "<div class=\"content_toggle_2\">"
            + "  <span class=\"Label_toggle_1\" ></span>"
             + "</div>"
            + "</label>";
    return _btn;
}

function Banco_actionEditar(cellvalue, options, rowObject) {
    var _btn = "<button title='Editar'  onclick='Banco_MostrarEditar(" + rowObject.ID_BANCO + ");' class=\"btn btn-outline-light\" type=\"button\" > <i class=\"bi bi-pencil-fill\" style=\"color:#f59d3f;font-size:17px\"></i></button>";
    return _btn;
}

function Banco_actionEliminar(cellvalue, options, rowObject) {
    var _btn = "<button title='Eliminar'  onclick='Banco_Eliminar(" + rowObject.ID_BANCO + ");' class=\"btn btn-outline-light\" type=\"button\" data-toggle=\"modal\" style=\"text-decoration: none !important;\"> <i class=\"bi bi-x-circle\" style=\"color:#e40613;font-size:17px\"></i></button>";
    return _btn;
}


function Banco_MostrarNuevo() {
    jQuery("#myModalNuevo").html('');
    jQuery("#myModalNuevo").load(baseUrl + "Administracion/Banco/Mantenimiento?id=0&Accion=N", function (responseText, textStatus, request) {
        $('#myModalNuevo').modal({ show: true });
        $.validator.unobtrusive.parse('#myModalNuevo');
        if (request.status != 200) return;
    });
}

function Banco_MostrarEditar(ID_BANCO) {
    jQuery("#myModalNuevo").html('');
    jQuery("#myModalNuevo").load(baseUrl + "Administracion/Banco/Mantenimiento?id=" + ID_BANCO + "&Accion=M", function (responseText, textStatus, request) {
        $('#myModalNuevo').modal({ show: true });
        $.validator.unobtrusive.parse('#myModalNuevo');
        if (request.status != 200) return;
    });
}


///*********************************************** ----------------- *************************************************/

///*********************************************** Lista los  sucursal **************************************************/

function Banco_CargarGrilla() {
    var item =
       {
           DESC_BANCO: $('#Banco_Desc_Banco').val(),
           FLG_ESTADO: $('#Banco_Estado').val()
       };
    var url = baseUrl + 'Administracion/Banco/Banco_Listar';
    var auditoria = SICA.Ajax(url, item, false);
    jQuery("#" + Banco_Grilla).jqGrid('clearGridData', true).trigger("reloadGrid");
    if (auditoria.EJECUCION_PROCEDIMIENTO) {
        if (!auditoria.RECHAZAR) {
            $.each(auditoria.OBJETO, function (i, v) {
                var idgrilla = i + 1;
                var myData =
                 {
                     CODIGO: idgrilla,
                     ID_BANCO: v.ID_BANCO,
                     DESC_BANCO: v.DESC_BANCO,
                     DIRECCION: v.DIRECCION,
                     TELEFONO: v.TELEFONO,
                     CORREO: v.CORREO,
                     URBANIZACION: v.URBANIZACION,
                     DESC_UBIGEO: v.DESC_UBIGEO,
                     FLG_ESTADO: v.FLG_ESTADO,
                     FEC_CREACION: v.FEC_CREACION,
                     USU_CREACION: v.USU_CREACION,
                     FEC_MODIFICACION: v.FEC_MODIFICACION,
                     USU_MODIFICACION: v.USU_MODIFICACION
                 };
                jQuery("#" + Banco_Grilla).jqGrid('addRowData', i, myData);
            });
            jQuery("#" + Banco_Grilla).trigger("reloadGrid");
        }
    } else {
        jError(auditoria.MENSAJE_SALIDA, "Atención");
    }
}



///*********************************************** ----------------- *************************************************/

///*********************************************** Actualiza  sucursals  ************************************************/

function Banco_Actualizar() {
    if ($("#frmMantenimiento_Banco").valid()) {
        var item =
                {
                    ID_BANCO: $("#hfd_ID_BANCO").val(),
                    DESC_BANCO: $("#DESC_BANCO").val(),
                    DIRECCION: $("#DIRECCION").val(),
                    TELEFONO: $("#TELEFONO").val(),
                    CORREO: $("#CORREO").val(),
                    URBANIZACION: $("#URBANIZACION").val(),
                    COD_UBIGEO: $("#COD_UBIGEO").val(),
                    USU_MODIFICACION: $('#input_hdcodusuario').val(),
                    Accion: $("#AccionBanco").val()
                };
        jConfirm("¿ Desea actualizar este sucursal ?", "Atención", function (r) {
            if (r) {
                var url = baseUrl + 'Administracion/Banco/Banco_Actualizar';
                var auditoria = SICA.Ajax(url, item, false);
                if (auditoria != null && auditoria != "") {
                    if (auditoria.EJECUCION_PROCEDIMIENTO) {
                        if (!auditoria.RECHAZAR) {
                            Banco_CargarGrilla();
                            Banco_Cerrar();
                            jOkas("Banco actualizado satisfactoriamente", "Proceso");
                        } else {
                            jError(auditoria.MENSAJE_SALIDA, "Atención");
                        }
                    } else {
                        jError(auditoria.MENSAJE_SALIDA, "Atención");
                    }
                }
            }
        });
    }
}

///*********************************************** ----------------- *************************************************/

///************************************************ Inserta sucursals  **************************************************/

function Banco_Ingresar() {
    if ($('#AccionBanco').val() != 'N') {
        Banco_Actualizar();
    } else {
        if ($("#frmMantenimiento_Banco").valid()) {
            jConfirm("¿ Desea registrar este sucursal ?", "Atención", function (r) {
                if (r) {
                    var item =
                        {
                            DESC_BANCO: $("#DESC_BANCO").val(),
                            DIRECCION: $("#DIRECCION").val(),
                            TELEFONO: $("#TELEFONO").val(),
                            CORREO: $("#CORREO").val(),
                            URBANIZACION: $("#URBANIZACION").val(),
                            COD_UBIGEO: $("#COD_UBIGEO").val(),
                            USU_CREACION: $('#input_hdcodusuario').val(),
                            ACCION: $("#AccionBanco").val()
                        };
                    var url = baseUrl + 'Administracion/Banco/Banco_Insertar';
                    var auditoria = SICA.Ajax(url, item, false);
                    if (auditoria != null && auditoria != "") {
                        if (auditoria.EJECUCION_PROCEDIMIENTO) {
                            if (!auditoria.RECHAZAR) {
                                Banco_CargarGrilla();
                                Banco_Cerrar();
                                jOkas("Banco registrado satisfactoriamente", "Proceso");
                            } else {
                                jError(auditoria.MENSAJE_SALIDA, "Atención");
                            }
                        } else {
                            jError(auditoria.MENSAJE_SALIDA, "Atención");
                        }
                    }
                }
            });
        }
    }
}

///*********************************************** ----------------- *************************************************/

///*********************************************** Elimina sucursals  ***************************************************/

function Banco_Eliminar(ID_BANCO) {
    jConfirm("¿ Desea eliminar este sucursal ?", "Atención", function (r) {
        if (r) {
            var item = {
                ID_BANCO: ID_BANCO
            };
            var url = baseUrl + 'Administracion/Banco/Banco_Eliminar';
            var auditoria = SICA.Ajax(url, item, false);
            if (auditoria != null && auditoria != "") {
                if (auditoria.EJECUCION_PROCEDIMIENTO) {
                    if (!auditoria.RECHAZAR) {
                        Banco_CargarGrilla();
                        Banco_Cerrar();
                        jOkas("Banco eliminado satisfactoriamente", "Proceso");
                    } else {
                        jError(auditoria.MENSAJE_SALIDA, "Atención");
                    }
                } else {
                    jError(auditoria.MENSAJE_SALIDA, "Atención");
                }
            }
        }
    });
}

///*********************************************** ----------------- *************************************************/

///*********************************************** Cambia estado de sucursals  ******************************************/

function Banco_Estado(ID_BANCO, CHECK) {
    var item = {
        ID_BANCO: ID_BANCO,
        FLG_ESTADO: CHECK.checked == true ? '1' : '0',
        USU_MODIFICACION: $('#input_hdcodusuario').val(),
    };
    var url = baseUrl + 'Administracion/Banco/Banco_Estado';
    var auditoria = SICA.Ajax(url, item, false);
    if (auditoria != null && auditoria != "") {
        if (auditoria.EJECUCION_PROCEDIMIENTO) {
            if (auditoria.RECHAZAR) {
                jError(auditoria.MENSAJE_SALIDA, "Atención");
            }
        } else {
            jError(auditoria.MENSAJE_SALIDA, "Atención");
        }
    }
}

///*********************************************** ----------------- *************************************************/