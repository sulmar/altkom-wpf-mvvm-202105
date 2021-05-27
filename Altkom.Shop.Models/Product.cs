namespace Altkom.Shop.Models
{
    public class Product : Item
    {
        public string Color { get; set; }
        public float Weight { get; set; }
        public byte[] Photo { get; set; }
        public bool IsOverLimit => UnitPrice > 500;

        public Product()
        {
            this.PropertyChanged += (s, e) =>
            {
                if (e.PropertyName == nameof(UnitPrice))
                {
                    OnPropertyChanged(nameof(IsOverLimit));
                }
            };
        }

        public WeightThreshold WeightThreshold
        {
            get
            {
                if (Weight < 300) 
                    return WeightThreshold.Light;
                else 
                    if (Weight > 700) 
                    return WeightThreshold.Havy;

                else return WeightThreshold.Standard;
            }
        }

        public bool IsWooden => Name.Contains("Wooden");

        // C# 9.0
        // Patterns
        // https://docs.microsoft.com/pl-pl/dotnet/csharp/fundamentals/functional/pattern-matching#relational-patterns
        //public WeightThreshold WeightThreshold2 => Weight switch
        //{
        //    < 300 => WeightThreshold.Light,
        //    < 700 => WeightThreshold.Havy,
        //    _ => WeightThreshold.Standard
        //};

    }

    public enum WeightThreshold
    {
        Light,
        Standard,
        Havy
    }
}
