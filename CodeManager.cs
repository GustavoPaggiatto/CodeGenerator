using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;

namespace TreasuryChallenge
{
    public sealed class CodeManager
    {
        static ConcurrentBag<string> _codes;

        int _maxLength;

        static CodeManager()
        {
            _codes = new ConcurrentBag<string>();
        }

        public CodeManager(int maxLength)
        {
            this._maxLength = maxLength;
        }

        public void Add(string code)
        {
            if (!IsFull())
                _codes.Add(code);
        }

        public bool IsFull()
        {
            return this._maxLength <= _codes.Count;
        }

        public IEnumerable<string> GetCodes(int startIndex, int length)
        {
            return _codes.Skip(startIndex).Take(length);
        }

        public int GetMaxLength()
        {
            return this._maxLength;
        }
    }
}