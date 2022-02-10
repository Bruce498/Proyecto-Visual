## Running the tests 

Arregla el problema del identity en la tabla Animal

``` sql
alter table Animal drop column IdAnimal
go
alter table Animal add IdAnimal int identity
go
```
hecho
