using System.Collections.Generic;
using System.Linq;

namespace TreasuryChallenge
{
    public sealed class PermuteManager
    {
        CodeManager _codeManager;

        public PermuteManager(CodeManager codeManager)
        {
            this._codeManager = codeManager;
        }

        public void Permute(char[] chars, string prefix, int aux)
        {
            if (aux == 0)
            {
                prefix += chars[0];
                this._codeManager.Add(prefix);

                return;
            }

            int charsLength = chars.Length;

            for (int i = 0; i < charsLength; i++)
            {
                string newPrefix = prefix + chars[i];
                var newChars = new List<char>();

                foreach (char c in chars)
                {
                    if (newPrefix.Contains(c))
                        continue;

                    newChars.Add(c);
                }

                Permute(newChars.ToArray(), newPrefix, aux - 1);

                if (this._codeManager.IsFull())
                    break;
            }
        }
    }
}