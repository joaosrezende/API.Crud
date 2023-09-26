## Api.Crud
## Requisitos
Para executar o projeto, certifique-se de que seu ambiente de desenvolvimento atenda aos seguintes requisitos:
- Node.js
- SQL Server
- Angular CLI:

## Configurando o Ambiente
Para configurar o ambiente corretamente, siga os passos abaixo:

Utilize migrations para manter o banco de dados sincronizado com as mudanças de código. Execute o comando a seguir para criar uma migração inicial:

add-migrations "Initial" -verbose
Esse comando garantirá que o banco de dados esteja alinhado com a estrutura de dados do projeto.

## Observações Finais
O projeto Api.Crud foi desenvolvido em aproximadamente 5 horas, com um foco principal na criação de uma estrutura sólida baseada no modelo Clean Architecture e na implementação de alguns padrões de design preferenciais. Vale ressaltar que, em um ambiente de produção real, as validações e a qualidade do código seriam muito mais rigorosas.

É importante notar que o projeto inclui um relacionamento muitos-para-muitos entre "Cliente" e "Produto" no back-end, mas atualmente, apenas o cadastro de clientes é utilizado no front-end. A funcionalidade de relacionamento está totalmente funcional no back-end.

O objetivo principal deste projeto foi estabelecer uma estrutura sólida e escalável para futuras expansões e melhorias.
