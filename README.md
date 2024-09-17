# Projeto de controle de estoque utilizando padrão Strategy , Factory Method, TDD e reflection.

 Esse projeto foi feito com o intuito de treinar meus conhecimentos em design patterns, TDD e explorar o conceito de reflection no C#. Ele foi feito a partir de um projeto anterior, mas de uma forma simplificada para manter o foco nos aprendizados propostos para o projeto.


## Padrão Strategy


### O que é?

O padrão Strategy é um Design Pattern que visa resolver um problema comportamental na orientação a objetos. Ele é útil quando temos uma classe que realiza um conjunto de tarefas de diferentes maneiras, dependendo de determinadas condições. Em vez de implementar múltiplas variações do algoritmo na própria classe, o padrão Strategy delega essas variações para classes específicas chamadas "estratégias".

### Como funciona?
 
A classe principal (conhecida como "contexto") possui uma referência para uma das estratégias e delega a ela o trabalho necessário. Isso torna o código mais flexível e fácil de estender, já que novas estratégias podem ser adicionadas sem modificar o código do contexto.
 
### De que forma foi aplicado?

O padrão Strategy foi aplicado na lógica de inserção e remoção de itens no estoque a partir de um lote. A lógica de entrada e saída de produtos ficou concentrada na entidade lote (Batch), onde o lote possui um tipo, que pode ser de entrada ou de saída. Dependendo do tipo do lote, a criação de um lote passava por processamentos e validações diferentes.

Para isso, foi criada a classe de contexto BatchProcessingStrategyFactory, que decide qual serviço de processamento utilizar com base no tipo do lote (representado por um enum). Se o lote for de entrada, o contexto delega o processamento para a estratégia de processamento de entrada; se for de saída, para a estratégia de processamento de saída. Dessa forma, o padrão Strategy separa as lógicas de entrada e saída, permitindo que no futuro, caso necessário, sejam adicionadas novas estratégias sem que o código anterior seja modificado. Isso garante inclusive um dos princípios do SOLID, o Open Closed Principle, que diz que uma classe deve estar aberta para extensão e fechada para modificação.

  
## Padrão Factory Method


### O que é?

O padrão Factory Method é um Design Pattern que resolve problemas relacionados à criação de objetos. Ele é útil quando a criação de um objeto se torna complexa devido a muitos atributos e condições específicas. Nesse caso, é difícil gerenciar todos os comportamentos na construção do objeto dentro da própria classe. O padrão sugere delegar a lógica de criação para uma classe especializada, chamada de fábrica, que pode ser estendida ou alterada conforme necessário. Dessa forma, você pode substituir o método de criação em subclasses, facilitando a mudança da classe de produtos que estão sendo criados pelo método.

### Como funciona?

O Factory Method trabalha criando uma interface ou uma classe abstrata que define um método para criar objetos. As subclasses então implementam esse método para especificar a lógica de criação do objeto. Isso permite que a lógica de criação de objetos seja encapsulada em uma classe separada (a fábrica), em vez de estar espalhada por todo o código da aplicação. Isso reduz a dependência direta da aplicação nos objetos específicos, tornando o código mais flexível e aberto para extensão.

A principal vantagem é que, ao usar o Factory Method, você não precisa instanciar objetos diretamente usando o operador new, mas sim chamar o método da fábrica. Dessa forma, a lógica para determinar qual objeto deve ser criado é centralizada, facilitando futuras expansões ou alterações.
 
### De que forma foi aplicado?

No projeto, o Factory Method foi aplicado na criação de lotes (Batch), que são os objetos mais complexos da API. A lógica de entrada e saída de produtos no estoque está concentrada nos lotes, e dependendo do tipo de lote (entrada ou saída), algumas propriedades podem ser nulas. Por exemplo, lotes de saída não possuem preço ou data de validade, enquanto lotes de entrada possuem.

Com isso, a criação de um lote envolve diferentes condições e comportamentos que poderiam se tornar ainda mais complexos se novos atributos ou tipos de lotes fossem adicionados no futuro. Para evitar essa complexidade e facilitar a manutenção do código, foi criada a classe BatchFactory.

