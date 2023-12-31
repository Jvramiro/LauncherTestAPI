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
O Unit Test programado para os endpoints da API pode ser encontrado no diretório Tests/LauncherControllerTests.cs.

## Documentação OpenAPI 3.0

É possível encontrar a documentação padronizada por OpenAPI 3.0 no diretório Docs/openapi.json
Também é possível conferir o conteúdo abaixo:

<details>
  <summary>Clique para expandir</summary>
  
```json
{
  "openapi": "3.0.1",
  "info": {
    "title": "LauncherTestAPI",
    "version": "1.0"
  },
  "paths": {
    "/Launcher": {
      "get": {
        "tags": [
          "Launcher"
        ],
        "responses": {
          "200": {
            "description": "Success"
          }
        }
      }
    },
    "/Launcher/launchers": {
      "get": {
        "tags": [
          "Launcher"
        ],
        "parameters": [
          {
            "name": "page",
            "in": "query",
            "schema": {
              "type": "integer",
              "format": "int32"
            }
          }
        ],
        "responses": {
          "200": {
            "description": "Success"
          }
        }
      }
    },
    "/Launcher/{launchId}": {
      "get": {
        "tags": [
          "Launcher"
        ],
        "parameters": [
          {
            "name": "launchId",
            "in": "path",
            "required": true,
            "schema": {
              "type": "integer",
              "format": "int32"
            }
          }
        ],
        "responses": {
          "200": {
            "description": "Success"
          }
        }
      },
      "put": {
        "tags": [
          "Launcher"
        ],
        "parameters": [
          {
            "name": "launchId",
            "in": "path",
            "required": true,
            "schema": {
              "type": "integer",
              "format": "int32"
            }
          }
        ],
        "requestBody": {
          "content": {
            "application/json": {
              "schema": {
                "$ref": "#/components/schemas/Launcher"
              }
            },
            "text/json": {
              "schema": {
                "$ref": "#/components/schemas/Launcher"
              }
            },
            "application/*+json": {
              "schema": {
                "$ref": "#/components/schemas/Launcher"
              }
            }
          }
        },
        "responses": {
          "200": {
            "description": "Success"
          }
        }
      },
      "delete": {
        "tags": [
          "Launcher"
        ],
        "parameters": [
          {
            "name": "launchId",
            "in": "path",
            "required": true,
            "schema": {
              "type": "integer",
              "format": "int32"
            }
          }
        ],
        "responses": {
          "200": {
            "description": "Success"
          }
        }
      }
    }
  },
  "components": {
    "schemas": {
      "Launcher": {
        "type": "object",
        "properties": {
          "id": {
            "type": "integer",
            "format": "int32"
          },
          "url": {
            "type": "string",
            "nullable": true
          },
          "flightProven": {
            "type": "boolean"
          },
          "serialNumber": {
            "type": "string",
            "nullable": true
          },
          "isPlaceholder": {
            "type": "boolean"
          },
          "launcherStatus": {
            "type": "string",
            "nullable": true
          },
          "details": {
            "type": "string",
            "nullable": true
          },
          "launcherConfig": {
            "$ref": "#/components/schemas/LauncherConfig"
          },
          "imageUrl": {
            "type": "string",
            "nullable": true
          },
          "flights": {
            "type": "integer",
            "format": "int32"
          },
          "lastLaunchDate": {
            "type": "string",
            "format": "date-time"
          },
          "firstLaunchDate": {
            "type": "string",
            "format": "date-time"
          },
          "imported_t": {
            "type": "string",
            "format": "date-time"
          },
          "status": {
            "$ref": "#/components/schemas/Status"
          }
        },
        "additionalProperties": false
      },
      "LauncherConfig": {
        "type": "object",
        "properties": {
          "id": {
            "type": "integer",
            "format": "int32"
          },
          "url": {
            "type": "string",
            "nullable": true
          },
          "name": {
            "type": "string",
            "nullable": true
          },
          "family": {
            "type": "string",
            "nullable": true
          },
          "fullName": {
            "type": "string",
            "nullable": true
          },
          "variant": {
            "type": "string",
            "nullable": true
          }
        },
        "additionalProperties": false
      },
      "Status": {
        "enum": [
          0,
          1,
          2
        ],
        "type": "integer",
        "format": "int32"
      }
    }
  }
}
```
</details>