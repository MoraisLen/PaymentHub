# PaymentHub.API

PaymentHub.API é uma API .NET para gerenciamento de pagamentos via PIX, oferecendo endpoints para criação, consulta e cancelamento de transações.

## 📋 Sumário

- [Visão Geral](#visão-geral)
- [Endpoints](#endpoints)
  - [Criar Pagamento](#criar-pagamento)
  - [Buscar Pagamento por Filtros](#buscar-pagamento-por-filtros)
  - [Buscar Pagamento por ID](#buscar-pagamento-por-id)
  - [Cancelar Pagamento](#cancelar-pagamento)
- [Modelos de Dados](#modelos-de-dados)
- [Possíveis Status de Pagamento](#possíveis-status-de-pagamento)
- [Respostas de Erro](#respostas-de-erro)

---

## Visão Geral

Esta API permite criar, consultar e cancelar pagamentos usando o sistema de pagamentos brasileiro **PIX**.

Versão atual: **v1**

Base URL padrão:  
`/api/Pix`

---

## Endpoints

### ➡️ Criar Pagamento

**POST** `/api/Pix/CreateAsync`

- **Descrição**: Cria um pagamento via PIX.
- **Body**: Objeto `PaymentModel`
- **Respostas**:
  - `201 Created`: Pagamento gerado com sucesso (`PreferenceModel`).
  - `400 Bad Request`: Erro no servidor.

---

### 🔍 Buscar Pagamento por Filtros

**GET** `/api/Pix/GetAsync`

- **Descrição**: Busca pagamentos com filtro opcional por **status**.
- **Parâmetros de Query**:
  - `status` (opcional): `cancelado`, `aprovado` ou `pendente`
- **Respostas**:
  - `200 OK`: Lista de pagamentos (`PaymentDetailModel[]`).
  - `400 Bad Request`: Erro no servidor.

---

### 🔎 Buscar Pagamento por ID

**GET** `/api/Pix/GetAsync/{Id}`

- **Descrição**: Busca um pagamento específico pelo ID.
- **Parâmetros de Path**:
  - `Id` (obrigatório): Identificador do pagamento.
- **Respostas**:
  - `200 OK`: Pagamento encontrado (`PaymentDetailModel[]`).
  - `404 Not Found`: Nenhum pagamento encontrado.
  - `400 Bad Request`: Erro no servidor.

---

### ❌ Cancelar Pagamento

**PUT** `/api/Pix/CancellAsync/{Id}`

- **Descrição**: Cancela um pagamento existente via PIX.
- **Parâmetros de Path**:
  - `Id` (obrigatório): Identificador do pagamento.
- **Respostas**:
  - `200 OK`: Pagamento cancelado (`PaymentDetailModel[]`).
  - `404 Not Found`: Pagamento não encontrado.
  - `400 Bad Request`: Erro no servidor.

---

## Modelos de Dados

### PaymentModel (Para criação de pagamento)

```json
{
  "valorTotal": 100.00,
  "descricao": "Compra de produto",
  "referenciaExterna": "REF12345",
  "pagador": {
    "nome": "João",
    "sobrenome": "Silva",
    "email": "joao@email.com"
  },
  "produtos": [
    {
      "nome": "Produto A",
      "descricao": "Descrição do produto A",
      "valorUnitario": 50.00,
      "quantidade": 2
    }
  ]
}
```

---

### PaymentDetailModel (Resposta de consulta)

- Dados como:
  - ID do pagamento
  - Valor total
  - Status do pagamento
  - Informações do pagador e produtos
  - Link para pagamento
  - Código "Copia e Cola" e QR Code Base64

---

## Possíveis Status de Pagamento

- `aprovado`: Pagamento aprovado.
- `pendente`: Aguardando pagamento.
- `cancelado`: Pagamento cancelado.

---

## Respostas de Erro (ProblemDetails)

Erro padrão em caso de falha na requisição:

```json
{
  "type": "string",
  "title": "string",
  "status": 400,
  "detail": "Descrição do erro",
  "instance": "string"
}
```

---

## 🛠️ Tecnologias

- .NET Core 8
- OpenAPI 3.0.1
- PIX (Sistema de Pagamento Instantâneo Brasileiro)
