UTILS = {
    Grilla: function (grilla, pager, identificador, height, width, caption, urlListar, id, colsNames, colsModel, opciones) {
        var grid = jQuery('#' + grilla);
        var estadoSubGrid = false;

        if (opciones.noregistro == null) { noregistro = true; }
        if (opciones.sort == null) { opciones.sort = 'desc'; }
        if (opciones.PositionColumnSort == null) { opciones.PositionColumnSort = 0; }
        if (opciones.subGrid != null) { estadoSubGrid = true; }
        if (opciones.rowNumber == null) { opciones.rowNumber = 10; }
        if (opciones.rowNumbers == null) { opciones.rowNumbers = [opciones.rowNumber, 10, 25, 50]; }
        if (opciones.rules == null) { opciones.rules = false; }
        if (opciones.search == null) { opciones.search = false; }
        if (opciones.footerrow == null) { opciones.footerrow = false; }
        if (opciones.multiselect == null) { opciones.multiselect = false; }
        if (opciones.agregarBotones == null) { opciones.agregarBotones = false; }
        if (opciones.GridLocal == null) {
            opciones.GridLocal = false;

            if (opciones.CellEdit == null) {
                opciones.CellEdit = false;
            }
            if (opciones.grouping == null) {
                opciones.grouping = false;
            }
        }

        if (opciones.NuevoCaption == null) opciones.NuevoCaption = "Nuevo";
        if (opciones.EditarCaption == null) opciones.EditarCaption = "Editar";
        if (opciones.EliminarCaption == null) opciones.EliminarCaption = "Eliminar";
        if (opciones.LeyendaCaption == null) opciones.LeyendaCaption = "Leyenda";

        if (opciones.Lenguaje == null) opciones.Lenguaje = "es";

        if (opciones.Lenguaje == "en") {
            if (opciones.dialogDelete == null) { opciones.dialogDelete = 'Delete'; }
            if (opciones.dialogAlert == null) { opciones.dialogAlert = 'Alert'; }
        }
        else if (opciones.Lenguaje == "es") {
            if (opciones.dialogDelete == null) { opciones.dialogDelete = 'Eliminar'; }
            if (opciones.dialogAlert == null) { opciones.dialogAlert = 'Alerta'; }
        }
        //alert(opciones.Lenguaje);

        //opciones.selectFunc = (opciones.selectFunc == null) ? false : opciones.OnSelect;

        var rowKey;
        var lasRowKey;
        var DataTable = null; 
        if (!opciones.GridLocal) {
            DataTable = grid.DataTable({
                //createdRow: function (row, data, index) {
                //    $(row).addClass('selected')
                //},
                responsive: true,
                "processing": true,
                "serverSide": true,
                "lengthMenu": opciones.rowNumbers,
                pageLength: opciones.rowNumber,
                "order": [[opciones.PositionColumnSort, opciones.sort]],
                "searching": opciones.search,
                rowId: id,

                ajax: {
                    type: "POST",
                    url: urlListar,
                    contentType: 'application/json; charset=utf-8',
                    dataType: "json",
                    data: function (dtParms) {
                        debugger;
                        var migrilla = new Object();
                        migrilla.draw = dtParms.draw;
                        migrilla.rows = dtParms.length;
                        migrilla.start = dtParms.start;
                        migrilla.sidx = dtParms.columns[dtParms.order[0].column].name;
                        migrilla.sord =  dtParms.order[0].dir;
                        migrilla._search = dtParms.search;
                        //migrilla.filters = postdata.filters;
                        if (opciones.rules != false) {
                            migrilla.Rules = GetRules(grilla);
                        }
                        var params = { grid: migrilla };
                        return JSON.stringify(params);
                    },
                    dataFilter: function (res) {
                        //recibimos del servidor
                        debugger;
                        if (res != null && res != "") {
                            var parsed = JSON.parse(res);
                            return JSON.stringify(parsed);
                        }
                        else {
                            alert('Error with AJAX callback');
                        }
                    },
                    error: function (x, y) {
                        console.log(x);
                    }
                },
                "filter": true,
                columns: colsModel,
                language: {
                    "lengthMenu": "Mostrar _MENU_ registros",
                    "zeroRecords": "No se encontró nada",
                    "info": "Mostrando del _START_ al _END_ de un total de _TOTAL_",
                    "infoEmpty": "No hay registros",
                    "emptyTable": "No hay datos para mostrar",
                    "loadingRecords": "Cargando...",
                    "processing": "Procesando...",
                    "search": "Buscar:",
                    "infoFiltered": "(filtrado de un total de _MAX_ registros)",
                    "paginate": {
                        "first": "Primera",
                        "last": "Última",
                        "next": "Siguiente",
                        "previous": "Anterior"
                    }
                },

            });

  
        } // fin de NO GridLocal
        else if (opciones.GridLocal) {
            $('#' + grilla).jqGrid({
                datatype: "local",
                colNames: colsNames,
                colModel: colsModel,
                sortorder: opciones.sort,
                rowNum: opciones.rowNumber,
                rownumbers: true,
                cellEdit: opciones.CellEdit,
                cellsubmit: "clientArray",
                rowList: opciones.rowNumbers,
                pager: '#' + pager,
                sortname: sortName,
                viewrecords: true,
                multiselect: opciones.multiselect,
                sortorder: opciones.sort,
                footerrow: opciones.footerrow,
                height: height,
                width: width,
                gridview: true,
                loadonce: true,
                //autowidth: true,
                //shrinkToFit: fals,
                //forceFit: true,
                shrinkToFit: false,
                //colNames: colsNames,
                //colModel: colsModel,
                grouping: opciones.grouping,
                groupingView: {
                    groupField: [opciones.groupingCampo],
                    // groupDataSorted: true,
                    groupColumnShow: false,
                    //  groupCollapse: true,
                    // groupText : ['<b>{0} - {1} Postor(s)</b>'],
                    //groupText: ['<b>{0}</b></div><input type = "button" class = "button" value = "NEW" id = "btnNew" style = "width:100px; hieght:10px" onclick = "javascript:AlertaxD(rowObject)" /><<b>{1} Orders</b>']
                    groupText: ['<b style="background-color:#FFFFDC"> {0} - {1} Documento(s) </b></div>' + opciones.groupfuncionMov + opciones.groupfuncionEstado],
                    //plusicon: 'bullet_toggle_plus',
                    //minusicon: 'bullet_toggle_minus'
                },
                caption: caption,
                subGrid: estadoSubGrid,
                editurl: opciones.editurl,
                subGridRowColapsed: function (subgrid_id, row_id) {
                    var subgrid_table_id, pager_id;
                    subgrid_table_id = subgrid_id + "_t";
                    pager_id = "p_" + subgrid_table_id;
                    jQuery("#" + subgrid_table_id).remove();
                    jQuery("#" + pager_id).remove();
                },
                subGridRowExpanded: function (subgrid_id, row_id) {
                    var subGrid = opciones.subGrid;
                    //debugger;
                    var subgrid_table_id, pager_id;
                    subgrid_table_id = subgrid_id + "_t";
                    pager_id = "p_" + subgrid_table_id;

                    $("#" + subgrid_id).html("<table id='" + subgrid_table_id + "' class='scroll'></table><div id='" + pager_id + "' class='scroll'></div>");

                    var datax = jQuery("#" + grilla).jqGrid('getRowData', row_id);
                    var parameters = {
                        ID_DOCUMENTO_USUARIO: datax.ID_DOCUMENTO_USUARIO,
                        ID_DOCUMENTO: datax.ID_DOCUMENTO_PADRE,
                        ID_ESTADO_DOCUMENTO: datax.ID_ESTADO_DOCUMENTO,
                        ID_OFICINA: $("#input_hdidoficina").val(), //ID_OFICINA,
                        ID_USUARIO: $("#input_hdidusuario").val(),
                        ID_PERFIL: $("#input_hdidperfil").val()
                    };
                    $.ajax({
                        type: "POST",
                        url: subGrid.Url,
                        contentType: "application/json; charset=utf-8",
                        dataType: "json",
                        data: JSON.stringify(parameters),
                        success: function (rsp) {
                            debugger;
                            var data = rsp.OBJETO; // (typeof rsp.d) == 'string' ? eval('(' + rsp.d + ')') : rsp.d;
                            $("#" + subgrid_table_id).jqGrid({
                                datatype: "local",
                                colNames: subGrid.ColNames,
                                colModel: subGrid.ColModels,
                                rowNum: 10,
                                rowList: [10, 20, 50, 100],
                                //sortorder: "desc",
                                viewrecords: true,
                                rownumbers: false,
                                pager: "#" + pager_id,
                                loadonce: true,
                                shrinkToFit: false,
                                sortable: true,
                                height: subGrid.Height,
                                width: width
                            });

                            for (var i = 0; i <= data.length; i++)
                                jQuery("#" + subgrid_table_id).jqGrid('addRowData', i + 1, data[i]);
                            $("#" + subgrid_table_id).trigger("reloadGrid");
                        },
                        failure: function (msg) {
                            $('#mensajeFalla').show().fadeOut(8000);
                        }
                    });
                },
                beforeSelectRow: function (rowid, e) {
                    var valor = false;
                    var rowKey = grid.getGridParam('selrow');

                    var i = $.jgrid.getCellIndex($(e.target).closest('td')[0]),
                        cm = grid.jqGrid('getGridParam', 'colModel');

                    if (cm[i].name === 'cb') {
                        valor = true;

                    } else {

                        valor = false;
                        var s, cantidad, l, ant = 0;
                        s = grid.jqGrid('getGridParam', 'selarrrow');
                        cantidad = s.length;

                        l = s;
                        if (cantidad > 1) {
                            for (var i = 0, il = cantidad; i < il; i++) {
                                grid.jqGrid('setSelection', l[ant], false);
                            }
                            grid.jqGrid('setSelection', rowid, true);
                        } else {

                            grid.jqGrid('setSelection', rowKey, false);
                            grid.jqGrid('setSelection', rowid, true);
                        }

                    }


                    return valor;
                },
                gridComplete: function () {

                    if (typeof opciones.GridCompleteHandler == "function")
                        opciones.GridCompleteHandler();
                    // if (opciones.EditingOptions != null && opciones.EditingOptions.canEditRowInline) {
                    if (jQuery.isFunction(opciones.GridCompleteHandlerGrid))
                        opciones.GridCompleteHandlerGrid(grid);
                    // }
                },
                loadComplete: function () {

                    if (typeof opciones.loadCompleteHandler == "function")
                        opciones.loadCompleteHandler();
                },
                ondblClickRow: function () {
                    if (typeof opciones.GridondblClickRowHandler == "function")
                        opciones.GridondblClickRowHandler();

                    if (jQuery.isFunction(opciones.BeforeEditHandler)) {
                        opciones.BeforeEditHandler(grid, rowKey);
                        grid.editRow(rowKey, true, true, true, null, null,
                           function (rowID, responseServer) {
                               AfterSaveRowInline(rowID, grid);
                           });
                        lasRowKey = rowKey;
                    }
                },
                //BeforeEditHandler: function () {
                //    if (jQuery.isFunction(opciones.BeforeEditHandler)) {
                //        opciones.BeforeEditHandler(grid, rowKey);
                //        grid.editRow(rowKey, true, true, true, null, null,
                //           function (rowID, responseServer) {
                //          AfterSaveRowInline(rowID, grid);
                //           });
                //        lasRowKey = rowKey;
                //    }               
                //},
                beforeSaveCell: function (rowid, celname, value, iRow, iCol) {
                    if (opciones.BeforeEditHandler != null)
                        opciones.BeforeEditHandler(rowid, cellname, value, iRow, iCol);
                },
                afterSaveCell: function (rowid, cellname, value, iRow, iCol) {
                    if (opciones.AfterSaveCellHandler != null)
                        opciones.AfterSaveCellHandler(rowid, cellname, value, iRow, iCol);
                },
                onSelectRow: function () {
                    debugger;
                    rowKey = grid.getGridParam('selrow');

                    if (rowKey != null) {
                        $("#" + identificador).val(rowKey);
                    }
                    if (opciones.selectRowFunc != null) {
                        if (typeof (opciones.selectRowFunc) == 'function') {
                            opciones.selectRowFunc(rowKey)
                        }
                    }
                }

            }).navGrid("#" + pager, { edit: false, add: false, del: false, search: opciones.search, refresh: false },
                {}, // use default settings for edit
                {}, // use default settings for add
                {}, // delete instead that del:false we need this
                {
                    multipleSearch: true,
                    beforeShowSearch: function () {
                        $(".ui-reset").trigger("click");
                        return true;
                    }
                }
            );

        } // fin de GridLocal
   
        $('#' + grilla + ' tbody').on('click', 'tr', function () {
            if ($(this).hasClass('selected')) {
                $(this).removeClass('selected');
            }
            else {
                DataTable.$('tr.selected').removeClass('selected');
                $(this).addClass('selected');
            }
        });

    }
       

}