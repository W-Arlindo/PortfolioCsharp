# Sistema de Gerenciamento de Pedidos

Projeto de aplicação **console em C# e .NET 10** para gerenciar clientes, produtos e pedidos, com um fluxo de finalização de compras e simulação de pagamento via Pix ou cartão.

O projeto foi desenvolvido para praticar **programação orientada a objetos (POO)**, organização de código e a divisão de responsabilidades entre modelos, serviços e interface de usuário.

> **Status:** projeto de estudos em evolução. Os pagamentos são **simulados** e os cadastros são mantidos **em memória**, sem banco de dados.

## Funcionalidades

| Área | Funcionalidades implementadas |
| --- | --- |
| **Clientes** | Cadastrar, listar e localizar clientes pelo ID. |
| **Produtos** | Cadastrar, listar e localizar produtos pelo ID. |
| **Pedidos** | Criar pedidos vinculando um cliente e um produto, informar a quantidade e calcular o total automaticamente. |
| **Consulta** | Listar os pedidos com número, cliente, produto, quantidade e valor total. |
| **Pagamento** | Escolher entre Pix e cartão e exibir uma confirmação **simulada**. |
| **Finalização** | Marcar o pedido como compra realizada e impedir uma segunda finalização do mesmo pedido durante a execução. |
| **Validações** | Rejeitar IDs, preços e quantidades não positivos e nomes vazios ou compostos apenas por espaços. |

**Observação:** cada pedido contém **um único produto** e sua quantidade. Ainda não há carrinho com vários itens, cobrança real, edição, exclusão nem persistência de dados.

## Tecnologias

- **C#** — linguagem principal.
- **.NET 10** — plataforma utilizada no projeto (`net10.0`).
- **Aplicação de console** — interface com menus e entrada de dados pelo terminal.
- **`List<T>`** — armazenamento temporário de clientes, produtos e pedidos.

Não são utilizadas bibliotecas externas ou banco de dados nesta versão.

## Como o sistema funciona

1. O usuário cadastra um **cliente** informando ID, nome e e-mail.
2. Cadastra um **produto** informando ID, nome e preço.
3. Cria um **pedido**, selecionando os IDs do cliente e do produto e informando a quantidade.
4. O sistema calcula o total com a regra **`preço × quantidade`**.
5. O usuário pode listar os pedidos e escolher um deles para finalizar.
6. Na finalização, seleciona **Pix** ou **cartão**; o programa exibe a confirmação simulada e marca o pedido como concluído.

### Opções do menu

```text
1 - Cadastrar cliente
2 - Listar clientes
3 - Cadastrar produto
4 - Listar produtos
5 - Criar pedido
6 - Listar pedidos
7 - Finalizar pedido
0 - Sair
```

## Estrutura do projeto

```text
SistemaPedidos/
├── Models/
│   ├── Dados.cs             # Cliente, Produto e Pedido
│   └── Interface.cs         # IPagamento e IFalha
├── Services/
│   ├── Pagamentos.cs        # Simulações de Pix e Cartão
│   ├── SistemaCliente.cs    # Cadastro, listagem e busca de clientes
│   ├── SistemProduto.cs     # Cadastro, listagem e busca de produtos
│   └── SistemaPedido.cs     # Criação, listagem e finalização de pedidos
├── UI/
│   └── Menu.cs              # Menu principal e leitura dos dados
├── Program.cs               # Ponto de entrada
└── SistemaPedidos.csproj    # Configuração do projeto (.NET 10)
```

A separação em pastas ajuda a identificar as responsabilidades do programa. **Ainda há dependência entre serviços e código de entrada do console**, algo que pode ser melhorado com uma arquitetura em camadas mais definida.

## Conceitos de C# praticados

