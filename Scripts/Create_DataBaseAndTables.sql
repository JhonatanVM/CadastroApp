create database CadastroApp
go

use CadastroApp
go

create table dbo.PessoaFisica(
	Id int primary key identity(1,1) not null,
	CEP varchar(8) not null,
	Logradouro varchar(100) not null,
	Numero varchar(10) not null,
	Complemento varchar(50),
	Bairro varchar(50) not null,
	Cidade varchar(50) not null,
	UF varchar(8) not null,

	CPF varchar(11) not null,
	DataDeNascimento Date not null,
	Nome varchar(20) not null,
	Sobrenome varchar(15) not null
);
go

create table dbo.PessoaJuridica(
	Id int primary key identity(1,1) not null,
	CEP varchar(8) not null,
	Logradouro varchar(100) not null,
	Numero varchar(10) not null,
	Complemento varchar(50),
	Bairro varchar(50) not null,
	Cidade varchar(50) not null,
	UF varchar(8) not null,

	CNPJ varchar(14) not null,
	RazaoSocial varchar(50) not null,
	NomeFantasia varchar(50) not null
);
go