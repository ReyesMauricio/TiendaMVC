$.ajax({
    url: '/Home/GraficaProductosPorCategoria',
    type: 'POST',
    dataType: 'json',
    success: function (data) {

        const $LienzoGrafica = document.getElementById('GraficaProductoPorCategoria');

        dataGrafica = data;
        graficaLabel = [];
        totalProductos = [];
        colorBarras = [];
        colorBordeBarras = [];

        for (var i in dataGrafica) {
            color = (Math.random() * (255 - 1) + 1);
            graficaLabel.push(dataGrafica[i].Categoria);
            totalProductos.push(dataGrafica[i].Total);
            colorBarras.push('rgba(54, 162, ' + color + ', 0.2)');
            colorBordeBarras.push('rgba(54, 162, ' + color + ', 1)')
        }

        const GraficaProductoPorCategoria = {
            label: "Productos por Categoria",
            data: totalProductos,
            backgroundColor: colorBarras,
            borderColor: colorBordeBarras,
            borderWidth: 1,
        };


        new Chart($LienzoGrafica, {
            type: 'bar',// Tipo de gráfica
            data: {
                labels: graficaLabel,
                datasets: [
                    GraficaProductoPorCategoria,
                ]
            },
            options: {
                scales: {
                    y: {
                        beginAtZero: true
                    },
                },
            }
        });
    },
    error: function () {
        console.log("Error al recibir los datos")
    }
});