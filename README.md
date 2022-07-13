# Zapoctak-Csharp
This project contains my credit program for subjects NPRG035, NPRG038 and NPRG064
## Specification
### Game description
This project will be a simple remake of well-known game called Ships.
The game is played by two players. Each one puts his ships in 10x10 square grid.
Important is that these ships can only touch with their corners and their position is hidden to the opponent.
There is one ship four squares long, two three squares long,
three two squares long and four ships one square long.
Players then take turns shooting on squares by randomly picking them and trying to sink each others ships.
The game ends when one of the players looses all of his ships.
### Game realisation
My implementation will support game of two players on their own machines.
One of the machines will act as host and the other one as client.
Application on the host machine will run http server and handle the whole game logic
while application on the client machine will only display current game state and send requests to the server.
The displaying to the player should be implemented by some sort of UI framework like WinFroms or WPF.


