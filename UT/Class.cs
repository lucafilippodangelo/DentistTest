using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Xunit;

namespace UT
{
    public class Class
    {
        [Fact]
        public void EnsureTupleNotNull()
        {
            (string, int) bob = ("bob", 23);
            
            (string,int) GetPerson() => ("bob", 23);

            var x = GetPerson();
            Console.WriteLine(x.Item1);
            Assert.NotNull (x.Item1);
        }

        [Fact]
        public void TestFunc()
        {
            //TEST ON GENERIC
            string doSomething<T>(T theInput)
            {
                return theInput.GetType().ToString();
            }
            var ddd = doSomething(1);


            //TEST ON FUNC (delegate pointng to a method)
            Func<int, int> myExp2 = (n) => n*n;
            var yy = myExp2(5);


            //TEST ON NORMAL FUNC 
            Func<int, int> square = x => x * x;
            var aNumber = square(5);

            //LD I will package my expression "x => x * x" as an object 
            System.Linq.Expressions.Expression<Func<int, int>> myExpression = x => x * x;
            var anExpression = myExpression;


            int[] numbers = { 2, 3, 4, 5 };
            var squaredNumbers = numbers.Select(myExpression.Compile()); //apply for each number the expression
            var squaredNumbersTwo = numbers.Select(x => x * x); //same as above

            var dd = string.Join(" ", squaredNumbers);

            List<int> aList = new List<int>() {1,2,3}; 
            var hyjy =  aList.Select (myExpression.Compile());
            foreach (int anInt in hyjy)
            {
                var luca = anInt; //Output -> 1,4,9
            }
        }

    }
}
