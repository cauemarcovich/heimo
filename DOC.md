# Documentação

Esta documentação está separada em 3 partes:  
[Front](#front)  
[Back](#back)  
[Database](#database)

## Front
### Estrutura

O front está separado em duas estruturas:
- Header.uxml - Template do header
- GarageVisualTree.uxml - Estrutura contendo toda a tela Garage

### Estilização
Há 4 arquivos de estilos:
- Header.uss - estilos usados no header
- GarageStyles.uss - estilos usados na tela garage
- GarageScrollViewStyles.uss - estilos usados no scrollview
- CardStyles.uss - estilos usados no card de item

Obs: diversos estilos precisavam de uma refatoração nos nomes, pois não estão seguindo o BEM. Isso aconteceu pois só lembrei da técnica na metade do projeto.

### CustomControls
Criei algumas classes para servirem como componentes reaproveitáveis:
- Card - card do item no content container
- RarityTag - tag de rarity usada nos cards
- DataButton - classe base usada para botões que seguram informações
    - TabButton - botão usado na barra lateral
    - PreviewButton - botão usado no preview container
    - FilterButton - botão usado como filtro

## Back
O back consiste de uma classe UIController que gerencia o projeto através de outras classes:

--- 
#### TabsContainer
Classe usada para gerenciar a inicialização e comportamento das guias laterais.

#### PreviewContainer
Uma classe similar a TabsContainer, usada para o container de preview.

#### ContentContainer
Classe responsável por controlar os items que aparecem no scrollview usando a tab e filtro selecionados.

---

O UIContainer inicializa as três classes acima e, após isso, todas as interações são executadas através de eventos registrados na inicialização.

O UIController possui acesso aos dados pois tem uma referência do UIItemDatabase.

## Database
Todos os items do jogo foram cadastrados como ScriptableData derivados de ItemData.

Temos um ContentType (também derivado de ScriptableObject) usado para saber de que tipo um item faz parte.

O database consiste em um último scriptable que segura todos os items.

Criei métodos helpers para me ajudar a criar e registrar todos os scriptables no database.

## Extra: PlayerData
Fiz outro mock, além do database, para guardar os items que o usuário está equipado.  
PlayerData consiste em uma classe simples, estática e com um dicionário de items equipados, apenas para ser usada como objeto de teste.