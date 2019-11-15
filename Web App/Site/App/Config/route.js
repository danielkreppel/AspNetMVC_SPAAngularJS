
MainApp.config(function ($routeProvider) {

    var baseUrl = $("base").first().attr("href");

    $routeProvider
        .when('/planovoo',
        {
            controller: 'PlanoVooController',
            templateUrl: '../../App/Views/PlanoVoo.html'
        }
        )
        .when('/aeronaves',
        {
            controller: 'AeronavesController',
            templateUrl: '../../App/Views/Aeronaves.html'
        })
        .when('/aeroportos',
        {
            controller: 'AeroportosController',
            templateUrl: '../../App/Views/Aeroportos.html'
        })
        .when('/tiposaeronaves',
        {
            controller: 'TiposAeronavesController',
            templateUrl: '../../App/Views/TiposAeronaves.html'
        })
        .otherwise({ redirectTo: '/planovoo' });
});