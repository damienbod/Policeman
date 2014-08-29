using System;
using Policeman;

namespace PolicemanConsole
{
    public class TestClass
    {
        public TestClass(string notNull, int numberLargerThan5)
        {
            Policeman.Guard.Requires<ArgumentNullException>("notNull fdfsdfsd", notNull != null);
            //Policeman.Guard.Requires<ArgumentOutOfRangeException>(numberLargerThan5 > 5);
            Guard.ArgumentGreaterOrEqualThan(DateTime.Now, DateTime.Now.AddHours(3.0), "ddd");
            Guard.ArgumentNotNull(null, "TestANullArg");
        }

		private string HelloWorld(int importantParamWhichNeedsaGuard)
		{
			// throws a PolicemanException exception if incorrect
			Guard.Requires<PolicemanException>(
			 string.Format("Expecting Exception of type PolicemanException, arg= {0}", "importantParamWhichNeedsaGuard"),
			 importantParamWhichNeedsaGuard == 7
		   );

			return "Your may continue your logic...";
		}

		private string HelloMinMax(int min, int max)
		{
			Guard.ArgumentGreaterOrEqualThan(min, 3, "min");
			Guard.ArgumentLowerOrEqualThan(max, 4, "max");
			
			// Do you business logic
			return "Your may continue your logic...";
		}
    }
}
