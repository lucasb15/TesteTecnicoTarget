# 📦 TesteTecnicoTarget – Desafio Técnico Target Sistemas

Aplicação desenvolvida em C# .NET, utilizando manipulação de JSON, cálculos financeiros e controle de estoque.
O projeto foi criado como parte do teste técnico da Target Sistemas, contendo três desafios distintos:

- Cálculo de comissão por vendas

- Sistema de movimentação de estoque

- Cálculo de juros por atraso

## 🧩 Descrição Geral

O TesteTecnicoTarget é um conjunto de módulos independentes desenvolvidos em C#, que realizam operações de cálculo e processamento baseadas em arquivos JSON e interações do usuário no console.

O projeto contém:

🔹 Processamento de vendas e cálculo automático de comissão

🔹 Controle simples de estoque com movimentações (entrada e saída)

🔹 Cálculo financeiro com juros por atraso

🔹 Interface em modo console, clara e interativa

O software foi estruturado com serviços, modelos e separação lógica entre domínio e apresentação.

# ⚙️ Funcionalidades
## 1️⃣ Cálculo de Comissão por Vendedor

Dado um arquivo JSON com registros de vendas no seguinte formato:
```json
{
  "vendas": [
    { "vendedor": "João Silva", "valor": 1200.50 },
    { "vendedor": "Maria Souza", "valor": 2100.40 }
  ]
}
```
### 📌 Regras da Comissão
Processa o JSON de vendas e calcula a comissão total de cada vendedor com base nas regras:

| Valor da Venda       | Comissão |
| -------------------- | -------- |
| Abaixo de R$ 100     | 0%       |
| De R$ 100 até 499,99 | 1%       |
| A partir de R$ 500   | 5%       |

### 🧮 Funcionalidades do módulo
✔ Lê o arquivo JSON\
✔ Agrupa vendas por vendedor\
✔ Calcula comissão individual por venda\
✔ Soma o total do vendedor\
✔ Gera relatório formatado no console

## 2️⃣ Controle de Estoque com Movimentações

O sistema inicia com produtos importados de um JSON como este:
```json
{
  "estoque": [
    { "codigoProduto": 101, "descricaoProduto": "Caneta Azul", "estoque": 150 }
  ]
}
```

### 📌 O usuário pode:

- Registrar entradas ou saídas de estoque

- Definir uma descrição da movimentação

- Gerar um ID único para cada operação

- Consultar saldo atualizado

- Importar ou cadastrar produtos manualmente

- Ver relatórios simples e detalhados:

- Relatório simples → entradas, saídas e saldo por produto

- Relatório detalhado → cada movimentação listada por ID

## 3️⃣ Cálculo de Juros por Atraso
Dado:
- Valor inicial
- Data de vencimento
- Data atual (automática)

O sistema calcula juros simples aplicando:

✔ Taxa padrão: 2,5% ao dia\
✔ OU taxa personalizada definida pelo usuário

### 🧮 O cálculo exibe:

- Dias em atraso
- Multa aplicada
- Valor final atualizado

## 🧠 Tecnologias Utilizadas
| Camada            | Tecnologias                              |
| ----------------- | ---------------------------------------- |
| Backend (Console) | C#, .NET                                 |
| Armazenamento     | JSON (entrada/importação)                |
| Organização       | Programação Orientada a Objetos          |
| Extras            | LINQ, tratamento de exceções, validações |

## ▶️ Como Rodar o Projeto
### 1️⃣ Clone o repositório
```bash
git clone https://github.com/lucasb15/TesteTecnicoTarget
```
### 2️⃣ Abra no Visual Studio ou VS Code com .NET SDK instalado
### 3️⃣ Execute:
```bash
dotnet run
```

## 🌐 Funcionalidades Extras Implementadas
Além do solicitado no teste, o projeto inclui:

✔ Relatório detalhado de estoque (movimentação por ID)\
✔ IDs únicos gerados automaticamente\
✔ Validações de operação (ex.: não permitir estoque ficar negativo)\
✔ Importação + entrada manual nos módulos 1 e 2\
✔ Taxa de juros ajustável pelo usuário

## 🧑‍💻 Autor

Desenvolvido por: Lucas Gomes Santos\
Desafio Técnico: Target Sistemas