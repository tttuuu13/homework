#include <iostream>
#include "unique_ptr.h"

int main() {
  UniquePtr<std::pair<int, int>> a{new std::pair<int, int>{1, 2}};
  (*a).second = 3;
}
