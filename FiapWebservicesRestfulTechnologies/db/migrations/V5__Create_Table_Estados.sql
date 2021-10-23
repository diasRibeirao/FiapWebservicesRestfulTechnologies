CREATE TABLE  `estados` (
  `id` bigint NOT NULL AUTO_INCREMENT,
  `nome` varchar(120) NOT NULL,
  `sigla` varchar(6) NOT NULL,
  `pais_id` bigint DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `FK_PAIS_ID` (`pais_id`),
  CONSTRAINT `FK_PAISES` FOREIGN KEY (`pais_id`) REFERENCES `paises` (`id`),
   UNIQUE `estado` (`nome`,`sigla`,`pais_id`)
) 
