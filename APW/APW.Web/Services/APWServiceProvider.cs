using APW.Architecture;
using APW.Architecture.Providers;
namespace APW.Web.Services;

    public interface IWrapperServiceProvider
{
    Task<object> GetDataAsync<T>(string endpoint) where T : class;
}

//llama al IRestProvider
public class WrapperServiceProvider(IRestProvider restProvider) : IWrapperServiceProvider
{

    //dependencia
    private readonly IRestProvider _restProvider = restProvider;

                                //generics "T" pasa un valor generico
    public async Task<object>  GetDataAsync<T>(string endpoint) where T : class
    {
        //await para esperer el resultado
      var content = await _restProvider.GetAsync(endpoint, id: null);
       return JsonProvider.DeserializeSimple<T>(content) ?? default;
    }
    
}
