#pragma once
#include "vector"


template<typename T, size_t N, size_t M>
class Matrix {
 private:
  std::vector<T> elems_;
 public:
  Matrix() : elems_(std::vector<T>(N * M)) {};
  explicit Matrix(std::vector<T> &init_elems) : elems_(init_elems) {};
  explicit Matrix(std::vector<T> &&init_elems) : elems_(init_elems) {};
  Matrix(const Matrix<T, N, M> &other) noexcept {
    elems_ = other.elems_;
  }
  Matrix(Matrix<T, N, M> &&other) noexcept {
    elems_ = std::move(other.elems_);
    other.elems_ = std::vector<T>(0);
  }
  ~Matrix() = default;
  const T &operator()(size_t i, size_t j) const {
    return elems_[M * i + j];
  }
  T &operator()(size_t i, size_t j) {
    return elems_[M * i + j];
  }

  Matrix<T, N, M> operator+(const Matrix<T, N, M> &other) const {
    Matrix<T, N, M> result;
    for (size_t i = 0; i < N; ++i) {
      for (size_t j = 0; j < M; ++j) {
        result(i, j) = (*this)(i, j) + other(i, j);
      }
    }
    return result;
  }

  Matrix<T, N, M> operator-(const Matrix<T, N, M> &other) const {
    Matrix<T, N, M> result;
    for (size_t i = 0; i < N; ++i) {
      for (size_t j = 0; j < M; ++j) {
        result(i, j) = (*this)(i, j) - other(i, j);
      }
    }
    return result;
  }

  template<size_t K>
  Matrix<T, N, K> operator*(const Matrix<T, M, K> &other) const {
    Matrix<T, N, K> result;
    for (size_t i = 0; i < N; ++i) {
      for (size_t j = 0; j < M; ++j) {
        for (size_t k = 0; k < M; ++k) {
          result(i, j) += (*this)(k, j) * other(i, k);
        }
      }
    }
    return result;
  }

  friend std::istream &operator>>(std::istream &is, Matrix<T, N, M> &matrix) {
    for (size_t i = 0; i < N; ++i) {
      for (size_t j = 0; j < M; ++j) {
        is >> matrix(i, j);
      }
    }
    return is;
  }

  friend std::ostream &operator<<(std::ostream &os, const Matrix<T, N, M> &matrix) {
    for (size_t i = 0; i < N; ++i) {
      for (size_t j = 0; j < M; ++j) {
        os << matrix(i, j) <<  ' ';
      }
      os << '\n';
    }
    return os;
  }
};
