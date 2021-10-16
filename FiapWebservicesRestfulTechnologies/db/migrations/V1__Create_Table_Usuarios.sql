CREATE TABLE `usuarios` (
  `id` bigint NOT NULL AUTO_INCREMENT,
  `nome` varchar(80) NOT NULL,
  `sobrenome` varchar(80) NOT NULL,
  `login` varchar(20) NOT NULL,
  `senha` varchar(200) NOT NULL,
  `email` varchar(80) NOT NULL,
  `refresh_token` VARCHAR(500) NULL DEFAULT '0',
  `refresh_token_expiry_time` DATETIME NULL DEFAULT NULL,
  PRIMARY KEY (`id`),
  UNIQUE `login` (`login`)
)