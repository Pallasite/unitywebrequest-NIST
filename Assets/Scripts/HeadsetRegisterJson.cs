using UnityEngine;

[System.Serializable]
public class HeadsetRegisterJson
{
    public Vector3 position;
    //public Vector3 orientation;
    //public Vector2 pixelPosition { get; set; } //it's null value messes with the serialization
    public string name;
    public string mapID;
    public string id;
    public float lastUpdate;
}
    /*
    public string playerName;
    public int lives;
    public float health;
    

    [ContextMenu("Save to String")]
    public string SaveToString()
    {
        Debug.Log(JsonUtility.ToJson(this));
        return JsonUtility.ToJson(this);
    }
    */



    // Given:
    // playerName = "Dr Charles"
    // lives = 3
    // health = 0.8f
    // SaveToString returns:
    // {"playerName":"Dr Charles","lives":3,"health":0.8}
