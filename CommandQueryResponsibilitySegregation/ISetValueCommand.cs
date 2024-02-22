namespace CommandQueryResponsibilitySegregation
{
    public interface ISetValueCommand
    {
        void SetValue(string value);
        bool CanExecute();
    }
}