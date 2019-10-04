#include <iostream>
#include <ctime>

#define ELEMENT 4

int main() {
	setlocale(LC_ALL, "Russian");
	std::srand(time(NULL));

	int matrix_a[ELEMENT][ELEMENT];
	int matrix_b[ELEMENT][ELEMENT];
	int matrix_s[ELEMENT][ELEMENT];
	for (int i = 0; i < ELEMENT; i++) {
		for (int j = 0; j < ELEMENT; j++) {
			matrix_a[i][j] = std::rand() % 20 - 10;
			matrix_b[i][j] = std::rand() % 20 - 10;
			//не помню как инициализируется масив при создании (надо уточнить)
			matrix_s[i][j] = 0;
		}
	}

	std::cout << "матрица А" << std::endl;
	for (int i = 0; i < ELEMENT; i++) {
		for (int j = 0; j < ELEMENT; j++) {
			std::cout << matrix_a[i][j] << "\t";
		}
		std::cout << std::endl;
	}

	std::cout << "матрица B" << std::endl;
	for (int i = 0; i < ELEMENT; i++) {
		for (int j = 0; j < ELEMENT; j++) {
			std::cout << matrix_b[i][j] << "\t";
		}
		std::cout << std::endl;
	}

	//находим сумму А + В
	for (int i = 0; i < ELEMENT; i++) {
		for (int j = 0; j < ELEMENT; j++) {
			/*
			matrix_s[i][j] = matrix_a[i][0] * matrix_b[0][j] + matrix_a[i][1] * matrix_b[1][j] + matrix_a[i][2] * matrix_b[2][j] + matrix_a[i][3] * matrix_b[3][j];
			*/
			for (int s = 0; s < ELEMENT; s++) {
				matrix_s[i][j] += matrix_a[i][s] * matrix_b[s][j];
			}
		}
	}

	std::cout << "А + B" << std::endl;
	for (int i = 0; i < ELEMENT; i++) {
		for (int j = 0; j < ELEMENT; j++) {
			std::cout << matrix_s[i][j] << "\t";
		}
		std::cout << std::endl;
	}

	//находим сумму В + А
	for (int i = 0; i < ELEMENT; i++) {
		for (int j = 0; j < ELEMENT; j++) {
			for (int s = 0; s < ELEMENT; s++) {
				matrix_s[i][j] += matrix_b[i][s] * matrix_a[s][j];
			}
		}
	}

	std::cout << "B + A" << std::endl;
	for (int i = 0; i < ELEMENT; i++) {
		for (int j = 0; j < ELEMENT; j++) {
			std::cout << matrix_s[i][j] << "\t";
		}
		std::cout << std::endl;
	}
	return 0;
}