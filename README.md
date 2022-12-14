# Geopet :: backend

este é um projeto desenvolvido por Alvaro, Jéssica e Telme para conclusão da Aceleração em C# oferecida pela Trybe em parceria com a XP Inc (dezembro 2022).

Utilizando C# e SQL Server desenvolvemos uma API para aplicação GeoPet, que fornece aos tutores de animais a possibilidade de localiza-los (em caso de fuga ou perda), através de um sensor de geolocalização acoplado à coleira do animal. O tutor do animal faz login em um sistema e consegue acessar a localização do pet. O pet, por sua vez, possui em sua coleira um QRCode que pode ser lido por quem encontrá-lo, obtendo informações para contato do usuário.

<details>
  <summary><strong>Banco de Dados</strong></summary><br />

para fornecer as informações à aplicação, foi desenhado um banco de dados conforme o [diagrama ER](https://drawsql.app/teams/trybe-26/diagrams/geopet), que relaciona Users e Pets.

![ER](https://github.com/telm-e/geopet/blob/general/geopet/ER_Diagram_Geopet.png)

O <i>[script](./geopet/geopet.sql)</i> pode ser executado para criação de um banco de dados exemplo. Utilizamos SQL Server e Entity Framework para conectar o código ao banco de dados.

  <br />
</details>
<details>
  <summary><strong>Desenvolvimento</strong></summary><br />

o desenvolvimento foi realizado utilizando C# e SQL Server. Foram desenvolvidos dois CRUDS, um para os USERS e outro para os PETS. Dessa forma, é possível fazer as operações básicas de listar (get), obter por id (get by id), cadastrar (post), alterar (put) e deletar (delete) usuários e pets.

para o cadastro de usuários, foi utilizado o serviço externo da ViaCep para validação do CEP cadastrado.

outros dois endpoints foram implementados: um que retorna um QR Code com as informações de um pet (utilizamos o serviço da GoQR API); outro que recebe uma latitude e uma longitude e retorna um endereço, utilizando o serviço da Nominatin API.

um endpoint para Login foi criado, garantindo a autenticação simples de um usuário no sistema, utilizando token JWT. A maioria das rotas foram autenticadas, sendo apenas a rota de cadastro e a rota de obter informações do dono do pet (getUserById) rotas anônimas.

foram elaborados testes para a aplicação utilizando xUnit e FluentAssertions. Trabalhamos para obter 30% de cobertura dos testes.

  <br />
</details>
<details>
  <summary><strong>Próximos passos</strong></summary><br />

elencamos algumas melhorias que podem ser feitas nas próximas etapas do desenvolvimento deste aplicativo, que não foram contempladas nesta sprint do projeto:
> a) Desenvolvimento de outros endpoints que podem facilitar o desenvolvimento do front-end da aplicação para uma melhor experiência do usuário (ex. ultima localização do pet, etc).
<br /><br />
> b) Autenticação mais robusta da aplicação: considerar que o usuário autenticado pode alterar apenas o seu cadastro e de seus pets.
<br /><br />
> c) Conteinerização da aplicação.
<br /><br />
> d) Deploy da aplicação na Azure.

  <br />
</details>

### Geopet API: como utilizar

para acompanhar o desenvolvimento desta API você pode:

1) Fazer o fork do repositório e clonar o seu fork em um repositório local.
2) Instalar as dependências em cada uma das pastas (geopet e geopet.Test) `dotnet restore`
3) Dentro da pasta Geopet, subir o docker-compose com a imagem do banco de dados `docker-compose up`. Rodar o arquivo .sql para criação do banco de dados exemplo.
4) Dentro da pasta Geopet, colocar o aplicativo para rodar `dotnet run` .
5) Após rodar a aplicação no servidor local, acompanhe as ações possíveis a partir da lista de endpoints na documentação do swagger: http://localhost:7253/swagger

gravamos uma apresentação em vídeo, demonstrando a utilização dos endpoints. A gravação está disponível em: XXXXXXXXXX

  <br />