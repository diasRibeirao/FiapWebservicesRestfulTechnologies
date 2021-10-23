CREATE TABLE `enderecos` (
  `id` bigint NOT NULL AUTO_INCREMENT,
  `cep` varchar(10) NOT NULL,
  `logradouro` varchar(250) DEFAULT NULL,
  `bairro` varchar(255) COLLATE utf8_unicode_ci DEFAULT NULL,
  `cidade_id` bigint NOT NULL,
  PRIMARY KEY (`id`),
  KEY `FK_CIDADE_ID` (`cidade_id`),
  CONSTRAINT `FK_CIDADES` FOREIGN KEY (`cidade_id`) REFERENCES `cidades` (`id`),
  UNIQUE `cep` (`cep`,`logradouro`,`bairro`,`cidade_id`)
) 

