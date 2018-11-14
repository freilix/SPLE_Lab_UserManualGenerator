# SPLE_Lab_UserManualGenerator

In this folder you find 
- a windows batch file ([createManual.bat](createManual.bat)) that creates the manuals on windows
- a linux batch file ([createManual.sh](createManual.sh)) that creates the manuals on linux
- a cpp file ([\_RadioManual.cpp](\_RadioManual.cpp)) that uses the C-preprocessor to include the txt-files depending on parameters passed
- a config file ([Config.txt](Config.txt)) in which the manuals and their specifications are defined
- a folder with [documentation](/Doku)
- folders with content in different languages

## Start
It your environment is properly set up you can start the script (.sh or .bat) in a console window as follows
createManual.bat DARMSTADT darmstadt.html on windows or
createManual.sh DARMSTADT darmstadt.html on linux

Be aware that the scripts compare strings. So it is important to use the correct spelling and to take care of uppercase letters.

## Requirements
This requires the GNU C-preprocessor. So please make sure that the command gcc is working in a console window.
gcc comes for example with the Code::Blocks IDE (if you choose the installation including the compiler).
Maybe you have to adopt your path-Variable to make sure that gcc is found.

## Orthogonal variability model
![Image Orthogonal variability model for UserManualGenerator](/Doku/UserManualGenerator-orthogonal_variability_model.png)
