using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace CS8NullBasics
{
    class MessagePopulator
    {
        public static void Populate3(Message message) {
            message.GetType().InvokeMember("From3", BindingFlags.Instance | BindingFlags.Public | BindingFlags.SetProperty,
                Type.DefaultBinder, message, new[] { "Jason (set using reflection)" });
        }
    }
}
