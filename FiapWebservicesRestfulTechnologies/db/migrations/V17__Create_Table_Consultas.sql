CREATE TABLE `consultas` (
   `id` bigint NOT NULL AUTO_INCREMENT,
   `paciente_id` bigint NOT NULL,
   `medico_id` bigint NOT NULL,
   `telefone` varchar(20) not null,
   `data` datetime NOT NULL,
  PRIMARY KEY (`id`),
  KEY `FK_CONSULTA_PACIENTE_ID` (`paciente_id`),
  CONSTRAINT `FK_CONSULTA_PACIENTE` FOREIGN KEY (`paciente_id`) REFERENCES `pacientes` (`id`),
  KEY `FK_CONSULTA_MEDICO_ID` (`medico_id`),
  CONSTRAINT `FK_CONSULTA_MEDICO` FOREIGN KEY (`medico_id`) REFERENCES `medicos` (`id`)
);