- **Classes e objetos:** representações de `Cliente`, `Produto` e `Pedido`.
- **Encapsulamento:** propriedades com `private set` para controlar alterações externas.
- **Construtores e validações:** conferência de dados ao criar objetos.
- **Interfaces e implementações:** `IPagamento` define `Pagar(decimal valor)`, implementado por `Pix` e `Cartao`; `IFalha` define mensagens de falha nos modelos. O fluxo de pagamento ainda pode ser refatorado para usar a interface de forma polimórfica.
- **Associação entre objetos:** `Pedido` referencia instâncias de `Cliente` e `Produto`, que são cadastradas independentemente.
- **Coleções genéricas:** listas (`List<T>`) mantêm os dados durante a execução.
- **Tratamento de situações inválidas:** uso de exceções como `ArgumentException` e `InvalidOperationException` (a interface do console ainda precisa tratá-las adequadamente).
- **Passagem de dependências pelo construtor:** `SistemaPedidos` recebe os serviços de clientes e produtos, reutilizando os mesmos cadastros do menu.
- **Separação de responsabilidades:** código distribuído entre `Models`, `Services` e `UI`.

## Executando o projeto

### Pré-requisito

Instale o **SDK do .NET 10**: [dotnet.microsoft.com/download](https://dotnet.microsoft.com/download).

### Passo a passo

1. Clone o repositório:

   ```bash
   git clone https://github.com/SEU-USUARIO/SEU-REPOSITORIO.git
   ```

2. Entre na pasta onde está o arquivo `SistemaPedidos.csproj`:

   ```bash
   cd SEU-REPOSITORIO
   ```

3. Execute o projeto:

   ```bash
   dotnet run
   ```

Também é possível abrir a pasta no **Visual Studio** ou **Visual Studio Code**, com o SDK do .NET instalado.

> Substitua `SEU-USUARIO/SEU-REPOSITORIO` pelo endereço real do seu repositório. Dependendo de como os arquivos forem publicados, talvez seja necessário entrar também na subpasta `SistemaPedidos` antes de executar o comando.

## Regras atuais e limitações conhecidas

- IDs, preço e quantidade precisam ser maiores que zero; os nomes não podem estar em branco.
- O e-mail não pode ser vazio, mas **o formato do endereço ainda não é validado**.
- Ainda **não existe verificação de IDs ou números de pedidos duplicados**.
- Entradas inválidas no menu (`int.Parse` e `decimal.Parse`) podem gerar exceções e interromper a execução; buscas sem resultado também lançam exceções não tratadas na interface.
- O estado dos cadastros e pagamentos **é perdido quando o programa é encerrado**; a listagem de pedidos também não exibe o status de pagamento.
- Cada pedido possui somente um produto. Não há estoque, controle de usuário, testes automatizados ou pagamentos integrados a provedores externos.
- O pagamento é uma mensagem exibida no console: **nenhuma transação financeira é realizada**.

## Próximas melhorias (roadmap)

Estas são **ideias para versões futuras**, não funcionalidades já implementadas.

- [ ] **Prioridade 1 — Robustez:** usar `TryParse` e tratar exceções no menu, permitindo corrigir entradas sem encerrar o programa.
- [ ] **Prioridade 1 — Regras de negócio:** impedir IDs e números de pedido duplicados, validar e-mails e mensagens de erro mais claras.
- [ ] **Prioridade 1 — Organização:** padronizar nomes (`SistemaProduto`, `SistemaCliente`, etc.) e separar a lógica de negócio da leitura/escrita no console.
- [ ] **Prioridade 2 — Modelo de pedidos:** permitir vários produtos por pedido com uma classe `ItemPedido` e somar os subtotais.
- [ ] **Prioridade 2 — Persistência:** salvar e recuperar dados, começando por arquivos JSON e evoluindo para banco de dados com Entity Framework Core.
- [ ] **Prioridade 2 — Qualidade:** criar testes automatizados para cálculos, validações e finalização de pedidos.
- [ ] **Prioridade 3 — Back-end:** evoluir o projeto para uma **API REST com ASP.NET Core**, com endpoints de clientes, produtos e pedidos.
- [ ] **Prioridade 3 — Pagamentos:** separar a simulação da confirmação de pagamento e implementar fluxos de aprovação/falha antes de considerar integrações reais.

## Objetivo de aprendizado

Este repositório registra minha evolução em **C# e desenvolvimento back-end com .NET**. A proposta é construir um sistema simples, aplicar os fundamentos da linguagem e refatorá-lo gradualmente à medida que aprendo arquitetura, testes, persistência e APIs.

---

**Projeto educacional:** criado para estudo e prática de programação. Não é destinado ao processamento de compras reais.
