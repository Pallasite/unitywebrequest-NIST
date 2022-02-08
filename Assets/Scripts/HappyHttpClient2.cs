using System;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;

public class HappyHttpClient2
{
    private readonly ISerializationOption _serializationOption;

    public HappyHttpClient2(ISerializationOption serializationOption)
    {
        _serializationOption = serializationOption;
    }

    public async Task<TResultType> Get<TResultType>(string url)
    {
        try
        {
            //It was throwing errors with the original using statment
            //I had to add the parens and the brackets I think that's
            //required to show the scope of the using statement?
            //I'm not really sure what it's for but I think it has something
            //to do with thread collection?
            using (var www = UnityWebRequest.Get(url))
            {

                www.SetRequestHeader("Content-Type", _serializationOption.ContentType);

                var operation = www.SendWebRequest();

                while (!operation.isDone)
                    await Task.Yield();

                if (www.result != UnityWebRequest.Result.Success)
                    Debug.LogError($"Failed: {www.error}");

                var result = _serializationOption.Deserialize<TResultType>(www.downloadHandler.text);

                return result;
            }
        }
        catch (Exception ex)
        {
            Debug.LogError($"{nameof(Get)} failed: {ex.Message}");
            return default;
        }
    }
}