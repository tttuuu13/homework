#include <iostream>
#include "matrix.h"

int main() {
  Matrix<int, 2, 2>a(std::vector<int>{1, 2, 3, 4});
  Matrix<int, 2, 1>b(std::vector<int>{1, 0});
  std::cout << a * b;
}
