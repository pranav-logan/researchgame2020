# researchgame2020
Source code for a Unity game that was done as part of the TAMS summer research program in 2020.

Concept & Goal-
The game has the user create a path from a sensor (starting point) to a reciever (end point). 
These two elements are seperated by many cores (computational blocks), and the user must position
what direction these cores face in order to form the proper pathing. Sensors send out numbers one at
a time, and the receiver expects a certain input to complete the level. Cores modify the inputs they are 
given and as such, the user must find out what cores to utilize in order to get the right output value
to the receiver.


Controls-
Arrow keys or WASD: Moves camera around the scene
Left click: Changes direction of the core being clicked on
Right click: Shows info about the core being clicked on
Ctrl key: Hides all wires
Tab key: Hides all core colors (makes them transparent)
Enter key: Hides all unmodified transfer (gray) cores and pre-selected cores
Space key: Intitiates data flow, cause all applicable cores and sensors to fire
P key: Changes behavior of selected core (only on cores marked with a black box)

