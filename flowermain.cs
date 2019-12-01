//Author: Ethan Kamus
//Email: ethanjpkamus@csu.fullerton.edu

/* The purpose of this program is to show the use of mouse click
 */

using System;
using System.Windows.Forms;

public class flowermain{

     static void Main(string[] args){

          System.Console.WriteLine("Welcome to the Main driver of the Flower Program.");
          floweruserinterface application = new floweruserinterface();
          Application.Run(application);
          System.Console.WriteLine("Main method will now shutdown.");

     }//End of Main

}//End of flowermain
