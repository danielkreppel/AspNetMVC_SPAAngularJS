Informações sobre a aplicação:

.Net Framework 4.6

Projeto Web
- MVC apenas para a primeira renderização contendo a aplicação AngularJS (HomeController com a View Index que carrega a aplicação AngularJS para o Cliente, utilizando _Layout.cshtml para as rotas (Tab Menu) das views da minha app AngularJS)
- WebApi2 para todas as ações REST para o CRUD de plano de vôo e também buscas de informações (Planos de Vôo, Aeronaves, Tipos de Aeronaves e Listagem de aeroportos)

Ioc Container (Projeto CrossCutting.IoC)
- Escolhi o SimpleInjector

ORM (Projeto Data)
- Escolhi o Dapper

Banco de Dados
- Utilizei o SQL Server 2008 R2
- Criei o script "Script DB.sql", que contém o script para a criação do banco de dados e as estruturas necessárias com alguma carga inicial de dados. Nomeei o banco de "TestDB" e no início do script eu verifico se já existe um banco com este nome, apagando o mesmo em seguida caso já exista. Caso este nome não esteja apropriado para o teste, deve-se alterar o nome do banco no script e também na connectionstring da aplicação, no Web.config do projeto Web.

Frontend
- Utilizei o AngularJS versão 1.6.5
- Incluí o filtro para os planos de vôo por aeroporto de origem e/ou destino.

Fora o stack mencionado acima, segue abaixo outros detalhes da aplicação:

Projeto Application
- Utilizei o AutoMapper para o mapeamento das ViewModels para as entidades do domínio, e vice-versa
- Criei uma classe de extensão para tornar genérica a lógica de projeção dos conteúdos de uma lista de entidades de domínio para uma lista respectiva de ViewModels.
- Incluí o NLog para realizar o log de erros ocorridos na aplicação.
- Incluí neste projeto as ViewModels utilizadas pela aplicação.

Projeto Data
-  Repositórios da aplicação, utilizando o Dapper.

Projeto Domain
- Entidades de domínio da aplicação.

Projeto Service
- Serviços utilizados pela aplicação, funcionando como uma camada de abstração entre os ApiControllers e os repositórios. Ajuda a manter os Controllers ou ApiControllers enxutos, e promove SoC.

Projeto Web
- Diretório "App" contém a aplicação AngularJS.

Testes Unitários (Projeto "Tests")
- Incluí os pacotes Nuget "NBuilder" para facilitar a criação de dados para testes e o pacote "Moq" para o mocking de serviços.
- Para testar, clicar na opção "Test" do Visual Studio, em seguida em "Run" e "All Tests" (Ou pressionar CTRL+R, A)


Para rodar a aplicação:

1- Executar o script para criar o Banco de dados, tabelas, procedures e dados básicos para testes no SQL Server.

2- Criar um usuário com permissão de acesso ao banco de dados recém criado e atualizar a Connectionstring no Web.config do projeto "Web" para incluir este usuário e  a senha.

3- Abrir o fonte no Visual Studio 2015 ou superior, executar a aplicação marcando o projeto Web como "Startup Project" e acessar a URL (Rota) "http://localhost:<porta gerada>/".
    Ou pode publicar a aplicação e registrá-la no IIS. Para publicar deve-se clicar com o botão direito sobre o projeto Web e selecionar "Publish", escolher o local onde quer armazenar os arquivos e o tipo de publicação (Debug ou Release). Após a geração dos arquivos, deve-se abrir o gerenciador do IIS nas Ferramentas Administrativas e criar um novo Web Site/Aplicação apontando para os arquivos publicados do projeto Web. 
