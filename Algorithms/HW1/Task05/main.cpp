#include <iostream>
#include <queue>
#include <deque>

int main() {
  std::ios::sync_with_stdio(false);
  std::cin.tie(nullptr);

  int T;
  std::cin >> T;
  std::queue<int> first_half;
  std::deque<int> second_half;

  for (int _ = 0; _ < T; _++) {
    while (first_half.size() != second_half.size() && first_half.size() - second_half.size() != 1) {
      first_half.push(second_half.front());
      second_half.pop_front();
    }

    char action;
    std::cin >> action;
    if (action == '*') {
      int i;
      std::cin >> i;
      second_half.push_front(i);
    } else if (action == '+') {
      int i;
      std::cin >> i;
      second_half.push_back(i);
    } else if (action == '-') {
      std::cout << first_half.front() << std::endl;
      first_half.pop();
    }
  }
}
