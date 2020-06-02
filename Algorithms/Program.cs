namespace Algorithms
{
    using Algorithms.Searching;
    using Algorithms.HackerRank;
	using System.CodeDom.Compiler;
	using System.Collections.Generic;
	using System.Collections;
	using System.ComponentModel;
	using System.Diagnostics.CodeAnalysis;
	using System.Globalization;
	using System.IO;
	using System.Linq;
	using System.Reflection;
	using System.Runtime.Serialization;
	using System.Text.RegularExpressions;
	using System.Text;
    using System;

    class Program
    {
        internal const string test = "hello world";

        static void Main(string[] args)
        {

            unsafe{

                fixed (char* ptr = test) {
                    for (var i = 0; i < test.Length; ++i) {
                        *(ptr + i) = 'h';
                    }
                }
            }

            
            Console.WriteLine(test);

        }
    }
}
