#include <iostream>

void F(int n) {
  int x = 100; // 1
  int y = 0; // 1

  int c = 0;
  for (size_t outer = 1; outer < n; outer *= 2) { // log(n)
    x = x + outer; // 2
    for (size_t inner = 2; inner < n; ++inner) { // n - 2
      if (x > y / inner) { // 2
        c++;
        y = y + outer / inner; // 3
      } else {
        --y;
      }
    }
  }
  std::cout << c;
}

int main() {
  std::cout << 0 / 0;
}
