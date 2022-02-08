using UnityEngine;


//This class will pull a random pokemon from the api and use its base experience and weight as coordinates on the map for spawning

public class TestControllerPoke : MonoBehaviour
{
    public GameObject mover_cube;
    public string pub_base_url;
   
    [ContextMenu("Test Get")]
    public async void TestGet()
    {
        //var url = "https://jsonplaceholder.typicode.com/todos/1";
        //var api_base_url = "https://pokeapi.co/api/v2/pokemon/";
        var api_base_url = pub_base_url;

        //Picking from all the possible pokemon.
        int poke_pick = Random.Range(1, 721);

        var url = api_base_url+poke_pick;

        
        var httpClient = new HappyHttpClient(new JsonSerializationOption());
        var result = await httpClient.Get<PokePlot>(url);
        //How to access the public elements of this class iterativlye?
        //Is this possible? Just use . sytax?
        //To string or a sort of array? I don't understand JSON parsing yet
        Debug.Log($"Poke: {result.name}");
        Debug.Log($"Base: {result.base_experience}");
        Debug.Log($"Weight: {result.weight}");

        //Cube position
        int x_spot = result.base_experience % 50;
        int z_spot = result.weight % 50;


        //Instantiate a new cube?
        var clone = Instantiate(mover_cube);

        //Get the transform from the game object
        Transform clone_trans = clone.GetComponent(typeof(Transform)) as Transform;

        clone_trans.position = new Vector3(x_spot, 0.5f, z_spot);

        // I don't know how to get to the sprite URLs from the JSON, but I'll construct them for now
        //var sprite_base_url = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/shiny/";
        var sprite_url = api_base_url + poke_pick + ".png";



    }
}
