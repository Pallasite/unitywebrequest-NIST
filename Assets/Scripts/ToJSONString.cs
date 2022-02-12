using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class ToJSONString : MonoBehaviour
{
    public Vector3 position;
    public Vector3 orientation;
    public string name_marker;
    public int id;
    public float last_update;

    public string output_folder;

    public HoloQube json_data;

    public GameObject holo_marker;

    [ContextMenu("Save to String")]
    public string SaveToString()
    {
        json_data = new HoloQube();

        json_data.position = position;
        json_data.orientation = orientation;
        json_data.name = name_marker;
        json_data.id = id;
        json_data.lastUpdate = last_update;


        //give the file a name and create it's path
        string file_name = "local_test.json";
        string output_path = output_folder + file_name;

        
        //Using the serialed class write to json
        string json = JsonUtility.ToJson(json_data);
        
        // using writealltext is easier than file streams
        File.WriteAllText(output_path, json);


        //FileStream fs = new FileStream(file_name, FileMode.CreateNew);

        //using (StreamWriter stream = new StreamWriter(output_path))
        //{
            
        //    //string json = JsonUtility.ToJson(json_data);
        //    string json = "json";
        //    stream.Write(json);
        //}


        Debug.Log(JsonUtility.ToJson(json));
        return JsonUtility.ToJson(this);

        
    }

    
    void Update()
    {
        //Updating the info based on moving the marker around seems useful in case you want to drop a merk
        position = holo_marker.GetComponent<Transform>().position;

        //I don't know how to interperate the orientation data in the JSON and the Quaternion of Unity
        //orientation = holo_marker.GetComponent<Transform>().rotation;
    }
}
