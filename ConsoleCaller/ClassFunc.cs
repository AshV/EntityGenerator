using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleCaller
{
    class ClassFunc
    {
        static void Main(string[] args)
        {
            var list = new List<String>();

            Console.Write(FuncTest(new ClassFunc().retString));
            //    Console.Write(FuncTest(() => { return "Ashish"; }));
        }

        public static string FuncTest(Func<int, float, string> a)
        {
            return a.Invoke(1, 1);
        }
        public static Boolean PredicateTest(Predicate<string> a)
        {
            return a.Invoke("A");
        }
        public static void ActionTest(Action<String> a)
        {
            a.Invoke("S");
        }

        public string retString(int a, float b)
        {
            return "Success!";
        }
    }
}
