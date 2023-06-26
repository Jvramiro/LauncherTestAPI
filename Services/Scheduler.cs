using LauncherTestAPI.Data;
using NCrontab;

namespace LauncherTestAPI.Services {
    public class Scheduler {
        private readonly LauncherContext _launcherContext;
        private readonly CancellationTokenSource _cancellationTokenSource;

        public Scheduler(LauncherContext launcherContext) {
            _launcherContext = launcherContext;
            _cancellationTokenSource = new CancellationTokenSource();
        }

        public void Start() {

            Task.Run(async () =>
            {
                var schedule = CrontabSchedule.Parse("0 3 * * *");

                while (!_cancellationTokenSource.Token.IsCancellationRequested) {
                    var nextOccurrence = schedule.GetNextOccurrence(DateTime.Now);
                    var delay = nextOccurrence - DateTime.Now;

                    if (delay.TotalMilliseconds > 0)
                        await Task.Delay(delay, _cancellationTokenSource.Token);

                    if (!_cancellationTokenSource.Token.IsCancellationRequested) {
                        await _launcherContext.FillContext();
                    }
                }
            }, _cancellationTokenSource.Token);
        }

        public void Stop() {
            _cancellationTokenSource.Cancel();
        }
    }
}
