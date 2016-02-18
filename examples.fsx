
#r "packages/FSharp.Data/lib/net40/FSharp.Data.dll"
#load "swapi.fs"
open StarWars.API

// Download information about all people in the Star Wars universe
let people = getAllPeople()
printfn "Number of people: %d" people.Length

// What is the most common eye color among Star Wars characters?
let eyeColor = 
   people
   |> Array.groupBy (fun person -> person.EyeColor )
   |> Array.map (fun (color, creatures) -> color, creatures |> Array.map (fun p -> p.Name))
   |> Array.sortByDescending (fun (_, xs) -> xs.Length)

// What is the average height of Star Wars characters?
let height = 
   people
   |> Array.choose (fun person -> person.Height.Number)
   |> Array.averageBy float

// Download infromation about all species
let species = getAllSpecies()

// which species has most characters?
let mostCommonSpecies = 
    species 
    |> Array.map (fun s -> s.Name, s.People.Length)
    |> Array.maxBy snd
printfn "The most common species is %s with %d characters" 
    (fst mostCommonSpecies) (snd mostCommonSpecies)

// *********************************

// Get information about a specific person
let p = getPerson 1
printfn "%s" p.Name

// which films does the person appear in?
p.Films 
|> Array.map (fun f -> Film.Load(f).Title)
