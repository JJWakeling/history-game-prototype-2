using System.Threading.Tasks;

namespace history_game
{
    public interface IGame
    {
        // made asynchronous so Game and Ui are easier to run on separate threads
        Task Run();
    }
}
