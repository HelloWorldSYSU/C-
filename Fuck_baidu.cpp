#include <iostream>
#include <fstream>
#include <string>

using namespace std;

int main(){
	int m = 100;
	ifstream in;
	in.open("to_change.txt");
	ofstream out;
	out.open("changed.txt");
	while(m --){
		string temp;
		getline(in, temp);
		for(int i = 0; i < temp.length(); i ++){
			if(temp[i] == ' '){
				temp = ' ';
			}
		}
		out << temp << endl;
	}
}