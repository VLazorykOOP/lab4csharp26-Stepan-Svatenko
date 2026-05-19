using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4CSharpVectorLong
{

    // --    Створити клас VectorLong (вектор цілих чисел). Розробити такі 
    // елементи класу:  
    // • Поля (захищені): 
    // − long [] IntArray; // масив 
    // − uint size; // розмір вектора 
    // − int codeError; // код помилки 
    // − static uint num_vl; // кількість векторів 
    // • Конструктори:  
    // − конструктор  без  параметрів(виділяє  місце  для  одного 
    // елемента та ініціалізує його в нуль); 
    // − конструктор  з  одним  параметром  - розмір  вектора 
    // (виділяє місце та ініціалізує значенням нуль); 
    // − конструктор  із двома  параметрами  -  розмір  вектора  та 
    // значення ініціалізації(виділяє місце -  значення першого 
    // аргументу та ініціалізує значенням другого аргументу). 
    // • Деструктор (виводить повідомлення в консоль). 
    // • Методи, що дозволяють: 
    // − ввести елементи вектора з клавіатури; 
    // − вивести елементи вектора на екран; 
    // − присвоєння елементам масиву вектора деякого значення, 
    // яке задається як параметр; 
    // − статичний  метод,  що  підраховує  кількість  векторів 
    // даного типу; 
    // − присвоїти елементам масиву деяке значення (параметр); 
    // • Властивості: 
    // − повертає  розмірність  вектора  (доступні  лише  для 
    // читання); 
    // − дозволяє  отримати-встановити  значення  поля 
    // codeError (доступні для читання і запису).  
    // • Індексатор, що дозволяє звертатися по індексу до масиву, якщо 
    // значення  індексу  невірне  в  поле  codeError  записується  -
    // 1(при читанні повертається значення –  0, при записі –  запис 
    // здійснюється тільки в поле codeError); . 
    // • Перевантаження:  
    // − унарних  операції  + +  (- -):  одночасно  збільшує 
    // (зменшує) значення елементів масиву на 1;  
    // − сталих true  і false: звертання до екземпляра класу дає 
    // значення true, якщо size  не дорівнює –  нулю, або всі 
    // елементи масиву не рівні – нулю, інакше false;  
    // − унарної  логічної  операції  !  (заперечення):  повертає 
    // значення true, якщо елементи якщо size не дорівнює – 
    // нулю, інакше false;  
    // − унарної  побітової  операції    ~  (заперечення):  повертає 
    // побітове  заперечення  для  всіх  елементів  масиву  класу 
    // вектор; 
    // − арифметичних бінарні операції (): 
    // a.  + додавання: 
    // i. для двох векторів 
    // ii. для вектора і скаляра типу long 
    // b.  - (віднімання):  
    // i. для двох векторів 
    // ii. для вектора і скаляра типу long; 
    // c.  *(множення)  
    // i. для двох векторів 
    // ii. для вектора і скаляра типу long; 
    // d.  / (ділення)  
    // i. для двох векторів 
    // ii. для вектора і скаляра типу long; 
    // e.  % (остача від ділення)  
    // i. для двох векторів 
    // ii. для вектора і скаляра типу long; 
    // − побітові бінарні операції  
    // a.  | (побітове додавання)  
    // i. для двох векторів 
    // ii. для вектора і скаляра типу long; 
    // b.  ^ (побітове додавання за модулем 2)  
    // i. для двох векторів 
    // ii. для вектора і скаляра типу long; 
    // c.  | (побітове множення)  
    // i. двох векторів 
    // ii. вектора і скаляра типу int; 
    // d.  >> (побітовий зсув право) 
    // i. для двох векторів 
    // ii. для вектора і скаляра типу long; 
    // e.  << (побітовий зсув ліво) 
    // i. для двох векторів 
    // ii. для вектора і скаляра типу long; 
    // − операцій  ==(рівності)  та  != (нерівності),  функція-
    // операція виконує певні дії над кожною парою елементів 
    // векторів за індексом; 
    // − порівняння  (функція-операція  виконує  певні  дії  над 
    // кожною парою елементів векторів за індексом) 
    // a.  > (більше) для двох векторів;  
    // b.  >= (більше рівне) для двох векторів; 
    // c.  < (менше) для двох векторів; 
    // d.  <=(менше рівне) для двох векторів. ++

    public class VectorLong
    {
        protected long[] IntArray;
        protected uint size;
        protected int codeError;
        protected static uint num_vl = 0;

        public VectorLong()
        {
            size = 1;
            IntArray = new long[size];
            IntArray[0] = 0;
            codeError = 0;
            num_vl++;
        }

        public VectorLong(uint n)
        {
            size = n;
            IntArray = new long[size];
            for (uint i = 0; i < size; i++) IntArray[i] = 0;
            codeError = 0;
            num_vl++;
        }

        public VectorLong(uint n, long initVal)
        {
            size = n;
            IntArray = new long[size];
            for (uint i = 0; i < size; i++) IntArray[i] = initVal;
            codeError = 0;
            num_vl++;
        }

        ~VectorLong()
        {
            Console.WriteLine($"[~VectorLong] Вектор розміром {size} знищено.");
            num_vl--;
        }

        public uint Size => size;

        public int CodeError
        {
            get => codeError;
            set => codeError = value;
        }

        public long this[uint index]
        {
            get
            {
                if (index >= size) { codeError = -1; return 0; }
                return IntArray[index];
            }
            set
            {
                if (index >= size) { codeError = -1; return; }
                IntArray[index] = value;
            }
        }

        public void Input()
        {
            Console.WriteLine($"Введіть {size} елементів вектора:");
            for (uint i = 0; i < size; i++)
            {
                Console.Write($"  [{i}]: ");
                if (long.TryParse(Console.ReadLine(), out long val))
                    IntArray[i] = val;
                else
                { Console.WriteLine("  Невірний ввід, записано 0."); IntArray[i] = 0; }
            }
        }

        public void Print(string label = "")
        {
            if (!string.IsNullOrEmpty(label)) Console.Write(label + ": ");
            Console.Write("[ ");
            for (uint i = 0; i < size; i++)
                Console.Write(IntArray[i] + (i < size - 1 ? ", " : " "));
            Console.WriteLine("]");
        }

        public void SetAll(long val)
        {
            for (uint i = 0; i < size; i++) IntArray[i] = val;
        }

        public static uint Count() => num_vl;


        public static VectorLong operator ++(VectorLong v)
        {
            for (uint i = 0; i < v.size; i++) v.IntArray[i]++;
            return v;
        }

        public static VectorLong operator --(VectorLong v)
        {
            for (uint i = 0; i < v.size; i++) v.IntArray[i]--;
            return v;
        }

        public static bool operator true(VectorLong v)
        {
            if (v.size == 0) return false;
            foreach (var el in v.IntArray) if (el == 0) return false;
            return true;
        }

        public static bool operator false(VectorLong v)
        {
            if (v.size == 0) return true;
            foreach (var el in v.IntArray) if (el != 0) return false;
            return true;
        }

        public static bool operator !(VectorLong v) => v.size != 0;

        public static VectorLong operator ~(VectorLong v)
        {
            var result = new VectorLong(v.size);
            for (uint i = 0; i < v.size; i++) result.IntArray[i] = ~v.IntArray[i];
            return result;
        }

        private static (long[] a, long[] b, uint len) Align(VectorLong x, VectorLong y)
        {
            uint len = Math.Max(x.size, y.size);
            long[] a = new long[len];
            long[] b = new long[len];
            for (uint i = 0; i < x.size; i++) a[i] = x.IntArray[i];
            for (uint i = 0; i < y.size; i++) b[i] = y.IntArray[i];
            return (a, b, len);
        }


        public static VectorLong operator +(VectorLong x, VectorLong y)
        {
            var (a, b, len) = Align(x, y);
            var r = new VectorLong(len);
            for (uint i = 0; i < len; i++) r.IntArray[i] = a[i] + b[i];
            return r;
        }
        public static VectorLong operator +(VectorLong x, long s)
        {
            var r = new VectorLong(x.size);
            for (uint i = 0; i < x.size; i++) r.IntArray[i] = x.IntArray[i] + s;
            return r;
        }
        public static VectorLong operator +(long s, VectorLong x) => x + s;

        public static VectorLong operator -(VectorLong x, VectorLong y)
        {
            var (a, b, len) = Align(x, y);
            var r = new VectorLong(len);
            for (uint i = 0; i < len; i++) r.IntArray[i] = a[i] - b[i];
            return r;
        }
        public static VectorLong operator -(VectorLong x, long s)
        {
            var r = new VectorLong(x.size);
            for (uint i = 0; i < x.size; i++) r.IntArray[i] = x.IntArray[i] - s;
            return r;
        }

        public static VectorLong operator *(VectorLong x, VectorLong y)
        {
            var (a, b, len) = Align(x, y);
            var r = new VectorLong(len);
            for (uint i = 0; i < len; i++) r.IntArray[i] = a[i] * b[i];
            return r;
        }
        public static VectorLong operator *(VectorLong x, long s)
        {
            var r = new VectorLong(x.size);
            for (uint i = 0; i < x.size; i++) r.IntArray[i] = x.IntArray[i] * s;
            return r;
        }
        public static VectorLong operator *(long s, VectorLong x) => x * s;

        public static VectorLong operator /(VectorLong x, VectorLong y)
        {
            var (a, b, len) = Align(x, y);
            var r = new VectorLong(len);
            for (uint i = 0; i < len; i++)
            {
                if (b[i] == 0) { r.codeError = -1; r.IntArray[i] = 0; }
                else r.IntArray[i] = a[i] / b[i];
            }
            return r;
        }
        public static VectorLong operator /(VectorLong x, long s)
        {
            var r = new VectorLong(x.size);
            if (s == 0) { r.codeError = -1; return r; }
            for (uint i = 0; i < x.size; i++) r.IntArray[i] = x.IntArray[i] / s;
            return r;
        }

        public static VectorLong operator %(VectorLong x, VectorLong y)
        {
            var (a, b, len) = Align(x, y);
            var r = new VectorLong(len);
            for (uint i = 0; i < len; i++)
            {
                if (b[i] == 0) { r.codeError = -1; r.IntArray[i] = 0; }
                else r.IntArray[i] = a[i] % b[i];
            }
            return r;
        }
        public static VectorLong operator %(VectorLong x, long s)
        {
            var r = new VectorLong(x.size);
            if (s == 0) { r.codeError = -1; return r; }
            for (uint i = 0; i < x.size; i++) r.IntArray[i] = x.IntArray[i] % s;
            return r;
        }


        public static VectorLong operator |(VectorLong x, VectorLong y)
        {
            var (a, b, len) = Align(x, y);
            var r = new VectorLong(len);
            for (uint i = 0; i < len; i++) r.IntArray[i] = a[i] | b[i];
            return r;
        }
        public static VectorLong operator |(VectorLong x, long s)
        {
            var r = new VectorLong(x.size);
            for (uint i = 0; i < x.size; i++) r.IntArray[i] = x.IntArray[i] | s;
            return r;
        }

        public static VectorLong operator ^(VectorLong x, VectorLong y)
        {
            var (a, b, len) = Align(x, y);
            var r = new VectorLong(len);
            for (uint i = 0; i < len; i++) r.IntArray[i] = a[i] ^ b[i];
            return r;
        }
        public static VectorLong operator ^(VectorLong x, long s)
        {
            var r = new VectorLong(x.size);
            for (uint i = 0; i < x.size; i++) r.IntArray[i] = x.IntArray[i] ^ s;
            return r;
        }

        public static VectorLong operator &(VectorLong x, VectorLong y)
        {
            var (a, b, len) = Align(x, y);
            var r = new VectorLong(len);
            for (uint i = 0; i < len; i++) r.IntArray[i] = a[i] & b[i];
            return r;
        }
        public static VectorLong operator &(VectorLong x, long s)
        {
            var r = new VectorLong(x.size);
            for (uint i = 0; i < x.size; i++) r.IntArray[i] = x.IntArray[i] & s;
            return r;
        }

        public static VectorLong operator >>(VectorLong x, int shift)
        {
            var r = new VectorLong(x.size);
            for (uint i = 0; i < x.size; i++) r.IntArray[i] = x.IntArray[i] >> shift;
            return r;
        }

        public static VectorLong operator <<(VectorLong x, int shift)
        {
            var r = new VectorLong(x.size);
            for (uint i = 0; i < x.size; i++) r.IntArray[i] = x.IntArray[i] << shift;
            return r;
        }


        public static bool operator ==(VectorLong x, VectorLong y)
        {
            if (x.size != y.size) return false;
            for (uint i = 0; i < x.size; i++)
                if (x.IntArray[i] != y.IntArray[i]) return false;
            return true;
        }
        public static bool operator !=(VectorLong x, VectorLong y) => !(x == y);

        public override bool Equals(object obj) =>
            obj is VectorLong v && this == v;
        public override int GetHashCode() =>
            HashCode.Combine(IntArray, size);


        public static bool operator >(VectorLong x, VectorLong y)
        {
            if (x.size != y.size) return false;
            for (uint i = 0; i < x.size; i++)
                if (x.IntArray[i] <= y.IntArray[i]) return false;
            return true;
        }
        public static bool operator >=(VectorLong x, VectorLong y)
        {
            if (x.size != y.size) return false;
            for (uint i = 0; i < x.size; i++)
                if (x.IntArray[i] < y.IntArray[i]) return false;
            return true;
        }
        public static bool operator <(VectorLong x, VectorLong y)
        {
            if (x.size != y.size) return false;
            for (uint i = 0; i < x.size; i++)
                if (x.IntArray[i] >= y.IntArray[i]) return false;
            return true;
        }
        public static bool operator <=(VectorLong x, VectorLong y)
        {
            if (x.size != y.size) return false;
            for (uint i = 0; i < x.size; i++)
                if (x.IntArray[i] > y.IntArray[i]) return false;
            return true;
        }

    }
}
