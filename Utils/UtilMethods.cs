﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SensorsProject.Utils
{

    internal static class UtilMethods
    {
        public static string DescribeObject<T>(T obj)
        {
            var props = typeof(T).GetProperties();
            var details = props.Select(p => $"{p.Name}={p.GetValue(obj)}");
            return $"{typeof(T).Name}: " + string.Join(", ", details);
        }


        public static void nullCounter(object[] objArr) {
            int nullCount = 0;
            foreach (var item in objArr)
            {
                if (item == null)
                {
                    nullCount++;
                }
            }
            Console.WriteLine($"There are {nullCount} null values in the array.");
        }
    }
}
