#include <iostream>
#include "vector"
#include "unordered_set"

int main() {
  int n;
  std::cin >> n;
  std::vector<int> p;
  for (int _ = 0; _ < n; _++) {
    std::cin >> p.emplace_back();
  }

  int max_distance = -1;
  int max_counter = 0;
  std::unordered_set<std::string> unique;

  for (int shift = 1; shift <= n; shift++) {
    int distance = n;
    std::string string;
    for (int i = 0; i < n; i++) {
      string += std::to_string(p[(i + shift) % n]);
      if (p[i] == p[(i + shift) % n]) {
        distance--;
      }
    }
    if (distance == max_distance and unique.find(string) == unique.end()) {
      max_counter++;
    } else if (distance > max_distance) {
      max_distance = distance;
      max_counter = 1;
    }
    unique.insert(string);
  }

  std::cout << max_counter;
}