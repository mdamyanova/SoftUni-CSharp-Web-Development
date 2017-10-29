#include <iostream>
#include <string>

using namespace std;

class Car
{
public:
	string make;
	string model;
	float horsePower;
	double timeTo60mph;
	float fuelConsumption;
	bool isRunning;

	void Run();
	void Stop();
};

void Car::Run()
{
	isRunning = true;
}

void Car::Stop()
{
	isRunning = false;
}

int main(int argc, char ** argv) 
{
	Car fordMustangRTR;
	fordMustangRTR.make = "Ford";
	fordMustangRTR.model = "Mustang RTR";
	fordMustangRTR.horsePower = 510;
	fordMustangRTR.isRunning = false;

	Car fordFocus;
	fordFocus.make = "Ford";
	fordFocus.model = "Focus";
	fordFocus.horsePower = 60;
	fordFocus.isRunning = false;

	cout << fordMustangRTR.make << " " << fordMustangRTR.isRunning << endl;
	cout << fordFocus.make << " " << fordFocus.isRunning << endl;
	
	fordMustangRTR.Run();

	cout << fordMustangRTR.make << " " << fordMustangRTR.isRunning << endl;
	cout << fordFocus.make << " " << fordFocus.isRunning << endl;
	
	return 0;
}