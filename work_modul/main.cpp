#include <iostream>
#include <ctime>

#define ELEMENT 20

void array_del(int*, int*);

int main() {
	//setlocale(LC_ALL, "Russian");
	std::srand(time(NULL));
	int count = ELEMENT;
	int* arr = new int[count];

	std::cout << arr << std::endl;
	
	for (int i = 0; i < count; i++) {
		arr[i] = rand() % 21 ;
		std::cout << arr[i] << ", ";
	}
	std::cout << std::endl;
	array_del(arr, &count);
	std::cout << arr << std::endl;
	std::cout << std::endl;
	for (int i = 0; i < count; i++) {
		std::cout << arr[i] << ", ";
	}
	std::cout << std::endl;

	delete []arr;
	return 0;
}

void array_del(int* arr, int* count) {
	int* temp = arr;
	arr = new int[--(*count)];
	std::cout << arr << std::endl;
	for (int i = 0; i < (*count); i++) {
		arr[i] = temp[i];
	}
	delete []temp;
}