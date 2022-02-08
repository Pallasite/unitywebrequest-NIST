using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ID_Color : MonoBehaviour
{
    public Material[] material_table;
    public int id_number = -1; // Magic number, if <0 an error occured
    public GameObject holo_marker;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        int array_size = material_table.Length;
        id_number = holo_marker.GetComponent<ToJSONString>().id;
        // NO index oob check yet, has might be more reasonable? or a list iteration search?
        if (material_table[id_number] != null)
        {
            //why doesn't this work?
            //holo_cube.GetComponent<Material>() = material_table[id_number];
            //why do I have to do this?

            //Getting the material from the list and setting the objects material to it
            //Material id_cube_color = holo_marker.GetComponent<Material>();
            //id_cube_color = material_table[id_number];
            // that didn't work beacuse i need to edi the mesh renderer

            //Get material from table and assign it to the first material of the parent's mesh renderer
            Material id_cube_color = material_table[id_number%(array_size+1)];

            MeshRenderer cube_mr = holo_marker.GetComponent<MeshRenderer>();
            cube_mr.material = id_cube_color;

            Debug.Log("ID index key " + id_number);
        }
        else
        {
            Debug.Log("No material for ID index key");
        }
    }
}
