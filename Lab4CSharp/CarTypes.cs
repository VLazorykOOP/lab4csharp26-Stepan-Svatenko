namespace Lab4Cars
{
    //  --   Структура "Автомобіль":  
    // - Марка;  
    // - Рік випуску;  
    // - ціна;  
    // - Колір.  
    // Видалити всі елементи, у яких рік випуску менше заданого, додати елемент на 
    // початок масиву ++
    public struct CarStruct
    {
        public string Brand;
        public int Year;
        public double Price;
        public string Color;

        public CarStruct(string brand, int year, double price, string color)
            => (Brand, Year, Price, Color) = (brand, year, price, color);

        public override string ToString() =>
            $"  {Brand,-15} | {Year,4} | {Price,12:N0} | {Color}";
    }

    public record Car(string Brand, int Year, double Price, string Color)
    {
        public override string ToString() =>
            $"  {Brand,-15} | {Year,4} | {Price,12:N0} | {Color}";
    }
}