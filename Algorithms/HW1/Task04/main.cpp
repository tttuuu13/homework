#include <iostream>
#include "deque"
#include "vector"

int main() {
  int n;
  std::cin >> n;
  std::deque<int> first;
  for (int i = 0; i < n; i++) {
    int k;
    std::cin >> k;
    first.push_back(k);
  }

  std::deque<int> second;
  second.push_back(0);
  std::deque<int> dead_end;

  std::vector<std::pair<int, int>> actions;
  while (second.size() != n + 1) {
    if (!dead_end.empty() && dead_end.back() == second.back() + 1) {
      int i = 0;
      while (!dead_end.empty() && dead_end.back() == second.back() + 1) {
        i++;
        second.push_back(dead_end.back());
        dead_end.pop_back();
      }
      actions.emplace_back(2, i);
    } else if (std::find(first.begin(), first.end(), second.back() + 1) != first.end()) {
      int i = std::find(first.begin(), first.end(), second.back() + 1) - first.begin();
      for (int _ = 0; _ <= i; _++) {
        dead_end.push_back(first.front());
        first.pop_front();
      }
      actions.emplace_back(1, i + 1);
    } else {
      std::cout << 0;
      return 0;
    }
  }

  for (auto action : actions) {
    std::cout << action.first << " " << action.second << std::endl;
  }
}
