namespace SmartHomeHub
{
    public abstract class SmartDevice
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public bool IsOn { get; protected set; }

        protected SmartDevice(string id, string name)
        {
            Id = id;
            Name = name;
        }

        public virtual void TurnOn() => IsOn = true;
        public virtual void TurnOff() => IsOn = false;

        public virtual string GetStatus()
        {
            return $"[{Id}] {Name}: {(IsOn ? "Вкл" : "Выкл")}";
        }
    }
}