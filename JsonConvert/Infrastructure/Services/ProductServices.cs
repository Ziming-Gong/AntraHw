using System.Net.Http.Json;
using System.Reflection;
using System.Text.Json;
using ApplicationCore.Entity;
using ApplicationCore.Services;
using Newtonsoft.Json;
using JsonSerializer = System.Text.Json.JsonSerializer;

// using Newtonsoft.Json;

namespace Infrastructure.Services;

public class ProductServices : IProductServices
{
    private readonly HttpClient _httpClient;
    private const string URL = "https://dummyjson.com/products";

    public ProductServices(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
    
    public async Task<List<Product>> GetAllProduct()
    {
        // var response = await _httpClient.GetFromJsonAsync<Product>(URL);
        HttpResponseMessage response = await _httpClient.GetAsync(URL);
        // var c = await response.Content.ReadFromJsonAsync<List<Product>>();
        var context = await response.Content.ReadAsStringAsync();
        Root jsonRes = JsonConvert.DeserializeObject<Root>(context);
        // Product product = JsonConvert.DeserializeObject<Product>(context);
        // List<Product> products = JsonConvert.DeserializeObject<List<Product>>(context);
        // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(response);
        return jsonRes.products;
    }

    public async Task<List<Product>> GetByCategory(string category)
    {
        HttpResponseMessage response = await _httpClient.GetAsync(URL);
        var str = await response.Content.ReadAsStringAsync();
        Root roots = JsonConvert.DeserializeObject<Root>(str);
        var res = roots.products.Where(x => x.category == category).ToList();
        return res;
    }
}

