using System;

namespace Lab4MatrixLong
{
    public class VectorLongM
    {
        public long[] IntArray;
        public uint size;

        public VectorLongM(uint n, long val = 0)
        {
            size = n;
            IntArray = new long[n];
            for (uint i = 0; i < n; i++) IntArray[i] = val;
        }
    }

    public class MatrixLong
    {
        protected long[,] LongArray;
        protected uint n, m;
        protected int codeError;
        protected static int num_m = 0;

        public MatrixLong()
        {
            n = 1; m = 1;
            LongArray = new long[1, 1];
            LongArray[0, 0] = 0;
            codeError = 0;
            num_m++;
        }

        public MatrixLong(uint rows, uint cols)
        {
            n = rows; m = cols;
            LongArray = new long[n, m];
            codeError = 0;
            num_m++;
        }

        public MatrixLong(uint rows, uint cols, long initVal)
        {
            n = rows; m = cols;
            LongArray = new long[n, m];
            for (uint i = 0; i < n; i++)
                for (uint j = 0; j < m; j++)
                    LongArray[i, j] = initVal;
            codeError = 0;
            num_m++;
        }

        ~MatrixLong()
        {
            Console.WriteLine($"[~MatrixLong] Матриця {n}x{m} знищена.");
            num_m--;
        }

        public uint Rows => n;
        public uint Cols => m;

        public int CodeError
        {
            get => codeError;
            set => codeError = value;
        }

        public long this[uint i, uint j]
        {
            get
            {
                if (i >= n || j >= m) { codeError = -1; return 0; }
                return LongArray[i, j];
            }
            set
            {
                if (i >= n || j >= m) { codeError = -1; return; }
                LongArray[i, j] = value;
            }
        }

        public long this[uint k]
        {
            get
            {
                uint i = k / m, j = k % m;
                if (i >= n || j >= m) { codeError = -1; return 0; }
                return LongArray[i, j];
            }
            set
            {
                uint i = k / m, j = k % m;
                if (i >= n || j >= m) { codeError = -1; return; }
                LongArray[i, j] = value;
            }
        }

        public void Input()
        {
            Console.WriteLine($"Введіть елементи матриці {n}x{m}:");
            for (uint i = 0; i < n; i++)
                for (uint j = 0; j < m; j++)
                {
                    Console.Write($"  [{i},{j}]: ");
                    if (long.TryParse(Console.ReadLine(), out long val))
                        LongArray[i, j] = val;
                    else
                        LongArray[i, j] = 0;
                }
        }

        public void Print(string label = "")
        {
            if (label != "") Console.WriteLine(label);
            for (uint i = 0; i < n; i++)
            {
                Console.Write("  [ ");
                for (uint j = 0; j < m; j++)
                    Console.Write($"{LongArray[i, j],6}{(j < m - 1 ? ", " : "")}");
                Console.WriteLine(" ]");
            }
        }

        public void SetAll(long val)
        {
            for (uint i = 0; i < n; i++)
                for (uint j = 0; j < m; j++)
                    LongArray[i, j] = val;
        }

        public static int Count() => num_m;

        public static MatrixLong operator ++(MatrixLong a)
        {
            for (uint i = 0; i < a.n; i++)
                for (uint j = 0; j < a.m; j++)
                    a.LongArray[i, j]++;
            return a;
        }

        public static MatrixLong operator --(MatrixLong a)
        {
            for (uint i = 0; i < a.n; i++)
                for (uint j = 0; j < a.m; j++)
                    a.LongArray[i, j]--;
            return a;
        }

        public static bool operator true(MatrixLong a)
        {
            if (a.n == 0 || a.m == 0) return false;
            for (uint i = 0; i < a.n; i++)
                for (uint j = 0; j < a.m; j++)
                    if (a.LongArray[i, j] == 0) return false;
            return true;
        }

        public static bool operator false(MatrixLong a)
        {
            if (a.n == 0 || a.m == 0) return true;
            for (uint i = 0; i < a.n; i++)
                for (uint j = 0; j < a.m; j++)
                    if (a.LongArray[i, j] != 0) return false;
            return true;
        }

        public static bool operator !(MatrixLong a) => a.n != 0 && a.m != 0;

        public static MatrixLong operator ~(MatrixLong a)
        {
            var r = new MatrixLong(a.n, a.m);
            for (uint i = 0; i < a.n; i++)
                for (uint j = 0; j < a.m; j++)
                    r.LongArray[i, j] = ~a.LongArray[i, j];
            return r;
        }

