# GerenciarLoja — Sistema de Gerenciamento de Produtos e Estoque

Aplicação de **console desenvolvida em C# com .NET 10** para cadastrar produtos e gerenciar seu estoque e preço por meio de um menu interativo.

O projeto foi criado para praticar **Programação Orientada a Objetos (POO)**, encapsulamento, coleções e a organização básica de uma aplicação em modelos, serviços e interface de usuário.

> **Status:** projeto de estudos. Os dados são armazenados **somente em memória** durante a execução; não há banco de dados nem salvamento em arquivos. É um exercício de fundamentos, não uma aplicação pronta para uso comercial.

## Funcionalidades implementadas

| Recurso | Descrição |
| --- | --- |
| **Cadastrar produtos** | Informar o nome e o preço inicial de um produto. Todo novo produto começa com **estoque igual a zero**. |
| **Consultar produtos** | Listar os produtos cadastrados, exibindo nome, preço e quantidade em estoque. |
| **Adicionar estoque** | Localizar produtos pelo nome e aumentar a quantidade, desde que o valor informado seja positivo. |
| **Remover estoque** | Reduzir a quantidade, desde que seja positiva e não ultrapasse o saldo disponível. |
| **Alterar preço** | Substituir o preço de produtos localizados pelo nome, aceitando apenas preços maiores que zero. |
| **Menu interativo** | Navegar pelas opções e encerrar a aplicação quando desejar. |

As buscas por nome para alteração de estoque e preço **ignoram diferenças entre letras maiúsculas e minúsculas**. Quando há **nomes repetidos**, a operação pode atingir mais de um produto — uma limitação da versão atual.

## Tecnologias utilizadas

- **C#** — linguagem de programação.
- **.NET 10** — plataforma alvo definida no arquivo `.csproj` (`net10.0`).
- **Aplicação console** — interação por `Console.ReadLine()` e `Console.WriteLine()`.
- **`List<Produto>`** — armazenamento dos cadastros na memória enquanto o programa permanece aberto.

Esta versão não utiliza pacotes externos nem banco de dados.

## Como o sistema funciona

1. No menu principal, selecione a opção para **cadastrar um produto**.
2. Informe o **nome** e o **preço**. O estoque inicial será `0`.
3. Cadastre quantos produtos desejar.
4. Utilize as opções para **adicionar ou remover unidades**, **alterar o preço** ou **consultar os produtos**.
5. Selecione a opção de saída para encerrar o programa.

### Opções do menu

```text
=== SISTEMA DE PRODUTOS ===

1 - Cadastrar produto
2 - Adicionar estoque
3 - Remover estoque
4 - Alterar preco
5 - Exibir produto
6 - Sair
```

## Estrutura do projeto

```text
GerenciarLoja/
├── Models/
│   └── Dados.cs              # Classe Produto e regras básicas de estoque/preço
├── Services/
│   └── Sistem.cs             # Lista de produtos, cadastro, buscas e operações
├── UIUX/
│   └── Menu.cs               # Menu interativo e escolha das operações
├── Program.cs                # Inicialização e laço principal da aplicação
├── GerenciarLoja.csproj      # Configuração do projeto (.NET 10)
├── .gitignore                # Ignora arquivos temporários de compilação
└── README.md                 # Documentação
```

A separação em pastas ajuda a localizar as responsabilidades. No entanto, **o serviço `Sistem` ainda lê e escreve diretamente no console**, e os métodos do modelo `Produto` também exibem mensagens. Por isso, a separação entre interface e regras de negócio é **parcial** e pode ser aprimorada.

## Conceitos de programação praticados

### Classes, objetos e construtores

A classe `Produto` representa cada item cadastrado, com **nome**, **preço** e **estoque**. O construtor recebe nome e preço e define o estoque inicial como `0`.

### Encapsulamento

As propriedades `Nome`, `Preco` e `Estoque` possuem `private set`, impedindo a alteração direta por outras classes. As mudanças de estoque e preço passam por métodos como `AdicionarEstoque`, `RemoverEstoque` e `AlterarPreco`.

### Coleções genéricas

O serviço utiliza uma **`List<Produto>`** para manter os produtos em memória e o **`foreach`** para percorrer os itens cadastrados.

### Métodos e regras básicas de negócio

