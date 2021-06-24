"# Pokedex" 
The available endpoints can be seen in the Pokemon Items Controller.cs file

The tasks from the MUST HAVE sub-items as well as searching by type, name, authentication and error-handling have been implemented.


To view a list of all pokemon, type: (GET) https://localhost:5001/api/PokemonItems

To update pokemon with id = 5, type: (PUT): https://localhost:5001/PokemonItems/5

To post new pokemon, type e.x.: (POST) https://localhost:5001/api/PokemonItems
JSON:
{
	"name": "Charizard",
	"type": "Flame",
	"weakness": "Water" 
}