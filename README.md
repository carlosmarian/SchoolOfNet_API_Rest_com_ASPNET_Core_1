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
    * 400: Permiss�o/Erro Cliente
    * 500: Erro de servidor

**Webservice:**

    Interface de comunica��o

**REST:**

    � um padr�o de desenvolvimento de WebServices.
    * Cliente Servidor;
    * Stateless;
    * Cache�vel;
    * Saber trabalhar com camadas;
    * Interface uniforme e direta.


**Rest X Restful:**

    ## Restful � uma API REST que foi implementada seguindo todas as recomenda��es do padr�o.


Para criar o projeto foi usado o comando:
```
dotnet new webapi
```
Este comando cria um projeto com a estrutura b�sica de uma WebAPI

**Configurar o MYSQL**

Primeiro vamos configurar a forma de acesso instalando `Pomelo.EntityFrameworkCore.MySql`:

Para usar Mysql deve: 
* Acessar https://www.nuget.org/ 
* Pesquisar pelo pacote: MySQL Entity Framework 
* Selecionar o pacote: Pomelo.EntityFrameworkCore.MySql copiar a linha de comando .NET CLI: exemplo: `dotnet add package Pomelo.EntityFrameworkCore.MySql --version 2.2.0` E executar no cmd
* Ap�s o CLI baixar e instalar as bibliotecas � recomendado executar `dotnet restore` Garante que todas as bibliotecas definidas no arq estar�o instaladas.

Ap�s isso precisamos subir nosso DOCKER do Mysql:
```
docker-compose up
```

Depois acessar o banco usando um cliente(HeidiSQL) e criar o banco:
```SQL
CREATE DATABASE apirest /*!40100 COLLATE 'latin1_general_cs' */;
```

Depois � necess�rio configurar a sttring de conex�o do nosso projeto, para isso acesse o arquivo `appsettings.json` e adicione a seguinte linha:
```JSON
"ConnectionStrings": {
    "DefaultConnection": "server=localhost;port=3306;database=apirest;uid=root;password=password"
  },
```

Depois criar a classe de contexto.

E por fim ajustar o servi�o;

Depois para testar:
`dotnet build`
`dotnet watch run`

E acessar : https://localhost:5001/api/values que � o exemplo de acesso.


**Entidade **

Criar um classe `Produto` com atributos.

Configurar a classe de conteto para o Produto no `ApplicationDbContext`.
```C#
public DbSet<Produto> Produtos { get; set ;}
```

Criar a migra��o:
```
dotnet ef migrations add AdicionandoProdutos
```
Com isso ser� gerado a arquivo de Migra��o na pasta `Migrations`.

Ap�s isso deve ser aplicada a migra��o de banco:
```
dotnet ef database update
```
OBS: Caso apresente erro de "Build failed" � pq � necess�rio dar um Build no projeto ou o projeto est� em execu��o pelo 'watch'.

