# Unity Setup

## 1. Criar o projeto

1. Abra o Unity Hub.
2. Clique em `New project`.
3. Escolha o template `3D`.
4. Use o nome `DriftLab`.
5. Se quiser aproveitar esta base direto, selecione esta pasta como destino do projeto.

## 2. Estrutura da cena inicial

1. Crie um `Plane` para o solo.
2. Crie alguns `Cube` como ilha ou obstaculos.
3. Crie uma `Capsule` chamada `Player`.
4. Marque a tag do player como `Player`.
5. Adicione um `Rigidbody` ao player e congele a rotacao em `X` e `Z`.

## 3. Scripts do prototipo

1. Adicione `PlayerMovement` ao objeto `Player`.
2. Adicione `InventorySystem` ao objeto `Player`.
3. Adicione `SurvivalStats` ao objeto `Player`.
2. Crie pequenos cubos para itens coletaveis.
3. Marque o `Box Collider` dos itens como `Is Trigger`.
4. Adicione `CollectItem` aos itens.
5. Em cada item, ajuste `Item Id` para algo como `Water`, `Charcoal` ou `Food`.
6. Crie um objeto vazio `CraftManager` e adicione `CraftSystem`.
7. Arraste o objeto `Player` para o campo `Inventory System` do `CraftSystem`.

## 4. UI simples

1. Crie um `Canvas`.
2. Dentro dele, crie quatro `UI > Text`.
3. Renomeie para `ItemText`, `InventoryText`, `HungerText` e `ThirstText`.
4. Ajuste os textos iniciais como preferir.
5. Crie um objeto vazio `GameUI`.
6. Adicione `ItemCounter`, `InventoryUI` e `SurvivalUI` ao `GameUI`.
7. Arraste `ItemText` para `ItemCounter`.
8. Arraste `InventoryText` e o objeto `Player` para `InventoryUI`.
9. Arraste `HungerText`, `ThirstText` e o objeto `Player` para `SurvivalUI`.

## 5. Teste rapido

1. Clique em `Play`.
2. Mova com `W`, `A`, `S`, `D`.
3. Encoste nos itens.
4. Confirme se o contador sobe, o inventario atualiza e os itens desaparecem.
5. Observe fome e sede diminuindo com o tempo.

## 6. Proximo passo recomendado

- Trocar o movimento por `CharacterController`
- Adicionar consumo de comida e agua
- Criar tela de crafting com botoes
- Salvar progresso basico

## 7. Sistemas novos ja preparados

Os scripts abaixo ja deixam a base pronta para a proxima etapa:

- `CharacterDefinition`: dados de personagem
- `CustomizationOption`: dados de roupa/cor
- `PlayerProfile`: personagem e roupa selecionados
- `MissionDefinition`: dados de missao
- `MissionSystem`: validacao e conclusao de missao
- `PlayerProfileUI`: texto simples para exibir personagem e roupa

## 8. Lobby e selecao de personagem

1. Crie um objeto vazio `UnlockDatabase`.
2. Adicione o script `UnlockDatabase`.
3. Crie `ScriptableObjects` de personagens com `Create > DriftLab > Character Definition`.
4. Crie `ScriptableObjects` de roupas com `Create > DriftLab > Customization Option`.
5. No objeto `Player`, adicione `PlayerProfile`.
6. Preencha listas de personagens e roupas no `PlayerProfile`.
7. Crie um objeto vazio `MissionManager` com `MissionSystem`.
8. Arraste `InventorySystem` do player e `UnlockDatabase` para o `MissionSystem`.
9. Dentro do `Canvas`, crie textos para `CharacterOptionsText`, `OutfitOptionsText`, `RoomNameText` e `PlayerCountText`.
10. No `GameUI`, adicione `CharacterSelectionUI`, `OutfitSelectionUI`, `PlayerProfileUI` e `LobbyUI`.
11. Ligue as referencias no Inspector.
12. Se quiser usar botoes, crie botoes de UI e aponte para `SelectCharacterByIndex()` e `SelectOutfitByIndex()`.

## 9. Tela inicial e roupa visual

1. No objeto visual do player, adicione `CharacterVisualController`.
2. Arraste o `PlayerProfile` para esse script.
3. Separe os `Renderer` que devem usar cor principal e secundaria.
4. Crie tres paineis no `Canvas`: `TitlePanel`, `LobbyPanel` e `CustomizationPanel`.
5. Adicione `TitleScreenUI` em um objeto `MenuManager`.
6. Arraste os tres paineis para o `TitleScreenUI`.
7. Crie botoes para `ShowTitle()`, `ShowLobby()` e `ShowCustomization()`.
8. Se quiser um resumo da selecao atual, adicione `MainMenuStatusUI` ao `GameUI` e ligue um `Text`.