A BatchFactory possui um método que encapsula a lógica de criação do lote, definindo os atributos padrão e aplicando as condições adequadas, dependendo do tipo de lote inserido. Isso simplifica o processo de criação, centraliza a lógica em um único lugar e facilita futuras extensões, pois a lógica de criação está isolada dentro da fábrica. Dessa forma, é garantido um dos princípios do SOLID, o Open Closed Principle, e também o Single Responsibility Principle, já que ele separa a responsabilidade de criação de objetos do resto da aplicação, mantendo a lógica de construção em uma classe dedicada (a fábrica).

## TDD ( Test-driven development)

  
###  O que é?

Test-Driven Development (TDD) é uma prática de desenvolvimento de software que se concentra em escrever testes automatizados antes de implementar o código em si. No TDD, o processo de desenvolvimento segue um ciclo específico: primeiro, escreve-se um teste para a funcionalidade desejada; em seguida, implementa-se o código necessário para passar no teste; por último, refatora-se o código para melhorar sua qualidade, sempre garantindo que os testes continuem a passar.

###  Qual seu propósito?

O TDD ajuda a garantir que o código atenda aos requisitos esperados desde o início. Escrever os testes primeiro incentiva a pensar no comportamento do software e como ele deve ser estruturado, evitando complexidade desnecessária.

###  Aplicação no Projeto

No projeto, o TDD foi utilizado nos testes de serviço do lote. Antes de implementar a lógica dos serviços de entrada e saída de lotes, foram escritos testes unitários que cobrem os principais cenários. Isso ajudou a guiar a implementação das funcionalidades.

Durante o desenvolvimento do código, os testes trouxeram insights valiosos. Por exemplo, tornou-se evidente que a adição de uma interface à classe BatchProcessingStrategyFactory facilitaria o processo de teste e promoveria a aderência ao Princípio da Inversão de Dependência (Dependency Inversion Principle - DIP) do SOLID. Inicialmente, a classe BatchProcessingStrategyFactory não possuía uma interface, tornando seu método GetStrategy não sobrescrevível, o que dificultava a testagem. Além disso, qualquer classe que dependesse diretamente dessa fábrica estaria acoplada à sua implementação concreta, em vez de depender de uma abstração.

O princípio DIP diz que módulos de alto nível não devem depender de módulos de baixo nível, e que ambos devem depender de abstrações. Essa relação de dependência invertida promove flexibilidade, estabilidade e capacidade de manutenção

Graças aos testes unitários utilizando TDD, pude prestar atenção nos detalhes de implementação na etapa de refatoração, o que tornou inclusive os testes mais limpos, e não apenas o código.

  
## Reflection

  
### O que é?

Reflection é um recurso da linguagem C# que permite inspecionar e interagir com os tipos, métodos, propriedades e outros membros de objetos e assemblies em tempo de execução. Com reflection, é possível acessar informações sobre classes e suas propriedades, invocar métodos, criar instâncias de objetos, e até modificar comportamento durante a execução do programa.

### Como foi utilizado no projeto?

No projeto, a reflection foi utilizada para criar um mapper genérico que converte uma instância de um tipo de objeto para outro. Este mapper foi desenvolvido com o objetivo de praticar conceitos avançados como o uso de reflection, e proporcionar um meio flexível de transformar objetos, especialmente para a conversão entre entidades e Data Transfer Objects (DTOs). 

### O que a classe Mapper faz?

O mapper genérico desenvolvido utiliza reflection para:

* **Mapear propriedades**: Ele identifica as propriedades que possuem o mesmo nome nos dois tipos (origem e destino) e as armazena em um cache para uso posterior.

* **Copiar valores**: Para cada propriedade correspondente, o mapper utiliza os métodos get e set para copiar os valores da instância de origem para a instância de destino.

* **Tratar propriedades complexas**: Quando o tipo de uma propriedade é uma coleção (IEnumerable), ele itera sobre os itens da coleção original, cria instâncias da coleção de destino e chama o método Map recursivamente para cada item.

* **Lidar com tipos personalizados**: Para propriedades que são classes e não são do tipo primitivo ou string, ele chama o método Map recursivamente, mapeando as propriedades aninhadas.

* **Manter cache para otimização** : O método PopulateCacheKey armazena os métodos get e set das propriedades em um cache para evitar o uso repetido de reflection, melhorando a performance nas chamadas subsequentes.