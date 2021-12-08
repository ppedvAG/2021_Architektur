using System;
using System.Collections.Generic;
using System.Linq;

namespace HalloEFCore
{
    delegate void EinfacherDelegate();
    delegate void DelegateMitPara(string msg);
    delegate long CalcDelegate(int a, int b);

    internal class HalloDelegate
    {
        public HalloDelegate()
        {
            EinfacherDelegate meinDele = EinfacheMethode;
            Action alsAction = EinfacheMethode;
            Action alsActionAno = delegate () { Console.WriteLine("Hallo"); };
            Action alsActionAno2 = () => { Console.WriteLine("Hallo"); };
            Action alsActionAno3 = () => Console.WriteLine("Hallo");

            DelegateMitPara delegateMitPara = MethodeMitPara;
            Action<string> alsActionMitPara = MethodeMitPara;
            Action<string> alsActionMitParaAno = (string x) => { Console.WriteLine(x); };
            Action<string> alsActionMitParaAno2 = (x) => Console.WriteLine(x);
            Action<string> alsActionMitParaAno3 = x => Console.WriteLine(x);

            CalcDelegate calcDele = Minus;
            Func<int, int, long> calcFunc = Sum;
            CalcDelegate calcAno = (int a, int b) => { return a + b; };
            CalcDelegate calcAno2 = (a, b) => { return a + b; };
            CalcDelegate calcAno3 = (a, b) => a + b;

            List<string> texte = new List<string>();
            texte.Where(x => x.StartsWith("b"));
            texte.Where(Filter);


            long res = calcDele.Invoke(12, 33);
        }

        private bool Filter(string x)
        {
            if(x.StartsWith("b"))
                return true;
            else
                return false;
        }

        private long Minus(int a, int b)
        {
            return a - b;
        }

        private long Sum(int a, int b)
        {
            return a + b;
        }

        private void MethodeMitPara(string name)
        {
            Console.WriteLine($"Hallo {name}");
        }

        void EinfacheMethode()
        {
            System.Console.WriteLine("Hallo");
        }
    }
}
