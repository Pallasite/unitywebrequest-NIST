using UnityEngine;


//This class will pull a random pokemon from the api and use its base experience and weight as coordinates on the map for spawning

public class TestControllerPara : MonoBehaviour
{
    public GameObject map_marker;
    public string pub_base_url;

    public bool echo_to_debug_log = true;
    
    [ContextMenu("Test Get")]
    public async void TestGet()
    {
        //var url = "https://jsonplaceholder.typicode.com/todos/1";
        //var api_base_url = "https://pokeapi.co/api/v2/pokemon/";
        // http://halo05.wings.cs.wisc.edu:5000/headsets/0

        var api_base_url = pub_base_url;

        //Picking from all the possible pokemon.
        int poke_pick = Random.Range(1, 721);

        var url = api_base_url;

        
        var httpClient = new HappyHttpClient(new JsonSerializationOption());
        var result = await httpClient.Get<HoloQube>(url);
        
        //Verbose output of JSON to log
        if (echo_to_debug_log)
        {
            //How to access the public elements of this class iterativlye?
            //Is this possible? Just use . sytax?
            //To string or a sort of array? I don't understand JSON parsing yet
            Debug.Log(result);
            Debug.Log($"Name: {result.name}");
            Debug.Log($"ID: {result.id}");
            Debug.Log($"Position: {result.position}");
            Debug.Log($"Orientation: {result.orientation}");
            Debug.Log($"Update: {result.lastUpdate}");
        }

        //Instantiate a new cube
        var clone = Instantiate(map_marker);
        clone.name = result.name;

        //Get the transform from the game object
        Transform clone_trans = clone.GetComponent(typeof(Transform)) as Transform;

        //clone_trans.position = new Vector3((poke_pick%10), 0.5f, (poke_pick%8));
        clone_trans.position = result.position;

        //Setting JSON to String classes' members, there should be a better way than this, but maybe not
        clone.GetComponent<ToJSONString>().id = result.id;
        clone.GetComponent<ToJSONString>().position = result.position;
        clone.GetComponent<ToJSONString>().orientation = result.orientation;
        clone.GetComponent<ToJSONString>().name_marker = result.name;
        clone.GetComponent<ToJSONString>().last_update = result.lastUpdate;
    }
}
