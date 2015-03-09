
function asignarcliente()
{
    jQuery.get('/BuscarCliente', function (data) {
        var data = JSON.parse(data);
        var buscar = "";
        for (i = 0; i < data.length; i++) {
            if (i == 0) {
                buscar += '<thead><th>Nombre</th><th>Apellidos</th><th>Telefono</th><th>Correo</th><th></th></thead>';

            }



            buscar += '<tr><td>' + data[i].nombre + '</td><td>' + data[i].apellidos + '</td><td>' + data[i].telefono + '</td><td>' + data[i].correo + '</td><td><a type="button" href="/Informacion/Create/' + data[i].id + '/' + data[i].nombre + '" class="btn btn-success" style="margin: 0% 0% 0% 31%;"><i class="fa fa-check"></i></a></td></tr>';
          
        }
        $(".mytable").hide(3000);
        $(".asignarCliente").show(2000);
        document.getElementById('tableAsignar').innerHTML = buscar;
        jQuery('#tableAsignar').dataTable({
            "lengthMenu": [5]
        });

       

    });
}

function asignarEditarCliente() {
    jQuery.get('/BuscarCliente', function (data) {
        var informacion = document.getElementById('editar').value;
        var data = JSON.parse(data);
        var buscar = "";
        for (i = 0; i < data.length; i++) {
            if (i == 0) {
                buscar += '<thead><th>Nombre</th><th>Apellidos</th><th>Telefono</th><th>Correo</th><th></th></thead>';

            }



            buscar += '<tr><td>' + data[i].nombre + '</td><td>' + data[i].apellidos + '</td><td>' + data[i].telefono + '</td><td>' + data[i].correo + '</td><td><a type="button" href="/Informacion/Edit/' + informacion + '/' + data[i].id + '/' + data[i].nombre + '" class="btn btn-success" style="margin: 0% 0% 0% 31%;"><i class="fa fa-check"></i></a></td></tr>';

        }
        $(".mytable").hide(3000);
        $(".asignarCliente").show(2000);
        document.getElementById('tableAsignar').innerHTML = buscar;
        jQuery('#tableAsignar').dataTable({
            "lengthMenu": [5]
        });



    });
}

$("#Cliente").keyup(function (event) {
    if (document.getElementById('Cliente').value.length >= 3) {
        validarCliente();
    }
});



function prueba5() {
    jQuery.ajax({
        url: '/agregarCliente',
        type: "post",
        data: jQuery("#form-agregar").serialize(),
        success: function (data) {
            var data = JSON.parse(data);
            var url = document.URL;
            window.location.href = url + "/Create/" + data[0].id + "/" + data[0].nombre;
            //validarCliente(data[0].id, data[0].nombre);
            
        }
    });

}
function crearCliente() {
    $('#element_to_pop_up').bPopup({

        appendTo: 'form'
                   , zIndex: 2
                   , modalClose: false
    });
    }
