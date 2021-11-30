# Dodge or Die

### 1. The Game
[**Dodge or Die**](https://frobros.itch.io/dodge-or-die) is a local 2-Player game in which you control the ball, as soon as it enters your opponents side of the field.
You loose control over the ball, when the ball hits the back of the wall or crosses the middle line back to your own side.
When a player is hit by the ball, his/her side of the field shrinks.
**Goal of the game** is to hit the opponent with the ball, until he has no more space left to move.

#### Controls

| Action | Player 1 (left) | Player 2 (right) | 
| :---: | :---: | :---: | 
| Move | WASD | Arrow Keys |



### 2. Mini Jam 86: Sports
The game was developed as part of the [Mini Jam 86: Sports](https://itch.io/jam/mini-jam-86-sports).
The Game Jam's theme was sports and its limitations were **"No Stopping"**.
We fullfilled the limitations by implementing a Dodge Ball Game with a Ball that never stops and keeps accellerating while the match progresses.

### 3. Project Structure

Open the project folder using Unity 2021.1.15f1.

If not already present install the following packages:
- Universal Renderpipeline
- Input System
- MasterAudio

The project's default build target is WebGL.

In order to make prefabs, scripts, materials, textures, and other game components easy to find, they are located _where they live_, meaning folders declare the containing files' scope.

**Example:**
All files concerning the ball object are located in the folder `./Assets/_GameComponents/InGame/Ball/`:

```
.
├── Assets
├──── ...
├──── _GameComponents
├────── ...
├────── InGame
├──────── Ball
├────────── \_materials
├──────────── \_textures
├────────────── ball_player.png
├────────────── ball_player_none.mat
├──────────── ball_player_1.mat
├──────────── ball_player_2.mat
├──────────── ball_player_both.mat
├──────────── ball_player_none.mat
├────────── Ball.cs
├────────── Ball.physicsMaterial2D
├────────── Ball.prefab
├──────── ...
├────── ...
```

Note that all textures are located within the `\_materials` folder, since they are only consumed by the ball's material.
