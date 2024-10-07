#include <iostream>
#include "vector_old.h"

int main() {
  Vector<int> a(4, 7);
  Vector<int> b{1, 2, 3, 4, 5};
  a.PushBack(3);
  a.Print();
}
