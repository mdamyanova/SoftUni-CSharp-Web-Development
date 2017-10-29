#include <iostream>

using namespace std;

class Origin
{
public:
	float x;
	float y;
};

class Size
{
public:
	float height;
	float width;
};

class Rect
{
public:
	Origin origin;
	Size size;

	double area();
};

double Rect::area()
{
	return size.height * size.width;
}

int main()
{
	Rect rect;
	rect.origin.x = 6;
	rect.origin.y = 9;
	rect.size.height = 8;
	rect.size.width = 3;

	return 0;
}