        private static (long[,] A, long[,] B, uint rows, uint cols) Align(MatrixLong x, MatrixLong y)
        {
            uint rows = Math.Max(x.n, y.n);
            uint cols = Math.Max(x.m, y.m);
            var A = new long[rows, cols];
            var B = new long[rows, cols];
            for (uint i = 0; i < x.n; i++)
                for (uint j = 0; j < x.m; j++)
                    A[i, j] = x.LongArray[i, j];
            for (uint i = 0; i < y.n; i++)
                for (uint j = 0; j < y.m; j++)
                    B[i, j] = y.LongArray[i, j];
            return (A, B, rows, cols);
        }

        public static MatrixLong operator +(MatrixLong x, MatrixLong y)
        {
            var (A, B, rows, cols) = Align(x, y);
            var r = new MatrixLong(rows, cols);
            for (uint i = 0; i < rows; i++)
                for (uint j = 0; j < cols; j++)
                    r.LongArray[i, j] = A[i, j] + B[i, j];
            return r;
        }

        public static MatrixLong operator +(MatrixLong x, long s)
        {
            var r = new MatrixLong(x.n, x.m);
            for (uint i = 0; i < x.n; i++)
                for (uint j = 0; j < x.m; j++)
                    r.LongArray[i, j] = x.LongArray[i, j] + s;
            return r;
        }

        public static MatrixLong operator +(long s, MatrixLong x) => x + s;

        public static MatrixLong operator -(MatrixLong x, MatrixLong y)
        {
            var (A, B, rows, cols) = Align(x, y);
            var r = new MatrixLong(rows, cols);
            for (uint i = 0; i < rows; i++)
                for (uint j = 0; j < cols; j++)
                    r.LongArray[i, j] = A[i, j] - B[i, j];
            return r;
        }

        public static MatrixLong operator -(MatrixLong x, long s)
        {
            var r = new MatrixLong(x.n, x.m);
            for (uint i = 0; i < x.n; i++)
                for (uint j = 0; j < x.m; j++)
                    r.LongArray[i, j] = x.LongArray[i, j] - s;
            return r;
        }

        public static MatrixLong operator *(MatrixLong x, MatrixLong y)
        {
            if (x.m != y.n)
            {
                x.codeError = -1;
                return new MatrixLong(x.n, y.m);
            }
            var r = new MatrixLong(x.n, y.m);
            for (uint i = 0; i < x.n; i++)
                for (uint j = 0; j < y.m; j++)
                    for (uint k = 0; k < x.m; k++)
                        r.LongArray[i, j] += x.LongArray[i, k] * y.LongArray[k, j];
            return r;
        }

        public static MatrixLong operator *(MatrixLong x, VectorLongM v)
        {
            if (x.m != v.size) { x.codeError = -1; return new MatrixLong(x.n, 1); }
            var r = new MatrixLong(x.n, 1);
            for (uint i = 0; i < x.n; i++)
                for (uint k = 0; k < x.m; k++)
                    r.LongArray[i, 0] += x.LongArray[i, k] * v.IntArray[k];
            return r;
        }

        public static MatrixLong operator *(MatrixLong x, long s)
        {
            var r = new MatrixLong(x.n, x.m);
            for (uint i = 0; i < x.n; i++)
                for (uint j = 0; j < x.m; j++)
                    r.LongArray[i, j] = x.LongArray[i, j] * s;
            return r;
        }

        public static MatrixLong operator *(long s, MatrixLong x) => x * s;

        public static MatrixLong operator /(MatrixLong x, MatrixLong y)
        {
            var (A, B, rows, cols) = Align(x, y);
            var r = new MatrixLong(rows, cols);
            for (uint i = 0; i < rows; i++)
                for (uint j = 0; j < cols; j++)
                {
                    if (B[i, j] == 0) { r.codeError = -1; r.LongArray[i, j] = 0; }
                    else r.LongArray[i, j] = A[i, j] / B[i, j];
                }
            return r;
        }

        public static MatrixLong operator /(MatrixLong x, long s)
        {
            var r = new MatrixLong(x.n, x.m);
            if (s == 0) { r.codeError = -1; return r; }
            for (uint i = 0; i < x.n; i++)
                for (uint j = 0; j < x.m; j++)
                    r.LongArray[i, j] = x.LongArray[i, j] / s;
            return r;
        }

        public static MatrixLong operator %(MatrixLong x, MatrixLong y)
        {
            var (A, B, rows, cols) = Align(x, y);
            var r = new MatrixLong(rows, cols);
            for (uint i = 0; i < rows; i++)
                for (uint j = 0; j < cols; j++)
                {
                    if (B[i, j] == 0) { r.codeError = -1; r.LongArray[i, j] = 0; }
                    else r.LongArray[i, j] = A[i, j] % B[i, j];
                }
            return r;
        }

        public static MatrixLong operator %(MatrixLong x, long s)
        {
            var r = new MatrixLong(x.n, x.m);
            if (s == 0) { r.codeError = -1; return r; }
            for (uint i = 0; i < x.n; i++)
                for (uint j = 0; j < x.m; j++)
                    r.LongArray[i, j] = x.LongArray[i, j] % s;
            return r;
        }

