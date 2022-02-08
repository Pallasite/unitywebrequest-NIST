using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class PostJson : MonoBehaviour
{
    //Parent object to post
    public GameObject holo_marker;

    //Unity data for json fields
    public Vector3 position;
    public Vector3 orientation;
    public string name_marker;
    public int id;
    public float last_update;

    public int object_index = -1; // -1 if error

    public string target_path;    

    void Update()
    {
        //Update the public data memebers with the parent object's data. 
        position = holo_marker.GetComponent<ToJSONString>().position;
        orientation = holo_marker.GetComponent<ToJSONString>().orientation;
        name_marker = holo_marker.GetComponent<ToJSONString>().name_marker;
        id = holo_marker.GetComponent<ToJSONString>().id;
        last_update = holo_marker.GetComponent<ToJSONString>().last_update;

        //Updating the info based on moving the marker around seems useful in case you want to drop a merk
        position = holo_marker.GetComponent<Transform>().position;

        //I don't know how to interperate the orientation data in the JSON and the Quaternion of Unity
        //orientation = holo_marker.GetComponent<Transform>().rotation;
    }


    [ContextMenu("Post Marker")]
    public async void TestPost()
    {
        //Write the datafields to the JSON object
        //HoloQube json_data = new HoloQube();

        HeadsetRegisterJson json_data = new HeadsetRegisterJson();


        json_data.position = position;
        //json_data.orientation = orientation;
        json_data.name = name_marker;
        //json_data.id = id; Register has it as a string not an int
        json_data.id = id.ToString();
        json_data.lastUpdate = last_update;

        //***
        //*** This was borrowed from the local class, but it might be messing up the URL
        //give the file a name and create it's path
        string file_name = "local_test.json";
        string output_path = target_path + file_name;

        //Using the serialed class write to json
        string json = JsonUtility.ToJson(json_data);
                
        var api_base_url = target_path + "test" + object_index + ".json";


        //Set url, we'll try the other URL I have
        var url = target_path;

        //***

        var httpClient = new HappyHttpClient(new JsonSerializationOption());
        var result = await httpClient.Post<HoloQube>(url, json);


        //How to access the public elements of this class iterativlye?
        //Is this possible? Just use . sytax?
        //To string or a sort of array? I don't understand JSON parsing yet
        Debug.Log(json_data);
        Debug.Log($"Name: {json_data.name}");
        Debug.Log($"ID: {json_data.id}");
        Debug.Log($"Position: {json_data.position}");
        //Debug.Log($"Orientation: {json_data.orientation}");
        Debug.Log($"Update: {json_data.lastUpdate}");

        //Cube position
        //int x_spot = result.base_experience % 50;
        //int z_spot = result.weight % 50;


    }
}
