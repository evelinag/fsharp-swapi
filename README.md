# F# Swapi

F# wrapper for [swapi.co](https://swapi.co/).

## Installation

To use `fsharp-swapi`, you'll need to get the [F# Data library](http://fsharp.github.io/FSharp.Data/). 

To use `fsharp-swapi`, simply reference the `swapi.fs` file from your solution. You can also add the file using the paket dependency manager by adding the following line into your paket.dependencies file:

  github evelinag/fsharp-swapi swapi.fs

See paket documentation for more details on referencing Github dependencies.
See [paket documentation](https://fsprojects.github.io/Paket/github-dependencies.html) for more details on referencing Github dependencies.

## Using F# Swapi

To use the library, reference `FSharp.Data` and `fsharp-swapi` from your F# code.

	#r "packages/FSharp.Data/lib/net40/FSharp.Data.dll"
	#load "swapi.fs"
	open StarWars.API

File `examples.fsx` contains "practical" examples of usage. Head there if you're interested in the average height of a Star Wars character, or if you want to know which eye colour is the most common.

### Accessing individual resources

In [swapi.co](https://swapi.co/), each resource is available through its ID number. To access each resource based on the ID, call the following functions:

* `getPerson id` returns information on a given person.
* `getPlanet id` returns information about a planet.
* `getFilm id` returns information about a film.
* `getSpecies id` gives information about a species.
* `getVehicle id` gives information about a vehicle.
* `getStarship id` returns information about a specific starship.

All the functions use the [F# JSON type providers](http://fsharp.github.io/FSharp.Data/library/JsonProvider.html). You can access all the information they return using the dot:

![swapi.gif]	

### Downloading all information

To download all items available for each resource in [swapi.co](https://swapi.co/), you can run the following functions:

* `getAllPeople()`
* `getAllPlanets()` 
* `getAllFilms()`
* `getAllSpecies()`
* `getAllVehicles()`
* `getAllStarships()`

The library is heavily based on [F# JSON type providers](http://fsharp.github.io/FSharp.Data/library/JsonProvider.html). 

