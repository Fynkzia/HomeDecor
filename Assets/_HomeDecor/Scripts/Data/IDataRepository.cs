
using Cysharp.Threading.Tasks;
using HomeDecor.Models;
using System.Collections.Generic;

public interface IDataRepository
{
    List<Category> Data { get; }
    UniTask<List<Category>> FetchData();
    List<Product> GetProductsByCategory(string v);
    void SaveList<T>(string key, List<T> list);
    List<T> LoadList<T>(string key);
}
