using ST10249266_PROG_POE.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ST10249266_PROG_POE
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            //creates an object of the WorkerClass and calls the startHere method
            WorkerClass worker = new WorkerClass();
            worker.startHere();
        }
    }
}