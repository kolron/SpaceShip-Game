# Spaceship Game - improvments!

This game is an improvment (or addition) to the base game provided [here](https://github.com/gamedev-at-ariel/02-prefabs-triggers), A 2D Shooter game, where your goal is to avoid and destroy enemy spacecrafts.

The game uses the following:
* Prefabs for instantiating new objects;
* Colliders for triggering outcomes of actions;
* Coroutines for setting time-based rules.

## In regards to the task

I chose to add the following elements to the task:
1) Added some Powerups! Look for the dropping Powerups and catch them to boost your Character! [Go to script](https://github.com/kolron/SpaceShip-Game/blob/main/Assets/Scripts/3-collisions/PickupPowerup.cs)

2) Added a cooldown between shots, enabling players to fire by also holding Spacebar (not just clicking)
3) Added a Cannon Power-up - Pick it up to improve your attack! [Go to script for points 2 and 3](https://github.com/kolron/SpaceShip-Game/blob/main/Assets/Scripts/2-spawners/LaserShooter.cs)
4) Added a Shield Power-up - Pick up the shield to destroy any spaceships you come in contact with! Make sure to notice when it fades away! [Go to script](https://github.com/kolron/SpaceShip-Game/blob/main/Assets/Scripts/2-spawners/ShieldSpawner.cs)
5) Added a Mine Power-up - Store mines in your inventory and place them in the map for extra points! [Go to script](https://github.com/kolron/SpaceShip-Game/blob/main/Assets/Scripts/2-spawners/MineSpawner.cs) (This part is my addition to the game, aside from what was needed)

I added the following scripts:
* [PickupPowerup](https://github.com/kolron/SpaceShip-Game/blob/main/Assets/Scripts/3-collisions/PickupPowerup.cs)
* [MineSpawner](https://github.com/kolron/SpaceShip-Game/blob/main/Assets/Scripts/2-spawners/MineSpawner.cs)
* [ShieldSpawner](https://github.com/kolron/SpaceShip-Game/blob/main/Assets/Scripts/2-spawners/ShieldSpawner.cs)
* [Pulser](https://github.com/kolron/SpaceShip-Game/blob/main/Assets/Scripts/1-movers/Pulser.cs)
* [WallCollider](https://github.com/kolron/SpaceShip-Game/blob/main/Assets/Scripts/3-collisions/WallCollider.cs)

I modified the following scripts:
* [LaserShooter](https://github.com/kolron/SpaceShip-Game/blob/main/Assets/Scripts/2-spawners/LaserShooter.cs)
* [DestroyOnTrigger](https://github.com/kolron/SpaceShip-Game/blob/main/Assets/Scripts/3-collisions/DestroyOnTrigger2D.cs)

I also removed some scripts which I found to be too messy for a project this size.


## Controls
* WASD or Arrow keys to move
* Spacebar to fire
* F to place mines



## Credits

Programming:
* Maoz Grossman
* Erel Segal-Halevi

Online courses:
* [The Ultimate Guide to Game Development with Unity 2019](https://www.udemy.com/the-ultimate-guide-to-game-development-with-unity/), by Jonathan Weinberger

Graphics:
* [Matt Whitehead](https://ccsearch.creativecommons.org/photos/7fd4a37b-8d1a-4d4c-80a2-4ca4a3839941)
* [Kenney's space kit](https://kenney.nl/assets/space-kit)
* [Ductman's 2D Animated Spacehips](https://assetstore.unity.com/packages/2d/characters/2d-animated-spaceships-96852)
* [Franc from the Noun Project](https://commons.wikimedia.org/w/index.php?curid=64661575)
* [Greek-arrow-animated.gif by Andrikkos is licensed under CC BY-SA 3.0](https://search.creativecommons.org/photos/2db102af-80d0-4ec8-9171-1ac77d2565ce)
* pngs I added are not licensed.
