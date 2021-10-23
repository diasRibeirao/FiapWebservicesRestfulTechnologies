CREATE TABLE `historicos` (
    `id` bigint NOT NULL AUTO_INCREMENT,
    `paciente` bigint,
     FOREIGN KEY(paciente) REFERENCES pacientes(id),
    `medico` bigint,
    FOREIGN KEY(medico) REFERENCES medicos(id),
    `anotacoes` varchar(600),
    `data` varchar(12),
  PRIMARY KEY (`id`)
)