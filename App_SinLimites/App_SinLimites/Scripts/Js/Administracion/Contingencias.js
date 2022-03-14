var Contingencias_Grilla = 'Contingencias_Grilla';
var Contingencias_Barra = 'Contingencias_Barra';


function Contingencias_Cerrar() {
    $('#myModalNuevo').modal('hide');
    jQuery("#myModalNuevo").html('');
}

function Contingencias_Limpiar() {
    $("#Contingencias_NombresApe").val('');
    $("#Contingencias_Documento").val('');
    $('#Contingencias_Estado').val(2);

    Contingencias_CargarGrilla();
}

function Contingencias_ConfigurarGrilla() {
    $("#" + Contingencias_Grilla).GridUnload();
    var colNames = ['Editar', 'Eliminar', 'Estado', 'codigo', 'ID', 'Nombre y Apellidos' ,'Tipo Documento', 'Dni','Telefono','Correo','CARGO',
        'flg_estado', 'Fecha Creación', 'Usuario Creación', 'Fecha Modificación', 'Usuario Modificación'];
    var colModels = [
            { name: 'EDITAR', index: 'EDITAR', align: 'center', width: 60, hidden: false, formatter: Contingencias_actionEditar, sortable: false },
            { name: 'ELIMINAR', index: 'ELIMINAR', align: 'center', width: 80, hidden: false, formatter: Contingencias_actionEliminar, sortable: false },
            { name: 'ACTIVO', index: 'ACTIVO', align: 'center', width: 70, hidden: false, sortable: true, formatter: Contingencias_actionActivo, sortable: false },
            { name: 'CODIGO', index: 'CODIGO', align: 'center', width: 100, hidden: true, },
            { name: 'ID_CONTINGENCIA', index: 'ID_CONTINGENCIA', width: 100, hidden: true, key: true },
            { name: 'NOMBRES_APE', index: 'NOMBRES_APE', width: 250, hidden: false, align: "left", formatter:Contingencia_TextContingencia },
            { name: 'DESC_TIPO_DOCUMENTO', index: 'DESC_TIPO_DOCUMENTO', width: 150, hidden: false, align: "left" },
            { name: 'NUMERO_DOCUMENTO', index: 'NUMERO_DOCUMENTO', width: 150, hidden: false, align: "left" },
            { name: 'TELEFONO', index: 'TELEFONO', width: 100, hidden: false, align: "left" },
            { name: 'CARGO', index: 'CARGO', width: 200, hidden: true, align: "left" },
            { name: 'CORREO', index: 'CORREO', width: 200, hidden: false, align: "left" },
            { name: 'FLG_ESTADO', index: 'FLG_ESTADO', width: 300, hidden: true, align: "left" },
            { name: 'FEC_CREACION', index: 'FEC_CREACION',  width: 150, hidden: false, align: "left" },
            { name: 'USU_CREACION', index: 'USU_CREACION',  width: 150, hidden: false, align: "left" },
            { name: 'FEC_MODIFICACION', index: 'FEC_MODIFICACION',  width: 150, hidden: false, align: "left" },
            { name: 'USU_MODIFICACION', index: 'USU_MODIFICACION', width: 150, hidden: false, align: "left" },
    ];
    var opciones = {
        GridLocal: true, multiselect: false, CellEdit: false, Editar: false, nuevo: false, eliminar: false, search: false ,rowNumber: 50, rowNumbers: [50, 100, 200, 300, 500],
    };
    SICA.Grilla(Contingencias_Grilla, Contingencias_Barra, Contingencias_Grilla, 400, '', "Lista de Contingencias", '', 'ID_CONTINGENCIA', colNames, colModels, '', opciones);
}

function Contingencias_actionActivo(cellvalue, options, rowObject) {
    var check_ = 'check';
    if (rowObject.FLG_ESTADO == 1)
        check_ = 'checked';

    var _btn = " <label class=\"content_toggle_1\">"
            + "<input id=\"Contingencias_chk_" + rowObject.ID_CONTINGENCIA + "\" class=\"toggle_Beatiful_1\" type=\"checkbox\" onchange=\"Contingencias_Estado(" + rowObject.ID_CONTINGENCIA + ",this)\" " + check_ + ">"
            + "<div class=\"content_toggle_2\">"
            + "  <span class=\"Label_toggle_1\" ></span>"
             + "</div>"
            + "</label>";
    return _btn;
}

