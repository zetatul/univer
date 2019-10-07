#include <iostream>
#include <ctime>

#define ELEMENT 4

int main() {
	//setlocale(LC_ALL, "Russian");
	std::srand(time(NULL));

	int matrix_a[ELEMENT][ELEMENT];
	int matrix_b[ELEMENT][ELEMENT];
	int matrix_s[ELEMENT][ELEMENT];		//sum
	int matrix_m[ELEMENT][ELEMENT];		//mul
	for (int i = 0; i < ELEMENT; i++) {
		for (int j = 0; j < ELEMENT; j++) {
			matrix_a[i][j] = std::rand() % 20 - 10;
			matrix_b[i][j] = std::rand() % 20 - 10;
			//clear result matrix
			matrix_m[i][j] = 0;
		}
	}

	std::cout << "matrix A" << std::endl;
	for (int i = 0; i < ELEMENT; i++) {
		for (int j = 0; j < ELEMENT; j++) {
			std::cout << matrix_a[i][j] << "\t";
		}
		std::cout << std::endl;
	}

	std::cout << std::endl << "matrix B" << std::endl;
	for (int i = 0; i < ELEMENT; i++) {
		for (int j = 0; j < ELEMENT; j++) {
			std::cout << matrix_b[i][j] << "\t";
		}
		std::cout << std::endl;
	}

	//find sum matrix A + B
	for (int i = 0; i < ELEMENT; i++) {
		for (int j = 0; j < ELEMENT; j++) {
			matrix_s[i][j] = matrix_a[i][j] + matrix_b[i][j];		//sum
			/*
			mul
			matrix_m[i][j] = matrix_a[i][0] * matrix_b[0][j] + matrix_a[i][1] * matrix_b[1][j] + matrix_a[i][2] * matrix_b[2][j] + matrix_a[i][3] * matrix_b[3][j];
			*/
			for (int s = 0; s < ELEMENT; s++) {
				matrix_m[i][j] += matrix_a[i][s] * matrix_b[s][j];
			}
		}
	}

	std::cout << std::endl << "A + B" << std::endl;
	for (int i = 0; i < ELEMENT; i++) {
		for (int j = 0; j < ELEMENT; j++) {
			std::cout << matrix_s[i][j] << "\t";
		}
		std::cout << std::endl;
	}

	std::cout << std::endl << "A x B" << std::endl;
	for (int i = 0; i < ELEMENT; i++) {
		for (int j = 0; j < ELEMENT; j++) {
			std::cout << matrix_m[i][j] << "\t";
		}
		std::cout << std::endl;
	}
	return 0;
}