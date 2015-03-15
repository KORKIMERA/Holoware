namespace CommandModule.Infrastructure
{
    public abstract class CommandProcessor
    {
        public abstract void Initialize();

        public abstract CommandStatus Execute(string line);

        public abstract bool ValidateParameter(string parameter);

        public abstract bool ValidateRootCommand(string text);
    }
}