function Contingencia_TextContingencia(cellvalue, options, rowObject) {
    var Contingencia = rowObject.NOMBRES_APE;
    var Cod_usuario = rowObject.CARGO;
    var _text = '<span>' + Contingencia + '</span><br><span style="font-size: 12px; color: #2c7be5;"><i class="bi bi-person"></i>&nbsp;Cargo: ' + Cod_usuario + '</span>';


    return _text
}

function Contingencias_actionEditar(cellvalue, options, rowObject) {
    var _btn = "<button title='Editar'  onclick='Contingencias_MostrarEditar(" + rowObject.ID_CONTINGENCIA + ");' class=\"btn btn-outline-light\" type=\"button\"> <i class=\"bi bi-pencil-fill\" style=\"color:#f59d3f;font-size:17px\"></i></button>";
    return _btn;
}

function Contingencias_actionEliminar(cellvalue, options, rowObject) {
    var _btn = "<button title='Eliminar'  onclick='Contingencias_Eliminar(" + rowObject.ID_CONTINGENCIA + ");' class=\"btn btn-outline-light\" type=\"button\" data-toggle=\"modal\" style=\"text-decoration: none !important;\"> <i class=\"bi bi-x-circle\" style=\"color:#e40613;font-size:17px\"></i></button>";
    return _btn;
}


function Contingencias_MostrarNuevo() {
    jQuery("#myModalNuevo").html('');
    jQuery("#myModalNuevo").load(baseUrl + "Administracion/Contingencia/Mantenimiento?id=0&Accion=N", function (responseText, textStatus, request) {
        $('#myModalNuevo').modal({ show: true });
        $.validator.unobtrusive.parse('#myModalNuevo');
        if (request.status != 200) return;
    });
}

function Contingencias_MostrarEditar(ID_CONTINGENCIA) {
    jQuery("#myModalNuevo").html('');
    jQuery("#myModalNuevo").load(baseUrl + "Administracion/Contingencia/Mantenimiento?id=" + ID_CONTINGENCIA + "&Accion=M", function (responseText, textStatus, request) {
        $('#myModalNuevo').modal({ show: true });
        $.validator.unobtrusive.parse('#myModalNuevo');
        if (request.status != 200) return;
    });
}


///*********************************************** ----------------- *************************************************/

///*********************************************** Lista los  cargo **************************************************/

function Contingencias_CargarGrilla() {
    var item =
       {
           NOMBRES_APE: $('#Contingencias_NombresApe').val(),
           NUMERO_DOCUMENTO: $('#Contingencias_Documento').val(),
           FLG_ESTADO: $('#Contingencias_Estado').val()
       };
    var url = baseUrl + 'Administracion/Contingencia/Contingencia_Listar';
    var auditoria = SICA.Ajax(url, item, false);
    jQuery("#" + Contingencias_Grilla).jqGrid('clearGridData', true).trigger("reloadGrid");
    if (auditoria.EJECUCION_PROCEDIMIENTO) {
        if (!auditoria.RECHAZAR) {
            $.each(auditoria.OBJETO, function (i, v) {
                var idgrilla = i + 1;

                var myData =
                 {
                     CODIGO: idgrilla,
                     ID_CONTINGENCIA: v.ID_CONTINGENCIA,
                     CARGO: v.CARGO,
                     NOMBRES_APE: v.NOMBRES_APE,
                     DESC_TIPO_DOCUMENTO: v.DESC_TIPO_DOCUMENTO,
                     NUMERO_DOCUMENTO: v.NUMERO_DOCUMENTO,
                     TELEFONO: v.TELEFONO,
                     CORREO: v.CORREO,
                     FLG_ESTADO: v.FLG_ESTADO,
                     FEC_CREACION: v.FEC_CREACION,
                     USU_CREACION: v.USU_CREACION,
                     FEC_MODIFICACION: v.FEC_MODIFICACION,
                     USU_MODIFICACION: v.USU_MODIFICACION,

                 };
                jQuery("#" + Contingencias_Grilla).jqGrid('addRowData', i, myData);
            });
            jQuery("#" + Contingencias_Grilla).trigger("reloadGrid");
        }
    } else {
        jError(auditoria.MENSAJE_SALIDA, "Atención");
    }
}



///*********************************************** ----------------- *************************************************/

///*********************************************** Actualiza  cargos  ************************************************/

