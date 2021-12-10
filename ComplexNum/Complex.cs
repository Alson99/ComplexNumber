using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComplexNum
{
    class Complex
    {
        /// Константа, очень маленькое число
        private const double eps = Double.Epsilon;

        /// Это свойства класса
        public double Re { get; set; }

        public double Im { get; set; }

        /// Конструкторы
        public Complex()
        {
        }

        public Complex(double re, double im)
        {
            Re = re;
            Im = im;
        }

        public Complex(double re)
        {
            Re = re;
        }

        public Complex(Complex other)
        {
            Re = other.Re;
            Im = other.Im;
        }

        // Метод для преобразования к строке(неэффективный)
        // override - переопределение(так как у object уже есть метод ToString) 
        //public override String ToString()
        //{
        //    String s = "";
        //    var aRe = Math.Abs(Re);
        //    var aIm = Math.Abs(Im);
        //    if (aRe > eps || aIm < eps) s += Re; /// Для корректного вывода при очень маленьких значениях
        //    if (aIm > eps)
        //    {
        //        s += (Im > 0) ? "+" : "-";
        //        if (Math.Abs(aIm-1.0) > eps) s += aIm;
        //        s += "i";
        //    }
        //    return s;
        //}

        /// Метод преобразования с сохранением памяти(эффективный)
        public override String ToString()
        {
            StringBuilder s = new StringBuilder(); /// Для сохранения памяти(так как += создаёт строку и хранит старую)
            var aRe = Math.Abs(Re);
            var aIm = Math.Abs(Im);
            if (aRe > eps || aIm < eps) s.Append(Re);
            if (aIm > eps)
            {
                s.Append((Im > 0) ? "+" : "-");
                if (Math.Abs(aIm - 1.0) > eps) s.Append(aIm);
                s.Append("i");
            }
            return s.ToString();
        }


        /// Сложение чисел
        public Complex Plus(Complex other)
        {
            return new Complex(Re + other.Re, Im + other.Im);
        }

        public Complex Plus(double value)
        {
            return new Complex(Re + value, Im);
        }

        /// Умножение чисел
        public Complex Times(Complex other)
        {
            return new Complex(
                Re * other.Re - Im * other.Im,
                Im * other.Re + Re * other.Im);
        }

        public Complex Times(double value)
        {
            return new Complex(
                Re * value,
                Im * value);
        }

        /// Деление чисел
        public Complex Div(Complex other)
        {
            var zn = other.Re * other.Re + other.Im * other.Im;
            return new Complex(
                (Re * other.Re + Im * other.Im) / zn,
                (Im * other.Re - Re * other.Im) / zn
                );
        }

        public Complex Div(double value)
        {
            return new Complex(Times(1 / value));
        }

        /// Модуль комплексного числа
        public double Abs()
        {
            return Math.Sqrt(Re * Re + Im * Im);
        }
    }
}
