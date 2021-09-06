namespace TreasuryChallenge
{
    public sealed class Facade
    {
        public ThreadManager GetThreadManager()
        {
            return new ThreadManager();
        }

        public PermuteManager GetPermuteManager(CodeManager codeManager)
        {
            return new PermuteManager(codeManager);
        }

        public CodeManager GetCodeManager(int maxLength)
        {
            return new CodeManager(maxLength);
        }

        public WriterManager GetWriterManager(CodeManager codeManager)
        {
            return new WriterManager(codeManager);
        }
    }
}