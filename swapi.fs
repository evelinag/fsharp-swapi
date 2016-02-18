module StarWars.API
open FSharp.Data

// Star Wars resource urls
let [<Literal>] baseUrl = "http://swapi.co/api/"
let [<Literal>] peopleUrl = baseUrl + "people/"
let [<Literal>] planetUrl = baseUrl + "planets/"
let [<Literal>] filmUrl = baseUrl + "films/"
let [<Literal>] speciesUrl = baseUrl + "species/"
let [<Literal>] vehicleUrl = baseUrl + "vehicles/"
let [<Literal>] starshipUrl = baseUrl + "starships/"

// Json type providers for individual types of resources
type Person = JsonProvider<"http://swapi.co/api/people/29/">
type Planet = JsonProvider<"http://swapi.co/api/planets/1/">
type Film = JsonProvider<"http://swapi.co/api/films/1/">
type Species = JsonProvider<"http://swapi.co/api/species/1/">
type Vehicle = JsonProvider<"http://swapi.co/api/vehicles/4/">
type Starship = JsonProvider<"http://swapi.co/api/starships/9/">

// Json type providers for downloading all items 
// from each resource
type AllPeople = JsonProvider<"http://swapi.co/api/people/?page=3">
type AllPlanets = JsonProvider<planetUrl>
type AllFilms = JsonProvider<filmUrl>
type AllSpecies = JsonProvider<speciesUrl>
type AllVehicles = JsonProvider<vehicleUrl>
type AllStarships = JsonProvider<starshipUrl>

// Helper functions to get specific item using its id
let getPerson id = Person.Load(peopleUrl + string id + "/")
let getPlanet id = Planet.Load(planetUrl + string id + "/")
let getFilm id = Film.Load(filmUrl + string id + "/")
let getSpecies id = Species.Load(speciesUrl + string id + "/")
let getVehicle id = Vehicle.Load(vehicleUrl + string id + "/")
let getStarship id = Starship.Load(starshipUrl + string id + "/")

/// Downloading all items requires paging - this type provider
/// gives general access to the "next" page's url in the JSON document
type Paging = JsonProvider<"""{"next": "http://swapi.co/api/people/?page=2"}""">

/// Recursively download all paged resources. The parser
/// is a wrapper around the individual types for each of the resources. 
let rec getAll parser nextUrl acc =
   match nextUrl with 
   | "" -> List.rev acc |> Array.concat
   | url ->
       let text = Http.RequestString(url)
       let next = Paging.Parse(text).Next
       let contents = parser text
       getAll parser next (contents::acc)

// Wrappers around individual type providers for each resource
let peopleParser url = AllPeople.Parse(url).Results
let planetParser url = AllPlanets.Parse(url).Results
let filmParser url = AllFilms.Parse(url).Results
let speciesParser url = AllSpecies.Parse(url).Results
let vehicleParser url = AllVehicles.Parse(url).Results
let starshipParser url = AllStarships.Parse(url).Results

// Functions to get all items for each resource
let getAllPeople () = getAll peopleParser peopleUrl []
let getAllPlanets () = getAll planetParser planetUrl []
let getAllFilms () = getAll filmParser filmUrl []
let getAllSpecies () = getAll speciesParser speciesUrl []
let getAllVehicles () = getAll vehicleParser vehicleUrl []
let getAllStarships () = getAll starshipParser starshipUrl []


