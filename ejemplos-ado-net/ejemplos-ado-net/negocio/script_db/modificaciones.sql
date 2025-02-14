
select * from POKEMONS
select * from ELEMENTOS

insert into ELEMENTOS values ('Bicho')
insert into ELEMENTOS values ('Volador')
insert into ELEMENTOS values ('Eléctrico')


SET IDENTITY_INSERT POKEMONS ON;

insert into POKEMONS (Numero, Nombre, Descripcion, UrlImagen, IdTipo, IdDebilidad, IdEvolucion, Activo)
values (25, 'Pikachu', 'Rata electrica', '', 6, 1, NULL, 1)


SET IDENTITY_INSERT POKEMONS OFF;

update POKEMONS set Id = 6 where Id=10;

update POKEMONS set IdTipo = 4 where Id = 3;
update POKEMONS set IdTipo = 5 where Id = 4 

update POKEMONS set IdDebilidad = 6 where IdTipo = 4;
update POKEMONS set IdDebilidad = 6 where IdTipo = 5;

update POKEMONS set UrlImagen = 'https://assets.pokemon.com/assets/cms2/img/pokedex/full/007.png' where Numero = 7;
update POKEMONS set UrlImagen = 'https://assets.pokemon.com/assets/cms2/img/pokedex/full/008.png' where Numero = 8;
update POKEMONS set UrlImagen = 'pokemon.com' where Numero = 25;

//select e.Descripcion, e.Id, p.Nombre, p.IdTipo, p.IdDebilidad from POKEMONS p, ELEMENTOS e where e.Id = p.IdDebilidad
// planta 1, fuego 2, agua 3, bicho 4, volador 5, electrico 6

Select Numero, Nombre, P.Descripcion, UrlImagen, E.Descripcion Tipo, D.Descripcion Debilidad From POKEMONS P, ELEMENTOS E, ELEMENTOS D Where E.Id = P.IdTipo and D.Id = P.IdDebilidad