        public static MatrixLong operator |(MatrixLong x, MatrixLong y)
        {
            var (A, B, rows, cols) = Align(x, y);
            var r = new MatrixLong(rows, cols);
            for (uint i = 0; i < rows; i++)
                for (uint j = 0; j < cols; j++)
                    r.LongArray[i, j] = A[i, j] | B[i, j];
            return r;
        }

        public static MatrixLong operator |(MatrixLong x, ulong s)
        {
            var r = new MatrixLong(x.n, x.m);
            for (uint i = 0; i < x.n; i++)
                for (uint j = 0; j < x.m; j++)
                    r.LongArray[i, j] = (long)((ulong)x.LongArray[i, j] | s);
            return r;
        }

        public static MatrixLong operator ^(MatrixLong x, MatrixLong y)
        {
            var (A, B, rows, cols) = Align(x, y);
            var r = new MatrixLong(rows, cols);
            for (uint i = 0; i < rows; i++)
                for (uint j = 0; j < cols; j++)
                    r.LongArray[i, j] = A[i, j] ^ B[i, j];
            return r;
        }

        public static MatrixLong operator ^(MatrixLong x, ulong s)
        {
            var r = new MatrixLong(x.n, x.m);
            for (uint i = 0; i < x.n; i++)
                for (uint j = 0; j < x.m; j++)
                    r.LongArray[i, j] = (long)((ulong)x.LongArray[i, j] ^ s);
            return r;
        }

        public static MatrixLong operator &(MatrixLong x, MatrixLong y)
        {
            var (A, B, rows, cols) = Align(x, y);
            var r = new MatrixLong(rows, cols);
            for (uint i = 0; i < rows; i++)
                for (uint j = 0; j < cols; j++)
                    r.LongArray[i, j] = A[i, j] & B[i, j];
            return r;
        }

        public static MatrixLong operator &(MatrixLong x, ulong s)
        {
            var r = new MatrixLong(x.n, x.m);
            for (uint i = 0; i < x.n; i++)
                for (uint j = 0; j < x.m; j++)
                    r.LongArray[i, j] = (long)((ulong)x.LongArray[i, j] & s);
            return r;
        }

        public static MatrixLong operator >>(MatrixLong x, int shift)
        {
            var r = new MatrixLong(x.n, x.m);
            for (uint i = 0; i < x.n; i++)
                for (uint j = 0; j < x.m; j++)
                    r.LongArray[i, j] = x.LongArray[i, j] >> shift;
            return r;
        }

        public static MatrixLong operator <<(MatrixLong x, int shift)
        {
            var r = new MatrixLong(x.n, x.m);
            for (uint i = 0; i < x.n; i++)
                for (uint j = 0; j < x.m; j++)
                    r.LongArray[i, j] = x.LongArray[i, j] << shift;
            return r;
        }

        public static bool operator ==(MatrixLong x, MatrixLong y)
        {
            if (x.n != y.n || x.m != y.m) return false;
            for (uint i = 0; i < x.n; i++)
                for (uint j = 0; j < x.m; j++)
                    if (x.LongArray[i, j] != y.LongArray[i, j]) return false;
            return true;
        }

        public static bool operator !=(MatrixLong x, MatrixLong y) => !(x == y);

        public override bool Equals(object obj) => obj is MatrixLong m && this == m;
        public override int GetHashCode() => HashCode.Combine(LongArray, n, m);

        public static bool operator >(MatrixLong x, MatrixLong y)
        {
            if (x.n != y.n || x.m != y.m) return false;
            for (uint i = 0; i < x.n; i++)
                for (uint j = 0; j < x.m; j++)
                    if (x.LongArray[i, j] <= y.LongArray[i, j]) return false;
            return true;
        }

        public static bool operator >=(MatrixLong x, MatrixLong y)
        {
            if (x.n != y.n || x.m != y.m) return false;
            for (uint i = 0; i < x.n; i++)
                for (uint j = 0; j < x.m; j++)
                    if (x.LongArray[i, j] < y.LongArray[i, j]) return false;
            return true;
        }

        public static bool operator <(MatrixLong x, MatrixLong y)
        {
            if (x.n != y.n || x.m != y.m) return false;
            for (uint i = 0; i < x.n; i++)
                for (uint j = 0; j < x.m; j++)
                    if (x.LongArray[i, j] >= y.LongArray[i, j]) return false;
            return true;
        }

        public static bool operator <=(MatrixLong x, MatrixLong y)
        {
            if (x.n != y.n || x.m != y.m) return false;
            for (uint i = 0; i < x.n; i++)
                for (uint j = 0; j < x.m; j++)
                    if (x.LongArray[i, j] > y.LongArray[i, j]) return false;
            return true;
        }
    }


}