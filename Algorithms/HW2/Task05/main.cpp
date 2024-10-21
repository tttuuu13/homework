#include <iostream>
#include <deque>
#include <algorithm>
#include <cmath>

using points = std::deque<std::pair<int, int>>;
using point = std::pair<int, int>;

double GetDist(points::const_iterator p1, points::const_iterator p2) {
  return std::sqrt(std::pow(p1->first - (p2)->first, 2) + std::pow(p1->second - (p2)->second, 2));
}
double FindMinDist(points::const_iterator begin, points::const_iterator end) {
  if (end - begin == 2) {
    return GetDist(begin, begin + 1);
  }
  if (end - begin == 3) {
    return std::min({GetDist(begin, begin + 1), GetDist(begin, begin + 2), GetDist(begin + 1, begin + 2)});
  }
  int64_t middle = (end - begin) / 2;
  points h1 = points(begin, begin + middle);
  points h2 = points(begin + middle, end);
  double minDist = std::min(
      FindMinDist(h1.begin(), h1.end()),
      FindMinDist(h2.begin(), h2.end())
  );
  while (!h1.empty() && h1.front().first < (begin + middle)->first - minDist) {
    h1.pop_front();
  }
  while (!h2.empty() && h2.back().first > (begin + middle)->first + minDist) {
    h2.pop_back();
  }
  if (h1.empty() || h2.empty()) {
    return minDist;
  }
  double minDistBetween = GetDist(h1.begin(), h2.begin());
  for (auto i1 = h1.begin(); i1 < h1.end(); i1++) {
    for (auto i2 = h2.begin(); i2 < h2.end(); i2++) {
      minDistBetween = std::min(minDistBetween, GetDist(i1, i2));
    }
  }
  return std::min(minDist, minDistBetween);
}

int main() {
  points p;
  int x, y;
  while (std::cin >> x >> y) {
    p.emplace_back(x, y);
  }
  std::sort(p.begin(), p.end(),
            [](const point &a, const point &b) {
              return a.first < b.first;
            });
  std::cout << (int)FindMinDist(p.begin(), p.end());
  return 0;
}