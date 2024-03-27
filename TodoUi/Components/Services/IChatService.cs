using ChatUi.Models;

namespace ChatUi.Services;

public interface IChatService
{
    public Task<Message> PostChatAsync(Message msg);
}
