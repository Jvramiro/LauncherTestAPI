# FutureSpace Inc REST API

Este é um projeto de desafio de back-end utilizando a API FutureSpace Inc, com o objetivo de criar uma REST API para gerenciar e exibir informações sobre lançamentos de foguetes.

## Descrição

O projeto é uma REST API que permite aos usuários realizar operações CRUD nos dados de lançamentos de foguetes. Ele inclui funcionalidades para importar dados de uma fonte externa, agendar atualizações diárias e fornecer endpoints para recuperar, atualizar e excluir informações de lançamentos.

## Endpoints da API

Os seguintes endpoints estão disponíveis:

- `GET /`: Retorna uma mensagem "REST Back-end Challenge Running".

- `PUT /launchers/:launchId`: Atualiza o lançamento especificado com os dados fornecidos.

- `DELETE /launchers/:launchId`: Remove o lançamento especificado do banco de dados.

- `GET /launchers/:launchId`: Recupera informações de um lançamento específico.

- `GET /launchers`: Lista todos os lançamentos de forma paginada.

## Gerenciamento de Dados

Como este diretório é um teste, não foi utilizado nenhuma hospedagem de banco de dados para gerir os dados. Os dados são salvos em uma variável local de um classe Singleton simulando o Context dos dados.
As nomenclaturas utilizadas são as mesmas utilizadas para quando utilizado algum banco de dados. Logo para a existência de um banco de dados, caso fosse criado e adicionado na API, seria adicionado a String de conexão, atualizado o Context de Launchers e realizado um mapeamento para atualizar os Modelos para o banco de dados.

## Unit Test

Foi criado um teste unitário para testar as principais funções que são requisitadas pelos endpoints dos controladores.
Os testes criados contém as possibilidades de entrada e as possibilidades de resultados de saída nas interações com a API.
O Unit Test programado para os endpoints da API pode ser encontrado em Tests/LauncherControllerTests.cs.
