jQuery.noConflict();

   function buscar(){
        jQueryPrueba = "";
        jQuery('#proceso').addClass('oculto');
        jQuery('.proceso').removeClass('active-tabs ');
        jQueryorden = document.getElementById('orden').value;
        
        if (jQueryorden) {


            jQuery.get('Proceso/Buscar/' + jQueryorden, function (data) {
                var data = jQuery.parseJSON(data);
                jQuery('#proceso').removeClass('oculto');
                if (data[0].ubicacion >= 0) {
                    for (i = 1; i < data[0].ubicacion; i++) {
                        document.getElementById(i).setAttribute('disabled', true);
                    }
                    jQuery('#' + data[0].ubicacion).addClass('active-tabs ');
                    jQuery('#proceso').removeClass('oculto');
                    asignar();
                } else {
                    //Session::flash('error', 'Error la orden ' + jQueryorden +  ' Ya Existe');

                    jQueryPrueba += '<div class="alert alert-danger alert-dismissible" role="alert"><button type="button" class="close" data-dismiss="alert">';
                    jQueryPrueba += '<span aria-hidden="true">&times;</span><span class="sr-only">Close</span></button>La Orden ' + jQueryorden + ' No Existe</div>';

                    document.getElementById('TableError').innerHTML = jQueryPrueba;
                }

            });
        } else {
            jQueryPrueba += '<div class="alert alert-danger alert-dismissible" role="alert"><button type="button" class="close" data-dismiss="alert">';
            jQueryPrueba += '<span aria-hidden="true">&times;</span><span class="sr-only">Close</span></button>Debe Digitar Una Orden</div>';

            document.getElementById('TableError').innerHTML = jQueryPrueba;
        }
    }

    function asignar() {
        jQuery("a[data-title=asignarProceso]").click(function () {
            $num_orden = document.getElementById('orden').value;
            $ubicacion = this.id;

            jQuery.get('Proceso/Asignar/' + $num_orden + '/' + $ubicacion, function (data) {
                var data = jQuery.parseJSON(data);
                
                for (i = 1; i < data; i++) {
                    document.getElementById(i).setAttribute('disabled' , true);
                    jQuery('#' + i).removeClass('active-tabs ');
                }
                jQuery('#' + data).addClass('active-tabs ');
            });
            
        });
    }
