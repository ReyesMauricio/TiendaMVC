$.ajax({
    url: '/Home/GraficaVentasPorProducto',
    type: 'POST',
    dataType: 'json',
    success: function (data) {

        const $LienzoGrafica = document.getElementById('GraficaVentasPorProducto');

        dataGrafica = data;
        graficaLabel = [];
        totalProductos = [];
        colorBarras = [];
        colorBordeBarras = [];

        for (var i in dataGrafica) {
            color = (Math.random() * (255 - 1) + 1);
            graficaLabel.push(dataGrafica[i].Producto);
            totalProductos.push(dataGrafica[i].Total);
            colorBarras.push('rgba(54, 162, ' + color + ', 0.2)');
            colorBordeBarras.push('rgba(54, 162, ' + color + ', 1)')
        }

        const GraficaVentaPorProducto = {
            label: "Productos más Vendidos",
            data: totalProductos,
            backgroundColor: colorBarras,
            borderColor: colorBordeBarras,
            borderWidth: 1,
        };


        new Chart($LienzoGrafica, {
            type: 'doughnut',// Tipo de gráfica
            data: {
                labels: graficaLabel,
                datasets: [
                    GraficaVentaPorProducto,
                ]
            },
            options: {
                scales: {
                    y: {
                        display: false,
                    },
                    x: {
                        display: false,
                    },
                },
            }
        });
    },
    error: function () {
        console.log("Error al recibir los datos")
    }
});