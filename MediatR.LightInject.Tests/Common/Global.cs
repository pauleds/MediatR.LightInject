using System.Collections.Generic;

namespace MediatR.LightInject.Tests.Common
{
    public class Global
    {
        public static void Reset()
        {
            IsHandled = false;
            Messages.Clear();
        }

        public static readonly List<string> Messages = new List<string>();
        public static bool IsHandled = false;
    }
}
