#include <iostream>
#include "vector"

struct Interval {
  int left;
  int right;
  bool isEmpty = false;

  Interval() {
    left = right = 0;
    isEmpty = true;
  }

  Interval(int left, int right) {
    this->left = left;
    this->right = right;
  }

  size_t length() const {
    if (isEmpty) {
      return 0;
    }
    return right - left + 1;
  }

  Interval overlap(const Interval &other) const {
    if ((left >= other.left && left <= other.right) ||
        (right >= other.left && right <= other.right) ||
        (left <= other.left && right >= other.right)) {
      return {std::max(left, other.left), std::min(right, other.right)};
    } else {
      return {};
    }
  }
};

void Sort(std::vector<Interval> &intervals, int low, int high) {
  if (high <= low) {
    return;
  }
  int i = low - 1;
  int j = low;
  int p = high;
  while (j < p) {
    if (intervals[j].left < intervals[p].left ||
    (intervals[j].left == intervals[p].left && intervals[j].right < intervals[p].right)) {
      i++;
      std::swap(intervals[i], intervals[j]);
    }
    j++;
  }
  i++;
  std::swap(intervals[i], intervals[p]);
  Sort(intervals, low, i - 1);
  Sort(intervals, i + 1, high);
}

int main() {
  int N;
  std::cin >> N;
  if (N == 0) {
    std::cout << 0;
    return 0;
  }
  std::vector<Interval> intervals;
  for (int _ = 0; _ < N; _++) {
    int a, b;
    std::cin >> a >> b;
    intervals.emplace_back(a, b);
  }
  Sort(intervals, 0, static_cast<int>(intervals.size() - 1));
  Interval max_right = intervals[0];
  Interval max_overlap = Interval();
  for (int i = 1; i < intervals.size(); i++) {
    Interval curr = intervals[i];
    Interval overlap = curr.overlap(max_right);
    if (overlap.length() > max_overlap.length()) {
      max_overlap = overlap;
    }
    if (curr.right > max_right.right) {
      max_right = curr;
    }
  }
  std::cout << max_overlap.length();
  if (!max_overlap.isEmpty) {
    std::cout << "\n" << max_overlap.left << " " << max_overlap.right;
  }
  return 0;
}
