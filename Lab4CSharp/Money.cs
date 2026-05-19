
namespace Lab4Task1
{

    // -- У клас Money додати:  
    // • Індексатор, що дозволяє по індексу 0 звертатися до поля 
    // first, по індексу 1 - до поля second, при інших значеннях 
    // індексу видається повідомлення про помилку.   
    // • Перевантаження:  
    // − операції ++ (--): одночасно збільшує (зменшує) 
    // значення полів first і second;  
    // − операції !: повертає значення true, якщо поле second 
    // не нульове, інакше false;  
    // − операції бінарний +: додає до значення поля second 
    // значення скаляра;  
    // • перетворення типу Money в string ( і навпаки).++


    public class Money
    {
        protected int nominal;
        protected int num;

        public Money(int nominal, int num)
        {
            this.nominal = nominal;
            this.num = num;
        }

        public int Nominal
        {
            get { return nominal; }
            set { nominal = value; }
        }

        public int Num
        {
            get { return num; }
            set { num = value; }
        }

        public int Total
        {
            get { return nominal * num; }
        }

        public int this[int index]
        {
            get
            {
                return index switch
                {
                    0 => nominal,
                    1 => num,
                    _ => throw new IndexOutOfRangeException(
                             $"Помилка: індекс {index} виходить за межі (допустимі: 0, 1).")
                };
            }
            set
            {
                switch (index)
                {
                    case 0: nominal = value; break;
                    case 1: num = value; break;
                    default:
                        throw new IndexOutOfRangeException(
                            $"Помилка: індекс {index} виходить за межі (допустимі: 0, 1).");
                }
            }
        }

        public static Money operator ++(Money m)
        {
            m.nominal++;
            m.num++;
            return m;
        }

        public static Money operator --(Money m)
        {
            m.nominal--;
            m.num--;
            return m;
        }

        public static bool operator !(Money m)
        {
            return m.num != 0;
        }

        public static Money operator +(Money m, int scalar)
        {
            return new Money(m.nominal, m.num + scalar);
        }

        public static Money operator +(int scalar, Money m)
        {
            return m + scalar;
        }


        public static implicit operator string(Money m)
        {
            return $"Nominal={m.nominal}, Num={m.num}, Total={m.Total}";
        }

        public static explicit operator Money(string s)
        {
            var parts = s.Split(':');
            if (parts.Length != 2
                || !int.TryParse(parts[0], out int n)
                || !int.TryParse(parts[1], out int k))
            {
                throw new FormatException(
                    "Помилка: рядок має бути у форматі \"nominal:num\" (наприклад, \"10:5\").");
            }
            return new Money(n, k);
        }

        public void Print()
        {
            Console.WriteLine($"Номінал: {nominal}, Кількість: {num}, Сума: {Total}");
        }

        public bool CanBuy(int price) => Total >= price;

        public int CountItems(int price)
        {
            if (price <= 0) return 0;
            return Total / price;
        }
    }

}