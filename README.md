# Night Shift

## SPRINT 1 (25/02)

- Cachorro seleciona objeto para interagir
	1. Objetos: Plano, cubos para interação e placeholder para o cachorro
	2. Cada cubo é um ponto de interesse.
	3. Escolha aleatória entre pontos de interesse
- Cachorro se move pelo mapa (https://www.youtube.com/watch?v=atCOd4o7tG4)
	1. Pathfinding até ponto de interesse (!! Parte mais importante)
	2. Precisamos que o cachorro OU encoste no objeto OU esteja a uma distância que queremos
- Cachorro interage com objeto
	1. A partir do ponto 2 do último tópico, precisamos setar uma propriedade no cubo
	   (false->true ou vice-versa) e setar um timer (temporário) para que essa propriedade volte ao estado
	   original.
	2. Voltamos ao primeiro ponto da Sprint, e temos um loop infinito.