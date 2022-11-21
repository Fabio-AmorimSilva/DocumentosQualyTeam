"# DocumentosQualyTeam" 

- O projeto foi realizado utilizando Arquitetura Limpa - Arquitetura Cebola (Onion Architecture)
    - Possuí 4 camadas de back-end e 1 camada de front-end
    - Back-end
        - Processos.API
            - API REST, Controllers, CORS, etc
        - Processos.Aplicacao
          - Serviços, Validações, ViewModels, Interfaces, etc
        - Processos.Dominio
          - Core, Modelos, etc
        - Processos.Infraestrutura
          - DbContext, Migrations, Mappings, etc

    - Front-end
      - Processos.MVC 
        - ViewModels, Views, Controllers, etc

- Características do Back-end
  - O projeto foi realizado utilizando a IDE Microsoft Visual Studio 2022  
  - Utilização de API REST com métodos POST, PUT, GET E DELETE
  - Versionamento via Swagger
  - Não possuí autentição e autorização de usuário
  - Uso de fluent api para validações (olhar Processos.Aplicacao/Validations)
  - Banco de dados utilizado foi o Mysql
  - Os processos possuem 5 tipos que são definidos com a utilização de uma classe do tipo enumeration (olhar Concessionaria.Dominio Core/Enumeration e Models/Enumerations) - https://learn.microsoft.com/pt-br/dotnet/architecture/microservices/microservice-ddd-cqrs-patterns/enumeration-classes-over-enum-types
  - Os tipos dos processos são inseridos no banco de dados no momento de sua criação (olhar Processos.Infraestrutura Context/ApplicationDbContext)

- Características do Front-end
  - O projeto foi realizado utilizando a IDE Microsoft Visual Studio 2022
  - Projeto foi realizado utilizando o ASP.NET CORE MVC
  - A estilização foi feita com a utilização de Materialize CSS - https://materializecss.com/
  - A listagem dos documentos foi feita com uma tabela
  - Os Html Helpers foram utilizados na construção das Views

- Montagem do banco de dados
  - O banco de dados utilizado foi o Mysql 8.0.31
  - A string de conexão para utilizar o banco é: 
    "ConnectionStrings": {
        "DefaultConnection": "server=localhost; database=NomeDoSeuDb; user=NomeDoSeuUsuarioMysql; password=SenhaDoSeuUsuarioMysql"
  }

- A string de conexão pode ser colocada tanto dentro do arquivo secrets.json quanto appsettings.json (dentro de Processos.API)
- Após configurar a string de conexão:
    - O ORM utilizado foi o EF Core 7
    - Instalação do EF Core 7 - https://learn.microsoft.com/pt-br/ef/core/cli/dotnet
    - Após a instalação:
        - As migrations já estão no projeto Processos.Infraestrutura
        - Basta entrar na pasta Processos.Infraestrutura via terminal e executar o comando "dotnet ef database update --startup-project ../Processos.API" via terminal para criar as tabelas no banco de dados

- Rodar o projeto
    - Para o funcionamento correto a etapa de "Montagem de banco de dados" deve ter sido realizada antes
    - Para rodar o projeto siga os passos a seguir:
    - Ter donet cli instalado - https://learn.microsoft.com/pt-br/dotnet/machine-learning/how-to-guides/install-ml-net-cli?tabs=windows
    - Após ter feito as etapas anteriores
        - Entrar na pasta Processos.API via terminal e executar o comando "dotnet run"
        - Entrar na posta Processos.MVC via terminal e executar o comando "dotnet run"
        - Esperar ambos os projetos serem executados e entrar no endereço fornecido pelo terminal de Processos.MVC
    - Observação: Essa é uma das maneiras de se executar o projeto, mas existem outras ficando ao seu critério qual utilizar 