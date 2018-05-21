DROP DATABASE IF EXISTS botnet;
CREATE DATABASE IF NOT EXISTS botnet;

use botnet;

CREATE TABLE IF NOT EXISTS `zombies` (
  `id` int(1) NOT NULL AUTO_INCREMENT,
  `ip` varchar(40) NOT NULL,
  `port` int(6) NOT NULL,
  `os` varchar(300),
  `machine_name` varchar(500),
  `user_session` varchar(150),
  `infection_date` DATETIME,
  `last_time_online` DATETIME,
  `status` varchar(150),
  PRIMARY KEY (`id`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=20 ;

INSERT INTO `zombies` (`ip`, `port`, `os`, `machine_name`, `user_session`, `infection_date`, `last_time_online`, `status`) VALUES
('192.168.1.1', '3456', 'Windows 10', 'Laptop home', 'Bobi', '2017-12-11 10:23:33', '2017-12-11 10:23:33', 'OK');

