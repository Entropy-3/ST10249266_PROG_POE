//Nathan Teixiera
//ST10249266
//Group 2

//references:
//GithubCopilot
//https://www.youtube.com/watch?v=WhACXlObR8s
//https://www.youtube.com/watch?v=aLhAmimoQj8
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

            //runs the startHere method
            worker.menuOptions();
        }
    }
}
//-------------------------------------EOF----------------------------------------\\