function Contingencias_Actualizar() {
    if ($("#frmMantenimiento_Contingencias").valid()) {
        var item =
                {
                    ID_CONTINGENCIA: $("#hfd_ID_CONTINGENCIA").val(),
                    NUMERO_DOCUMENTO: $("#NUMERO_DOCUMENTO").val(),
                    NOMBRE: $("#NOMBRE").val(),
                    APELLIDO_PATERNO: $("#APELLIDO_PATERNO").val(),
                    APELLIDO_MATERNO: $("#APELLIDO_MATERNO").val(),
                    TELEFONO: $("#TELEFONO").val(),
                    CORREO: $("#CORREO").val(),
                    CARGO: $("#CARGO").val(),
                    ID_TIPO_DOCUMENTO: $("#ID_TIPO_DOCUMENTO").val(),
                    USU_MODIFICACION: $('#input_hdcodusuario').val(),
                    Accion: $("#AccionContingencias").val()
                };
        jConfirm("¿ Desea actualizar este usuario ?", "Atención", function (r) {
            if (r) {
                var url = baseUrl + 'Administracion/Contingencia/Contingencia_Actualizar';
                var auditoria = SICA.Ajax(url, item, false);
                if (auditoria != null && auditoria != "") {
                    if (auditoria.EJECUCION_PROCEDIMIENTO) {
                        if (!auditoria.RECHAZAR) {
                            Contingencias_CargarGrilla();
                            Contingencias_Cerrar();
                            jOkas("Contingencias actualizado satisfactoriamente", "Proceso");
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

///************************************************ Inserta cargos  **************************************************/

function Contingencias_Ingresar() {
    debugger; 
    if ($('#AccionContingencias').val() != 'N') {
        Contingencias_Actualizar();
    } else {
        if ($("#frmMantenimiento_Contingencias").valid()) {
            jConfirm("¿ Desea registrar este usuario ?", "Atención", function (r) {
                if (r) {
                    var item =
                        {
                            DNI: $("#DNI").val(),
                            NUMERO_DOCUMENTO: $("#NUMERO_DOCUMENTO").val(),
                            NOMBRE: $("#NOMBRE").val(),
                            APELLIDO_PATERNO: $("#APELLIDO_PATERNO").val(),
                            APELLIDO_MATERNO: $("#APELLIDO_MATERNO").val(),
                            TELEFONO: $("#TELEFONO").val(),
                            CORREO: $("#CORREO").val(),
                            CARGO: $("#CARGO").val(),
                            ID_TIPO_DOCUMENTO: $("#ID_TIPO_DOCUMENTO").val(),
                            USU_CREACION: $('#input_hdcodusuario').val(),
                            ACCION: $("#AccionContingencias").val()
                        };
                    var url = baseUrl + 'Administracion/Contingencia/Contingencia_Insertar';
                    var auditoria = SICA.Ajax(url, item, false);
                    if (auditoria != null && auditoria != "") {
                        if (auditoria.EJECUCION_PROCEDIMIENTO) {
                            if (!auditoria.RECHAZAR) {
                                Contingencias_CargarGrilla();
                                Contingencias_Cerrar();
                                jOkas("Contingencia registrado correctamente", "Proceso");
                        

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

///*********************************************** Elimina cargos  ***************************************************/

function Contingencias_Eliminar(ID_CONTINGENCIA) {
    jConfirm("¿ Desea eliminar este usuario ?", "Atención", function (r) {
        if (r) {
            var item = {
                ID_CONTINGENCIA: ID_CONTINGENCIA
            };
            var url = baseUrl + 'Administracion/Contingencia/Contingencia_Eliminar';
            var auditoria = SICA.Ajax(url, item, false);
            if (auditoria != null && auditoria != "") {
                if (auditoria.EJECUCION_PROCEDIMIENTO) {
                    if (!auditoria.RECHAZAR) {
                        Contingencias_CargarGrilla();
                        Contingencias_Cerrar();
                        jOkas("Contingencias eliminado satisfactoriamente", "Proceso");
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

///*********************************************** Cambia estado de cargos  ******************************************/

function Contingencias_Estado(ID_CONTINGENCIA, CHECK) {
    var item = {
        ID_CONTINGENCIA: ID_CONTINGENCIA,
        FLG_ESTADO: CHECK.checked == true ? '1' : '0',
        USU_MODIFICACION: $('#input_hdcodusuario').val(),
    };
    var url = baseUrl + 'Administracion/Contingencia/Contingencia_Estado';
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

