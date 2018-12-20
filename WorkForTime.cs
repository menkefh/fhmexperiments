using System.Threading;
using System.Threading.Tasks;
using System.Timers;

namespace ThreadFun
{
    public class WorkForTime
    {
        private static int _lastDelay = 0;

        public static int LastDelay
        {
            get
            {
                return _lastDelay;
            }
        }
        private static async Task<string> RunForSeconds(int numSecs)
        {
            Thread.Sleep(numSecs * 1000);
            _lastDelay = numSecs;
            return string.Format("Delay {0} seconds\n", numSecs);
        }

        public static async Task<string> DoWork(int numSecs)
        {
            var message = await RunForSeconds(numSecs).ConfigureAwait(false);
            return message;

        }
    }

}
