using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructurePractice.Test
{
    [TestClass]
    public class StringTest
    {
        [TestMethod]
        public void test()
        {
            var str1 = "abc";
            var str2 = str1;

            str1 = "def";

            Console.WriteLine(str2); // "def"
        }
    }
}
