//So I think I made a custom .NET type here as a class? 
//I'm not quite sure how the JSON deserialzer makes this work, but I think it just matches keys?
//Is it auto generating the getter and settes? What are these for if the values are public?
//Can I define a custom to string?
//How to be storing the nested arrays and such?
// I think this is the part I understand the least the JSON deserialziation and parsing into a generic is really confusing me
public class PokePlot
{
    public int height{ get; set; }
    public int base_experience { get; set; }
    public int weight { get; set; }
    public string name { get; set; }
    public string url { get; set; }    
}
