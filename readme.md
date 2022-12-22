Mantenho o projeto para fins de estudo e POC. Aqui você encontra:

- Domain Driven Design;
- Testes unitários com SpecFlow;
- Api Gateway com Ocelot;
- Multitenancy com SassKit;
- EF Core;

Os experimentos serão documentados no meu medium: https://medium.com/@dev.anna.laura.

# Sobre o negócio

O objetivo é criar um sistema de controle de estoque, o sistema será simples mas terá dois atores: administrador e o operador. As interações dos meus atores com o sistema estão explicadas nos casos de uso abaixo:

![Casos de uso](./docs/images/use-case.drawio.png)

## Bounded Context

Com base no comportamento de meus atores, modelei dois Bounded Context's sendo eles o Administration Context e o Stock Context.

![Context map](./docs/images/context-map.drawio.png)

Vamos entender melhor sobre o que cada contexto é responsável:

- Administration Context: responsável pelo cadastro dos produtos e checagem de inventário.
- Stock Context: responsável pelo fluxo de entrada e saída dos produtos.

## Administration Context
Responsável por manter o cadastro dos produtos que o sistema controlará, através desse contexto será possível cadastrar, editar ou excluir produtos e emitir um relatório de status do inventário. Para atender a esses requisitos a modelagem de classes ficou da seguinte maneira:

![Diagrama de classes](./docs/images/adm-context-class.drawio.png)

A sinalização de `aggregate` que você vê acima indica que essas classes são responsáveis pelos principais comportamentos do contexto, ou seja, tudo que é feito ocorre através dela. Para ficar mais claro, veja a imagem abaixo:

![Diagrama de classes](./docs/images/adm-context-class-aggregate.drawio.png)

# Artigos publicados

- [Reflexões sobre o uso de ORM's em domínios complexos](https://medium.com/nddtech/reflex%C3%B5es-sobre-o-uso-de-entity-framework-em-dom%C3%ADnios-complexos-c19d740ca5f2)

