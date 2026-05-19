using Lab4Task1;
using Lab4CSharpVectorLong;
using Lab4MatrixLong;
using Lab4Cars;

namespace Lab4CSharp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Lab 4 CSharp");
            int n = Convert.ToInt32(Console.ReadLine());

            do
            {
                Console.WriteLine("Enter number of task: ");
                n = Convert.ToInt32(Console.ReadLine());
                switch (n)
                {
                    case 1:
                        Cartest();
                        break;
                    case 2:
                        MatrixTest();
                        break;
                    case 3:
                        MoneyTest();
                        break;
                    case 4:
                        VectorLongTest();
                        break;
                }
            } while (n != 0);


        }

        static void TableHeader()
        {
            Console.WriteLine($"  {"Марка",-15} | {"Рік",4} | {"Ціна",12} | Колір");
            Console.WriteLine("  " + new string('-', 53));
        }

        static void Section(string title)
        {
            Console.WriteLine();
            Console.WriteLine(new string('═', 54));
            Console.WriteLine($"  {title}");
            Console.WriteLine(new string('═', 54));
        }

        static void Cartest()
        {


            const int MIN_YEAR = 2014;
            const string NEW_BRAND = "Honda";
            const int NEW_YEAR = 2023;
            const double NEW_PRICE = 780_000;
            const string NEW_COLOR = "Зелений";

            (string Brand, int Year, double Price, string Color)[] SeedData() =>
                new (string, int, double, string)[]
                {
        ("Toyota",     2015,   620_000, "Білий"),
        ("BMW",        2010,   850_000, "Чорний"),
        ("Volkswagen", 2019,   730_000, "Сірий"),
        ("Ford",       2008,   390_000, "Синій"),
        ("Mercedes",   2021, 1_200_000, "Чорний"),
        ("Skoda",      2013,   480_000, "Червоний"),
        ("Audi",       2017,   950_000, "Білий"),
                };





            Section("1 struct");

            List<CarStruct> structs = SeedData()
                .Select(d => new CarStruct(d.Brand, d.Year, d.Price, d.Color))
                .ToList();

            Console.WriteLine("\n> START:");
            TableHeader();
            structs.ForEach(c => Console.WriteLine(c));
            structs.RemoveAll(c => c.Year < MIN_YEAR);
            Console.WriteLine($"\n> видалення (рік < {MIN_YEAR}):");
            TableHeader();
            structs.ForEach(c => Console.WriteLine(c));
            structs.Insert(0, new CarStruct(NEW_BRAND, NEW_YEAR, NEW_PRICE, NEW_COLOR));
            Console.WriteLine($"\n> додавання «{NEW_BRAND}» на початок:");
            TableHeader();
            structs.ForEach(c => Console.WriteLine(c));

            Section("2 ValueTuple");

            static string TupleLine((string Brand, int Year, double Price, string Color) c) =>
                $"  {c.Brand,-15} | {c.Year,4} | {c.Price,12:N0} | {c.Color}";

            List<(string Brand, int Year, double Price, string Color)> tuples =
                SeedData().ToList();

            Console.WriteLine("\n> START:");
            TableHeader();
            tuples.ForEach(c => Console.WriteLine(TupleLine(c)));

            tuples.RemoveAll(c => c.Year < MIN_YEAR);
            Console.WriteLine($"\n> видалення (рік < {MIN_YEAR}):");
            TableHeader();
            tuples.ForEach(c => Console.WriteLine(TupleLine(c)));

            tuples.Insert(0, (NEW_BRAND, NEW_YEAR, NEW_PRICE, NEW_COLOR));
            Console.WriteLine($"\n> додавання «{NEW_BRAND}» на початок:");
            TableHeader();
            tuples.ForEach(c => Console.WriteLine(TupleLine(c)));

            var (brand, year, price, color) = tuples[0];
            Console.WriteLine($"\n> Brand={brand}, Year={year}, Price={price:N0}, Color={color}");


            Section("3 record");

            List<Car> records = SeedData()
                .Select(d => new Car(d.Brand, d.Year, d.Price, d.Color))
                .ToList();

            Console.WriteLine("\n> START:");
            TableHeader();
            records.ForEach(Console.WriteLine);

            records.RemoveAll(c => c.Year < MIN_YEAR);
            Console.WriteLine($"\n> видалення (рік < {MIN_YEAR}):");
            TableHeader();
            records.ForEach(Console.WriteLine);

            var newCar = new Car(NEW_BRAND, NEW_YEAR, NEW_PRICE, NEW_COLOR);
            records.Insert(0, newCar);
            Console.WriteLine($"\n> додавання «{NEW_BRAND}» на початок:");
            TableHeader();
            records.ForEach(Console.WriteLine);

            Console.WriteLine("\n> with:");
            Car modified = newCar with { Color = "Жовтий", Price = 800_000 };
            Console.WriteLine($"  Оригінал : {newCar}");
            Console.WriteLine($"  Копія    : {modified}");
            Console.WriteLine($"  ?   : {newCar == modified}");

            Console.WriteLine("\n> Pattern matching:");
            foreach (var c in records)
            {
                string label = c switch
                {
                    { Year: >= 2020 } => "Новий",
                    { Year: >= 2015, Price: > 700_000 } => "Сучасний / дорогий",
                    { Year: >= 2015 } => "Сучасний / бюджетний",
                    _ => "Старий",
                };
                Console.WriteLine($"  {c.Brand,-15} ({c.Year}) -> {label}");
            }
        }

        static void MatrixTest()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Section("1. Конструктори");
            var m0 = new MatrixLong();
            var m1 = new MatrixLong(2, 3);
            var m2 = new MatrixLong(2, 3, 5L);
            var m3 = new MatrixLong(2, 3, 3L);
            m0.Print("m0 (1x1, =0):");
            m1.Print("m1 (2x3, =0):");
            m2.Print("m2 (2x3, =5):");
            Console.WriteLine($"Кількість матриць: {MatrixLong.Count()}");

            Section("2. SetAll");
            m1.SetAll(7L);
            m1.Print("m1 після SetAll(7):");

            Section("3. Властивості Rows/Cols");
            Console.WriteLine($"m2.Rows={m2.Rows}, m2.Cols={m2.Cols}");

            Section("4. Індексатор [i,j]");
            Console.WriteLine($"m2[0,0] = {m2[0, 0]}");
            m2[0, 0] = 99;
            Console.WriteLine($"m2[0,0] після запису 99 = {m2[0, 0]}");
            _ = m2[9, 9];
            Console.WriteLine($"CodeError після m2[9,9] = {m2.CodeError}");
            m2[0, 0] = 5;

            Section("5. Індексатор [k]");
            Console.WriteLine($"m2[1] = {m2[1]}  (рядок 0, стовпець 1)");
            m2[1] = 42;
            Console.WriteLine($"m2[1] після запису 42 = {m2[1]}");
            m2[1] = 5;

            Section("6. ++ та --");
            m2.Print("m2 до ++:");
            m2++;
            m2.Print("m2 після ++:");
            m2--;
            m2.Print("m2 після --:");

            Section("7. true / false");
            var mz = new MatrixLong(2, 2, 0L);
            Console.WriteLine($"m2 (ненульова): {(m2 ? "true" : "false")}");
            Console.WriteLine($"mz (нульова):   {(mz ? "true" : "false")}");

            Section("8. Оператор !");
            Console.WriteLine($"!m2 = {!m2}");

            Section("9. Оператор ~");
            var mBit = new MatrixLong(2, 2, 6L);
            mBit.Print("mBit (=6):");
            (~mBit).Print("~mBit:");

            Section("10. Арифметика: матриця op матриця");
            var a = new MatrixLong(2, 3, 8L);
            var b = new MatrixLong(2, 3, 3L);
            a.Print("a (=8):"); b.Print("b (=3):");
            (a + b).Print("a + b:");
            (a - b).Print("a - b:");
            (a / b).Print("a / b:");
            (a % b).Print("a % b:");

            Section("11. Множення матриць (2x3 * 3x2)");
            var ma = new MatrixLong(2, 3, 1L);
            var mb = new MatrixLong(3, 2, 2L);
            ma.Print("ma (2x3, =1):");
            mb.Print("mb (3x2, =2):");
            (ma * mb).Print("ma * mb (2x2):");

            Section("12. Множення матриця * вектор");
            var vec = new VectorLongM(3, 2L);
            ma.Print("ma (2x3, =1):");
            Console.WriteLine($"vec (size=3, =2): [ {string.Join(", ", System.Linq.Enumerable.Range(0, 3).Select(i => vec.IntArray[i]))} ]");
            (ma * vec).Print("ma * vec (2x1):");

            Section("13. Арифметика: матриця op скаляр");
            a.Print("a (=8):");
            (a + 5L).Print("a + 5:");
            (a - 2L).Print("a - 2:");
            (a * 3L).Print("a * 3:");
            (a / 2L).Print("a / 2:");
            (a % 3L).Print("a % 3:");

            Section("14. Ділення на нуль");
            var dz = a / 0L;
            dz.Print("a / 0:");
            Console.WriteLine($"CodeError = {dz.CodeError}");

            Section("15. Побітові: матриця op матриця");
            var p = new MatrixLong(2, 2, 12L);
            var q = new MatrixLong(2, 2, 10L);
            p.Print("p (12=1100):"); q.Print("q (10=1010):");
            (p | q).Print("p | q (очік. 14):");
            (p ^ q).Print("p ^ q (очік. 6):");
            (p & q).Print("p & q (очік. 8):");

            Section("16. Побітові зсуви");
            p.Print("p (12):");
            (p >> 1).Print("p >> 1 (очік. 6):");
            (p << 1).Print("p << 1 (очік. 24):");

            Section("17. Побітові: матриця op скаляр");
            (p | 15UL).Print("p | 15:");
            (p ^ 7UL).Print("p ^ 7:");
            (p & 14UL).Print("p & 14:");

            Section("18. == та !=");
            var e1 = new MatrixLong(2, 2, 7L);
            var e2 = new MatrixLong(2, 2, 7L);
            var e3 = new MatrixLong(2, 2, 9L);
            Console.WriteLine($"e1 == e2: {e1 == e2}  (очік. True)");
            Console.WriteLine($"e1 == e3: {e1 == e3}  (очік. False)");
            Console.WriteLine($"e1 != e3: {e1 != e3}  (очік. True)");

            Section("19. Порівняння");
            var lo = new MatrixLong(2, 2, 2L);
            var hi = new MatrixLong(2, 2, 9L);
            Console.WriteLine($"hi >  lo: {hi > lo}   (очік. True)");
            Console.WriteLine($"hi >= lo: {hi >= lo}   (очік. True)");
            Console.WriteLine($"lo <  hi: {lo < hi}   (очік. True)");
            Console.WriteLine($"lo <= hi: {lo <= hi}   (очік. True)");
            Console.WriteLine($"hi >  hi: {hi > hi}  (очік. False)");
            Console.WriteLine($"hi >= hi: {hi >= hi}   (очік. True)");

            Console.WriteLine();
            Console.WriteLine(new string('═', 54));
            Console.WriteLine("  Тестування завершено.");
            Console.WriteLine(new string('═', 54));
        }
        static void MoneyTest()
        {
            var m = new Money(10, 5);
            m.Print();

            // Індексатор
            Console.WriteLine($"m[0] = {m[0]}");
            Console.WriteLine($"m[1] = {m[1]}");
            m[0] = 20;
            m[1] = 3;
            m.Print();

            try { _ = m[5]; }
            catch (IndexOutOfRangeException ex)
            { Console.WriteLine(ex.Message); }

            // ++ / --
            m++;
            m.Print();
            m--;
            m.Print();

            // Оператор !
            Console.WriteLine(!m);
            var empty = new Money(5, 0);
            Console.WriteLine(!empty);

            // Бінарний +
            Money m2 = m + 7;
            m2.Print();

            // Перетворення типів
            string s = m;
            Console.WriteLine(s);

            Money m3 = (Money)"50:4";
            m3.Print();

            try { Money _ = (Money)"bad_input"; }
            catch (FormatException ex)
            { Console.WriteLine(ex.Message); }
        }
        static void VectorLongTest()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            // ── Конструктори ─────────────────────────────────────────
            Section("1. Конструктори");
            var v0 = new VectorLong();            // без параметрів
            var v1 = new VectorLong(4);           // розмір 4, нулі
            var v2 = new VectorLong(4, 10L);      // розмір 4, всі = 10
            var v3 = new VectorLong(3, 5L);       // розмір 3, всі = 5
            v0.Print("v0 (розмір 1, =0)");
            v1.Print("v1 (розмір 4, =0)");
            v2.Print("v2 (розмір 4, =10)");
            v3.Print("v3 (розмір 3, =5)");
            Console.WriteLine($"Кількість векторів: {VectorLong.Count()}");

            // ── SetAll ────────────────────────────────────────────────
            Section("2. SetAll");
            v1.SetAll(3L);
            v1.Print("v1 після SetAll(3)");

            // ── Властивість Size ──────────────────────────────────────
            Section("3. Властивість Size");
            Console.WriteLine($"v2.Size = {v2.Size}");

            // ── Індексатор ────────────────────────────────────────────
            Section("4. Індексатор");
            Console.WriteLine($"v2[0] = {v2[0]}");
            v2[0] = 99;
            Console.WriteLine($"v2[0] після запису 99 = {v2[0]}");
            _ = v2[10];   // невірний індекс — читання
            Console.WriteLine($"v2.CodeError після v2[10] = {v2.CodeError}");
            v2[(uint)10] = 42;  // невірний індекс — запис
            Console.WriteLine($"v2.CodeError після запису v2[10]=42 = {v2.CodeError}");
            v2[0] = 10;   // відновлюємо

            // ── ++ / -- ───────────────────────────────────────────────
            Section("5. ++ та --");
            v2.Print("v2 до ++");
            v2++;
            v2.Print("v2 після ++");
            v2--;
            v2.Print("v2 після --");

            // ── true / false ──────────────────────────────────────────
            Section("6. true / false");
            var vz = new VectorLong(3, 0L);
            Console.WriteLine($"v2 (ненульовий): if(v2) → {(v2 ? "true" : "false")}");
            Console.WriteLine($"vz (нульовий):   if(vz) → {(vz ? "true" : "false")}");

            // ── ! ─────────────────────────────────────────────────────
            Section("7. Оператор !");
            Console.WriteLine($"!v2 (size=4) = {!v2}");
            var vEmpty = new VectorLong(0);
            Console.WriteLine($"!vEmpty (size=0) = {!vEmpty}");

            // ── ~ ─────────────────────────────────────────────────────
            Section("8. Побітове заперечення ~");
            var vBit = new VectorLong(3, 6L);
            vBit.Print("vBit (6)");
            (~vBit).Print("~vBit");

            // ── Арифметика: однаковий розмір ──────────────────────────
            Section("9. Арифметика: вектор op вектор (однаковий розмір)");
            var a = new VectorLong(4, 8L);
            var b = new VectorLong(4, 3L);
            a.Print("a"); b.Print("b");
            (a + b).Print("a + b");
            (a - b).Print("a - b");
            (a * b).Print("a * b");
            (a / b).Print("a / b");
            (a % b).Print("a % b");

            // ── Арифметика: різний розмір ─────────────────────────────
            Section("10. Арифметика: вектор op вектор (різний розмір)");
            var big = new VectorLong(5, 10L);
            var small = new VectorLong(3, 4L);
            big.Print("big   (5 ел., =10)");
            small.Print("small (3 ел., =4)");
            (big + small).Print("big + small (5 ел.)");
            (big - small).Print("big - small (5 ел.)");
            (big * small).Print("big * small (5 ел.)");

            // ── Арифметика: вектор + скаляр ──────────────────────────
            Section("11. Арифметика: вектор op скаляр");
            a.Print("a (=8)");
            (a + 5L).Print("a + 5");
            (a - 2L).Print("a - 2");
            (a * 3L).Print("a * 3");
            (a / 2L).Print("a / 2");
            (a % 3L).Print("a % 3");

            // ── Ділення на нуль ───────────────────────────────────────
            Section("12. Ділення на нуль");
            var dz = a / 0L;
            dz.Print("a / 0");
            Console.WriteLine($"codeError = {dz.CodeError}");

            // ── Побітові: вектор op вектор ────────────────────────────
            Section("13. Побітові: вектор op вектор");
            var p = new VectorLong(3, 12L);   // 1100
            var q = new VectorLong(3, 10L);   // 1010
            p.Print("p (12 = 1100)"); q.Print("q (10 = 1010)");
            (p | q).Print("p | q  (очікується 14 = 1110)");
            (p ^ q).Print("p ^ q  (очікується  6 = 0110)");
            (p & q).Print("p & q  (очікується  8 = 1000)");

            Section("14. Побітові зсуви");
            p.Print("p (12)");
            (p >> 1).Print("p >> 1  (очікується 6)");
            (p << 1).Print("p << 1  (очікується 24)");

            Section("15. Побітові: вектор op скаляр");
            (p | 15L).Print("p | 15   (очікується 15)");
            (p ^ 7L).Print("p ^ 7    (очікується 11)");
            (p & 14L).Print("p & 14  (очікується 12)");

            // ── == та != ──────────────────────────────────────────────
            Section("16. == та !=");
            var e1 = new VectorLong(3, 7L);
            var e2 = new VectorLong(3, 7L);
            var e3 = new VectorLong(3, 9L);
            e1.Print("e1 (7)"); e2.Print("e2 (7)"); e3.Print("e3 (9)");
            Console.WriteLine($"e1 == e2 : {e1 == e2}  (очікується True)");
            Console.WriteLine($"e1 == e3 : {e1 == e3}  (очікується False)");
            Console.WriteLine($"e1 != e3 : {e1 != e3}  (очікується True)");

            // ── Порівняння ────────────────────────────────────────────
            Section("17. Порівняння");
            var lo = new VectorLong(3, 2L);
            var hi = new VectorLong(3, 9L);
            lo.Print("lo (2)"); hi.Print("hi (9)");
            Console.WriteLine($"hi >  lo : {hi > lo}   (очікується True)");
            Console.WriteLine($"hi >= lo : {hi >= lo}   (очікується True)");
            Console.WriteLine($"lo <  hi : {lo < hi}   (очікується True)");
            Console.WriteLine($"lo <= hi : {lo <= hi}   (очікується True)");
            Console.WriteLine($"hi >  hi : {hi > hi}  (очікується False)");
            Console.WriteLine($"hi >= hi : {hi >= hi}   (очікується True)");

            Console.WriteLine();
            Console.WriteLine(new string('═', 52));
            Console.WriteLine("  Тестування завершено.");
            Console.WriteLine(new string('═', 52));
        }
    }
}
