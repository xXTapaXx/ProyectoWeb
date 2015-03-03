jQuery.noConflict();

    function buscar () {
        $urlPrueba = this.baseURI;
        jQuery("#ordenes").remove();
        var num_orden = document.getElementById('num_orden').value;
        var nombre_trabajo = document.getElementById('trabajo').value;
        jQueryBuscar = null;
        jQueryTipo = null;
        if (num_orden)
        {
            jQueryBuscar = num_orden;
            jQueryTipo = "num_orden";
        } else if (nombre_trabajo)
        {
            jQueryBuscar = nombre_trabajo;
            jQueryTipo = "trabajo";
        }
        jQuery.get('BuscarOrden/Buscar/' + jQueryTipo + "/" + jQueryBuscar, function (data) {
            var data = jQuery.parseJSON(data);
            var buscar = "";
            var prueba = "";
            for (i = 0; i < data.length; i++) {
                if (i == 0) {
                    buscar += '<thead><th># Orden</th><th>Vendedora</th><th>Nombre Fantasia</th><th>Trabajo</th><th>F_Ingreso</th><th>F_Salida</th><th></th></thead>';

                }

                buscar += '<tr><td><a type="button" href="#" id="' + data[i].num_orden + '" data-title="show" data-toggle="modal" data-target="#show" data-placement="top">' + data[i].num_orden + '</a></td>';
                buscar += '<td>' + data[i].idusuario + '</td><td>' + data[i].idcliente + '</td><td>' + data[i].nombre_trabajo + '</td><td>' + data[i].fecha_ingreso + '</td><td>' + data[i].fecha_salida + '</td>';
                buscar += '<td><form  method="POST"  action ="' + $urlPrueba + '/' + data[i].num_orden + '" accept-charset="UTF-8" id="form' + data[i].num_orden + '"><input name="_method" type="hidden" value="DELETE"><input name="_token" type="hidden" value="86BNyVpfTC0XeoLDpbpQQE0kVOevhquCR4auH05s"> <a type="button" id="' + data[i].num_orden + '" data-title="edit" data-toggle="modal" data-target="#edit" data-placement="top" href="#" class="btn btn-primary"><span class="glyphicon glyphicon-pencil"></span></a> <a type="button" id="' + data[i].num_orden + '"   data-title="delete" data-toggle="modal" data-target="#delete" href="#" class="btn btn-danger"><span class="glyphicon glyphicon-remove"></span></a></form><div id="FndYnnovaAlertas"></div></td></tr>';


            }

            document.getElementById('legend').innerHTML = 'Lista de Ordenes';
            document.getElementById('Ordenes').innerHTML = buscar;            
        });
}