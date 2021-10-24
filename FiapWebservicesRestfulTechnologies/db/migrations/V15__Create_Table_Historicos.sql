CREATE TABLE `historicos` (
   `id` bigint NOT NULL AUTO_INCREMENT,
   `paciente_id` bigint NOT NULL,
   `medico_id` bigint NOT NULL,
   `anotacoes` varchar(1000) NOT NULL,
   `data` datetime NOT NULL,
  PRIMARY KEY (`id`),
  KEY `FK_HISTORICO_PACIENTE_ID` (`paciente_id`),
  CONSTRAINT `FK_HISTORICO_PACIENTE` FOREIGN KEY (`paciente_id`) REFERENCES `pacientes` (`id`),
  KEY `FK_HISTORICO_MEDICO_ID` (`medico_id`),
  CONSTRAINT `FK_HISTORICO_MEDICO` FOREIGN KEY (`medico_id`) REFERENCES `medicos` (`id`)
);