#Author: Ethan Kamus
#email: ethanjpkamus@csu.fullerton.edu

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
