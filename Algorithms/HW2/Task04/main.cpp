#include <iostream>
#include "vector"

bool IsOkay(std::vector<std::pair<int, int>> &table, double delay, int L) {
  
}

int main() {
  int L, N;
  std::cin >> L >> N;
  std::vector<std::pair<int, int>> table;
  for (int _ = 0; _ < N; _++) {
    int T, V;
    std::cin >> T >> V;
    table.emplace_back(T, V);
  }
  IsOkay(table, 27, L);
}
