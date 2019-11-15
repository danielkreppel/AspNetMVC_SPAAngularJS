MainApp.factory('PlanoVooFactory', ['$http', function ($http) {
    var factory = {};

    factory.BuscarPlanosVoo = function () {
        return $http({
            url: "Api/PlanoDeVoo/PlanosDeVoo",
            dataType: 'json',
            method: 'GET',
            data: '',
            headers: {
                "Content-Type": "application/json"
            }
        });
    }

    factory.BuscarMatriculas = function () {
        return $http({
            url: "Api/Aeronave/Matriculas",
            dataType: 'json',
            method: 'GET',
            data: '',
            headers: {
                "Content-Type": "application/json"
            }
        });
    }

    factory.BuscarAeroportos = function () {
        return $http({
            url: "Api/Aeroporto/BuscarTodos",
            dataType: 'json',
            method: 'GET',
            data: '',
            headers: {
                "Content-Type": "application/json"
            }
        });
    }

    factory.SalvarPlanoVoo = function(plano){
        return $http({
            url:"Api/PlanoDeVoo/Salvar",
            dataType: 'json',
            method: 'POST',
            data: JSON.stringify(plano),
            headers:{
                "Content-Type": "application/json"
            }
        });
    }

    factory.ExcluirPlanoVoo = function (plano) {
        return $http({
            url: "Api/PlanoDeVoo/Excluir",
            dataType: 'json',
            method: 'POST',
            data: JSON.stringify(plano),
            headers: {
                "Content-Type": "application/json"
            }
        });
    }

    return factory;
}]);    