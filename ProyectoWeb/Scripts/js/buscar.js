jQuery.noConflict();
var contador = 0;
    function buscar () {
        $urlPrueba = this.baseURI;
        jQuery("#ordenes").remove();
        var num_orden = document.getElementById('num_orden').value;
        var nombre_trabajo = document.getElementById('trabajo').value;
        var nombre_vendedora = document.getElementById('vendedora').value;
        var nombre_cliente = document.getElementById('cliente').value;
        jQueryBuscar = null;
        jQueryTipo = null;
        if (num_orden)
        {
            jQueryBuscar = num_orden;
            jQueryTipo = "num_orden";
        } else if(nombre_vendedora)
        {
            jQueryBuscar = nombre_vendedora;
            jQueryTipo = "vendedora";
        
        }
        else if(nombre_cliente)
        {
            jQueryBuscar = nombre_cliente;
            jQueryTipo = "cliente";
        }
        else if (nombre_trabajo)
        {
            jQueryBuscar = nombre_trabajo;
            jQueryTipo = "trabajo";
        }
            jQuery.get('BuscarOrden/Buscar/' + jQueryTipo + "/" + jQueryBuscar, function (data) {
                var data = JSON.parse(data);
                var buscar = "";
                var prueba = "";
                var orden = JSON.parse(data.orden);
                var etapa = JSON.parse(data.etapa);
            
           
                for (i = 0; i < orden.length; i++) {
                    if (i == 0) {
                        buscar += '<thead><th># Orden</th><th>Vendedora</th><th>Nombre Fantasia</th><th>Trabajo</th><th>F_Ingreso</th><th>F_Salida</th><th>Proceso</th><th></th></thead>';

                    }

               

                    buscar += '<tr><td>' + orden[i].num_orden + '</td>';
                    buscar += '<td>' + orden[i].idusuario + '</td><td>' + orden[i].idcliente + '</td><td>' + orden[i].nombre_trabajo + '</td><td>' + orden[i].fecha_ingreso + '</td><td>' + orden[i].fecha_salida + '</td><td>' + etapa[i][0].etapa + '</td>';
                    buscar += '<td><a type="button" href="/Informacion/Edit/' + orden[i].id + '" class="btn btn-primary"><span class="glyphicon glyphicon-pencil"></span></a><a type="button" href="/Informacion/Details/' + orden[i].id + '" class="btn btn-warning"><span class="glyphicon glyphicon-eye-open"></span></a><a type="button"  href="/Informacion/Delete/' + orden[i].id + '" class="btn btn-danger"><span class="glyphicon glyphicon-remove"></span></a></form><div id="FndYnnovaAlertas"></div></td></tr>';

                }

                document.getElementById('legend').innerHTML = 'Lista de Ordenes';
                document.getElementById('mytable').innerHTML = buscar;

                if (contador == 0)
                {
                    contador++;
                    jQuery('#mytable').dataTable({
                        "lengthMenu": [5, 10, 15, 20]
                    });
                }
           

            });
        }

