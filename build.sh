# Author: Ethan Kamus
# Email: ethanjpkamus@csu.fullerton.edu

# Version 1.1.0: December 10, 2019

# The purpose of this program is to show how to use a Bitmap
# and how to animate a dot following a flower pattern

rm *.dll
rm *.exe

echo View the list of source files
ls -l

echo "Compile floweruserinterface.cs:"
mcs -target:library -r:System.Drawing.dll -r:System.Windows.Forms.dll -out:floweruserinterface.dll floweruserinterface.cs

echo "Compile and link flowerusermain.cs:"
mcs -r:System -r:System.Windows.Forms -r:floweruserinterface.dll -out:flower.exe flowermain.cs

echo "Run the program Flower Program"
./flower.exe

echo "The bash script has terminated."
