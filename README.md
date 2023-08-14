# Test BackEnd micro-services

## Para iniciar el proyecto

Se requires [docker]() para correr el proyecto

Luego de clonar proyecto ingresar: 
```sh
cd test-lisit-backEnd
docker-compose up -d
```
Ingresamos al contenedor del api y corremos el comando de la migracion
```sh
docker exec -it test-lisit-api-1 /bin/bash
php artisan migrate --seed
```
Ahora podemos Realizar consultar al API a traves de
## http://localhost:8080
Para ver Colleccion de Request hacer click [Aqui]()

## Estructura del proyecto
   1.- Bff (backEnd for frontend)
   2.- Users (micro-service)
   3.- Location (micro-service)
    4.- Social Helper (micro-service)

## Scafolding del servicios
   1.- Controllers
   2.- Models
   3.- Entities
    4.- Services
    5.- Repositories
    6.- Helpers
MIT

> The well-being of humanity, its peace and security are unattainable, unless its unity is firmly established.
> Bahá’u’lláh
**Free Software is a big step.**