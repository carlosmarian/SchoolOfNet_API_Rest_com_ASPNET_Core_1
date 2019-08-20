# SchoolOfNet_API_Rest_com_ASPNET_Core_1
Projeto usado no curso API Rest com ASP.NET Core - Parte 1


**Metodos Http:**

Get

Post

PUT

PATCH

DELETE

**Status Code:**

Fonte: https://pt.wikipedia.org/wiki/Lista_de_c%C3%B3digos_de_estado_HTTP

Grupos:

    * 100 : Informativo
    * 200: Sucesso
    * 300: Movidos/Redirecionamentos
    * 400: Permissão/Erro Cliente
    * 500: Erro de servidor

**Webservice:**

    Interface de comunicação

**REST:**

    É um padrão de desenvolvimento de WebServices.
    * Cliente Servidor;
    * Stateless;
    * Cacheável;
    * Saber trabalhar com camadas;
    * Interface uniforme e direta.


**Rest X Restful:**

    ## Restful é uma API REST que foi implementada seguindo todas as recomendações do padrão.


Para criar o projeto foi usado o comando:
```
dotnet new webapi
```
Este comando cria um projeto com a estrutura básica de uma WebAPI

**Configurar o MYSQL**

Primeiro vamos configurar a forma de acesso instalando `Pomelo.EntityFrameworkCore.MySql`:

Para usar Mysql deve: 
* Acessar https://www.nuget.org/ 
* Pesquisar pelo pacote: MySQL Entity Framework 
* Selecionar o pacote: Pomelo.EntityFrameworkCore.MySql copiar a linha de comando .NET CLI: exemplo: `dotnet add package Pomelo.EntityFrameworkCore.MySql --version 2.2.0` E executar no cmd
* Após o CLI baixar e instalar as bibliotecas é recomendado executar `dotnet restore` Garante que todas as bibliotecas definidas no arq estarão instaladas.

Após isso precisamos subir nosso DOCKER do Mysql:
```
docker-compose up
```

Depois acessar o banco usando um cliente(HeidiSQL) e criar o banco:
```SQL
CREATE DATABASE apirest /*!40100 COLLATE 'latin1_general_cs' */;
```

Depois é necessário configurar a sttring de conexão do nosso projeto, para isso acesse o arquivo `appsettings.json` e adicione a seguinte linha:
```JSON
"ConnectionStrings": {
    "DefaultConnection": "server=localhost;port=3306;database=apirest;uid=root;password=password"
  },
```

Depois criar a classe de contexto.

E por fim ajustar o serviço;

Depois para testar:
`dotnet build`
`dotnet watch run`

E acessar : https://localhost:5001/api/values que é o exemplo de acesso.


**Entidade **

Criar um classe `Produto` com atributos.

Configurar a classe de conteto para o Produto no `ApplicationDbContext`.
```C#
public DbSet<Produto> Produtos { get; set ;}
```

Criar a migração:
```
dotnet ef migrations add AdicionandoProdutos
```
Com isso será gerado a arquivo de Migração na pasta `Migrations`.

Após isso deve ser aplicada a migração de banco:
```
dotnet ef database update
```
OBS: Caso apresente erro de "Build failed" é pq é necessário dar um Build no projeto ou o projeto está em execução pelo 'watch'.

