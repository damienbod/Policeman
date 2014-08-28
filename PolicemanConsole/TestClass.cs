using System;

namespace PolicemanConsole
{
    public class TestClass
    {
        public TestClass(string notNull, int numberLargerThan5)
        {
            Policeman.Guard.Requires<ArgumentNullException>("notNull fdfsdfsd", notNull != null);
            //Policeman.Guard.Requires<ArgumentOutOfRangeException>(numberLargerThan5 > 5);
            Policeman.Guard.ArgumentGreaterOrEqualThan(DateTime.Now, DateTime.Now.AddHours(3.0), "ddd");
            Policeman.Guard.ArgumentNotNull(null, "TestANullArg");
        }
    }
}
