//Nathan Teixiera
//ST10249266
//Group 2

//references:
//GithubCopilot
//https://www.youtube.com/watch?v=WhACXlObR8s
//https://www.youtube.com/watch?v=aLhAmimoQj8
//https://www.youtube.com/watch?v=bBDmL0U-4U8
//https://www.gosh.nhs.uk/conditions-and-treatments/general-health-advice-children/eat-smart/food-science/food-group-fun/
//https://www.youtube.com/watch?v=uAhVpw8zzm4
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