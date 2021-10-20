using System.Threading.Tasks;

namespace history_game.ui
{
    public interface IUserInterface
    {
        // made asynchronous so Game and Ui are easier to run on separate threads
        Task Run();
    }
}
