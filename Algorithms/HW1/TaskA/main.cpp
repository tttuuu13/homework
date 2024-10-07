#include "iostream"

void CheckIfSorted(std::vector<int> A, int start, int end) {
  std::vector<int> copy = std::move(A);
  std::sort(copy.begin(), copy.end());
  for (int i = start; i < end; i++) {
    if (A[i] != copy[i]) {
      std::cout << "ERROR";
      return;
    }
  }
  std::cout << "OK";
}

void SelectionSort(std::vector<int> &A) {
  size_t n = A.size();
  // На каждой итерации A[..i+1] упорядочен по неубыванию
  // Т.к на каждом шаге минимальный элемент из A[i+1..j+1] меняется с A[i]
  for (size_t i = 0; i < n; ++i) {
    int minId = i;
    // На каждой итерации minId = индексу минимального элемента в A[i + 1..j+1]
    for (size_t j = i + 1; j < n; ++j) {
      if (A[j] < A[minId]) {
        minId = j;
      }
    }

    std::swap(A[minId], A[i]);
  }
}

int main() {
  std::vector<int> A = {5, 2, 4, 3, 1, 8, 7, 9};
  SelectionSort(A);
}