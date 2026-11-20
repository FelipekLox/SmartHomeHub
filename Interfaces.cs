namespace SmartHomeHub
{
    public interface IAdjustable
    {
        int Level { get; }
        void SetLevel(int level);
    }

    public interface IReportable
    {
        string GetShortReport();
    }
}