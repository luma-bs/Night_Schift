# Night Shift

## SPRINT 2 (11/03)

### O que será necessário:
	- Novo GameObject: Guarda noturno

### Observações:
	- O cachorro precisa se movimentar mais devagar para que seja possível arrumar todas as coisas antes do término da noite
	- Seria bom começar a modelar os personagens e os objetos do museu e fazer as animações respectivas

1. Movimentação do guarda
	1. [X] Objetos: Guarda
	2. [ ] Script: Movimentação através do teclado
2. Interação com objetos
	1. [ ] Mesma interação que a do cachorro, mas invertida
3. Cronômetro de tempo para a duração da noite
	1. [ ] Criar uma caixa de texto para exibir o cronômetro
	2. [ ] Criar o script do cronômetro, precisa estar em segundos


## SPRINT 1 (25/02)

1. Cachorro seleciona objeto para interagir
	1. [X] Objetos: Plano, cubos para interação e placeholder para o cachorro
	2. [X] Cada cubo é um ponto de interesse
	3. [X] Escolha aleatória entre pontos de interesse
2. Cachorro se move pelo mapa (https://www.youtube.com/watch?v=atCOd4o7tG4)
	1. [X] Pathfinding até ponto de interesse (!! Parte mais importante)
	2. [X] Precisamos que o cachorro OU encoste no objeto OU esteja a uma distância que queremos
3. Cachorro interage com objeto
	1. [X] A partir do ponto 2 do último tópico, precisamos setar uma propriedade no cubo
	   (false->true ou vice-versa) e setar um timer (temporário) para que essa propriedade volte ao estado
	   original
	2. [X] Voltamos ao primeiro ponto da Sprint, e temos um loop infinito