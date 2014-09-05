using System;
using System.Diagnostics;

namespace Policeman
{
    public static class Guard
    {
	[DebuggerStepThrough]
        public static void Requires<TExceptionArgument>(string message, bool isTrue) where TExceptionArgument : Exception
        {
            if (!isTrue )
            {
                var exceptionArgument = Activator.CreateInstance(typeof(TExceptionArgument), message) as TExceptionArgument;
                if (exceptionArgument != null)
                {
                    throw exceptionArgument;
                }

                throw new PolicemanException("Guard AssertIsTrue is false for" + typeof(TExceptionArgument)); 
            }
        }

	[DebuggerStepThrough]
        public static void Requires<TExceptionArgument>(bool isTrue) where TExceptionArgument : Exception
        {
            if (!isTrue)
            {
                var exceptionArgument = Activator.CreateInstance(typeof(TExceptionArgument), "Policeman Guard Exception") as TExceptionArgument;
                if (exceptionArgument != null)
                {
                    throw exceptionArgument;
                }

                throw new PolicemanException("Guard AssertIsTrue is false for" + typeof(TExceptionArgument)); 
            }
        }

	[DebuggerStepThrough]
        public static void ArgumentNotNull([ValidatedNotNullAttribute]object argumentValue, string argumentName)
        {
            if (argumentValue == null) throw new ArgumentNullException(argumentName);
        }

	[DebuggerStepThrough]
        public static void ArgumentNotNullOrEmpty(string argumentValue, string argumentName)
        {
            if (argumentValue == null) throw new ArgumentNullException(argumentName);
            if (argumentValue.Length == 0) throw new ArgumentException("Argument must not be empty", argumentName);
        }

	[DebuggerStepThrough]
        public static void ArgumentGreaterOrEqualThan<T>(T lowerValue, T argumentValue, string argumentName) where T : struct, IComparable
        {
            if (argumentValue.CompareTo(lowerValue) < 0)
            {
                throw new ArgumentOutOfRangeException(argumentName, argumentValue, string.Format("Argument not greater or equal to {1} : {0}", argumentName, lowerValue));
            }
        }

	[DebuggerStepThrough]
        public static void ArgumentLowerOrEqualThan<T>(T higherValue, T argumentValue, string argumentName) where T : struct, IComparable
        {
            if (argumentValue.CompareTo(higherValue) > 0)
            {
                throw new ArgumentOutOfRangeException(argumentName, argumentValue, string.Format("Argument not lower or equal to  {1} : {0}", argumentName, higherValue));
            }
        }  
    }
}
