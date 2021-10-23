using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace history_game
{
    //TODO: make Game also implement IGameElement so that it can be messaged to create new elements
    ///<summary>
    /// marshalls game elements to change state in time with a fixed tick rate
    ///</summary>
    public class Game : IGame
    {
        //using ICollection instead of IEnumerable so new processManagers can be added once I implement that functionality
        private readonly ICollection<IProcessManager> _processManagers;
        private readonly int _tickMilliseconds;

        public Game(ICollection<IProcessManager> processManagers, int tickMilliseconds)
        {
            _processManagers = processManagers;
            _tickMilliseconds = tickMilliseconds;
        }

        public async Task Run()
        {
            //TODO: implement way of ending playsession
            while (true)
            {
                var tickEnd = Task.Delay(_tickMilliseconds);

                Task.WaitAll(
                    _processManagers.Select(m => m.ExecuteProcesses()).ToArray()
                );
                Task.WaitAll(
                    _processManagers.Select(m => m.SendProcesses(_processManagers)).ToArray()
                );

                // pad out each tick to standard length
                await tickEnd;
            }
        }
    }
}
