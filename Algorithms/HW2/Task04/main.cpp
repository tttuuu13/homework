#include <iostream>
#include <vector>

double GetDistance(std::vector<std::pair<int, int>> &table, double time, double delay = 0) {
  double currDist = 0;
  int i = 0;
  while (time - table[i].first > delay) {
    time -= table[i].first;
    currDist += table[i].first * table[i].second;
    i++;
  }
  currDist += (time - delay) * table[i].second;
  return currDist;
}


bool IsOkay(std::vector<std::pair<int, int>> &table, double delay, int L) {
  if (GetDistance(table, delay) - GetDistance(table, delay, delay) < L) {
    return false;
  }
  double currTime = 0;
  int i = 0;
  while (currTime < delay) {
    currTime += table[i].first;
    i++;
  }
  while (i <= table.size()) {
    if (GetDistance(table, currTime) - GetDistance(table, currTime, delay) < L) {
      return false;
    }
    currTime += table[i].first;
    i++;
  }
  return true;
}

double DelayBinarySearch(std::vector<std::pair<int, int>> &table, double low, double high, int L) {
  double res;
  while (high - low > 0.001) {
    double middle = (low + high) / 2.0;
    if (IsOkay(table, middle, L)) {
      high = middle;
      res = middle;
    } else {
      low = middle;
    }
  }
  return res;
}

int main() {
  int L, N;
  std::cin >> L >> N;
  std::vector<std::pair<int, int>> table;
  double timeSum = 0;
  for (int _ = 0; _ < N; _++) {
    int T, V;
    std::cin >> T >> V;
    table.emplace_back(T, V);
    timeSum += T;
  }
  std::cout << DelayBinarySearch(table, 0, timeSum + 1, L);
}
