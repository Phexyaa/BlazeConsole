using Microsoft.JSInterop;

namespace BlazeConsole;
public class JsInteropHelper : IAsyncDisposable
{
    private readonly Lazy<Task<IJSObjectReference>> moduleTask;

    public JsInteropHelper(IJSRuntime jsRuntime)
    {
        moduleTask = new(() => jsRuntime.InvokeAsync<IJSObjectReference>(
            "import", "./_content/BlazeConsole/JsFunctions.js").AsTask());
    }

    public async ValueTask<int> GetWidthPixels(string id)
    {
        var module = await moduleTask.Value;
        var result = await module.InvokeAsync<double>("getWidth", id);
        return (int)result;
    }
    public async ValueTask<int> GetHeightPixels(string id)
    {
        var module = await moduleTask.Value;
        var result = await module.InvokeAsync<double>("getHeight", id);
        return (int)result;
    }

    public async ValueTask DisposeAsync()
    {
        if (moduleTask.IsValueCreated)
        {
            var module = await moduleTask.Value;
            await module.DisposeAsync();
        }
    }
}
