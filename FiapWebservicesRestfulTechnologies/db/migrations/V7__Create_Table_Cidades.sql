CREATE TABLE  `cidades` (
  `id` bigint NOT NULL AUTO_INCREMENT,
  `nome` varchar(255) COLLATE utf8_unicode_ci DEFAULT NULL,
  `estado_id` bigint DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `FK_ESTADO_ID` (`estado_id`),
  CONSTRAINT `FK_ESTADOS` FOREIGN KEY (`estado_id`) REFERENCES `estados` (`id`),
  UNIQUE `cidade` (`nome`,`estado_id`)
) 

