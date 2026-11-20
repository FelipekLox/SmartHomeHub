namespace SmartHomeHub
{
    /*
     * ПОЧЕМУ СЕНСОРЫ НЕ НАСЛЕДУЮТСЯ ОТ SmartDevice:
     * 1. Разница в поведении (принцип разделения интерфейсов и подстановки Лисков):
     *    SmartDevice — это исполнительное устройство (актуатор), которым пользователь управляет
     *    (методы TurnOn / TurnOff). Сенсор (датчик) не «включают» и не «выключают» как лампу или вентилятор —
     *    он пассивно считывает показатели окружающей среды (GetMeasurement).
     * 2. Наследование сенсора от SmartDevice заставило бы его иметь бессмысленные методы управления
     *    состоянием питания и попадать в общие циклы управления актуаторами.
     */
    public abstract class SmartSensor
    {
        public string Id { get; set; }
        public string Name { get; set; }

        protected SmartSensor(string id, string name)
        {
            Id = id;
            Name = name;
        }

        public abstract string GetMeasurement();

        public virtual string GetStatus()
        {
            return $"[{Id}] Датчик «{Name}»: {GetMeasurement()}";
        }
    }
}
