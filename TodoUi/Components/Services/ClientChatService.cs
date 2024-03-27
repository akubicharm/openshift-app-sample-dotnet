using ChatUi.Models;
using System.Net.Http.Json;
using System.Net.Http;
using System.Text.Json;

namespace ChatUi.Services;

public class ClientChatService(HttpClient http) : IChatService
{
   public string? uri = Environment.GetEnvironmentVariable("ChatUrl");

   public async Task<Message> PostChatAsync(Message msg)
   {
      Console.WriteLine(uri);
      string jsonStr = JsonSerializer.Serialize(msg);
      Console.WriteLine(jsonStr);

      //var res = await http.PostAsJsonAsync($"chat", msg);
      var res = await http.PostAsJsonAsync(uri + "chat", msg);

      Console.WriteLine(res);

      var jsonRes = await res.Content.ReadAsStringAsync();
      Console.WriteLine(jsonRes);

      var retMsg = new Message { User = "Chat", Text = jsonRes };
      return retMsg;

   }
}