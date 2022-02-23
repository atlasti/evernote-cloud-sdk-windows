using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvernoteSDK
{
    internal static class AsyncHelper
    {
        public static T GetResult<T>(this Func<Task<T>> action)
        {
            return Task.Run(action).Result;
        }
    }
}
