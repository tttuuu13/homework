#include <iostream>
#include "shared_ptr.h"

int main() {
  auto ptr = new int(11);
  const SharedPtr<SharedPtr<int>> a(new SharedPtr<int>(ptr));

  std::cout << (a->UseCount() == 1);
  //std::cout << (a->Get() == ptr);
}
