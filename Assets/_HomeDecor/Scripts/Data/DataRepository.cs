using Cysharp.Threading.Tasks;
using HomeDecor.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DataRepository : IDataRepository
{
    private List<Category> _data;

    public List<Category> Data
    {
        get { return _data; }
        private set { _data = value; }
    }
    public async UniTask<List<Category>> FetchData()
    {
        TextAsset json = await Resources.LoadAsync<TextAsset>("categories") as TextAsset;
        Data = JsonConvert.DeserializeObject<List<Category>>(json.text);
        return Data;
    }

    public List<Product> GetProductsByCategory(string categoryName)
    {
        var category = Data.FirstOrDefault(i => i.Name == categoryName);
        return category?.Products ?? new List<Product>();
    }

    public void SaveList<T>(string key, List<T> list)
    {
        string json = JsonConvert.SerializeObject(list);
        PlayerPrefs.SetString(key, json);
        PlayerPrefs.Save();
    }

    public List<T> LoadList<T>(string key)
    {
        if (!PlayerPrefs.HasKey(key))
            return new List<T>();

        string json = PlayerPrefs.GetString(key);
        return JsonConvert.DeserializeObject<List<T>>(json) ?? new List<T>();
    }

    public static async UniTask<GameObject> GetModelById(string id)
    {
        GameObject model = await Resources.LoadAsync<GameObject>($"models/{id}") as GameObject;
        return model;
    }

    public static async UniTask<Sprite> GetSpriteById(string id)
    {
        Sprite sprite = await Resources.LoadAsync<Sprite>($"images/{id}") as Sprite;
        return sprite;
    }
}
