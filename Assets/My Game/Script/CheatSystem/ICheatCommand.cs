public interface ICheatCommand
{
    public string Command { get; }

    public string Description { get; }

    public void Apply();
}