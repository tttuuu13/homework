#pragma once
#include <stdexcept>

class ArrayOutOfRange : public std::out_of_range {
 public:
  ArrayOutOfRange() : std::out_of_range("ArrayOutOfRange") {
  }
};

template<typename T, size_t N>
class Array {
 public:
  T elements[N];

  const T &operator[](size_t index) const {
    return elements[index];
  }
  T &operator[](size_t index) {
    return elements[index];
  }

  const T &At(size_t index) const {
    if (index >= N) {
      throw ArrayOutOfRange{};
    }
    return elements[index];
  }
  T &At(size_t index) {
    if (index >= N) {
      throw ArrayOutOfRange{};
    }
    return elements[index];
  }

  const T &Front() const {
    return elements[0];
  }
  T &Front() {
    return elements[0];
  }

  const T &Back() const {
    return elements[N - 1];
  }
  T &Back() {
    return elements[N - 1];
  }

  const T *Data() const {
    return elements;
  }
  T *Data() {
    return elements;
  }

  size_t Size() const {
    return N;
  }

  bool Empty() const {
    return N == 0;
  }

  Array<T, N> &Fill(const T &value) {
    for (size_t i = 0; i < N; i++) {
      elements[i] = value;
    }
    return *this;
  }

  Array<T, N> &Swap(Array<T, N> &other) {
    Array<T, N> temp;
    for (size_t i = 0; i < N; i++) {
      temp[i] = other[i];
    }
    for (size_t i = 0; i < N; i++) {
      other[i] = elements[i];
      elements[i] = temp[i];
    }
    return *this;
  }
};