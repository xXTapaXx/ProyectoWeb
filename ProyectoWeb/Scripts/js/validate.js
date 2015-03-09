jQuery.get('/validar', function (data) {
    data = JSON.parse(data);
    
    if (data[0].departamento == 1)
    {
        $('.proceso').addClass("oculto");
        $('.usuario').addClass("oculto");

    }
    else if (data[0].departamento == 2)
    {
        $('.mantenimiento').addClass("oculto");
        $('.buscar').addClass("oculto");
       
    }

   



});