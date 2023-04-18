# Towers-Of-Hanoi

The Tower of Hanoi or simply pyramid puzzle is a mathematical game or puzzle consisting of three rods and a number of disks of various diameters, which can slide onto any rod. The puzzle begins with the disks stacked on one rod in order of decreasing size, the smallest at the top, thus approximating a conical shape. The objective of the puzzle is to move the entire stack to the last rod, obeying the following rules:

-Only one disk may be moved at a time.
-Each move consists of taking the upper disk from one of the stacks and placing it on top of another stack or on an empty rod.
-No disk may be placed on top of a disk that is smaller than it.
*Wikipedia*

This game uses object orientated principles to create objects for Disk, Pole and the platform.
Pole object stores Disk objects in a stack to allow for pop() and push().
This allowed for creating a game that lets the player choose the number of disks they are playing with.
Added an indicator that lets the player know when they have made an invalid move.
Added an indicator that shows the selected Disk.
