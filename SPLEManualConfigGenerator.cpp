#include "stdafx.h"
#include <fstream>
#include <string>
#include <iostream>
#include <windows.h>
#include <fstream>
#include <sstream>
#include <algorithm>
using namespace std;


void writeToRadioManual(string name, string path) {
	const std::string fileName = path.append("\\_RadioManual.cpp");
	std::fstream processedFile(fileName.c_str());
	std::stringstream fileData;
	string upperName = name;
	transform(upperName.begin(), upperName.end(), upperName.begin(), ::toupper);
	fileData << "#ifdef " + upperName << endl;
	fileData << "#include \"config/_" << name << ".cpp\"" << endl;
	fileData << "#endif" << endl;
	fileData << endl;

	fileData << processedFile.rdbuf();
	processedFile.close();

	processedFile.open(fileName.c_str(), std::fstream::out | std::fstream::trunc);
	processedFile << fileData.rdbuf();
}

int main()
{
	string pathToConfig;
	string path;
	string radioName;
	string lowerName;
	string upperName;
	cout << "Config-file generator" << endl;
	cout << "Enter the working directory: " << endl;
	cin >> path;
	cout << "Please name your radio?" << endl;
	cin >> radioName;
	lowerName = radioName;
	upperName = radioName;
	transform(lowerName.begin(), lowerName.end(), lowerName.begin(), ::tolower);
	transform(upperName.begin(), upperName.end(), upperName.begin(), ::toupper);
	ofstream outFile;
	pathToConfig = path;
	pathToConfig.append("\\config\\_" + lowerName + ".cpp");
	outFile.open(pathToConfig);
	string decision = "";
	
	//RadioName
	outFile << "#ifdef " << upperName << endl;
	outFile << "\t#define Bluedot_City_Name " << lowerName << endl;
	
	//HoldTuning
	cout << "Do you want the possibility to hold tuning button for faster search? Yes(y) or No(n)" << endl;
	cin >> decision;
	if (decision.compare("y") == 0) {
		outFile << "\t#define HoldTuning" << endl;
	}
	
	//Button Type Left
	cout << "Which button type do you want for the left button? <-- (1) or &larr; (2)" << endl;
	cout << "Pls enter 1 or 2." << endl;
	cin >> decision;
	if (decision.compare("1") == 0) {
		outFile << "\t#define Bluedot_Button_Type_Left &lt;&lt;" << endl;
	}
	else if (decision.compare("2") == 0) {
		outFile << "\t#define Bluedot_Button_Type_Left &larr;" << endl;
	}
	
	//Button Type Right
	cout << "Which button type do you want for the right button? --> (1) or &rarr; (2)" << endl;
	cout << "Pls enter 1 or 2." << endl;
	cin >> decision;
	if (decision.compare("1") == 0) {
		outFile << "\t#define Bluedot_Button_Type_Right &gt;&gt;" << endl;
	}
	else if (decision.compare("2") == 0) {
		outFile << "\t#define Bluedot_Button_Type_Right &rarr;" << endl;
	}
	
	//Numeric Keypad
	cout << "Do you want the numeric keypad search? Yes(y) or No(n)" << endl;
	cin >> decision;
	if (decision.compare("y") == 0) {
		outFile << "\t#define NumericKeypadSearch" << endl;
	}
	
	
	//Language
	cout << "Which language? English(e) or german(g)" << endl;
	cin >> decision;
	if (decision.compare("g") == 0){
		outFile << "\t#define Bluedot_Manual_Language Bluedot_Manual_Language_German" << endl;
	}
	else{
		outFile << "\t#define Bluedot_Manual_Language Bluedot_Manual_Language_English" << endl;
	}
	
	outFile.close();
		
	writeToRadioManual(lowerName, path);
	cout << "The Configuration file was created in the config folder. Name: _" << lowerName << ".cpp" << endl;
	cout << "Input any letter to close..." << endl;
	cin >> decision;
	exit(0);

}