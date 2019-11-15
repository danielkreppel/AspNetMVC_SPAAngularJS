MainApp.controller('PlanoVooController', function ($scope, $rootScope, $routeParams, $location, $filter, $timeout, $window, ngDialog, PlanoVooFactory, DTOptionsBuilder, DTColumnBuilder, DTDefaultOptions, CommonService) {

    DTDefaultOptions.setLoadingTemplate('<h4>Carregando...</h4>');

    toastr.options = {
        "closeButton": true,
        "debug": false,
        "newestOnTop": false,
        "progressBar": false,
        "positionClass": "toast-top-right",
        "preventDuplicates": false,
        "onclick": null,
        "showDuration": "0",
        "hideDuration": "1000",
        "timeOut": "6000",
        "extendedTimeOut": "1000",
        "showEasing": "swing",
        "hideEasing": "linear",
        "showMethod": "fadeIn",
        "hideMethod": "fadeOut"
    };

    //Lista de Planos de Vôo
    $scope.PlanosVoo = {
        IdAeronave: 0,
        NumeroVoo: '',
        Matricula: '',
        TipoAeronave: '',
        Data: '',
        Origem: '',
        Destino: ''
    };

    //Lista para o DataTable
    $scope.PlanosVooGrid = {};

    //Objeto para cadastro ou alteração do plano de vôo
    $scope.PlanoVoo = {
        IdPlanoVoo: 0,
        IdAeronave: 0,
        IdAeroportoOrigem: 0,
        IdAeroportoDestino: 0,
        NumeroVoo: '',
        Matricula: '',
        TipoAeronave: '',
        Data: '',
        Origem: '',
        Destino: '',
        MatriculasAeronaves: {},
        AeroportosOrigem: {},
        AeroportosDestino: {}
    }

    //Listas para os combos
    $scope.MatriculasAeronaves = {};
    $scope.Aeroportos = {};

    //Seleções na tela
    $scope.AeronaveSelecionada = {};
    $scope.AeroportoOrigemSelecionado = {};
    $scope.AeroportoDestinoSelecionado = {};

    //Configuração do campo Data
    setDate();

    //Buscando informações da Web Api
    BuscarPlanosVoo();
    BuscarMatriculas();
    BuscarAeroportos();

    function BuscarPlanosVoo() {
        PlanoVooFactory.BuscarPlanosVoo().then(function (response) {
            $scope.PlanosVoo = response.data;
            $scope.PlanosVooGrid = response.data;
        }, function (error) {
            alert(error);
        });
    }

    function BuscarMatriculas() {
        PlanoVooFactory.BuscarMatriculas().then(function (response) {
            $scope.MatriculasAeronaves = response.data;
        });
    }

    function BuscarAeroportos() {
        PlanoVooFactory.BuscarAeroportos().then(function (response) {
            $scope.Aeroportos = response.data;
        });
    }

    $scope.txtPesquisarOrigemDestinoChanged = function () {
        $scope.PlanosVooGrid = $scope.PlanosVoo.filter(
            function (p) { 
                return p.Origem.toUpperCase().indexOf($('#txtPesquisarOrigem').val().toUpperCase()) > -1 && p.Destino.toUpperCase().indexOf($('#txtPesquisarDestino').val().toUpperCase()) > -1;
            });
    }

    $scope.SalvarPlanoVoo = function () {
        
        var MensagemValidacao = '';
        if ($scope.PlanoVoo.NumeroVoo.trim() == '')
            MensagemValidacao = 'Número do vôo requerido.\n';
        if ($scope.AeronaveSelecionada.IdAeronave == undefined)
            MensagemValidacao += 'Selecione a matrícula da aeronave.\n'
        if ($scope.AeroportoOrigemSelecionado.IdAeroporto == undefined)
            MensagemValidacao += 'Selecione o aeroporto de origem.\n';
        if ($scope.AeroportoDestinoSelecionado.IdAeroporto == undefined)
            MensagemValidacao += 'Selecione o aeroporto de destino.\n';
        if ($scope.PlanoVoo.Data.trim() == '')
            MensagemValidacao += 'Selecione a data e horário.\n';
        if ($scope.AeroportoOrigemSelecionado.IdAeroporto == $scope.AeroportoDestinoSelecionado.IdAeroporto)
            MensagemValidacao += 'Origem e Destino não podem ser o mesmo aeroporto.';

        if (MensagemValidacao != '') {
            toastr.warning(MensagemValidacao, 'Campos Obrigatórios' );
            return false;
        }
        
        $scope.PlanoVoo.IdAeronave = $scope.AeronaveSelecionada.IdAeronave;
        $scope.PlanoVoo.IdAeroportoOrigem = $scope.AeroportoOrigemSelecionado.IdAeroporto;
        $scope.PlanoVoo.IdAeroportoDestino = $scope.AeroportoDestinoSelecionado.IdAeroporto;
        var data = $scope.PlanoVoo.Data;
        $scope.PlanoVoo.Data = CommonService.TryGetDateFromValue($scope.PlanoVoo.Data, 2, 1, 0, '/')

        PlanoVooFactory.SalvarPlanoVoo($scope.PlanoVoo).then(function (response) {
            if (response.data.Erro == false){
                toastr.success('Plano de vôo salvo com sucesso.', 'Sucesso');
                LimparPlanoVoo();
                BuscarPlanosVoo();
            }
            else if (response.data.Mensagem != undefined && response.data.Mensagem.trim() != ''){
                $scope.PlanoVoo.Data = data;
                toastr.error(response.data.Mensagem, 'Erro');
            }
            else {
                $scope.PlanoVoo.Data = data;
                toastr.error('Ocorreu algum erro ao tentar salvar o plano de vôo.', 'Erro');
            }
                
        });
    }

    $scope.EditarPlanoVoo = function (p) {
        $scope.PlanoVoo = p;
        $scope.AeronaveSelecionada = $scope.MatriculasAeronaves.filter(
            function (a) {
                return a.IdAeronave == p.IdAeronave;
            }
        )[0];
        $scope.AeroportoOrigemSelecionado = $scope.Aeroportos.filter(
            function (a) {
                return a.IdAeroporto == p.IdAeroportoOrigem;
            }
        )[0];
        $scope.AeroportoDestinoSelecionado = $scope.Aeroportos.filter(
            function (a) {
                return a.IdAeroporto == p.IdAeroportoDestino;
            }
        )[0];
        $scope.PlanoVoo.Data = p.DataFormatada;

        document.body.scrollTop = document.documentElement.scrollTop = 0;
    }

    $scope.CancelarEdicao = function () {
        LimparPlanoVoo();
    }


    function  LimparPlanoVoo(){
        $scope.PlanoVoo = {
            IdPlanoVoo: 0,
            IdAeronave: 0,
            IdAeroportoOrigem: 0,
            IdAeroportoDestino: 0,
            NumeroVoo: '',
            Matricula: '',
            TipoAeronave: '',
            Data: '',
            Origem: '',
            Destino: ''
        };
        $scope.AeronaveSelecionada = {};
        $scope.AeroportoOrigemSelecionado = {};
        $scope.AeroportoDestinoSelecionado = {};
    }

    

    $scope.ExcluirPlanoVoo = function (p) {

        PlanoVooFactory.ExcluirPlanoVoo(p).then(function (response) {
            if (response.data.Erro == false) {
                BuscarPlanosVoo();
                toastr.success('Plano de vôo excluído com sucesso.', 'Sucesso');
            }
            else if (response.data.Mensagem != undefined && response.data.Mensagem.trim() != '')
                toastr.error(response.data.Mensagem, 'Erro');
            else
                toastr.error('Ocorreu algum erro ao tentar excluir o plano de vôo.', 'Erro');
        });        
    }

    function setDate() {
        var dateFormat = "dd/mm/yy";

        $("#Data").datetimepicker({
              defaultDate: "+1w",
              timeFormat: "HH:mm:ss",
              showHour: true,
              showMinute: true,
              hour: 0,
              minute: 0,
              second: 0,
              timeInput: true,
              timeText: "Horário",
              hourText: "Hora",
              minuteText: "Minuto",
              secondText: "Segundo",
              changeMonth: true,
              numberOfMonths: 1,
              showOn: "button",
              buttonImage: "",
              buttonImageOnly: false,
              buttonText: "<i class='glyphicon glyphicon-calendar'></i>",
              dateFormat: 'dd/mm/yy',
              dayNames: ['Domingo', 'Segunda', 'Terça', 'Quarta', 'Quinta', 'Sexta', 'Sábado'],
              dayNamesMin: ['D', 'S', 'T', 'Q', 'Q', 'S', 'S', 'D'],
              dayNamesShort: ['Dom', 'Seg', 'Ter', 'Qua', 'Qui', 'Sex', 'Sáb', 'Dom'],
              monthNames: ['Janeiro', 'Fevereiro', 'Março', 'Abril', 'Maio', 'Junho', 'Julho', 'Agosto', 'Setembro', 'Outubro', 'Novembro', 'Dezembro'],
              monthNamesShort: ['Jan', 'Fev', 'Mar', 'Abr', 'Mai', 'Jun', 'Jul', 'Ago', 'Set', 'Out', 'Nov', 'Dez'],
              nextText: 'Próximo',
              prevText: 'Anterior',
              closeText: 'Aplicar',
              currentText: 'Agora'
          });
         
        function getDate(element) {
            var date;
            try {
                date = $.datepicker.parseDate(dateFormat, element.value);
            } catch (error) {
                date = null;
            }

            return date;
        }
    }
});