using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Knowledge
{

    /// <summary>
    /// 基础-反射
    /// </summary>
    public class ReflectionSyntax
    {
        public static void Excute()
        {
            Type type = GetType("Knowledge.Kiba");
            Kiba kiba = (Kiba)Activator.CreateInstance(type);

            Type type2 = GetType2("Knowledge.Kiba");
            Kiba kiba2 = (Kiba)Activator.CreateInstance(type2);
        }

        public static Type GetType(string fullName)
        {

            Assembly assembly = Assembly.Load("Knowledge");
            Type type = assembly.GetType(fullName, true, false);
            return type;
        }

        public static Type GetType2(string fullName)
        {
            Type type = Type.GetType(fullName);

            return type;
        }

        public static void ExcuteMethod()
        {
            Assembly assembly = Assembly.Load("Knowledge");
            Type type = assembly.GetType("Knowledge.Kiba", true,false);
            MethodInfo method = type.GetMethod("PrintName");

            object kiba = assembly.CreateInstance("Knowledge.Kiba");
            object[] pmts = new object[] {"Kiba518" };
            method.Invoke(kiba,pmts);
        }
    }

    public class Kiba
    {
        public string name { get; set; }
        public void PrintName(string name)
        {
            Console.WriteLine(name);
        }
    }
}
