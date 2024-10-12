create database dbBancoApp;
use dbBancoapp;
create table Usuario(
idUsu int primary key auto_increment,
nomeUsu varchar(50) not null,
Cargo varchar(50) not null,
DataNasc datetime not null
);

create table Cliente(
idCli int primary key auto_increment,
nomeCli varchar(50) not null,
Email varchar(50) not null,
DataNasc datetime not null,
Telefone Decimal(11,0) not null
);

