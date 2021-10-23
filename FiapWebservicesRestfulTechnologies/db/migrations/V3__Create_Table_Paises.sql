CREATE TABLE `paises` (
  `id` bigint NOT NULL AUTO_INCREMENT,
  `nome` varchar(40) NOT NULL,
  `sigla` varchar(6) NOT NULL,
  PRIMARY KEY (`id`),
  UNIQUE `login` (`nome`,`sigla`)
)