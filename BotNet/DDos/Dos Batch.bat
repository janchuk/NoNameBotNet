@echo off
 
rem Faire Ctrl+C ou fermer l'invite de commandes
rem pour quitter la boucle
 
:debut_boucle
rem -n 1 : ne pinguer qu'une fois
ping lemonde.fr /w 1 /t /l 1000 >> C:\Dos.txt
 
goto debut_boucle


