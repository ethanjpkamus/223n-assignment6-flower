// Author: Ethan Kamus
// Email: ethanjpkamus@csu.fullerton.edu

// Version 1.1.0: December 10, 2019

/* The purpose of this program is to show how to use a Bitmap
 * and how to animate a dot following a flower pattern
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
