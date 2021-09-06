using System.IO;
using System.Linq;

namespace TreasuryChallenge
{
    public sealed class WriterManager
    {
        const int RANGEPICKER = 100000;

        static int _lastIndex;

        static int _wroteLength;

        static object _lock;

        static StreamWriter _writer;

        private CodeManager _codeManager;

        static WriterManager()
        {
            _lastIndex = 0;
            _wroteLength = 0;
            _lock = new object();
            _writer = new StreamWriter("codes.txt", false, System.Text.Encoding.Default);
        }

        public WriterManager(CodeManager codeManager)
        {
            this._codeManager = codeManager;
        }

        public bool Write()
        {
            lock (_lock)
            {
                var codes = this._codeManager.GetCodes(_lastIndex, RANGEPICKER);

                if (codes != null && codes.Count() > 0)
                {
                    if (_wroteLength + codes.Count() > this._codeManager.GetMaxLength())
                    {
                        int aux = this._codeManager.GetMaxLength() - _wroteLength;

                        codes = codes.Take(aux);
                        _wroteLength += aux;
                    }
                    else
                        _wroteLength += codes.Count();

                    foreach (string code in codes)
                    {
                        _writer.WriteLine(code);
                    }
                }

                _lastIndex += RANGEPICKER;

                if (_wroteLength >= this._codeManager.GetMaxLength())
                {
                    _writer.Flush();
                    _writer.Close();
                    _writer.Dispose();

                    return false;
                }

                return true;
            }
        }
    }
}