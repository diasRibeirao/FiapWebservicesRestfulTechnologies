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
);

CREATE TABLE `medicos` (
  `id` bigint NOT NULL AUTO_INCREMENT,
  `nome` varchar(80) NOT NULL,
  `sobrenome` varchar(80) NOT NULL,
  `login` varchar(20) NOT NULL,
  `senha` varchar(200) NOT NULL,
  `email` varchar(80) NOT NULL,
  `crm` varchar(30) NOT NULL,
  `refresh_token` VARCHAR(500) NULL DEFAULT '0',
  `refresh_token_expiry_time` DATETIME NULL DEFAULT NULL,
  PRIMARY KEY (`id`),
  UNIQUE `login` (`login`)
);

CREATE TABLE `pacientes` (
  `id` bigint NOT NULL AUTO_INCREMENT,
  `nome` varchar(80) NOT NULL,
  `sobrenome` varchar(80) NOT NULL,
  `login` varchar(20) NOT NULL,
  `senha` varchar(200) NOT NULL,
  `email` varchar(80) NOT NULL,
  `plano` varchar(100) NOT NULL,
  `refresh_token` VARCHAR(500) NULL DEFAULT '0',
  `refresh_token_expiry_time` DATETIME NULL DEFAULT NULL,
  PRIMARY KEY (`id`),
  UNIQUE `login` (`login`)
)

CREATE TABLE `historicos` (
    `id` bigint NOT NULL AUTO_INCREMENT,
    `paciente` bigint,
     FOREIGN KEY(paciente) REFERENCES pacientes(id),
    `medico` bigint,
    FOREIGN KEY(medico) REFERENCES medicos(id),
    `anotacoes` varchar(600),
    `data` varchar(12),
  PRIMARY KEY (`id`),
  UNIQUE `login` (`login`)
)
