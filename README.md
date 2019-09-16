# Planets-game
For own scripts, which already in-game use.

In this game you should protect planets from collision of each over by drag them away.

Here is list of all scripts, which used in game:
1) DragAndDrop
2) Menu
3) RandomPatrol
4) Mover
5) Rotator

1. DragAndDrop script.
This script allows to move game objects (planets) through scene. In this script we deside what exaxtly happens with objects, which we touch
in every touch moment (touch, drag, drop). Here is public vars from it:
- selectionEggect. You must plase essect, which you want to appers once, then you choose obj by tour finger
- deathEffect. Here must be death effect. Appers, then obj collides

2. Menu script
This one aloows to conrol game scenes and UI in game event. Contains methods to return, restart and backMenu in game. Public  vars:
- RestartPannel. Place here UI pannel, which appers, then Game is over (planets collide)
- score. Here place UI text, which would show player score

3. RandomPatrol
Allows obj (to which one this script would be added) to move random in specified area and chenge speed of motion by increasing difficulty.
Contains this public vars:
- minX. Minimum X axis coordinate of area in which obj (planet) can move.
- maxX. Maximum X axis coordinate of area in which obj (planet) can move.
- minY. Minimum Y axis coordinate of area in which obj (planet) can move.
- maxY. Maximum Y axis coordinate of area in which obj (planet) can move.
- speed. Speed of motion
- seondsToMaxDif. Seconds, when speed going to achive max speed
- minSpeed. Min speed of motion
- maxSpeed. Max speed of motion

4. Rotator & Mover script
Alomost useless scripts. I used it only in main menu to add some movemet of background. All this things should be idle animation. It's 
easyer and more simple. Includes this public vars:
- speed (rotator file). Speed of rotation by Z axis.
- speed (Mover file). Speed of move
- lPos, rPos (Mover file). Should contain 2 obj, which coordinates are using of area. In this obj can move 
(x min, x max of point uses only).
