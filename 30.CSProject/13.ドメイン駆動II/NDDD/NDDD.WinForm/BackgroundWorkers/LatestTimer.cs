using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NDDD.WinForm.BackgroundWorkers {
    internal static class LatestTimer {

        private static Timer _timer;
        private static bool _isWork=false;

        static LatestTimer() {
            _timer = new Timer(Callback);
        }

        internal static void Start() {
            _timer.Change(10000, 10000);
        }

        internal static void Stop() {
            _timer.Change(Timeout.Infinite, Timeout.Infinite);
        }

        private static void Callback(object o) {
            if (_isWork) {
                return;
            }

            try {
                _isWork = true;
                // timerの処理
            }
            finally{
                _isWork = false;
            }
        }

    }
}
