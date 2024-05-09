### Conteinerizando uma API NetCore

[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](https://opensource.org/licenses/MIT)

A ideia central é **_conteinerizar_** um aplicativo .NET Core para desenvolvimento com o Docker Compose. Neste caso, trata-se de uma aplicação para controle de clientes e pedidos de empréstimo, que passará por uma análise (definida em regra de negócio) que poderá ser aprovada ou não pelos administradores do sistema.

> Todo processo está configurado num arquivo de manifesto (**docker-compose.yaml**) que está na raiz da solução.

### 🔥 Para baixar:

```bash
$ git clone https://github.com/fabioborges-ti/Financing-api
```

### 📋 Pré-requisitos
Antes de começar, você vai precisar ter instalado as seguintes ferramentas: [Git]([https://git-scm.com](https://git-scm.com/)) e o [Docker]([https://docs.docker.com/desktop/](https://docs.docker.com/desktop/)). Além disto, sugiro que você também utilize um bom editor de código, como o [VSCode]([https://code.visualstudio.com/]  (https://code.visualstudio.com/)). Este vai te oferecer _muitas_ extensões que farão toda diferença.

### 📦 Dependências do projeto
Abra seu terminal na pasta da solução e execute o seguinte comando: 

```bash
$ dotnet restore
```

### 🤞 Vamos testar?
Agora que você já tem tudo... chegou a hora de testar. Novamente, abra seu terminal na pasta **_raiz_** da solução, digite o comando abaixo e aguarde o fim do processo ☕

```bash
$ docker-compose up -d 
```
O **_Docker_** vai baixar do seu repositório https://hub.docker.com todas as imagens mencionadas no arquivo do _compose_ (**_yaml_**). Depois, inicia a geração da imagem e por fim a geração do container. Em poucos instantes nosso container estará de pé 😲

Quando esse processo encerrar, você pode conferir usando o comando abaixo:

```bash
$ docker-compose ps  
```
Atente para os seguintes containers:

```bash
api
portainer
sqlserver
```

Se estes foram listados, sucesso! 🤗 Já podemos fazer nossa primeira chamada da API. 👋🏼

### 🧭 Para acessar esses recursos 

| Recursos          | Portas        | Urls                                      |
| ----------------- | ------------- | ----------------------------------------- |
| healthchecks      | 8081          | https://localhost:8081/health             |
| api               | 8081          | https://localhost:8081/swagger/index.html |
| portainer         | 9000          | http://localhost:9000                     |


### 🛟 Importante

É recomendado que você acesse a url do Portainer [mencionada acima](http://localhost:9000), crie uma conta de administrador para conseguir acessar e conferir se todos os recursos estão funcionando adequadamente. 

Trata-se de uma ótima alternativa para controle de logs da API e conferir um monte de outras coisas, como redes, volumes, imagens, eventos e uma série de coisas. Vale a pena testar e conhecer!

Vale ressaltar que essa API atende dois públicos distintos: os adminstradores do sistema e usuários comuns (aqueles que farão pedidos de empréstimo). Isso você vai poder conferir no link do Swagger, em **https://localhost:8081/swagger/index.html**

No topo da página, você verá as versões disponíveis (v1 e v2) para administradores e usuários, respectivamente. Agora vamos ao que interessa... os recursos da API😜

### 💼 Versão administrador

| Recursos                      | Endpoints                  | Finalidade                       |
| ----------------------------- | -------------------------- | -------------------------------- |
| Credito                       | /api/v1/Credito/Tipos      | Listar tipos de crédito          |
| Proposta                      | /api/v1/Proposta           | Manter propostas                 |


> **Nota:** Nessa versão, o administrador não fará cadastro de clientes; ele tem o papel de aprovar ou recusar o pedido de empréstimo.

### 📱 Versão Cliente

| Recursos                      | Endpoints             | Finalidade                                 |
| ----------------------------- | --------------------- | ------------------------------------------ |
| Clientes                      | /api/v2/Clientes      | Cadastro de clientes                       |
| Parcelas                      | /api/v2/Parcelas      | Para controle das mensalidades             |
| Proposta                      | /api/v2/Proposta      | Cria sua proposta e acompanha seu status   |

> **Nota:** As regras para o acesso ao crédito seguem uma série de critérios (definidos pelo usuário), contudo essa proposta não é imediatamente aprovada (trata-se de um pedido de crédito); então segue para análise dos administradores, que podem aprovar ou recusar a proposta... 

### 📢 Notas importantes 

> - Irei anexar um arquivo PDF (notas técnicas) no repositório que ajudará na utilização do sistema.

### 💾 Principais tecnologias envolvidas 

Principais tecnologias e padrões envolvidos;


- Netcore 6;
- MediatR;
- SqlServer;
- EntityFrameWorkCore e Dapper;
- Docker; 
- Docker-compose;
- FluentValidation;
- Serilog;
- RestSharp;
- HealthChecks;
- Princípios SOLID;
- Clean Architecture e Clean Code;
- Padrões de projeto
  - CQRS;
  - Chain of responsibility;
- Arquitetura e modelagem de dados;
- Versionamento de APIs;
- xUnit;
  - Moq;
  - Unit tests;
  - Integration tests;


### ✈️ Para mais informações:
Se você não conhece sobre docker ou docker-compose e quer mais detalhes, consulte em:

https://docs.docker.com/compose/

E bons estudos! 🚀
