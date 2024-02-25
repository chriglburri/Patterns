namespace CmdLineTools
{
    public class ColorSwitcher : IDisposable
    {
        public ColorSwitcher(ConsoleColor color)
        {
            DefaultColor=Console.ForegroundColor;
            Console.ForegroundColor = color;
        }

        public ConsoleColor DefaultColor { get; }

        public void Dispose()
        {
            Console.ForegroundColor = DefaultColor;
        }
    }
}
