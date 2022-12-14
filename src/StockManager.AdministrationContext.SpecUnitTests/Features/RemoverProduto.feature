Feature: RemoverProduto

A short summary of the feature

@Produtos
Scenario: Remover produto ativo
	Given o produto está ativo
	And há 0 itens em inventário
	When remover o produto
	Then remover com sucesso

Scenario: Remover produto ativo com itens no inventário
	Given o produto está ativo
	And há 3 itens em inventário
	When remover o produto
	Then não deve permitir a remoção

Scenario: Remover produto ativo com itens no inventário
	Given o produto está ativo
	And há 3 itens em inventário
	When remover o produto
	Then não deve permitir a remoção

Scenario: Remover produto inativo
	Given o produto está inativo
	When remover o produto
	Then não deve permitir a remoção
