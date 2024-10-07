#include <iostream>
#include "array.h"

int main() {
  Array<int, 3> a{1, 2, 3};
  Array<int, 3> b{3, 2, 1};
  a.Swap(b);
  std::cout << a.Front();
}