Os métodos da classe `Produto` verificam condições como **quantidade positiva**, **estoque suficiente na remoção** e **novo preço maior que zero**. Algumas entradas do serviço usam `TryParse`, porém a validação ainda é incompleta.

### Estruturas de controle

O menu utiliza `switch` para selecionar operações e `do...while` para manter a aplicação em funcionamento até o usuário escolher sair.

## Como executar

### Pré-requisitos

- **SDK do .NET 10** instalado: [download oficial do .NET](https://dotnet.microsoft.com/download).
- Terminal ou editor compatível com .NET (por exemplo, Visual Studio Code ou Visual Studio).

### Passos

1. Baixe ou clone este repositório e abra um terminal na pasta que contém `GerenciarLoja.csproj`.
2. Execute:

   ```bash
   dotnet run
   ```

   Se estiver na pasta acima do projeto, você também pode utilizar:

   ```bash
   dotnet run --project GerenciarLoja/GerenciarLoja.csproj
   ```

3. Escolha uma opção no menu e siga as instruções exibidas no terminal.

> **Atenção:** como os cadastros ficam apenas em memória, os produtos e as alterações de estoque/preço **são perdidos quando o aplicativo é encerrado**.

## Limitações conhecidas

Estas limitações foram identificadas na implementação atual:

- **Validação de entrada incompleta:** `int.Parse` no menu e `decimal.Parse` no cadastro podem lançar exceções em entradas inválidas e encerrar o programa.
- **Cadastro sem validação de nome e preço:** o construtor `Produto` não impede nome vazio ou preço inicial zero/negativo, apesar de `AlterarPreco` exigir um preço positivo.
- **Nomes duplicados:** não existe ID ou código exclusivo por produto. Como as buscas percorrem toda a lista, vários produtos com o mesmo nome podem ser alterados na mesma operação.
- **Falhas silenciosas:** quantidade inválida, estoque insuficiente ou produto inexistente nem sempre geram mensagens explicativas para o usuário.
- **Sem persistência:** não há salvamento de informações em arquivo ou banco de dados.
- **Separação parcial de responsabilidades:** modelos e serviços ainda usam `Console` diretamente, dificultando testes e uma futura migração para API.
- **Sem testes automatizados:** o comportamento das regras ainda não é verificado por uma suíte de testes.

## Próximas melhorias (roadmap)

Os itens abaixo são **ideias para versões futuras**, não recursos já existentes.

### Curto prazo — qualidade e correções

- [ ] Substituir as conversões diretas por `TryParse` e permitir nova tentativa após entradas inválidas.
- [ ] Validar nome e preço **no momento do cadastro**.
- [ ] Informar claramente quando um produto não for encontrado ou uma operação não puder ser concluída.
- [ ] Adicionar um **ID único** por produto para evitar alterações em vários itens com o mesmo nome.
- [ ] Padronizar a nomenclatura de classes e arquivos (`Sistem` → `SistemaProdutos`, por exemplo) e remover código/comentários não utilizados.

### Médio prazo — arquitetura e funcionalidades

- [ ] Separar a lógica de negócio dos comandos de console, fazendo os métodos retornarem resultados em vez de imprimirem mensagens.
- [ ] Implementar edição de dados do produto e exclusão de cadastros.
- [ ] Criar consulta por ID e filtros de produtos com estoque baixo.
- [ ] Calcular o **valor total do estoque** (`preço × quantidade` de cada produto, somados).
- [ ] Salvar e recuperar dados em **JSON** e posteriormente em banco de dados.
- [ ] Criar testes unitários para as regras de validação e movimentação de estoque.

### Longo prazo — evolução para back-end

- [ ] Migrar as funcionalidades para uma **API REST com ASP.NET Core**.
- [ ] Utilizar **Entity Framework Core** e um banco de dados relacional.
- [ ] Adicionar endpoints de cadastro, consulta, atualização, exclusão e movimentações de estoque.
- [ ] Registrar um histórico de entradas e saídas para permitir auditoria das movimentações.

## Objetivo do projeto

Este repositório registra uma etapa do meu aprendizado em **C# e desenvolvimento de software**: transformar conceitos estudados em um programa funcional, com classes, métodos e regras simples de negócio.

É um projeto inicial de **gestão de produtos e estoque**, que pode evoluir gradualmente para uma aplicação back-end mais robusta conforme novos conceitos forem aprendidos.
