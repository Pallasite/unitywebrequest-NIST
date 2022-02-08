using System.IO;
using UnityEngine;


//This class will pull a random pokemon from the api and use its base experience and weight as coordinates on the map for spawning

public class TestControllerParaUnity : MonoBehaviour
{
    public GameObject map_marker;
    public string local_path;
    public string local_output_path;
    public int object_index = 0;
   
    [ContextMenu("Test Get")]
    public async void TestGet()
    {
        //var url = "https://jsonplaceholder.typicode.com/todos/1";
        //var api_base_url = "https://pokeapi.co/api/v2/pokemon/";
        // http://halo05.wings.cs.wisc.edu:5000/headsets/0

        var api_base_url = local_path + object_index + ".json";

        var url = api_base_url;
                
        var httpClient = new HappyHttpClient(new JsonSerializationOption());
        var result = await httpClient.Get<HoloQube>(url);
        //How to access the public elements of this class iterativlye?
        //Is this possible? Just use . sytax?
        //To string or a sort of array? I don't understand JSON parsing yet
        Debug.Log(result);
        Debug.Log($"Name: {result.name}");
        Debug.Log($"ID: {result.id}");
        Debug.Log($"Position: {result.position}");
        Debug.Log($"Orientation: {result.orientation}");
        Debug.Log($"Update: {result.lastUpdate}");

        //Cube position
        //int x_spot = result.base_experience % 50;
        //int z_spot = result.weight % 50;


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

        //I thought this would give a reference to the json result, but I'm not sure that 
        //it still exsists anymore after this returns? I have to manually asign it perhaps?
        //or a constructor to get the data out via a method?
        clone.GetComponent<ToJSONString>().json_data = result;

    }


    //I don't think this can actually happen here unless we keep track of the game objects somehow
    [ContextMenu("Test Post")]
    public async void TestPost()
    {    
        //var url = "https://jsonplaceholder.typicode.com/todos/1";
        //var api_base_url = "https://pokeapi.co/api/v2/pokemon/";
        // http://halo05.wings.cs.wisc.edu:5000/headsets/0

        var api_base_url = local_path + "test" + object_index + ".json";

        var url = api_base_url;

        var httpClient = new HappyHttpClient(new JsonSerializationOption());
        var result = await httpClient.Post<HoloQube>(url, null);
        //How to access the public elements of this class iterativlye?
        //Is this possible? Just use . sytax?
        //To string or a sort of array? I don't understand JSON parsing yet
        Debug.Log(result);
        Debug.Log($"Name: {result.name}");
        Debug.Log($"ID: {result.id}");
        Debug.Log($"Position: {result.position}");
        Debug.Log($"Orientation: {result.orientation}");
        Debug.Log($"Update: {result.lastUpdate}");

        //Cube position
        //int x_spot = result.base_experience % 50;
        //int z_spot = result.weight % 50;


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
